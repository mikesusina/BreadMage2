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
        private engBattle BattleEngine;
        public GameScreen myGameScr { get; set; }

        private Color c;
        private List<clsSpell> activeSpells { get; set; } = new List<clsSpell>();


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
                myGameScr.gMonsterList = BreadNet.LoadMonsterList();
            }

            //Get list of local monsters
            // *************handle if locaiton contains no encounters
            List<clsMonster> locMonsters = new List<clsMonster>();
            foreach (clsMonster m in myGameScr.gMonsterList)
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
            rtbChatter.AppendText(Environment.NewLine + "Look out it's a " + myMonster.MonName + "!!!");

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
                myGameScr.gMonsterList = BreadNet.LoadMonsterList();
            }

            
            if (myGameScr.gMonsterList.Exists(x => x.monID == anID))
            {
                clsMonster newMonster = myGameScr.gMonsterList.Find(x => x.monID == anID);
                myGameScr.gMonster = newMonster;
            }

            txtChatter.Clear();
            txtChatter.Text = "Look out it's a " + myGameScr.gMonster.MonName + "!!!";
            myGameScr.bFight = this;

            Load_Fight();
        }

        private void Load_Fight()
        {

            //create the battle engine
            BattleEngine = new engBattle(myGameScr);
            myMonster = myGameScr.gMonster;

            //remember to unlock/lock quick spells/items when combat starts and ends

            //load monster image
            object o = Properties.Resources.ResourceManager.GetObject(myMonster.ImgURL);
            if (o is Image) { pbMonster.Image = o as Image; }
            else { pbMonster.Image = Properties.Resources.BreadMage2; }
            pbMonster.Show();


            //Set Bars, just in case, reset the monster HP to full
            myMonster.HP = myMonster.HPmax;
            pbMonHP.Maximum = myMonster.HPmax;
            pbMonHP.Value = myMonster.HP;

            //set the interface
            SetSpellUI();
        }

        private void SetSpellUI()
        {
            List<clsSpell> MageSpells = myGameScr.gMage.EQSpells();
            List<clsSpell> ItemSpells = myGameScr.GetItemSpells();
            //List<int> UnlockedItems = myGameScr.gMage.ItemSpells();

            lstSpellBook.DataSource = MageSpells;
            lstSpellBook.DisplayMember = "SpellName";
            foreach (clsSpell s in ItemSpells)
            {
                if (myGameScr.gMage.AllSpells().Contains(s.spellID))
                {
                    lstItem.Items.Add(s);
                }
            }
            lstItem.DisplayMember = "spellName";


            /*
            List<int> UIList = myGameScr.gMage.GetMageSpellIDs();

            foreach (clsSpell s in myGameScr.gSpellBook)
            {
                foreach (int i in UIList)
                {
                    if (s.spellID == i)
                    {
                        activeSpells.Add(s);
                        ///spelltype 999 are item spells
                        if (s.spellType == 999) { lstItem.Items.Add(s.spellName); }
                        else { lstSpellBook.Items.Add(s.spellName); }
                    }
                }
            }
            */
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

            ///new lines should ALWAYS end WITHOUT a new line!

            txtChatter.AppendText(Environment.NewLine + newText);
            txtChatter.ScrollBars = ScrollBars.Vertical;

            if (c == Color.Lime) { c = Color.CornflowerBlue; }
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
            //get a list of available chatters for this type and pick one
            List<BattleChatter> FullChatter = new List<BattleChatter>();
            List<BattleChatter> ChatterRoll = new List<BattleChatter>();
            FullChatter.AddRange(myGameScr.gMonster.ChatterList);
            FullChatter.AddRange(myGameScr.gChatBot.ChatterList);
            foreach (BattleChatter b in FullChatter)
            {
                if (b.iType == aType) { ChatterRoll.Add(b); }
            }
            int i = myGameScr.gRandom.Next(ChatterRoll.Count - 1);
            BattleChatter someChatter = ChatterRoll[i];

            //prepare if for appending
            string newText = "";
            if (someChatter.NewLineFlag) { newText += Environment.NewLine; }


            if (someChatter.IsDamageless())
            {
                string t = "";
                switch (someChatter.iType)
                {
                    case 3: //miss
                        break;
                    case 4: //defend
                        t = " (DEFENDEDEDED!)";
                        break;
                    case 8: //stun
                        t = " (STUNNED!)";
                        break;
                }

                rtbChatter.SelectionColor = Color.White;
                newText += someChatter.ChatText;
                rtbChatter.AppendText(newText);
                if (t != "")
                {
                    rtbChatter.SelectionColor = someChatter.ChatColor;
                    rtbChatter.AppendText(t);
                }
            }
            else if (someChatter.sPostDmgText != null && someChatter.sPostDmgText != "")
            {

                newText += someChatter.sPreDmgText;
                rtbChatter.SelectionColor = Color.White;
                rtbChatter.AppendText(newText);

                newText = " " + aDamage.ToString() + " damage ";
                rtbChatter.SelectionColor = someChatter.ChatColor;
                rtbChatter.AppendText(newText);

                newText = someChatter.sPostDmgText;
                rtbChatter.SelectionColor = Color.White;
                rtbChatter.AppendText(newText);
            }
            else
            {
                newText += someChatter.ChatText;
                rtbChatter.SelectionColor = Color.White;
                rtbChatter.AppendText(newText);

                newText = " " + aDamage.ToString() + " damage!";
                rtbChatter.SelectionColor = someChatter.ChatColor;
                rtbChatter.AppendText(newText);
            }


            /*
            List<string> ChatterRoll = new List<string>();
            switch (aType)
            {
                case 1:
                    ChatterRoll.AddRange(myMonster.PAKChatterList);
                    ChatterRoll.AddRange(myGameScr.gChatBot.PAKChatterList);
                    break;
                case 2:
                    ChatterRoll.AddRange(myMonster.MAKChatterList);
                    ChatterRoll.AddRange(myChatterBox.MAKChatterList);
                    break;
                case 3:
                    ChatterRoll.AddRange(myMonster.MISChatterList);
                    ChatterRoll.AddRange(myChatterBox.MISChatterList);
                    break;
                case 4:
                    ChatterRoll.AddRange(myMonster.DEFChatterList);
                    ChatterRoll.AddRange(myChatterBox.DEFChatterList);
                    break;
                case 5:
                    ChatterRoll.AddRange(myMonster.EAKChatterList);
                    ChatterRoll.AddRange(myChatterBox.EAKChatterList);
                    break;
                default:
                    /*
                    ChatterRoll.AddRange(myMonster.PAKChatterList);
                    ChatterRoll.AddRange(myGameScr.gChatBot.PAKChatterList);
                    break;



                    int i = myGameScr.gRandom.Next(ChatterRoll.Count - 1);
            AddBattleChatter(ChatterRoll[i], aDamage);
            string s = ChatterRoll[i].ToString() + " " + aDamage.ToString() + " damage!";
            AddChatter(s);
                    */
        }
      

        private void btnAttack_Click(object sender, EventArgs e)
        {
            BattleEngine.MageAttack(1);
        }

        private void btnMAtk_Click(object sender, EventArgs e)
        {
            BattleEngine.MageAttack(2);
        }

        private void btnDef_Click(object sender, EventArgs e)
        {
            BattleEngine.MonsterAttack(5);
        }

        private void btnSpell_Click(object sender, EventArgs e)
        {
            int tier = 1;
            //when implemented, grab the highest spell tier known
            //if (cbxMaxSpellTier.Checked) { tier = max tier(); }
            BattleEngine.MageSpell(lstSpellBook.SelectedItem.ToString(), tier);
        }

        private void lstSpellBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbSpellBox.ResetText();
            string t = lstSpellBook.SelectedItem.ToString();
            foreach (clsSpell s in activeSpells)
            {
                if (s.spellName == t)
                {
                    string spellInfo = s.spellName + " Cost: " + Environment.NewLine + Environment.NewLine + s.spellDescription;
                    rtbSpellBox.AppendText(spellInfo);
                    break;
                }
            }
        }
    }
}
