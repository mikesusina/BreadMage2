using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2.Controls
{
    public partial class ChoiceBoard : UserControl
    {
        public GameScreen sGameScreen { get; set; }
        public clsChoiceAdventure cChoice { get; set; }
        public ChoiceBoard bChoice { get; set; }
        public List<string> lResultData { get; set; }


        private int iMonID { get; set; }

        private bool bFightFlag { get; set; }

        private Button btnChoiceThree { get; set; }
        private Button btnChoiceFour { get; set; }


        public ChoiceBoard(clsChoiceAdventure anAdventure)
        {
            InitializeComponent();

            tbChoiceText.Text = anAdventure.AdvText;

            //load image
            //pbMonster.Image = Properties.Resources.[URL];
            object o = Properties.Resources.ResourceManager.GetObject(anAdventure.ImgURL);
            if (o is Image) { pbChoicePic.Image = o as Image; }
            else { pbChoicePic.Image = Properties.Resources.BreadMage2; }
            pbChoicePic.Show();
        }




        public ChoiceBoard(GameScreen aGS, clsChoiceAdventure anAdventure)
        {
            InitializeComponent();

            tbChoiceText.Text = anAdventure.AdvText;

            // parse out all relevant data
            // generate any buttons if needed
            // wait for user input

            cChoice = anAdventure;
            sGameScreen = aGS;

            //buttons:
            btnChoiceOne.Text = cChoice.Btn1;
            btnChoiceTwo.Text = cChoice.Btn2;


            //TODO: implement conditions, clean up how these are generated (ie if 3 won't exist but 4 will)
            if (cChoice.Btn3 != null && cChoice.Btn3 != "")
            {
                Button aButton = new Button();
                Point p = new Point();
                p.X = btnChoiceOne.Location.X;
                p.Y = btnChoiceTwo.Location.Y + 40;

                aButton.Size = new Size(250, 30);
                aButton.Location = p;
                aButton.Text = cChoice.Btn3;
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
                aButton.Text = cChoice.Btn4;
                btnChoiceFour = aButton;

                this.Controls.Add(btnChoiceFour);
                btnChoiceFour.Click += new EventHandler(BtnFourClick);
                btnChoiceFour.Show();
            }
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
            //more stuff: add money(YST), exp, status effects(STF)
            // take result text and overwrite text box - "chain" adventures should NOT contain result flavor text, next adv text box will deal
            //
            // ***currently plan is ADV= tags should not be mixed with other tags, and contain no flavor text, as it's on the next adventure
            //      [can trigger increments or stats? just MAKE SURE IT'S MENTIONED CLEARLY IN THE NEXT TEXT]
            //


            int advID = 0;
            bool bChainFlag = false;
            bFightFlag = false;
            foreach (string s in lResultData)
            {
                //decode action tag "XYZ="
                switch (s.Substring(0, 3))
                {
                    case "FLV": // flavor text
                        tbChoiceText.Text = s.Substring(4);
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
                    case "ADV": // chain adventure
                        bChainFlag = true;
                        advID = Convert.ToInt32(s.Substring(4));
                        break;
                    default:
                        break;
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
                sGameScreen.ChoiceChain(sGameScreen.gChoiceList.Find(x => x.AdvID == advID));
            }
            else if (bFightFlag == true)
            {

            }

            {
                btnClose.Enabled = true;
                btnClose.Show();
                if (bFightFlag) { btnClose.Text = "Commence the bakedown"; }
                else { btnClose.Text = "Click to continue..."; }

                //TODO: remove buttons, strip out actions
            }

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
            lResultData = cChoice.GetResults(4, RareRoll());
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
    }
}
