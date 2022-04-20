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
using System.Reflection;

namespace BreadMage2
{
    public partial class ExtraBoard : UserControl
    {

        public engGame myGame { get; set; }

        private int o { get; set; } = 0;

        public ExtraBoard(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }

        private void btnWander_Click(object sender, EventArgs e)
        {
            myGame.Wander();
        }

        private void btnSpellBook_Click(object sender, EventArgs e)
        {
            if (myGame.gLock == false)
            {
                if (textBox1.Text == "equip")
                {
                    myGame.OpenSpellbookBoard();
                }
                else
                {
                    myGame.OpenCastBoard();
                }
            }
            else { MessageBox.Show("Hey there's something there!"); }
        }

        private void btnMap_Click(object sender, EventArgs e)
        {

            if (myGame.gLock == false)
            {
                myGame.OpenMap();
            }
            else { MessageBox.Show("Hey there's something there!"); }
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            if (myGame.gLock == false)
            {
                myGame.OpenEquipBoard();
            }
            else { MessageBox.Show("Hey there's something there!"); }
        }

        public void TestVar(int i)
        {
            Console.WriteLine("DuringBefore: {0} {1}", new object[] { o.ToString(), i.ToString() });
            o += i;
            Console.WriteLine("DuringAfter:" + o);
        }


     



        //DevTools
        private void button1_Click(object sender, EventArgs e)
        {
            DevTools myform = new DevTools(myGame);
            myform.Show();
            Point p = new Point(1375, 300);
            myform.Location = p;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            string s = "";
            foreach (clsSpell p in myGame.gMage.EQSpells())
            {
                s += Environment.NewLine + p.spellName;
            }
            MessageBox.Show(s);

            string s = "Mage properties:" +
                  "HP: " + myGame.gMage.HP +
                  "Location: " + myGame.gMage.Location +
                  "" +
                  "" +
                  "okay!";
            MessageBox.Show(s);
            */
            /*
            if (textBox1.Text != null &&  int.TryParse(textBox1.Text, out int outnum) == true)
            {
              
                myGame.gMage.Location = Convert.ToInt32(textBox1.Text);
                MessageBox.Show((Convert.ToInt32(textBox1.Text)).ToString());
            }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myGame.gMage != null)
            {
                myGame.PortToHome();


            }


            /*
             * 
                myGame.GrantSpell(1);
                myGame.GrantSpell(2);
                myGame.GrantSpell(4);
                myGame.GrantSpell(5);
                myGame.GrantSpell(6);
                myGame.GrantSpell(8);
                myGame.GrantSpell(10);
                myGame.EquipSpell(myGame.GetSpellByID(5));
                myGame.EquipSpell(myGame.GetSpellByID(6));
                myGame.EquipSpell(myGame.GetSpellByID(7));


                myGame.GrantUniqueItem(4);
                myGame.GrantUniqueItem(3);
                myGame.GrantUniqueItem(5);
                myGame.GrantUniqueItem(7);
                myGame.EquipItem(myGame.GameLibraries.EquipLib().Find(x => x.equipID == 4));
                myGame.bMage.UpdateBars();

            o = 1;
            engChoice c = new engChoice();

            Type t = this.GetType();
            string s = "TestVar";
            MethodInfo mi = t.GetMethod(s);
            Console.WriteLine("Before:" + o);
            mi.Invoke(this, new object[] { 10 });
            Console.WriteLine("After:" + o);
            Console.WriteLine("Hey we made it");

            */



            /* this definitely works
            engChoice c = new engChoice();

            Type t = c.GetType();
            string s = "TestMethod";
            MethodInfo mi = t.GetMethod(s);

            string a = "";
            mi.Invoke(c, null);
            //mi.Invoke(a, new object[] { 1, 10 });
            Console.WriteLine("Hey we made it");
            */



            /*
            Type t = c.GetType();
            string s = "TestMethod";
            MethodInfo mi = t.GetMethod(s);


            mi.Invoke(null, new object[] { 1, 2 });


            Type t = this.GetType();
            t.InvokeMember(, ,, )
            if (myGame.gMage != null)
            {
                myGame.gMage.GrantSpell(1);
                myGame.gMage.GrantSpell(2);
                myGame.gMage.GrantSpell(4);
                myGame.gMage.GrantSpell(5);
                myGame.gMage.GrantSpell(6);
                myGame.gMage.GrantSpell(7);
                myGame.gMage.equipspell(myGame.GetSpell(5));
                myGame.gMage.equipspell(myGame.GetSpell(6));
                myGame.gMage.equipspell(myGame.GetSpell(7));
            }
            */


            /*
            if (myGame.gLock == false)
            {
                Control pZone = new Control();
                TownBoard bTown = new TownBoard(myGame);
                pZone = myGame.Controls["pArea"];
                pZone.Controls.Add(bTown);
                myGame.gLock = true;
                bTown.Show();
            }
            else { MessageBox.Show("Hey there's something there!"); }
            */



            /*
            if (myGame.gMage != null)
            {
                BreadDB BN = new BreadDB();
                BN.SavePlayerInv(myGame.gMage.SaveID, myGame.gMage.myInv);
                BN.SaveMageEffectList(myGame.gMage.SaveID, myGame.gMage.myStatEffects);
            }
            if (myGame.GetPlayerInv() != null)
            {
                int i = 0;
                string s = "";
                List<clsItem> dt = myGame.GetPlayerInv();
                foreach (clsItem d in dt)
                {
                    s += "ID: " + d.iIDType.ToString() + "  Count: " + d.iCount.ToString() + Environment.NewLine;
                    i++;
                }
                MessageBox.Show(s);
            }
            */
        }

    }
}
