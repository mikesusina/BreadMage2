using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadMage2.Controls;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace BreadMage2
{
    public class engBattleChatter
    {
        public List<MonsterChatter> fullMonsterChatter { get; set; } = new List<MonsterChatter>();
        private engGame myGame;
        public RichTextBox FightBox;
        public List<clsChatterText> infoQueue = new List<clsChatterText>();
        public int QueueTracker = 1;
        bool AddTurnInfo = false;

        public engBattleChatter(engGame aGame)
        {
            myGame = aGame;
        }

        public void ClearQueue()
        {
            infoQueue.Clear();
            QueueTracker = 1;
        }
        public void AddChatItemToQueue(clsChatterText someChatter, string aSpeaker)
        {
            someChatter.speaker = aSpeaker;
            if (myGame.BattleEngine.newTurn)
            {
                //enable the turn label indicator for this item
                myGame.BattleEngine.newTurn = false;
            }
            someChatter.iSlot = QueueTracker;
            infoQueue.Add(someChatter);
            QueueTracker++;
        }
        public string getEffectNamefromCode(string sCode = "N")
        {
            switch (sCode.ToLower())
            {
                case "M":
                    return "mold";
                case "Z":
                    return "zest";
                case "T":
                    return "tension";
                case "H":
                    return "charge";
                case "B":
                    return "block";
                case "S":
                    return "stun";
                case "L":
                    return "silence";
            }
            return "";
        }

        public void LoadMonsterInfo(clsMonster aMonster)
        {
            fullMonsterChatter.AddRange(aMonster.ChatterList);
            fullMonsterChatter.AddRange(myGame.gChatBot.ChatterList);
        }

        public string GetNextMonsterChatter(string aType)
        {
            //eventually - add a monster "type" and have generics?
            try
            {
                List<MonsterChatter> ChatterRoll = fullMonsterChatter.FindAll(x => x.chatType == aType);
                if (ChatterRoll.Count > 0)
                {
                    int i = myGame.gRandom.Next(ChatterRoll.Count - 1);
                    return ChatterRoll[i].ChatText;
                }
                return "";
            }
            catch
            {
                throw new IndexOutOfRangeException("No chatter list found");
            }

        }
        public void nextMonsterChatter(string aType)
        {
            //eventually - add a monster "type" and have generics?
            try
            {
                List<MonsterChatter> ChatterRoll = fullMonsterChatter.FindAll(x => x.chatType == aType);
                if (ChatterRoll.Count > 0)
                {
                    int i = myGame.gRandom.Next(ChatterRoll.Count - 1);
                    AddChatter(ChatterRoll[i]); 
                }
            }
            catch
            {
                throw new IndexOutOfRangeException("No chatter list found");
            }
            
        }
        public string GetNextMageChatter(string aType)
        //public void nextMageChatter(string aType, string anElement = "none")
        {
            try
            {
                //eventually - change magechatter to use weaponchatter class, based on p vs m/weapon type/element alignment
                //p atk - weapon type (crushing, poking, shooting, etc...), plus element if weapon is aligned?
                //m atk button : magic type (and add override with elemental passives?)
                //defend: ??
                //List<WeaponChatter> ChatterRoll = myGame.GameLibraries.WeaponChatter.FindAll(x => x.iType == aType);


                List<MonsterChatter> ChatterRoll = myGame.gMageChatBot.ChatterList.FindAll(x => x.chatType == aType);
                int i = myGame.gRandom.Next(ChatterRoll.Count - 1);
                return ChatterRoll[i].ChatText;
            }
            catch
            {
                throw new IndexOutOfRangeException("No chatter list found");
            }

        }
        public void nextMageChatter(string aType)
        //public void nextMageChatter(string aType, string anElement = "none")
        {
            try
            {
                //eventually - change magechatter to use weaponchatter class, based on p vs m/weapon type/element alignment
                //p atk - weapon type (crushing, poking, shooting, etc...), plus element if weapon is aligned?
                //m atk button : magic type (and add override with elemental passives?)
                //defend: ??
                //List<WeaponChatter> ChatterRoll = myGame.GameLibraries.WeaponChatter.FindAll(x => x.iType == aType);
                

                List<MonsterChatter> ChatterRoll = myGame.gMageChatBot.ChatterList.FindAll(x => x.chatType == aType);
                int i = myGame.gRandom.Next(ChatterRoll.Count - 1);
                AddChatter(ChatterRoll[i]);
            }
            catch
            {
                throw new IndexOutOfRangeException("No chatter list found");
            }
            
        }


        public string GetNextEffectReactChatter(string aType)
        {
            List<EffectChatter> ChatterRoll = myGame.GameLibraries.EffectChatterLib().FindAll(x => x.EffType == aType);

            try
            {
                if (myGame.BattleEngine.GetTurn() == "Mage")
                {
                    ChatterRoll.RemoveAll(x => x.SpeakerType == 2);
                }
                else { ChatterRoll.RemoveAll(x => x.SpeakerType == 1); }

                int i = myGame.gRandom.Next(ChatterRoll.Count - 1);
                return ChatterRoll[i].ChatText;
            }
            catch
            {
                throw new IndexOutOfRangeException("No Effect chatter list found");
            }
        }

        public void nextEffectReactChatter(string aType)
        {
            List<EffectChatter> ChatterRoll = myGame.GameLibraries.EffectChatterLib().FindAll(x => x.EffType == aType);

            try
            {
                if (myGame.BattleEngine.GetTurn() == "Mage")
                {
                    ChatterRoll.RemoveAll(x => x.SpeakerType == 2);
                }
                else { ChatterRoll.RemoveAll(x => x.SpeakerType == 1); }

                int i = myGame.gRandom.Next(ChatterRoll.Count - 1);
                AddChatter(ChatterRoll[i]);
            }
            catch
            {
                throw new IndexOutOfRangeException("No Effect chatter list found");
            }
        }

        public string GetNextSpellChatter(clsSpell aSpell)
        {
            List<SpellChatter> ChatterRoll = new List<SpellChatter>();
            List<SpellChatter> AllChatter = new List<SpellChatter>();
            clsSpell s = aSpell;
            ChatterRoll.AddRange(s.SpellChatter);
            AllChatter = myGame.GameLibraries.SpellChatterLib().FindAll(x => x.SpellType != "I");

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

            int i = myGame.gRandom.Next(ChatterRoll.Count);
            return ChatterRoll[i].ChatText;
        }

        public void nextSpellChatter(clsSpell aSpell)
        {
            List<SpellChatter> ChatterRoll = new List<SpellChatter>();
            List<SpellChatter> AllChatter = new List<SpellChatter>();
            clsSpell s = aSpell;
            ChatterRoll.AddRange(s.SpellChatter);
            AllChatter = myGame.GameLibraries.SpellChatterLib().FindAll(x => x.SpellType != "I");

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

            int i = myGame.gRandom.Next(ChatterRoll.Count);
            AddChatter(ChatterRoll[i]);
        }

       public MonsterChatter nextIntroChatter(int iType = 1)
        {
            //type 1 is for the identification text, 2 is losing initiative
            //I don't see too many of these being written, or needing custom ones so just build this here
            string s = "";
            if (iType == 1)
            {
                List<string> CommonRoll = new List<string> { "Look out, it's a $!", "Heads up! A $!", "Analysis: $, mad as heck"
                                                                , "You're fighting a $!", "Here comes a $!", "$! It's go time!", "Sights set on $"
                                                                , "A $ approaches!"};
                List<string> RareRoll = new List<string> { "Hark! A $ over yonder wants to fight!", "Alart! $ spotted, ready weapon systems!"
                                                                , "This $ is crusin' for a bruisin'", "A $ approachesthes!" };
                if (myGame.gRandom.Next(21) > 15) { s = RareRoll.ElementAt(myGame.gRandom.Next(RareRoll.Count - 1)); }
                else { s = CommonRoll.ElementAt(myGame.gRandom.Next(CommonRoll.Count - 1)); }
            }
            else
            {
                List<string> CommonRoll = new List<string> { "It gets the jump!", "Drat! Where'd that come from?", "Olive loaf! You're caught surprised!"
                                                                , "Corncobs! It's a sneak attack!"};
                List<string> RareRoll = new List<string> { "$ rushes in!", "Beans! It got you good!", "Jumpscare! You're fighting now!", "No fair, it cheated, you're sure of it!"
                                                                , "Get those eyes checked, you walked into a fight!"};
                if (myGame.gRandom.Next(21) > 15) { s = RareRoll.ElementAt(myGame.gRandom.Next(RareRoll.Count - 1)); }
                else { s = CommonRoll.ElementAt(myGame.gRandom.Next(CommonRoll.Count - 1)); }
            }
            return new MonsterChatter(s);
        }

        public void PostChatterQueue()
        {
            if (infoQueue.Count > 0)
            {
                foreach (clsChatterText c in infoQueue)
                {
                    c.pbActionIcon = new PictureBox();
                    c.pbActionIcon.Size = new Size(25, 25);
                    c.pbActionIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                    //c.pbActionIcon.Image = Program.GetImage(c.imgURL);
                    c.rtbActionText = new RichTextBox();
                    c.rtbActionText.BackColor = Color.Black;
                    c.rtbActionText.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    c.rtbActionText.ForeColor = Color.White;
                    c.rtbActionText.ReadOnly = true;
                    c.rtbActionText.MaximumSize = new Size(240, 0);
                    c.rtbActionText.Size = new Size(240, 50);
                    c.rtbActionText.ContentsResized += new ContentsResizedEventHandler(rtb_ContentsResized);

                    c.rtbActionText.Multiline = true;

                    //c.ActionPanel.Controls.Add(c.pbActionIcon);
                    //c.ActionPanel.Controls.Add(c.rtbActionText);
                    AddChatterNew(c);
                }
            }
        }


        public void AddChatterNew(clsChatterText someChatter)
        {
            string sText = "";
            someChatter.rtbActionText.SelectionColor = Color.White;
            someChatter.ActionPanel = new Panel();

            someChatter.pbActionIcon.Image = Properties.Resources.bomb;
            if (someChatter.speaker == "mage")
            {
                someChatter.pbActionIcon.Location = new Point(2, 2);
                someChatter.rtbActionText.Location = new Point(2, 27);
            }
            else
            {
                someChatter.pbActionIcon.Location = new Point(222, 2);
                someChatter.rtbActionText.Location = new Point(2, 27);
            }


            someChatter.rtbActionText.AppendText(someChatter.ChatText);
            if (someChatter.iDamage != 0 || someChatter.iTick != 0)
            {
                sText = "(";
                int iStart = someChatter.rtbActionText.TextLength;
                Font OrigFont = new Font("Trebuchet MS", 10, FontStyle.Regular);
                Font infoFont = new Font("Trebuchet MS", 8, FontStyle.Regular);
                someChatter.rtbActionText.AppendText(Environment.NewLine + "(");
                someChatter.rtbActionText.SelectionColor = someChatter.GetColor();
                if (someChatter.GetValueChatter().Length > 0)
                {
                    someChatter.rtbActionText.AppendText(someChatter.GetValueChatter());
                    sText += someChatter.GetValueChatter();
                    if (someChatter.GetTickChatter().Length > 0)
                    {
                        someChatter.rtbActionText.SelectionColor = Color.White;
                        someChatter.rtbActionText.AppendText(", ");
                        sText += ", ";
                    }
                }
                if (someChatter.GetTickChatter().Length > 0)
                {
                    someChatter.rtbActionText.AppendText(someChatter.GetTickChatter());
                    sText += someChatter.GetTickChatter();
                }
                someChatter.rtbActionText.SelectionColor = Color.White;
                someChatter.rtbActionText.AppendText(")");
                sText += ")";

                someChatter.rtbActionText.Find(sText, RichTextBoxFinds.Reverse);
                someChatter.rtbActionText.SelectionStart = iStart + 1;
                someChatter.rtbActionText.SelectionFont = infoFont;
                someChatter.rtbActionText.SelectionStart = someChatter.rtbActionText.TextLength;
                someChatter.rtbActionText.SelectionFont = OrigFont;
                someChatter.rtbActionText.DeselectAll();


            }
                        
            someChatter.ActionPanel.Controls.Add(someChatter.rtbActionText);
            someChatter.ActionPanel.Controls.Add(someChatter.pbActionIcon);

            someChatter.ActionPanel.Size = new Size(250, 35 + someChatter.rtbActionText.Height);




            myGame.gGS.Controls["pMidBar"].Controls.Add(someChatter.ActionPanel);
            if (someChatter.iSlot > 1)
            { 
                someChatter.ActionPanel.Location = new Point(0, infoQueue.Find(x=> x.iSlot == someChatter.iSlot- 1).ActionPanel.Location.Y + infoQueue.Find(x => x.iSlot == someChatter.iSlot - 1).ActionPanel.Height);
            }
            someChatter.ActionPanel.Show();
            someChatter.pbActionIcon.Show();
            someChatter.rtbActionText.Show();
        }

        private void rtb_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            ((RichTextBox)sender).Height = e.NewRectangle.Height + 5;
        }

        public void AddChatter(clsChatterText someChatter)
        {


            /*
            string sFlavor = "";
            bool NewLine = true;
            if (FightBox is null) { FightBox = myGame.bFight.Controls["rtbChatter"] as RichTextBox;  }


            Color chatColor = Color.White;
            if (someChatter is MonsterChatter)
            {
                MonsterChatter b = someChatter as MonsterChatter;
                sFlavor = b.ChatText;
                chatColor = b.ChatColor;

            }
            else if (someChatter is SpellChatter)
            {
                SpellChatter b = someChatter as SpellChatter;
                sFlavor = b.ChatText;
                chatColor = b.ChatColor;

            }
            else if (someChatter is EffectChatter)
            {
                EffectChatter b = someChatter as EffectChatter;
                sFlavor = b.ChatText;
                chatColor = b.ChatColor;
            }
            else if (someChatter is WeaponChatter)
            {
                WeaponChatter b = someChatter as WeaponChatter;
                
            }
            else if (someChatter is DamageInfoChatter)
            {
                int iStart = FightBox.TextLength;
                string sText = "";
                Font OrigFont = new Font("Trebuchet MS", 10, FontStyle.Regular);
                Font infoFont = new Font("Trebuchet MS", 8, FontStyle.Regular);
                DamageInfoChatter b = someChatter as DamageInfoChatter;
                chatColor = b.GetColor(b.chatType);

                if (b.GetValueChatter().Length > 0 || b.GetTickChatter().Length > 0)
                {
                    FightBox.SelectionColor = Color.White;
                    FightBox.AppendText(Environment.NewLine + "(");
                    sText += "(";
                    if (b.GetValueChatter().Length > 0)
                    {
                        if (b.GetDamageType() == "R") { FightBox.SelectionColor = chatColor; }
                        else if (b.GetDamageType() == "P") { FightBox.SelectionColor = Color.Red; }
                        else if (b.GetDamageType() == "M") { FightBox.SelectionColor = Color.DeepSkyBlue; }
                        FightBox.AppendText(b.GetValueChatter());
                        sText += b.GetValueChatter();
                        if (b.GetTickChatter().Length > 0)
                        {
                            FightBox.SelectionColor = Color.White;
                            FightBox.AppendText(", ");
                            sText += ", ";
                        }
                    }
                    if (b.GetTickChatter().Length > 0)
                    {
                        FightBox.SelectionColor = chatColor;
                        FightBox.AppendText(b.GetTickChatter());
                        sText += b.GetTickChatter();
                    }
                    FightBox.SelectionColor = Color.White;
                    FightBox.AppendText(")");
                    sText += ")";

                    FightBox.Find(sText, RichTextBoxFinds.Reverse);
                    FightBox.SelectionStart = iStart + 1;
                    FightBox.SelectionFont = infoFont;
                    FightBox.SelectionStart = FightBox.TextLength;
                    FightBox.SelectionFont = OrigFont;
                    FightBox.DeselectAll();
                    FightBox.AppendText(Environment.NewLine);
                    
                    //FightBox.SelectionStart = FightBox.GetFirstCharIndexOfCurrentLine();
                    //FightBox.SelectionLength = FightBox.Lines[FightBox.Lines.Length -1 ].Length;
                    //FightBox.SelectionFont = new Font("Viner Hand ITC", 8);
                    //FightBox.Font = new Font("Trebuchet MS", 10);
                    return;
                }
            }

                */

            //FightBox.SelectionColor = Color.White;


            //string[] TickEffects = new string[] { "Mold", "Zest", "Tension" };
            //string[] NoValEffects = new string[] { "Miss", "Block", "Parry", "Stun" };

            //FightBox.AppendText(Environment.NewLine + sFlavor);

            ///
            // Add the flavor text first, in white
            // second line conveys information: 
            // ( X damage/healed/restored, +/-Y ticks Z element)
            /*
            FightBox.SelectionColor = chatColor;
            FightBox.AppendText(Environment.NewLine + lineTwo);
            FightBox.SelectionColor = Color.White;

            FightBox.SelectionColor = c;
            FightBox.AppendText(Environment.NewLine + newText);
            */

        }

        public void AddIntroChatter(int iType = 1)
        {
            try
            {
                FightBox.Clear();
                FightBox.SelectionColor = Color.White;
                if (iType == 2)
                {
                    MonsterChatter jumpText = nextIntroChatter(2);
                    jumpText.ChatText = jumpText.ChatText.Replace("$", myGame.gMonster.MonName);
                    MessageBox.Show(jumpText.ChatText);
                }
                MonsterChatter introText = nextIntroChatter(1);
                introText.ChatText = introText.ChatText.Replace("$", myGame.gMonster.MonName);
                introText.ChatText += Environment.NewLine + Environment.NewLine + myGame.gMonster.IntroChatter;
                //if (iType == 2) { introText.ChatText += "... and it gets a free hit!";  }
                FightBox.AppendText(introText.ChatText);
            }
            catch
            {
                throw new Exception("Something happened generating the battle intro text");
            }
        }

        public void AddTurnChatter()
        {

            FightBox.SelectionColor = Color.Lime;
            Font OrigFont = FightBox.Font;
            int iStart = FightBox.TextLength;
            string sText = "'s turn:";
            switch (myGame.BattleEngine.GetTurn())
            {
                case "Mage":
                    sText = myGame.gMage.GetMageName() + sText;
                    break;
                case "Monster":
                    sText = myGame.gMonster.MonName + sText;
                    break;
            }
            FightBox.AppendText(Environment.NewLine + sText);
            Font infoFont = new Font("Trebuchet MS", 8, FontStyle.Regular);

            FightBox.Find(sText, RichTextBoxFinds.Reverse);
            FightBox.SelectionStart = iStart + 1;
            FightBox.SelectionFont = infoFont;
            FightBox.SelectionStart = FightBox.TextLength;
            FightBox.SelectionFont = OrigFont;
            FightBox.DeselectAll();
        }

        public void SetChatBox(RichTextBox aBox)
        {
            FightBox = aBox;
        }
    }
}
