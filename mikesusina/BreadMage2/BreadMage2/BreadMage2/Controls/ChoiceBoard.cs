using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace BreadMage2.Controls
{
    public partial class ChoiceBoard : UserControl
    {
        public GameScreen sGameScreen { get; set; }
        public clsChoiceAdventure cChoice { get; set; }
        public ChoiceBoard bChoice { get; set; }
        public List<string> lResultData { get; set; }
        public List<string> lExtraData { get; set; }


        private int iMonID { get; set; }

        private bool bFightFlag { get; set; }

        private Button btnChoiceThree { get; set; }
        private Button btnChoiceFour { get; set; }

        /* I think this can go - 
         * 
        public ChoiceBoard(clsChoiceAdventure anAdventure)
        {
            InitializeComponent();

            string sText = TextFixer(anAdventure.AdvText);
            tbChoiceText.Text = sText;

            //load image
            //pbMonster.Image = Properties.Resources.[URL];
            object o = Properties.Resources.ResourceManager.GetObject(anAdventure.ImgURL);
            if (o is Image) { pbChoicePic.Image = o as Image; }
            else { pbChoicePic.Image = Properties.Resources.BreadMage2; }
            pbChoicePic.Show();
        }

        */


        public ChoiceBoard(GameScreen aGS, int anID)
        {
            InitializeComponent();
            sGameScreen = aGS;
            // parse out all relevant data
            // generate any buttons if needed
            // wait for user input

            clsChoiceAdventure anAdventure = aGS.GameLibraries.ChoiceLib().Find(x => x.AdvID == anID);
            if (anAdventure.ReplaceCondition != null && CheckReplacement(anAdventure.ReplaceCondition) == true)
            {
                int replaceID = anAdventure.ReplaceID;
                anAdventure = aGS.GameLibraries.ChoiceLib().Find(x => x.AdvID == replaceID);
            }

            cChoice = anAdventure.ShallowCopy();

            string sText = TextFixer(cChoice.AdvText);
            tbChoiceText.Text = sText;

            //buttons:
            btnChoiceOne.Text = TextFixer(cChoice.Btn1);
            btnChoiceTwo.Text = TextFixer(cChoice.Btn2);


            //TODO: implement conditions, clean up how these are generated (ie if 3 won't exist but 4 will)
            if (cChoice.Btn3 != null && cChoice.Btn3 != "")
            {
                Button aButton = new Button();
                Point p = new Point();
                p.X = btnChoiceOne.Location.X;
                p.Y = btnChoiceTwo.Location.Y + 40;

                aButton.Size = new Size(250, 30);
                aButton.Location = p;
                aButton.Text = TextFixer(cChoice.Btn3);
                aButton.Font = btnChoiceOne.Font;
                btnChoiceThree = aButton;

                this.Controls.Add(btnChoiceThree);
                btnChoiceThree.Click += new EventHandler(BtnThreeClick);
                btnChoiceThree.Show();
            }

            if (cChoice.Btn4 != null && cChoice.Btn4 != "")
            {

                Button aButton = new Button();
                Point p = new Point();

                p.X = btnChoiceOne.Location.X;
                if (btnChoiceThree != null) { p.Y = btnChoiceThree.Location.Y + 40; }
                else { p.Y = btnChoiceTwo.Location.Y + 40; }

                aButton.Size = new Size(250, 30);
                aButton.Location = p;
                aButton.Text = TextFixer(cChoice.Btn4);
                aButton.Font = btnChoiceOne.Font;
                btnChoiceFour = aButton;

                this.Controls.Add(btnChoiceFour);
                btnChoiceFour.Click += new EventHandler(BtnFourClick);
                btnChoiceFour.Show();
            }


            //load image
            object o = Properties.Resources.ResourceManager.GetObject(cChoice.ImgURL);
            if (o is Image) { pbChoicePic.Image = o as Image; }
            else { pbChoicePic.Image = Properties.Resources.BreadMage2; }
            pbChoicePic.Show();

        }

        private void ResolveChoice()
        {
            // go through list of result info
            // stored in database as one long string per button that informs all relevant info
            // string is pipe-delimited, each string has a tag

            //FLV=this is the sample flavor text|MON=3|ITM=4
            //above excample: list should contain 3 strings

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


            int advID = 0;
            bool bChainFlag = false;
            bool bFreshText = true;
            bFightFlag = false;

            if (lExtraData is null) { lExtraData = new List<string>(); }
            else { lExtraData.Clear(); }


            foreach (string s in lResultData)
            {
                //decode action tag "XYZ="
                switch (s.Substring(0, 3))
                {
                    case "FLV": // flavor text
                        if (bFreshText) { tbChoiceText.Text = TextFixer(s.Substring(4)); bFreshText = false; }
                        else { tbChoiceText.AppendText(Environment.NewLine + TextFixer(s.Substring(4))); }
                        break;
                    case "MON": // Enter combat w/ monster ID
                        //trigger fight on window close, not before!
                        bFightFlag = true;
                        iMonID = Convert.ToInt32(s.Substring(4));
                        //sGameScreen.ChoiceFight(iMonID);
                        break;
                    case "ITM": // grant item (add ability to grant more than one. Handle multiple item drops as individual tags. actually give an item??
                        int iItemID = Convert.ToInt32(s.Substring(4));
                        string t = "You got a " + sGameScreen.GetItemName(iItemID);
                        sGameScreen.gMage.GetUniqueItem(iItemID);
                        sGameScreen.gLog.Add(t);
                        /*
                        int i = 1;
                        sGameScreen.gMage.AddItem(iItemID, i);
                        string t = "Nice work, you got(" + i.ToString() + ") ";
                        if (i == 1) { t += t; }
                        else { t += "(s) " + "s"; }

                        sGameScreen.gLog.Add("okay");
                        */
                        break;
                    case "EQP": //grant equipment
                        break;
                    case "EXP": // exp, unimplemented
                        break;
                    case "YST": // yeast, unimplemented
                        break;
                    case "RHP": // restore HP
                        break;
                    case "BUF": // grant buff
                        break;
                    case "ADV": // chain adventure
                        bChainFlag = true;
                        advID = Convert.ToInt32(s.Substring(4));
                        break;
                    case "MTD": //custom scripts
                        RunMethod(s.Substring(4));
                        break;
                    default:
                        break;
                }
            }

            //I can do better than this...
            if (lExtraData.Count > 0)
            {
                foreach (string s in lExtraData)
                {
                    //decode action tag "XYZ="
                    switch (s.Substring(0, 3))
                    {
                        case "FLV": // flavor text
                            if (bFreshText) { tbChoiceText.Text = TextFixer(s.Substring(4)); bFreshText = false; }
                            else { tbChoiceText.AppendText(Environment.NewLine + TextFixer(s.Substring(4))); }
                            break;
                        case "MON": // Enter combat w/ monster ID
                            //trigger fight on window close, not before!
                            bFightFlag = true;
                            iMonID = Convert.ToInt32(s.Substring(4));
                            //sGameScreen.ChoiceFight(iMonID);
                            break;
                        case "ITM": // grant item (add ability to grant more than one. Handle multiple item drops as individual tags. actually give an item??
                            int iItemID = Convert.ToInt32(s.Substring(4));
                            string t = "You got a " + sGameScreen.GetItemName(iItemID);
                            sGameScreen.gLog.Add(t);
                            /*
                            int i = 1;
                            sGameScreen.gMage.AddItem(iItemID, i);
                            string t = "Nice work, you got(" + i.ToString() + ") ";
                            if (i == 1) { t += t; }
                            else { t += "(s) " + "s"; }

                            sGameScreen.gLog.Add("okay");
                            */
                            break;
                        case "EQP": //grant equipment
                            break;
                        case "EXP": // exp, unimplemented
                            break;
                        case "YST": // yeast, unimplemented
                            break;
                        case "RHP": // restore HP
                            break;
                        case "BUF": // grant buff
                            break;
                        case "ADV": // chain adventure
                            bChainFlag = true;
                            advID = Convert.ToInt32(s.Substring(4));
                            break;
                        case "MTD": //custom scripts
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
                //remember to remove this:
                advID = 1;
                // if it chains, no need to wait for window close - refresh that info now
                sGameScreen.ChoiceChain(advID);
            }
            else if (bFightFlag == true)
            {

            }
            btnClose.Enabled = true;
            btnClose.Show();
            if (bFightFlag) { btnClose.Text = "Commence the bakedown"; }
            else { btnClose.Text = "Click to continue..."; }

            //TODO: remove buttons, strip out actions
        }


        private void btnChoiceOne_Click(object sender, EventArgs e)
        {
            lResultData = cChoice.GetResults(1, RareRoll());
            ResolveChoice();
        }

        private void btnChoiceTwo_Click(object sender, EventArgs e)
        {
            // button 2 clicked 
            lResultData = cChoice.GetResults(2, RareRoll());
            ResolveChoice();
        }
        private void BtnThreeClick(object sender, EventArgs e)
        {
            // when Button 3 is clicked
            lResultData = cChoice.GetResults(3, RareRoll());
            ResolveChoice();
        }

        private void BtnFourClick(object sender, EventArgs e)
        {
            // when Button 4 is clicked
            //lResultData = cChoice.GetResults(4, RareRoll());
            lResultData = cChoice.GetResults(4, true);
            ResolveChoice();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (bFightFlag == true)
            {
                sGameScreen.gLock = false;
                sGameScreen.ChoiceFight(iMonID);
            }
            else
            {
                sGameScreen.gLock = false;
                this.Dispose();
            }
        }

        private bool RareRoll()
        {
            bool b = false;
            if (sGameScreen.gRandom.Next(1, 11) == 10) { b = true; }
            return b;
        }

        private bool CheckReplacement(string s)
        {
            bool b = false;
            switch (s.Substring(0, 3))
            {
                case "ITM": // Item obtained?
                    if (sGameScreen.gMage.GetSaveData().gottenItems.Contains(Convert.ToInt32(s.Substring(4)))) { b = true; }
                    break;
                case "LVL": //Level requirement
                    break;
                case "FLG": // Game flag check
                    //sGameScreen.gMage.myGameFlags.CheckWhatever()
                    break;
                case "MTD": //custom scripts - needs updating for checking true/false?
                    //RunMethod(s.Substring(4));
                    break;
                default:
                    break;
            }
            return b;
        }

        /// <summary>
        /// Begin custom result methods
        /// </summary>

        private void RunMethod(string s)
        {
            Type t = this.GetType();
            MethodInfo mi = t.GetMethod(s, BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(this, new object[] { });
            Console.WriteLine("Hey we made it");
        }

        private void TestMethod()
        {
            if (sGameScreen.gRandom.Next(2) == 1) { iMonID = 4; bFightFlag = true; }
            else { sGameScreen.gLog.Add("Whew, missed that one"); }
        }

        private void GatchaRoulette()
        {
            List<int> GatchaPrizes = new List<int> { /* the prioze IDs */ 2, 3};

            int i = sGameScreen.gRandom.Next(10);
            if (i == 0) { AddExtraData("ITM", "1"); AddExtraData("FLV", "It looks like a bonus one rolled out! Lucky day!"); AddExtraData("ITM", "2"); } /*double prizes*/
            else if (i > 4) { AddExtraData("ITM", "1"); AddExtraData("FLV", "Woah something came down from the tree when you shook it! Look out!"); AddExtraData("MON", "4");  }
            else { AddExtraData("FLV", "Dang, nothing happened"); }
        }

        private void AddExtraData(string tag, string text)
        {
            string s = tag + "=" + text;
            lExtraData.Add(s);
        }

        private string TextFixer(string s)
        {
            //there will probably be more here, but jsut to get this started - 
            s = s.Replace("%n", sGameScreen.gMage.GetSaveData().mageName);
            return s;
        }


    }
}
