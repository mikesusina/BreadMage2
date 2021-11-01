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


        private List<clsSpell> ActiveSpells;
        private List<clsSpell> SpellPool;


        public SpellBookBoard(GameScreen aGS)
        {
            InitializeComponent();
            sGameScreen = aGS;
            SpellPool = new List<clsSpell>();

            //load spells
            ActiveSpells = sGameScreen.gMage.EQSpells();
            foreach (int i in sGameScreen.gMage.AllSpells())
            {
                SpellPool.Add(sGameScreen.GetSpell(i));
            }

            //set the SP info
            iCap = sGameScreen.gMage.SP;
            iEquipped = GetEquippedSP();
            barSkillCap.Maximum = iCap;
            try { barSkillCap.Value = iEquipped; }
            catch { barSkillCap.Value = 0; }
            UpdateSPTag();

            //populate the boxes
            foreach (clsSpell s in SpellPool)
            {
                boxKnown.Items.Add(s.spellName);
            }
            foreach (clsSpell s in ActiveSpells)
            {
                boxKnown.Items.Remove(s.spellName);
                boxEquipped.Items.Add(s.spellName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (boxKnown.SelectedItem != null)
            {
                clsSpell z = sGameScreen.GameLibraries.SpellBook().Find(x => x.spellName == boxKnown.SelectedItem.ToString());
                if (z.SPCost + iEquipped > iCap)
                {
                    MessageBox.Show("Woah now, that's too many sps bud");
                }
                else
                {
                    ActiveSpells.Add(z);
                    boxEquipped.Items.Add(boxKnown.SelectedItem);
                    boxKnown.Items.Remove(boxKnown.SelectedItem);
                    RefreshSPInfo();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (boxEquipped.SelectedItem != null)
            {
                clsSpell z = sGameScreen.GameLibraries.SpellBook().Find(x => x.spellName == boxEquipped.SelectedItem.ToString());
                ActiveSpells.Remove(z);
                boxKnown.Items.Add(boxEquipped.SelectedItem);
                boxEquipped.Items.Remove(boxEquipped.SelectedItem);
                RefreshSPInfo();
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (boxEquipped.SelectedItem != null && boxKnown.Focused) { boxEquipped.ClearSelected(); }
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxKnown.SelectedItem != null && boxEquipped.Focused) { boxKnown.ClearSelected(); }
        }

        private int GetEquippedSP()
        {
            int i = 0;
            foreach (clsSpell s in ActiveSpells) { i += s.SPCost; }
            return i;
        }

        private void UpdateSPTag()
        {
            string s = "Skill points: " + iEquipped.ToString() + "/" + iCap.ToString();
            lblEquipCap.Text = s;
            barSkillCap.Value = iEquipped;
        }
        private void RefreshSPInfo()
        {
            int i = 0;
            foreach (clsSpell s in ActiveSpells)
            {
                i += s.SPCost;
            }
            iEquipped = i;
            UpdateSPTag();
        }
    }
}
