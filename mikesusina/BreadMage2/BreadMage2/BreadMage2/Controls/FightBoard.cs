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


        public FightBoard(GameScreen aGameScr)
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
            
            //Get list of local monsters
            //grab IDs of local monsters into a list
            // *************handle if locaiton contains no encounters
            List<clsMonster> locMonsters = new List<clsMonster>();
            foreach (clsMonster m in myMonsterList)
            {
                if (m.Location == myGameScr.gMage.Location)
                {
                    locMonsters.Add(m);
                }
            }

            //possible work in to make more common or less common encounters? maybe roll a d20 or something and make rare flag on 20?
            myMonster = locMonsters.ElementAt(myGameScr.gRandom.Next(0, (locMonsters.Count)));

            
            
            /*
             * old:
            string s = "Location = " + myGameScr.gMage.Location;
            DataTable vLocMonster = myGameScr.gMonsterList.Tables[0].Select(s).CopyToDataTable();
            s = "MonsterID = " + vLocMonster.Rows[myGameScr.gRandom.Next(0, vLocMonster.Rows.Count)]["MonsterID"];
            vLocMonster = vLocMonster.Select(s).CopyToDataTable();
            */

            txtChatter.Clear();
            txtChatter.Text = "Look out it's a " + myMonster.MonName + "!!!";
            //myMonster = new clsMonster(myMonster);

            myGameScr = aGameScr;
            myGameScr.gMonster = myMonster;
            myGameScr.bFight = this;
            Load_Fight();
        }
        /*
        public FightBoard(GameScreen myGameScr, Monster aMonster)
        {
            InitializeComponent();

            myMonster = aMonster;
            myMage = aMage;
            Load_Fight();
        }
        */
        private void Load_Fight()
        {

            //create the battle engine
            BattleEngine = new engBattle(myGameScr);

            //remember to unlock/lock quick spells/items when combat starts and ends

            //load image
            //pbMonster.Image = Properties.Resources.[URL];
            object o = Properties.Resources.ResourceManager.GetObject(myGameScr.gMonster.ImageURL);
            if (o is Image) { pbMonster.Image = o as Image; }
            else { pbMonster.Image = Properties.Resources.BreadMage2; }
            pbMonster.Show();

            //Set Bars
            //pbMonHP.Minimum = 0;
            pbMonHP.Maximum = myMonster.HPmax;
            pbMonHP.Value = myMonster.HP;
        }

        
        public clsMonster GetMonster() { return myMonster; }


        public void UpdateBars(int newHP)
        {
            if (newHP < 0) { newHP = 0;  }
            myGameScr.gMonster.HP = newHP;
            pbMonHP.Value = newHP;
        }

        public void AddChatter(string newText)
        {
            
            txtChatter.AppendText(Environment.NewLine + Environment.NewLine + newText);
            txtChatter.ScrollBars = ScrollBars.Vertical;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            BattleEngine.MageAttack(1);
        }


    }
}
