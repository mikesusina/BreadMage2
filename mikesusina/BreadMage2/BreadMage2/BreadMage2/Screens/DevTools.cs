using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2.Screens
{
    public partial class DevTools : Form
    {
        engGame myGame { get; set; }

        public DevTools(engGame aGame)
        {
            InitializeComponent();

            myGame = aGame;
        }

        private void btnSetLoc_Click(object sender, EventArgs e)
        {
            if (txbLoc.Text != null && int.TryParse(txbLoc.Text, out int outnum) == true)
            {

                myGame.gMage.Location = Convert.ToInt32(txbLoc.Text);
                MessageBox.Show((Convert.ToInt32(txbLoc.Text)).ToString());
            }
        }

        private void btnClrEventArea_Click(object sender, EventArgs e)
        {
            if (myGame != null && myGame.gGS.Controls["pArea"] != null)
            {
                foreach (Control item in myGame.gGS.Controls["pArea"].Controls)
                {
                    // if (item.Name == "FightBoard") {}
                    item.Hide();
                    myGame.gGS.Controls["pArea"].Controls.Remove(item);
                }
                myGame.gLock = false;
            }

        }

        private void btnHeal_Click(object sender, EventArgs e)
        {
            if (txbHeal.Text == null || txbHeal.Text == "")
            {
                myGame.gMage.Stats.HP = myGame.gMage.Stats.HPMax;
                //myGame.gMage.SP = myGame.gMage.SPmax;
                myGame.bMage.UpdateBars();


            }
            else if (int.TryParse(txbHeal.Text, out int outnum) == true)
            {

                int i = myGame.gMage.Stats.HP + (Convert.ToInt32(txbHeal.Text));
                myGame.gMage.AdjustHP(i);
                myGame.bMage.UpdateBars();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //myGame.gMage.AddEffect(13, 1, 1);
            //myGame.bMage.BuffStuff();
            myGame.GrantUniqueItem(4);
            myGame.GrantUniqueItem(3);
            myGame.EquipItem(myGame.GameLibraries.EquipLib().Find(x => x.equipID == 4));
            myGame.bMage.UpdateBars();
        }

        private void btnQuickSlots_Click(object sender, EventArgs e)
        {
            if (tbAmount != null && tbItemID != null && int.TryParse(tbAmount.Text, out int outnum) == true 
                    && int.TryParse(tbItemID.Text, out int outnum2) == true)
            {
                if (myGame != null && myGame.gGS.Controls["pQuickBoard"].Controls["QuickBoard"] != null)
                {
                    myGame.gMage.AdjustComponent(Convert.ToInt32(tbItemID.Text.ToString()), Convert.ToInt32(tbAmount.Text.ToString()));
                }
            }
                
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //checking gMage Inventory status
            if (myGame.gMage != null)
            {
                /*
                string s = "okay + ";
                foreach (DataRow r in myGame.gMage.myInv.Rows)
                {
                    s = s + Environment.NewLine + "ItemID: " + r[1].ToString() + " Count: " +  r[2].ToString();
                }
                MessageBox.Show(s);
                */
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myGame.gMage != null)
            {
                BreadDB BN = new BreadDB();
                myGame.gMage.PrepSaveData();
                BN.SaveData(myGame.gMage.GetSaveData());
               // BN.SavePlayerInv(myGame.gMage.SaveID, myGame.gMage.myInv);
               // BN.SaveMageEffectList(myGame.gMage.SaveID, myGame.gMage.myStatEffects);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            //testing XML stuff
            BreadDB bnet = new BreadDB();
            List<clsSpell> sb = new List<clsSpell>();
            
            myGame.gMage.myGameFlags.aspellbook = sb;
            bnet.SaveGameFlags(myGame.gMage.myGameFlags);
            */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = txbLoc.Text;

            int tID = 0;
            int tRate = 0;
            tID = Convert.ToInt32(s.Substring(s.IndexOf("ID=") + 3, s.IndexOf("RT") - 3));
            tRate = Convert.ToInt32(s.Substring(s.IndexOf("RT=") + 3));

            string t = "ID = " + tID.ToString() + Environment.NewLine + "RT = " + tRate.ToString();
            MessageBox.Show(t);
        }

        private void DevTools_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboItemType.SelectedItem != null)
            {
                int i = Convert.ToInt32(comboItemType.SelectedItem.ToString());
                List<clsUniqueItem> list = new List<clsUniqueItem>();
                foreach (int i2 in myGame.gMage.GetSaveData().gottenItems)
                {
                    clsUniqueItem o = myGame.GetUniqueItem(i2);
                    if (o.itemType == i) { list.Add(o); }
                }
                if (list.Count > 0)
                {
                    string s = "";
                    foreach (clsUniqueItem o in list)
                    {
                       s += o.ItemName + Environment.NewLine; 
                    }
                    tbDisplay.Text = s;
                }

            }

        }
    }
}
