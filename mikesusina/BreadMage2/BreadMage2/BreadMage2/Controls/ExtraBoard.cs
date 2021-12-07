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

        public BreadMage bMage { get; set; }
        public FightBoard bFight { get; set; }
        public ChoiceBoard bChoice { get; set; }
        public GameScreen myGameScr { get; set; }

        private int o { get; set; } = 0;

        public ExtraBoard(GameScreen aGameScr)
        {
            InitializeComponent();
            myGameScr = aGameScr;
            bFight = myGameScr.bFight;
            bChoice = myGameScr.bChoice;
        }

        private void btnWander_Click(object sender, EventArgs e)
        {
            //check if in combat
            //check if at a location
            //run logic on chosing a result

            //noncombat
            if (myGameScr.gLock == false)
            {
                if (textBox1.Text == "test")
                {
                    bChoice = new ChoiceBoard(myGameScr, 4);
                    myGameScr.Controls["pArea"].Controls.Add(bChoice);
                    myGameScr.gLock = true;
                    bChoice.Show();
                }
                else
                {
                    //combat
                    bFight = new FightBoard(myGameScr);
                    myGameScr.Controls["pArea"].Controls.Add(bFight);
                    myGameScr.gLock = true;
                    bFight.Show();
                    bFight.SetChatterBox();
                    bFight.BeginFight();
                }
            }
            else { MessageBox.Show("Hey there's something there!"); }
        }

        private void btnSpellBook_Click(object sender, EventArgs e)
        {
            if (myGameScr.gLock == false)
            {
                Control pZone = new Control();

                Control bSpell = new Control();
                if (textBox1.Text == "test")
                {
                    bSpell = new CastBoard(myGameScr);
                }
                else
                {
                    bSpell = new SpellBookBoard(myGameScr);
                }

                pZone = myGameScr.Controls["pArea"];
                pZone.Controls.Add(bSpell);
                myGameScr.gLock = true;
                bSpell.Show();
            }
            else { MessageBox.Show("Hey there's something there!"); }
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            if (myGameScr.gLock == false)
            {
                Control pZone = new Control();
                EquipBoard bEquip = new EquipBoard(myGameScr);
                pZone = myGameScr.Controls["pArea"];
                pZone.Controls.Add(bEquip);
                myGameScr.gLock = true;
                bEquip.Show();

            }



            /*
            if (myGameScr.gLock == false)
            {
                Control pZone = new Control();
                MapBoard bMap = new MapBoard(myGameScr);
                pZone = myGameScr.Controls["pArea"];
                pZone.Controls.Add(bMap);
                myGameScr.gLock = true;
                bMap.Show();
            }
            else { MessageBox.Show("Hey there's something there!"); }
            */
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
            DevTools myform = new DevTools(myGameScr);
            myform.Show();
            Point p = new Point(1375, 300);
            myform.Location = p;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            string s = "";
            foreach (clsSpell p in myGameScr.gMage.EQSpells())
            {
                s += Environment.NewLine + p.spellName;
            }
            MessageBox.Show(s);

            string s = "Mage properties:" +
                  "HP: " + myGameScr.gMage.HP +
                  "Location: " + myGameScr.gMage.Location +
                  "" +
                  "" +
                  "okay!";
            MessageBox.Show(s);
            */
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
            if (myGameScr.gMage != null)
            {
                myGameScr.gMage.GrantSpell(1);
                myGameScr.gMage.GrantSpell(2);
                myGameScr.gMage.GrantSpell(4);
                myGameScr.gMage.GrantSpell(5);
                myGameScr.gMage.GrantSpell(6);
                myGameScr.gMage.GrantSpell(8);
                myGameScr.gMage.GrantSpell(10);
                //myGameScr.gMage.EquipSpell(myGameScr.GetSpell(5));
                myGameScr.gMage.EquipSpell(myGameScr.GetSpell(6));
                //myGameScr.gMage.EquipSpell(myGameScr.GetSpell(7));


                myGameScr.gMage.GetUniqueItem(4);
                myGameScr.gMage.GetUniqueItem(3);
                myGameScr.gMage.GetUniqueItem(5);
                myGameScr.gMage.GetUniqueItem(7);
                myGameScr.gMage.EquipItem(myGameScr.GameLibraries.EquipLib().Find(x => x.equipID == 4));
                myGameScr.bMage.UpdateBars();
            }


            /*

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
            if (myGameScr.gMage != null)
            {
                myGameScr.gMage.GrantSpell(1);
                myGameScr.gMage.GrantSpell(2);
                myGameScr.gMage.GrantSpell(4);
                myGameScr.gMage.GrantSpell(5);
                myGameScr.gMage.GrantSpell(6);
                myGameScr.gMage.GrantSpell(7);
                myGameScr.gMage.equipspell(myGameScr.GetSpell(5));
                myGameScr.gMage.equipspell(myGameScr.GetSpell(6));
                myGameScr.gMage.equipspell(myGameScr.GetSpell(7));
            }
            */


            /*
            if (myGameScr.gLock == false)
            {
                Control pZone = new Control();
                TownBoard bTown = new TownBoard(myGameScr);
                pZone = myGameScr.Controls["pArea"];
                pZone.Controls.Add(bTown);
                myGameScr.gLock = true;
                bTown.Show();
            }
            else { MessageBox.Show("Hey there's something there!"); }
            */



            /*
            if (myGameScr.gMage != null)
            {
                BreadDB BN = new BreadDB();
                BN.SavePlayerInv(myGameScr.gMage.SaveID, myGameScr.gMage.myInv);
                BN.SaveMageEffectList(myGameScr.gMage.SaveID, myGameScr.gMage.myStatEffects);
            }
            if (myGameScr.GetPlayerInv() != null)
            {
                int i = 0;
                string s = "";
                List<clsItem> dt = myGameScr.GetPlayerInv();
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
