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
        private engBattleChatter ChatEngine;
        public GameScreen myGameScr { get; set; }

        private Color c;
        private List<clsSpell> activeSpells { get; set; } = new List<clsSpell>();
        


        public FightBoard(GameScreen aGameScr, int anID = 0)
        {
            InitializeComponent();
            myGameScr = aGameScr;
            BreadDB BreadNet = new BreadDB();
            ChatEngine = new engBattleChatter(myGameScr);


            c = new Color();
            c = Color.Lime;

            // if the local full monster set is empty load it
            if (myGameScr.GameLibraries.MonsterLib() is null || myGameScr.GameLibraries.MonsterLib().Count == 0)
            {
                myGameScr.GameLibraries.SetMonsterLib(BreadNet.LoadMonsterList());
            }

            if (anID != 0 && myGameScr.GameLibraries.MonsterLib().Exists(x => x.monID == anID))
            {
                myMonster = myGameScr.GameLibraries.MonsterLib().Find(x => x.monID == anID).ShallowCopy();
            }
            else if (myGameScr.GameLibraries.MonsterLib().FindIndex(x => x.Location == myGameScr.gMage.Location) >= 0)
            {
                //Get list of local monsters
                List<clsMonster> locMonsters = myGameScr.GameLibraries.MonsterLib().FindAll(x => x.Location == myGameScr.gMage.Location);
                //possible work in to make more common or less common encounters? maybe roll a d20 or something and make rare flag on 20?
                myMonster = locMonsters.ElementAt(myGameScr.gRandom.Next(0, (locMonsters.Count))).ShallowCopy();
                myGameScr.gMonster = myMonster;
            }

            if (myMonster != null)
            {
                myMonster.RefreshMonster();
                myGameScr.gMonster = myMonster;
                myGameScr.bFight = this;
                ChatEngine.LoadMonsterInfo(myMonster);
                preloadFight();
            }
            else { throw new ArgumentNullException("no monster found at the board"); }

        }

        private void preloadFight()
        {
            //create the battle engine
            BattleEngine = new engBattle(myGameScr);
            BattleEngine.LoadFight();
            //remember to unlock/lock quick spells/items when combat starts and ends

            //load monster image
            // remember to flip boxes for boss fights
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
            lstSpellBook.DisplayMember = "spellName";
            foreach (clsSpell s in ItemSpells)
            {
                if (myGameScr.gMage.AllSpells().Contains(s.spellID))
                {
                    lstItem.Items.Add(s);
                }
            }
            lstItem.DisplayMember = "spellName";
        }

        public void BeginFight()
        {
            // The turn rolled should be flipped because action starts with chaging sTurn to current attacker
            if (BattleEngine.GetTurn() == "Mage")
            {
                ChatEngine.AddIntroChatter(2);
                BattleEngine.MonsterAttack();
            }
            else
            {
                ChatEngine.AddIntroChatter(1);
                BattleEngine.MageTurn();
            }
        }


        public clsMonster GetMonster() { try { return BattleEngine.GetMonster(); } catch { throw new ArgumentNullException("No monster loaded in the engine"); } }

        public string GetTurn() { return BattleEngine.GetTurn(); }

        public EffectChatter nextEffectChatter (string aType)
        {
            return ChatEngine.nextEffectReactChatter(aType);
        }
        public MonsterChatter nextMonsterChatter(int aType)
        {
            return ChatEngine.nextMonsterChatter(aType);
        }

        public void UpdateBars(clsMonster aMonster)
        {
            if (pbMonHP.Maximum != aMonster.HPmax) { pbMonHP.Maximum = aMonster.HPmax; }

            string s = "Mold: " + myGameScr.gMonster.MoldCount.ToString();
            lblMoldCounter.Text = s;
            s = "Zest: " + myGameScr.gMonster.ZestCount.ToString();
            lblZestCounter.Text = s;
            s = "Tension: " + myGameScr.gMonster.TensionCount.ToString();
            lblTensionCounter.Text = s;

            if (aMonster.HP > 0) { pbMonHP.Value = aMonster.HP; }
            else { pbMonHP.Value = 0; }
        }


        //chatter stuff. Most of this should move to the engine eventually

        public void SetChatterBox()
        {
            ChatEngine.SetChatBox(Controls["rtbChatter"] as RichTextBox);
        }

        public void AddChatter(clsChatterText someChatter)
        {
            ChatEngine.AddChatter(someChatter);
        }
        public void AddTurnChatter()
        {
            ChatEngine.AddTurnChatter();
        }

        public void AddChatterString(string newText)
        {
            /*
            System.Text.RegularExpressions.Regex e = new System.Text.RegularExpressions.Regex("\b(" + newText + "\b");
            rtbChatter.Select()
            rtbChatter.SelectedText.*/

            ///new lines should ALWAYS end WITHOUT a new line!
            rtbChatter.SelectionColor = c;
            rtbChatter.AppendText(Environment.NewLine + newText);
        }

        public void AddEffectReactChatter(EffectChatter effectChatter, int aDamage, int aType = 1)
        {
            /* this is going to need some treatment, but this will be used for mage-focused effect chatter, monster effect reactions will be something else? */
            //string s = "You quiver with ";

        }

        public void AddEffectReactChatter(EffectChatter someChatter, int aDamage)
        {
            string newText = "";
            /* this is going to need some treatment, but this will be used for mage-focused effect chatter, monster effect reactions will be something else */
            if (someChatter.NewLineFlag) { newText += Environment.NewLine; }

            newText += someChatter.ChatText;
            rtbChatter.SelectionColor = Color.White;
            rtbChatter.AppendText(newText);

            newText = " " + aDamage.ToString() + " damage!";
            rtbChatter.SelectionColor = someChatter.ChatColor;
            rtbChatter.AppendText(newText);

        }

        public void AddMonsterChatter(int aType, int aDamage)
        {
            MonsterChatter someChatter = ChatEngine.nextMonsterChatter(aType);

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
            else
            {
                newText += someChatter.ChatText;
                rtbChatter.SelectionColor = Color.White;
                rtbChatter.AppendText(newText);

                newText = " " + aDamage.ToString() + " damage!";
                rtbChatter.SelectionColor = someChatter.ChatColor;
                rtbChatter.AppendText(newText);
            }
        }

        public void AddSpellChatter(clsSpell aSpell, int someDamage)
        {
            List<SpellChatter> ChatterRoll = new List<SpellChatter>();
            List<SpellChatter> AllChatter = new List<SpellChatter>();
            clsSpell s = aSpell;
            ChatterRoll.AddRange(s.SpellChatter);
            AllChatter = myGameScr.GameLibraries.SpellChatterLib().FindAll(x => x.SpellType != "I");

            String[] Elementals = new string[] { "M", "Z", "T", "D" };
            foreach (string block in s.SpellBlocks)
            {
                List<string> TypeList = new List<string>();
                foreach (string sptypes in Elementals)
                {
                    if (block.IndexOf(sptypes) > 0 && TypeList.Contains(sptypes) == false)
                    {
                        ChatterRoll.AddRange(AllChatter.FindAll(x => x.Element == sptypes));
                        TypeList.Add(sptypes);
                    }
                }
            }

            int i = myGameScr.gRandom.Next(ChatterRoll.Count);
            SpellChatter someChatter = ChatterRoll[i];

            //prepare if for appending
            string newText = "";
            if (someChatter.NewLineFlag) { newText += Environment.NewLine; }

            newText += someChatter.ChatText;
            rtbChatter.SelectionColor = Color.White;
            rtbChatter.AppendText(newText);

            newText = " " + someDamage.ToString() + " damage!";
            rtbChatter.SelectionColor = someChatter.ChatColor;
            rtbChatter.AppendText(newText);
            rtbChatter.SelectionColor = Color.White;
        }

       



        //control actions
      

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
            //when implemented, grab the highest spell tier known
            //if (cbxMaxSpellTier.Checked) { tier = max tier(); }
            //BattleEngine.MageSpell(lstSpellBook.SelectedItem as clsSpell, tier);
            BattleEngine.MageAttack(3);
        }

        private void lstSpellBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbSpellBox.ResetText();
            string t = lstSpellBook.SelectedItem.ToString();
            clsSpell s = lstSpellBook.SelectedItem as clsSpell;
            string info = s.spellName + Environment.NewLine + "Cost: " + Environment.NewLine + Environment.NewLine + s.spellDescription;
            rtbSpellBox.AppendText(info);

            
        }
    }
}
