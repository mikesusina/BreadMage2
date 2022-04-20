using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadMage2.Controls;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;

namespace BreadMage2
{
    public class engChoice
    {
        private engGame myGame;
        public ChoiceBoard bChoice => myGame.bChoice;
        public clsChoiceAdventure cChoice => myGame.gChoice;
        public List<string> lResultData { get; set; }
        public List<string> lExtraData { get; set; } = new List<string>();


        public int MonsterIDtoChain { get; set; }

        public bool bFightFlag { get; set; }

        public engChoice(engGame aGame)
        {
            myGame = aGame;
        }

        public void InitializeBoard()
        {
            CheckButtonConditions();
            bChoice.SetInitUI();
        }

        public bool CheckReplacement()
        {
            bool b = false;
            if (cChoice != null)
            {
                foreach (string rItem in cChoice.ReplaceCondition)
                {
                    switch (rItem.Substring(0, 3))
                    {
                        case "ITM": // Item obtained?
                            if (myGame.gMage.GetSaveData().gottenItems.Contains(Convert.ToInt32(rItem.Substring(4)))) { b = true; }
                            break;
                        case "LVL": //Level requirement

                            break;
                        case "FLG": // Game flag check
                                    //sGame.gMage.myGameFlags.CheckWhatever()
                        case "DAY": //only having adventures during specific times
                            int i =  myGame.gMage.myGameFlags.DayTracker;
                            switch (rItem.Substring(4).ToLower())
                            {
                                case "morning":
                                    if (i <= 10) { b = true; }
                                    break;
                                case "night":
                                    if (i > 10) { b = true; }
                                    break;
                            }
                            break;
                        case "MTD": //custom scripts - needs updating for checking true/false?
                            //RunMethod(s.Substring(4));
                            break;
                        default:
                            break;

                } 
                }
            }
            return b;
        }

        public void ResolveChoice(int iChoice)
        {
            // result info is already stored in lists as tagged items ("XXX=Foo")



            // FLV=X is the flavor text. Just add to text box
            //if MON=X, start a fight with monsterID
            //if ITM=X, gain item ID (possibly work in multiples if needed?)
            //if ADV=X, start next choice adventure - mark bFlag true and handle
            // MTD=X
            //more stuff: add money(YST), exp, status effects(STF)
            // take result text and overwrite text box - "chain" adventures should NOT contain result flavor text, next adv text box will deal
            //
            // ***currently plan is ADV= tags should not be mixed with other tags, and contain no flavor text, as it's on the next adventure
            //      [can trigger increments or stats? just MAKE SURE IT'S MENTIONED CLEARLY IN THE NEXT TEXT]
            //
            //
            // ***IS THIS DOABLE? make like a "MHD=Meow" result type, and have it run choiceboard.meow() (or choice engine, if I go that route)
            // this would allow for a lot more unique, specific, and involved results than spitting out text and giving items
            //

            string flavorText = "";
            int advID = 0;
            bool bChainFlag = false;
            bool bFreshText = true;
            bFightFlag = false;

            lResultData = cChoice.GetResults(cChoice.AdventureResults.Find(x => x.SlotID == iChoice), RareRoll());

            foreach (string s in lResultData)
            {
                //decode action tag "XYZ="
                switch (s.Substring(0, 3))
                {
                    case "FLV": // flavor text - pass this raw text to the text manipulator, then to the choice adventure textbox
                        if (bFreshText == false) { flavorText += Environment.NewLine; } 
                        flavorText += s.Substring(4);
                        if (bFreshText) { bFreshText = false; }
                        break;
                    case "ADV": // chain to another choice adventure - int value is the choice ID
                        bChainFlag = true;
                        advID = Convert.ToInt32(s.Substring(4));
                        break;
                    case "MON": // queue up a monster to fight - int value is the monsterID
                        bFightFlag = true;
                        MonsterIDtoChain = Convert.ToInt32(s.Substring(4));
                        break;
                    case "ITM": // grant item - int value is the master item list ID
                        clsUniqueItem anItem = myGame.GetUniqueItem(Convert.ToInt32(s.Substring(4)));
                        myGame.GrantUniqueItem(anItem);
                        string t = "You got a " + anItem.ItemName;
                        myGame.gLog.Add(t);
                        break;
                    case "EQP": //grant equipment **does this need to be done through ITM?
                        break;
                    case "EXP": // exp, unimplemented
                        break;
                    case "YST": // yeast, unimplemented
                        break;
                    case "RHP": // restore HP
                        break;
                    case "BUF": // grant buff
                        break;
                    case "MTD": //custom scripts. open subgames through this
                        RunMethod(s.Substring(4));
                        break;
                    default:
                        break;
                }
            }

            //I can do better than this...
            if (lExtraData != null && lExtraData.Count > 0)
            {
                foreach (string s in lExtraData)
                {
                    //decode action tag "XYZ="
                    switch (s.Substring(0, 3))
                    {
                        case "FLV": // flavor text - pass this raw text to the text manipulator, then to the choice adventure textbox
                            if (bFreshText == false) { flavorText += Environment.NewLine; }
                            flavorText += s.Substring(4);
                            if (bFreshText) { bFreshText = false; }
                            break;
                        case "ADV": // chain to another choice adventure - int value is the choice ID
                            bChainFlag = true;
                            advID = Convert.ToInt32(s.Substring(4));
                            break;
                        case "MON": // queue up a monster to fight - int value is the monsterID
                            bFightFlag = true;
                            MonsterIDtoChain = Convert.ToInt32(s.Substring(4));
                            break;
                        case "ITM": // grant item - int value is the master item list ID
                            clsUniqueItem anItem = myGame.GetUniqueItem(Convert.ToInt32(s.Substring(4)));
                            myGame.GrantUniqueItem(anItem);
                            string t = "You got a " + anItem.ItemName;
                            myGame.gLog.Add(t);
                            break;
                        case "EQP": //grant equipment **does this need to be done through ITM?
                            break;
                        case "EXP": // exp, unimplemented
                            break;
                        case "YST": // yeast, unimplemented
                            break;
                        case "RHP": // restore HP
                            break;
                        case "BUF": // grant buff
                            break;
                        case "MTD": //custom scripts. open subgames through this
                            RunMethod(s.Substring(4));
                            break;
                        default:
                            break;
                    }
                }
            }

            // after decoding, decide: if chain, refresh immediately with new adventure
            // if combat, throw up flavor text and wait for close button, which generates the fight board
            // otherwise return to idle/wander
            if (bChainFlag == true)
            {
                // if it chains, no need to wait for window close - refresh that info now
                myGame.BeginChoiceEncounter(advID);
            }
            else 
            {
                if (flavorText != "")
                {
                    bChoice.SetText(flavorText);
                }
                bChoice.SetCloseButton(); 
            }
        }

        private bool RareRoll()
        {
            bool b = false;
            if (myGame.gRandom.Next(1, 11) == 10) { b = true; }
            return b;
        }

        private void AddExtraData(string tag, string text)
        {
            string s = tag + "=" + text;
            lExtraData.Add(s);
        }

        public void CheckButtonConditions()
        {
            int i = 3;
            while (i < 5)
            {
                if (cChoice.AdventureResults.Find(x => x.SlotID == i) != null)
                {
                    //Unimplemented, but hook logic to check against stuff here
                    //&& cChoice.AdventureResults.Find(x => x.SlotID == i).ResultCondition != "")
                    cChoice.AdventureResults.Find(x => x.SlotID == i).ConditionMet = true;
                }
                i++;
            }
        }



        public void RunMethod(string s)
        {
            Type t = this.GetType();
            MethodInfo mi = t.GetMethod(s, BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(this, new object[] { });
            Console.WriteLine("Hey we made it");
        }


        private void GatchaRoulette()
        {
            List<int> GatchaPrizes = new List<int> { /* the prioze IDs */ 2, 3 };

            int i = myGame.gRandom.Next(10);
            if (i == 0) { AddExtraData("ITM", "1"); AddExtraData("FLV", "It looks like a bonus one rolled out! Lucky day!"); AddExtraData("ITM", "2"); } /*double prizes*/
            else if (i > 4) { AddExtraData("ITM", "1"); AddExtraData("FLV", "Woah something came down from the tree when you shook it! Look out!"); AddExtraData("MON", "4"); }
            else { AddExtraData("FLV", "Dang, nothing happened"); }
        }

       

    }
}
