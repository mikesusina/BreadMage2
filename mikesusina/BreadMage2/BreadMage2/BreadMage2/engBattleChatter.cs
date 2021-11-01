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
    class engBattleChatter
    {
        public List<MonsterChatter> fullMonsterChatter { get; set; } = new List<MonsterChatter>();
        private GameScreen myGameScr;
        private RichTextBox FightBox;


        public engBattleChatter(GameScreen aGameScreen)
        {
            myGameScr = aGameScreen;
        }

        public void LoadMonsterInfo(clsMonster aMonster)
        {
            fullMonsterChatter.AddRange(aMonster.ChatterList);
            fullMonsterChatter.AddRange(myGameScr.gChatBot.ChatterList);
        }

        public MonsterChatter nextMonsterChatter(int aType)
        {
            try
            {
                List<MonsterChatter> ChatterRoll = fullMonsterChatter.FindAll(x => x.iType == aType);
                int i = myGameScr.gRandom.Next(ChatterRoll.Count - 1);
                return ChatterRoll[i];
            }
            catch
            {
                throw new IndexOutOfRangeException("No chatter list found");
            }
            
        }

        public EffectChatter nextEffectReactChatter(string aType)
        {
            List<EffectChatter> ChatterRoll = myGameScr.GameLibraries.EffectChatterLib().FindAll(x => x.EffType == aType);

            try
            {
                if (myGameScr.bFight.GetTurn() == "Mage")
                {
                    ChatterRoll.RemoveAll(x => x.SpeakerType == 2);
                }
                else { ChatterRoll.RemoveAll(x => x.SpeakerType == 1); }

                int i = myGameScr.gRandom.Next(ChatterRoll.Count - 1);
                return ChatterRoll[i];
            }
            catch
            {
                throw new IndexOutOfRangeException("No Effect chatter list found");
            }
        }

       public MonsterChatter nextIntroChatter(int iType = 1)
        {
            //type 1 is for the identification text, 2 is losing initiative
            //I don't see too many of these being written, or needing custom ones so just build this here
            string s = "";
            if (iType == 1)
            {
                List<string> CommonRoll = new List<string> { "Look out, it's a $!", "Heads up! A $!", "Analysis: $ , mad as heck"
                                                                , "You're fighting a $!", "Here comes a $!", "$! It's go time!", "Sights set on $"
                                                                , "A $ approaches!"};
                List<string> RareRoll = new List<string> { "Hark! A $ over yonder wants to fight!", "Alart! $ spotted, ready weapon systems!"
                                                                , "This $ is crusin' for a bruisin'", "A $ approachesthes!" };
                if (myGameScr.gRandom.Next(21) > 15) { s = RareRoll.ElementAt(myGameScr.gRandom.Next(RareRoll.Count - 1)); }
                else { s = CommonRoll.ElementAt(myGameScr.gRandom.Next(CommonRoll.Count - 1)); }
            }
            else
            {
                List<string> CommonRoll = new List<string> { "It gets the jump!", "Drat! Where'd that come from?", "Olive loaf! You're caught surprised!"
                                                                , "Corncobs! It's a sneak attack!"};
                List<string> RareRoll = new List<string> { "$ rushes in!", "Beans! It got you good!", "Jumpscare! You're fighting now!", "No fair, it cheated, you're sure of it!"
                                                                , "Get those eyes checked, you walked into a fight!"};
                if (myGameScr.gRandom.Next(21) > 15) { s = RareRoll.ElementAt(myGameScr.gRandom.Next(RareRoll.Count - 1)); }
                else { s = CommonRoll.ElementAt(myGameScr.gRandom.Next(CommonRoll.Count - 1)); }
            }
            return new MonsterChatter(s);
        }






        public void AddChatter(clsChatterText someChatter)
        {
            string sFlavor = "";
            string sInfoType = "";
            bool NewLine = true;
            if (FightBox is null) { FightBox = myGameScr.bFight.Controls["rtbChatter"] as RichTextBox;  }


            Color chatColor = Color.White;
            if (someChatter is MonsterChatter)
            {
                MonsterChatter b = someChatter as MonsterChatter;
                sFlavor = b.ChatText;
                chatColor = b.ChatColor;
                sInfoType = b.getMChatTypeInfo();

            }
            else if (someChatter is SpellChatter)
            {
                SpellChatter b = someChatter as SpellChatter;
                sFlavor = b.ChatText;
                chatColor = b.ChatColor;
                sInfoType = b.getSChatTypeInfo();

            }
            else if (someChatter is EffectChatter)
            {
                EffectChatter b = someChatter as EffectChatter;
                sFlavor = b.ChatText;
                chatColor = b.ChatColor;
                sInfoType = b.getEChatTypeInfo();
            }
            else if (someChatter is DamageInfoChatter)
            {
                int iStart = FightBox.TextLength;
                string sText = "";
                Font OrigFont = FightBox.Font;
                Font infoFont = new Font("Trebuchet MS", 8, FontStyle.Regular);
                DamageInfoChatter b = someChatter as DamageInfoChatter;
                chatColor = b.GetColor(b.effType);

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
                    /*
                    FightBox.SelectionStart = FightBox.GetFirstCharIndexOfCurrentLine();
                    FightBox.SelectionLength = FightBox.Lines[FightBox.Lines.Length -1 ].Length;
                    FightBox.SelectionFont = new Font("Viner Hand ITC", 8);
                    FightBox.Font = new Font("Trebuchet MS", 10);
                    */
                    return;
                }
            }


            FightBox.SelectionColor = Color.White;


            string[] TickEffects = new string[] { "Mold", "Zest", "Tension" };
            string[] NoValEffects = new string[] { "Miss", "Block", "Parry", "Stun" };

            FightBox.AppendText(Environment.NewLine + Environment.NewLine + sFlavor);

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
                FightBox.SelectionColor = Color.White;
                if (iType == 2)
                {
                    MonsterChatter jumpText = nextIntroChatter(2);
                    jumpText.ChatText = jumpText.ChatText.Replace("$", myGameScr.gMonster.MonName);
                    MessageBox.Show(jumpText.ChatText);
                }
                MonsterChatter introText = nextIntroChatter(1);
                introText.ChatText = introText.ChatText.Replace("$", myGameScr.gMonster.MonName);
                introText.ChatText += Environment.NewLine + myGameScr.bFight.GetMonster().IntroChatter;
                if (iType == 2) { introText.ChatText += "... and it gets a free hit!";  }
                FightBox.AppendText(introText.ChatText);
            }
            catch
            {
                throw new Exception("Something happened generating the battle intro text");
            }
        }

        public void AddTurnChatter()
        {
            FightBox.SelectionColor = Color.White;
            Font OrigFont = FightBox.Font;
            int iStart = FightBox.TextLength;
            string sText = "'s turn:";
            switch (myGameScr.bFight.GetTurn())
            {
                case "Mage":
                    sText = myGameScr.gMage.GetMageName() + sText;
                    break;
                case "Monster":
                    sText = myGameScr.gMonster.MonName + sText;
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
