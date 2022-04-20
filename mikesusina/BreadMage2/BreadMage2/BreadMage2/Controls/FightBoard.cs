using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BreadMage2.Controls
{
    public partial class FightBoard : UserControl
    {
        private clsMonster myMonster => myGame.gMonster;
        private engBattle BattleEngine => myGame.BattleEngine;
        public engGame myGame { get; set; }

        private Color c = Color.Lime;
        private List<clsSpell> activeSpells { get; set; } = new List<clsSpell>();


        private BindingSource castingBS = new BindingSource();
        private BindingSource itemBS = new BindingSource();


        public FightBoard(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }

        public void InitializeBoard()
        {
            //load monster image
            // remember to flip boxes for boss fights
            object o = Properties.Resources.ResourceManager.GetObject(myMonster.ImgURL);
            if (o is Image) { pbMonster.Image = o as Image; }
            else { pbMonster.Image = Properties.Resources.BreadMage2; }
            pbMonster.Show();

            //Set Bars, just in case, reset the monster HP to full
            myMonster.HP = myMonster.HPmax;
            pbMonHP.Maximum = myMonster.HPmax;
            pbMonHP.Value = myMonster.HP;

            //set the interface
            SetSpellUI();
        }

        private void SetSpellUI()
        {
            btnMAtk.Image = Properties.Resources.matk;
            btnPAtk.Image = Properties.Resources.patk;
            btnDef.Image = Properties.Resources.defend;



            List<clsSpell> MageSpells = myGame.gMage.EQSpells("battle");
            MageSpells.AddRange(myGame.EffectHelper.AddWeaponSkills());

            List<clsSpell> ItemSpells = myGame.GetAllKnownMageSpells("item");
            
            castingBS.DataSource = MageSpells;
            itemBS.DataSource = ItemSpells;

            boxSpells.DataSource = castingBS;
            boxSpells.DisplayMember = "spellName";
            if (ItemSpells.Count < 1) { radioItems.Enabled = false; }
            radioSpells.Checked = true;
            boxSpells.ClearSelected();

            barActivePoints.ForeColor = Color.Lime;
            barActivePoints.Maximum = myGame.gMage.Stats.MaxSP;
            barActivePoints.Value = BattleEngine.GetBattleSP();
            string s = "Skill Points: " + BattleEngine.GetBattleSP().ToString() + "/" + myGame.gMage.Stats.MaxSP.ToString();
            lbActiveSP.Text = s;


            lblIngredients.Hide();
            lblElementalMotes.Hide();
            /*
            lstSpellBook.DataSource = castingBS;
            lstSpellBook.DisplayMember = "spellName";
            lstItem.DataSource = itemBS;
            lstItem.DisplayMember = "spellName";
            */
        }

        public void setSpellCosts(int i = 1)
        {
            if (i == 1)
            {
                lblElementalMotes.Hide();
                lblIngredients.Hide();

                barActivePoints.Maximum = myGame.gMage.Stats.MaxSP;
                barActivePoints.Value = BattleEngine.GetBattleSP();
                barActivePoints.Show();

                string s = "Skill Points: " + BattleEngine.GetBattleSP().ToString() + "/" + myGame.gMage.Stats.MaxSP.ToString();
                lbActiveSP.Text = s;
            }
            else
            {
                barActivePoints.Hide();

                string s = "";
                s = "Ingredients: " + myGame.gMage.GetComponentCount(1).ToString();
                lblIngredients.Text = s;
                lblIngredients.Show();
                s = "CosmicEnergy: " + myGame.gMage.GetComponentCount(1).ToString();
                lbActiveSP.Text = s;
                s = "ElementalMotes: " + myGame.gMage.GetComponentCount(1).ToString();
                lblElementalMotes.Text = s;
                lblElementalMotes.Show();
            }
        }

        public string GetTurn() { return BattleEngine.GetTurn(); }


        public void UpdateBars(clsMonster aMonster)
        {
            if (pbMonHP.Maximum != aMonster.HPmax) { pbMonHP.Maximum = aMonster.HPmax; }

            string s = "Mold: " + myGame.gMonster.MoldCount().ToString();
            lblMoldCounter.Text = s;
            s = "Zest: " + myGame.gMonster.ZestCount().ToString();
            lblZestCounter.Text = s;
            s = "Tension: " + myGame.gMonster.TensionCount().ToString();
            lblTensionCounter.Text = s;

            if (aMonster.HP > 0) { pbMonHP.Value = aMonster.HP; }
            else { pbMonHP.Value = 0; }
        }


        public void AddChatterString(string newText)
        {
            /*
            System.Text.RegularExpressions.Regex e = new System.Text.RegularExpressions.Regex("\b(" + newText + "\b");
            rtbChatter.Select()
            rtbChatter.SelectedText.*/

            ///new lines should ALWAYS end WITHOUT a new line!
            rtbChatter.SelectionColor = c;
            rtbChatter.AppendText(Environment.NewLine + newText);
        }


        //control actions
      

        private void btnAttack_Click(object sender, EventArgs e)
        {
            myGame.Engage(1);
        }

        private void btnMAtk_Click(object sender, EventArgs e)
        {
            myGame.Engage(2);
        }

        private void btnDef_Click(object sender, EventArgs e)
        {
            myGame.gMage.AddEffect(myGame.GameLibraries.EffectLib().Find(x => x.sType == "M").ShallowCopy(), 5);
            myGame.bMage.UpdateBars();

        }

        private void btnSpell_Click(object sender, EventArgs e)
        {
            //when implemented, grab the highest spell tier known
            //if (cbxMaxSpellTier.Checked) { tier = max tier(); }
            //BattleEngine.MageSpell(lstSpellBook.SelectedItem as clsSpell, tier);
            if (boxSpells.SelectedItem != null)
            {
                clsSpell tempSpell = boxSpells.SelectedItem as clsSpell;
                if (myGame.BattleEngine.GetBattleSP() < (tempSpell.SPCost /* *current spell tier*/ ))
                {
                    MessageBox.Show("You don't quite have the SP remaining for that spell");
                }
                else
                {
                    myGame.Engage(3);
                }
            }
            else { MessageBox.Show("What spell!?!?"); }
        }

        private Image GetSpellIconImage(clsSpell aSpell)
        {
            if (aSpell.ImgURL != null && aSpell.ImgURL != "")
            {
                object o = Properties.Resources.ResourceManager.GetObject(aSpell.ImgURL);
                if (o is Image) { return o as Image; }
                else return Properties.Resources.freshbaked;
            }
            else return Properties.Resources.freshbaked;
        }

        private void radioSpells_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSpells.Focused && radioSpells.Checked)
            {
                setSpellCosts(1);
                boxSpells.DataSource = castingBS;
                boxSpells.ClearSelected();
            }
        }

        private void radioItems_CheckedChanged(object sender, EventArgs e)
        {
            if (radioItems.Focused && radioItems.Checked)
            {
                setSpellCosts(2);
                boxSpells.DataSource = itemBS;
                boxSpells.ClearSelected();
            }
        }
    }
}
