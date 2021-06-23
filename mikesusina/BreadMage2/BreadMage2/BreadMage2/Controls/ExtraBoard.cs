using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BreadMage2.Controls;
using BreadMage2.Screens;

namespace BreadMage2
{
    public partial class ExtraBoard : UserControl
    {

        public BreadMage bMage { get; set; }
        public FightBoard bFight { get; set; }
        public GameScreen myGameScr { get; set; }

        public ExtraBoard(GameScreen aGameScr)
        {
            InitializeComponent();
            myGameScr = aGameScr;
           
        }

        private void btnWander_Click(object sender, EventArgs e)
        {
            //check if in combat
            //check if at a location
            //run logic on chosing a result

            //noncombat

            if (textBox1.Text == "test")
            {
                Form ChoiceScreen = new ChoiceScreen(myGameScr, myGameScr.gChoiceList.Find(x => x.AdvID == 1));
                myGameScr.Hide();
                ChoiceScreen.Show();
            }
            else
            {
                //combat
                if (this.Parent.Parent.Controls["pArea"].Controls["FightBoard"] == null)
                {

                    Control FightZone = new Control();
                    bFight = new FightBoard(myGameScr);
                    FightZone = this.Parent.Parent.Controls["pArea"];
                    FightZone.Controls.Add(bFight);
                    myGameScr.bFight = bFight;
                    bFight.Show();
                    //FightZone.Controls["FightBoard"].Show();

                }
                else { MessageBox.Show("Hey there's something there!"); }
            }
        }


        //DevTools
        private void button1_Click(object sender, EventArgs e)
        {
            DevTools myform = new DevTools(myGameScr);
            myform.Show();
            Point p = new Point(1375, 300);
            myform.Location = p;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string s = "Mage properties:" +
                  "HP: " + myGameScr.gMage.HP +
                  "Location: " + myGameScr.gMage.Location +
                  "" +
                  "" +
                  "okay!";
            MessageBox.Show(s);
            /*
            if (textBox1.Text != null &&  int.TryParse(textBox1.Text, out int outnum) == true)
            {
              
                myGameScr.gMage.Location = Convert.ToInt32(textBox1.Text);
                MessageBox.Show((Convert.ToInt32(textBox1.Text)).ToString());
            }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myGameScr.GetPlayerInv() != null)
            {
                int i = 0;
                string s = "";
                DataTable dt = myGameScr.GetPlayerInv();
                foreach (DataRow d in dt.Rows)
                {
                    s += "ID: " + d[0].ToString() + "  Count: " + d[1].ToString() + Environment.NewLine;
                    i++;
                }
                MessageBox.Show(s);
            }
        }
    }
}
