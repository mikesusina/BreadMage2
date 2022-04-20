using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2.Controls
{
    public partial class CastBoard : UserControl
    {
        private engGame myGame;
        private int iCap;
        private int iActive;

        private List<clsSpell> ActiveSpells;
        private List<clsSpell> EQPassiveSpells;
        private List<clsSpell> ItemSpells;
        private clsSpell spellSelector = new clsSpell();

        private engEffects EffectHelper => myGame.EffectHelper;
        //private engSpellEngine => myGame.thespellengine?

        private BindingSource castingBS = new BindingSource();
        private BindingSource passiveBS = new BindingSource();
        private BindingSource itemBS = new BindingSource();


        public CastBoard(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
            
        }

        public void LoadBoard()
        {
            ItemSpells = new List<clsSpell>();

            //load spells
            ActiveSpells = myGame.gMage.EQSpells("global");
            ActiveSpells.AddRange(myGame.gMage.EQSpells("castonly"));
            EQPassiveSpells = myGame.gMage.EQSpells("passive");
            ItemSpells = myGame.GetAllKnownMageSpells("item");


            //set the SP info
            iCap = myGame.gMage.Stats.MaxSP;
            iActive = myGame.gMage.Stats.CurrentMaxSP;
            barActivePoints.Maximum = iCap;
            try { barActivePoints.Value = iActive; }
            catch { barActivePoints.Value = 0; }

            castingBS.DataSource = ActiveSpells;
            itemBS.DataSource = ItemSpells;
            passiveBS.DataSource = EQPassiveSpells;


            boxSpells.DataSource = castingBS;
            boxSpells.DisplayMember = "spellName";
            boxPassives.DataSource = passiveBS;
            boxPassives.DisplayMember = "spellName";

            boxSpells.ClearSelected();
            boxPassives.ClearSelected();

            radioSpells.Checked = true;
            setSpellCosts(1);
        }

        private void UpdateDescBox(clsSpell aSpell)
        {
            //update to display cost info in box?
            rtbSpellDesc.Text = aSpell.spellDescription;
            pbSpellIcon.Image = GetSpellIconImage(aSpell);
            pbSpellIcon.Show();
            lbSpellName.Text = aSpell.spellName;
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




        private void boxSpells_Enter(object sender, EventArgs e) { { if (btnCast.Enabled == false && boxPassives.SelectedItem == null) { btnCast.Enabled = true; } } }
        private void boxSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxSpells.Focused)
            {
                if (btnCast.Enabled == false) { btnCast.Enabled = true; }
                if (boxPassives.SelectedItem != null) { boxPassives.ClearSelected(); }
                try
                {
                    spellSelector = boxSpells.SelectedItem as clsSpell;
                    UpdateDescBox(spellSelector);
                }
                catch { throw new Exception("could not get your spell"); }

            }
        }

        private void boxPassives_Enter(object sender, EventArgs e) { if (btnCast.Enabled) { btnCast.Enabled = false; } }
        private void boxPassives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxPassives.Focused)
            {
                if (btnCast.Enabled) { btnCast.Enabled = false; }
                if (boxSpells.SelectedItem != null) { boxSpells.ClearSelected(); }
                try
                {
                    spellSelector = boxPassives.SelectedItem as clsSpell;
                    UpdateDescBox(spellSelector);
                }
                catch { throw new Exception("could not get your spell"); }
            }
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

        public void setSpellCosts(int i = 1)
        {
            if (i == 1)
            {
                pnlComponents.Hide();

                barActivePoints.Maximum = iCap;
                barActivePoints.Value = iActive;
                string s = "Skill Points: " + iActive.ToString() + "/" + iCap.ToString();
                lbActiveSP.Text = s;

                pnlSPBar.Show();
            }
            else
            {
                pnlSPBar.Hide();


                pbIngredientsIcon.Image = Properties.Resources.moldico;
                pbIngredientsIcon.Show();
                pbCosmicEnergyIcon.Image = Properties.Resources.zestico;
                pbCosmicEnergyIcon.Show();
                pbElementalMotesIcon.Image = Properties.Resources.tensionico;
                pbElementalMotesIcon.Show();

                string s = "";
                s = "Ingredients: " + myGame.gMage.GetComponentCount(1).ToString();
                lblIngredients.Text = s;
                lblIngredients.Show();
                s = "CosmicEnergy: " + myGame.gMage.GetComponentCount(1).ToString();
                lblCosmicEnergy.Text = s;
                lblCosmicEnergy.Show();
                s = "ElementalMotes: " + myGame.gMage.GetComponentCount(1).ToString();
                lblElementalMotes.Text = s;
                lblElementalMotes.Show();

                pnlComponents.Show();
            }
        }

        private void tkCombatSpells_CheckedChanged(object sender, EventArgs e)
        {
            if (tkCombatSpells.Checked)
            {
                ActiveSpells.AddRange(myGame.gMage.EQSpells("battle"));
                castingBS.DataSource = ActiveSpells;
                castingBS.ResetBindings(false);
            }
            else
            {
                ActiveSpells = myGame.gMage.EQSpells("global");
                ActiveSpells.AddRange(myGame.gMage.EQSpells("castonly"));
                castingBS.DataSource = ActiveSpells;
                castingBS.ResetBindings(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Get out of here?", "Cancel", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                myGame.gLock = false;
                this.Hide();
            }
        }



        /*
         * * 
         * 
         * 
         */
    }
}
