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


        private GameScreen sGameScreen;
        private int iCap;
        private int iActive;

        private List<clsSpell> ActiveSpells;
        private List<clsSpell> EQPassiveSpells;
        private List<clsSpell> ItemSpells;
        private clsSpell spellSelector = new clsSpell();

        private engBuffs BuffHelper = new engBuffs();


        private BindingSource castingBS = new BindingSource();
        private BindingSource passiveBS = new BindingSource();
        private BindingSource itemBS = new BindingSource();


        public CastBoard(GameScreen aGS)
        {
            InitializeComponent();
            sGameScreen = aGS;
            BuffHelper = sGameScreen.BuffHelper();
            ItemSpells = new List<clsSpell>();

            //load spells
            ActiveSpells = sGameScreen.gMage.EQSpells(3);
            EQPassiveSpells = sGameScreen.gMage.EQSpells(2);
            ItemSpells = sGameScreen.GetAllKnownMageSpells("I");
            

            //set the SP info
            iCap = sGameScreen.gMage.Stats.MaxSP;
            iActive = sGameScreen.gMage.Stats.CurrentMaxSP;
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
                s = "Ingredients: " + sGameScreen.gMage.GetComponentCount(1).ToString();
                lblIngredients.Text = s;
                lblIngredients.Show();
                s = "CosmicEnergy: " + sGameScreen.gMage.GetComponentCount(1).ToString();
                lblCosmicEnergy.Text = s;
                lblCosmicEnergy.Show();
                s = "ElementalMotes: " + sGameScreen.gMage.GetComponentCount(1).ToString();
                lblElementalMotes.Text = s;
                lblElementalMotes.Show();

                pnlComponents.Show();
            }
        }

        private void tkCombatSpells_CheckedChanged(object sender, EventArgs e)
        {
            if (tkCombatSpells.Checked)
            {
                ActiveSpells = sGameScreen.gMage.EQSpells(4);
                castingBS.DataSource = ActiveSpells;
            }
            else
            {
                ActiveSpells = sGameScreen.gMage.EQSpells(3);
                castingBS.DataSource = ActiveSpells;
            }
        }



        /*
         * * 
         * 
         * 
         */
    }
}
