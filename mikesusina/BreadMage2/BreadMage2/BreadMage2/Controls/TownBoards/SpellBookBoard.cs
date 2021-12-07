using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2
{
    public partial class SpellBookBoard : UserControl
    {
        private GameScreen sGameScreen;
        private int iCap;
        private int iEquipped;

        private List<clsSpell> OriginalSpells;
        private List<clsSpell> ActiveSpells;
        private List<clsSpell> EQPassiveSpells;
        private List<clsSpell> SpellPool;
        private clsSpell spellSelector = new clsSpell();



        private BindingSource activeBS = new BindingSource();
        private BindingSource passiveBS = new BindingSource();
        private BindingSource allBS = new BindingSource();

        public SpellBookBoard(GameScreen aGS)
        {
            InitializeComponent();
            sGameScreen = aGS;
            SpellPool = new List<clsSpell>();

            //load spells
            OriginalSpells = sGameScreen.gMage.EQSpells();
            ActiveSpells = sGameScreen.gMage.EQSpells(4);
            EQPassiveSpells = sGameScreen.gMage.EQSpells(2);
            foreach (clsSpell s in sGameScreen.GetAllKnownMageSpells())
            {
                if (ActiveSpells.Contains(s) == false) { SpellPool.Add(s); }
            }

            //set the SP info
            iCap = sGameScreen.gMage.Stats.MaxSP;
            iEquipped = sGameScreen.gMage.EquippedSP();
            barSkillCap.Maximum = iCap;
            try { barSkillCap.Value = iEquipped; }
            catch { barSkillCap.Value = 0; }

            UpdateSPTag();

            activeBS.DataSource = ActiveSpells;
            allBS.DataSource = SpellPool;
            passiveBS.DataSource = EQPassiveSpells;


            boxKnown.DataSource = allBS;
            boxKnown.DisplayMember = "spellName";
            boxEquipped.DataSource = activeBS;
            boxEquipped.DisplayMember = "spellName";
            boxPassives.DataSource = passiveBS;
            boxPassives.DisplayMember = "spellName";

            boxKnown.ClearSelected();
            boxEquipped.ClearSelected();
            boxPassives.ClearSelected();


            /* ???? do display members and datasources update these automatically?

            //populate the boxes
            foreach (clsSpell s in SpellPool)
            {
                boxKnown.Items.Add(s.spellName);
            }
            foreach (clsSpell s in ActiveSpells)
            {
                boxEquipped.Items.Add(s.spellName);
            }
            */
        }
        private void MoveSpell()
        {
            ListBox home = new ListBox();
            ListBox destination = new ListBox();

            if (boxKnown.Focused) { boxKnown = home; boxEquipped = destination; }
            else { boxKnown = destination; boxEquipped = home; }
        }


        private void btnMove_Click(object sender, EventArgs e)
        {
            ListBox home = new ListBox();
            ListBox destination = new ListBox();

            if (boxKnown.SelectedItem != null)
            {
                home = boxEquipped;
                destination = boxKnown;
                if ((GetActiveEquippedSP() + spellSelector.SPCost) > iCap)
                {
                    MessageBox.Show("You don't have that many skill points");
                    return;
                }
                else
                {
                    ActiveSpells.Add(spellSelector);
                    SpellPool.Remove(spellSelector);

                    //home.Items.Remove(spellSelector);
                    //destination.Items.Add(spellSelector);
                    UpdateSPTag();
                    UpdateBoxes();
                }
            }
            else if (boxEquipped.SelectedItem != null)
            {
                destination = boxEquipped;
                home = boxKnown;

                ActiveSpells.Remove(spellSelector);
                SpellPool.Add(spellSelector);

                UpdateSPTag();
                UpdateBoxes();
            }
            boxKnown.ClearSelected();
            boxEquipped.ClearSelected();
            
        }


       
        private int GetActiveEquippedSP()
        {
            /*
            int iTemp = 0;
            foreach (object o in boxEquipped.Items)
            {
                try { clsSpell s = o as clsSpell; iTemp += s.SPCost; }
                catch { throw new ArgumentException("I found a non-spell in the box apparently"); }
            }


            int i = 0;
            foreach (clsSpell s in ActiveSpells) { i += s.SPCost; }
            return i;
            */
            int i = 0;
            foreach (clsSpell s in ActiveSpells) { i += s.SPCost; }
            return i;
        }

        private void UpdateSPTag()
        {
            iEquipped = GetActiveEquippedSP();
            string s = "Equipped Skill Points: " + iEquipped.ToString() + "/" + iCap.ToString();
            lblEquipCap.Text = s;
            try { barSkillCap.Value = iEquipped; }
            catch { barSkillCap.Value = 0; }
        }

        private void UpdateDescBox(clsSpell aSpell)
        {
            //update to display cost info in box?
            rtbSpellDesc.Text = aSpell.spellDescription;
            pbSpellIcon.Image = GetSpellIconImage(aSpell);
            pbSpellIcon.Show();
            pictureBox1.Image = GetSpellIconImage(aSpell);
            pictureBox1.Show();
            lbSpellName.Text = aSpell.spellName;
        }

        private void UpdateBoxes()
        {
            activeBS.ResetBindings(false);
            allBS.ResetBindings(false);
            /*
            boxKnown.DataSource = SpellPool;
            boxKnown.DisplayMember = "spellName";
            boxEquipped.DataSource = ActiveSpells;
            boxEquipped.DisplayMember = "spellName";
            */
        }

        

        private void boxKnown_Enter(object sender, EventArgs e) { if (btnMove.Enabled == false && boxPassives.SelectedItem == null) { btnMove.Enabled = true; } }
        private void boxKnown_SelectedValueChanged(object sender, EventArgs e)
        {
            if (boxKnown.Focused)
            {
                if (btnMove.Enabled == false) { btnMove.Enabled = true; }
                if (boxEquipped.SelectedItem != null) { boxEquipped.ClearSelected(); }
                if (boxPassives.SelectedItem != null) { boxPassives.ClearSelected(); }
                try
                {
                    spellSelector = boxKnown.SelectedItem as clsSpell;
                    UpdateDescBox(spellSelector);
                }
                catch { throw new Exception("could not get your spell"); }
            }
        }



        private void boxEquipped_Enter(object sender, EventArgs e) { if (btnMove.Enabled == false && boxPassives.SelectedItem == null) { btnMove.Enabled = true; } }
        private void boxEquipped_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxEquipped.Focused)
            {
                if (btnMove.Enabled == false) { btnMove.Enabled = true; }
                if (boxKnown.SelectedItem != null) { boxKnown.ClearSelected(); }
                if (boxPassives.SelectedItem != null) { boxPassives.ClearSelected(); }
                try
                {
                    spellSelector = boxEquipped.SelectedItem as clsSpell;
                    UpdateDescBox(spellSelector);
                }
                catch { throw new Exception("could not get your spell"); }
            }
        }




        private void boxPassives_Enter(object sender, EventArgs e) { if (btnMove.Enabled) { btnMove.Enabled = false; } }
        private void boxPassives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxPassives.Focused)
            {
                if (btnMove.Enabled) { btnMove.Enabled = false; }
                if (boxEquipped.SelectedItem != null) { boxEquipped.ClearSelected(); }
                if (boxKnown.SelectedItem != null) { boxKnown.ClearSelected(); }
                try
                {
                    spellSelector = boxPassives.SelectedItem as clsSpell;
                    UpdateDescBox(spellSelector);
                }
                catch { throw new Exception("could not get your spell"); }
            }
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








        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Okay with these spells?", "Equip", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<clsSpell> returnSpells = new List<clsSpell>();
                returnSpells.AddRange(ActiveSpells);
                returnSpells.AddRange(EQPassiveSpells);
                sGameScreen.gMage.EquipSpellSet(returnSpells);
                sGameScreen.gLock = false;
                this.Dispose();
                // at some point - need to fix SP values - if maxSP drops below currentmaxSP, if somehow we gain maxSP
                //sGameScreen.gMage.Stats.CurrentMaxSP;

                sGameScreen.RefreshMage();
                sGameScreen.gLock = false;
                this.Hide();
                this.Dispose();
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Get out of here?", "Cancel", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                sGameScreen.gLock = false;
                this.Hide();
                this.Dispose();
            }
        }
    }
}
