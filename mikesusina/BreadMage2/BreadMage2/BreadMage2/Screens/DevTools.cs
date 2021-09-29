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
        GameScreen myGameScr { get; set; }

        public DevTools(GameScreen aGameScr)
        {
            InitializeComponent();

            myGameScr = aGameScr;
        }

        private void btnSetLoc_Click(object sender, EventArgs e)
        {
            if (txbLoc.Text != null && int.TryParse(txbLoc.Text, out int outnum) == true)
            {

                myGameScr.gMage.Location = Convert.ToInt32(txbLoc.Text);
                MessageBox.Show((Convert.ToInt32(txbLoc.Text)).ToString());
            }
        }

        private void btnClrEventArea_Click(object sender, EventArgs e)
        {
            if (myGameScr != null && myGameScr.Controls["pArea"] != null)
            {
                foreach (Control item in myGameScr.Controls["pArea"].Controls)
                {
                    // if (item.Name == "FightBoard") {}
                    myGameScr.Controls["pArea"].Controls.Remove(item);
                    item.Dispose();
                }
                myGameScr.gLock = false;
            }

        }

        private void btnHeal_Click(object sender, EventArgs e)
        {
            if (txbHeal.Text == null || txbHeal.Text == "")
            {
                myGameScr.gMage.HP = myGameScr.gMage.HPmax;
                myGameScr.gMage.MP = myGameScr.gMage.MPmax;
                //myGameScr.gMage.SP = myGameScr.gMage.SPmax;
                myGameScr.bMage.UpdateBars(myGameScr.gMage);


            }
            else if (int.TryParse(txbHeal.Text, out int outnum) == true)
            {

                int i = myGameScr.gMage.HP + (Convert.ToInt32(txbHeal.Text));
                myGameScr.gMage.HP = i;
                myGameScr.bMage.UpdateBars(myGameScr.gMage);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        
        }

        private void btnQuickSlots_Click(object sender, EventArgs e)
        {
            if (tbAmount != null && tbItemID != null && int.TryParse(tbAmount.Text, out int outnum) == true 
                    && int.TryParse(tbItemID.Text, out int outnum2) == true)
            {
                if (myGameScr != null && myGameScr.Controls["pQuickBoard"].Controls["QuickBoard"] != null)
                {
                    myGameScr.gMage.AddItem(Convert.ToInt32(tbItemID.Text.ToString()), Convert.ToInt32(tbAmount.Text.ToString()));
                }
            }
                
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //checking gMage Inventory status
            if (myGameScr.gMage != null)
            {
                /*
                string s = "okay + ";
                foreach (DataRow r in myGameScr.gMage.myInv.Rows)
                {
                    s = s + Environment.NewLine + "ItemID: " + r[1].ToString() + " Count: " +  r[2].ToString();
                }
                MessageBox.Show(s);
                */
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myGameScr.gMage != null)
            {
                BreadDB BN = new BreadDB();
                BN.SavePlayerInv(myGameScr.gMage.SaveID, myGameScr.gMage.myInv);
                BN.SaveMageEffectList(myGameScr.gMage.SaveID, myGameScr.gMage.myStatEffects);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            //testing XML stuff
            BreadDB bnet = new BreadDB();
            List<clsSpell> sb = new List<clsSpell>();
            
            myGameScr.gMage.myGameFlags.aspellbook = sb;
            bnet.SaveGameFlags(myGameScr.gMage.myGameFlags);
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
    }
}
