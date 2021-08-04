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
        private clsMonster myMonster;
        private List<clsMonster> myMonsterList;
        private engBattle BattleEngine;
        public GameScreen myGameScr { get; set; }

        private Color c;


        public FightBoard(GameScreen aGameScr)
        {
            InitializeComponent();
            myGameScr = aGameScr;
            c = new Color();
            c = Color.Lime;
            // if the local full monster set is empty load it
            if (myGameScr.gMonsterList is null)
            {
                BreadDB BreadNet = new BreadDB();
                myMonsterList = BreadNet.LoadMonsterList();
                myGameScr.gMonsterList = myMonsterList;
            }
            else { myMonsterList = myGameScr.gMonsterList; }
            
            //Get list of local monsters
            // *************handle if locaiton contains no encounters
            List<clsMonster> locMonsters = new List<clsMonster>();
            foreach (clsMonster m in myMonsterList)
            {
                if (m.Location == myGameScr.gMage.Location)
                {
                    m.RefreshMonster();
                    locMonsters.Add(m);
                }
            }

            //possible work in to make more common or less common encounters? maybe roll a d20 or something and make rare flag on 20?
            myMonster = locMonsters.ElementAt(myGameScr.gRandom.Next(0, (locMonsters.Count)));

            
            txtChatter.Clear();
            txtChatter.Text = "Look out it's a " + myMonster.MonName + "!!!";
            //myMonster = new clsMonster(myMonster);

            myGameScr = aGameScr;
            myGameScr.gMonster = myMonster;
            myGameScr.bFight = this;
            Load_Fight();
        }


        //for loading in a fight with a specific monster instead of using location pool:
        public FightBoard(GameScreen aGameScr, int anID)
        {
            InitializeComponent();
            myGameScr = aGameScr;
            // if the local full monster set is empty load it
            if (myGameScr.gMonsterList is null)
            {
                BreadDB BreadNet = new BreadDB();
                myMonsterList = BreadNet.LoadMonsterList();
                myGameScr.gMonsterList = myMonsterList;
            }
            else { myMonsterList = myGameScr.gMonsterList; }

            if (myGameScr.gMonsterList.Exists(x => x.monID == anID))
            {
                myMonster = myGameScr.gMonsterList.Find(x => x.monID == anID);
            }

            txtChatter.Clear();
            txtChatter.Text = "Look out it's a " + myMonster.MonName + "!!!";
            //myMonster = new clsMonster(myMonster);

            myGameScr = aGameScr;
            myGameScr.gMonster = myMonster;
            myGameScr.bFight = this;
            Load_Fight();
        }

        private void Load_Fight()
        {

            //create the battle engine
            BattleEngine = new engBattle(myGameScr);

            //remember to unlock/lock quick spells/items when combat starts and ends

            //load image
            //TODO: in boss encounter, flip picture boxes
            //pbMonster.Image = Properties.Resources.[URL];
            object o = Properties.Resources.ResourceManager.GetObject(myGameScr.gMonster.ImageURL);
            if (o is Image) { pbMonster.Image = o as Image; }
            else { pbMonster.Image = Properties.Resources.BreadMage2; }
            pbMonster.Show();

            //Set Bars
            //just in case, reset the monster HP to full
            //pbMonHP.Minimum = 0;
            myGameScr.gMonster.HP = myGameScr.gMonster.HPmax;
            pbMonHP.Maximum = myGameScr.gMonster.HPmax;
            pbMonHP.Value = myGameScr.gMonster.HP;
        }

        
        public clsMonster GetMonster() { return myGameScr.gMonster; }

        public void UpdateBars(clsMonster aMonster)
        {
            if (aMonster.HPmax > pbMonHP.Maximum) { pbMonHP.Maximum = aMonster.HPmax; }

            if (aMonster.HP > 0) { pbMonHP.Value = aMonster.HP; }
            else { pbMonHP.Value = 0; }
        }

        public void AddChatter(string newText)
        {

            txtChatter.AppendText(Environment.NewLine + newText);
            txtChatter.ScrollBars = ScrollBars.Vertical;

            if (c == Color.Lime) {c = Color.CornflowerBlue; }
            else { c = Color.Lime; }
            /*
            System.Text.RegularExpressions.Regex e = new System.Text.RegularExpressions.Regex("\b(" + newText + "\b");

            rtbChatter.Select()
            rtbChatter.SelectedText.*/
            rtbChatter.SelectionColor = c;
            rtbChatter.AppendText(Environment.NewLine + newText);

            /*
            rtbChatter.SelectionColor = Color.Maroon;
            rtbChatter.AppendText(Environment.NewLine + "Hey now");
            rtbChatter.SelectionColor = Color.LightCoral;
            rtbChatter.AppendText(" you're an all star");
            */

        }

        public void AddMonsterChatter(int aType, int aDamage)
        {
            List<string> ChatterRoll = new List<string>();

            switch (aType)
            {
                case 1:
                    ChatterRoll.AddRange(myGameScr.gMonster.PAKChatterList);
                    ChatterRoll.AddRange(myGameScr.gChatBot.PAKChatterList);
                    break;
                case 2:
                    ChatterRoll.AddRange(myGameScr.gMonster.MAKChatterList);
                    ChatterRoll.AddRange(myGameScr.gChatBot.MAKChatterList);
                    break;
                case 3:
                    ChatterRoll.AddRange(myGameScr.gMonster.MISChatterList);
                    ChatterRoll.AddRange(myGameScr.gChatBot.MISChatterList);
                    break;
                case 4:
                    ChatterRoll.AddRange(myGameScr.gMonster.DEFChatterList);
                    ChatterRoll.AddRange(myGameScr.gChatBot.DEFChatterList);
                    break;
                case 5:
                    ChatterRoll.AddRange(myGameScr.gMonster.EAKChatterList);
                    ChatterRoll.AddRange(myGameScr.gChatBot.EAKChatterList);
                    break;
                default:
                    /*
                    ChatterRoll.AddRange(myGameScr.gMonster.PAKChatterList);
                    ChatterRoll.AddRange(myGameScr.gChatBot.PAKChatterList);
                    */
                    break;
            }
            int i = myGameScr.gRandom.Next(ChatterRoll.Count - 1);
            string s = ChatterRoll[i].ToString() + " " + aDamage.ToString() + " damage!";
            AddChatter(s);
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            BattleEngine.MageAttack(1);
        }


    }
}
