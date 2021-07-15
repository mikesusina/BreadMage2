using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using BreadMage2.Controls;

namespace BreadMage2.Screens
{
    public partial class ChoiceScreen : Form
    {
        /// 
        /// 
        /// Currently this form is not in use! replaced with a custom control!
        /// 
        /// 


        public GameScreen sGameScreen { get; set; }
        public clsChoiceAdventure cChoice { get; set; }
        public ChoiceBoard bChoice { get; set; }
        public List<string> lResultData { get; set; }


        private int iMonID { get; set; }

        private bool bFightFlag { get; set; }

        private Button btnChoiceThree { get; set; }
        private Button btnChoiceFour { get; set; }

        public ChoiceScreen(GameScreen aGS, clsChoiceAdventure anAdventure)
        {
            InitializeComponent();

            // parse out all relevant data
            // pass info to the text and image board and display
            // generate any buttons if needed
            // wait for user input

            cChoice = anAdventure;
            sGameScreen = aGS;

            //image and text:
            bChoice = new ChoiceBoard(cChoice);
            Controls["pChoiceArea"].Controls.Add(bChoice);
            Controls["pChoiceArea"].Controls["ChoiceBoard"].Show();

            //buttons:
            btnChoiceOne.Text = cChoice.Btn1;
            btnChoiceTwo.Text = cChoice.Btn2;


            //TODO: implement conditions, clean up how these are generated (ie if 3 won't exist but 4 will)
            if(cChoice.Btn3 != null && cChoice.Btn3 != "")
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

            this.FormClosing += Form1_FormClosing;
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
                        bChoice.Controls["tbChoiceText"].Text = s.Substring(4);
                        break;
                    case "MON": // Enter combat w/ monster ID
                        //trigger fight on window close, not before!
                        bFightFlag = true;
                        iMonID = Convert.ToInt32(s.Substring(4));
                        //sGameScreen.ChoiceFight(iMonID);
                        break;
                    case "ITM": // grant item (add ability to grant more than one. Handle multiple item drops as individual tags
                        int iItemID = Convert.ToInt32(s.Substring(4));
                        sGameScreen.gMage.AddItem(iItemID, 1);
                        break;
                    case "EXP": // exp, unimplemented
                        break;
                    case "YST": // yeast, unimplemented
                        break;
                    case "ADV": // chain adventure
                        bChainFlag = true;
                        advID = Convert.ToInt32(s.Substring(5));
                        break;
                    default:
                        break;
                }
            }


            //after decoding, decide: if chain, refresh immediately with new adventure
            // if combat, throw up flavor text and wait for close button, which generates the fight board
            // otherwise return to idle/wander
            if (bChainFlag == true)
            {
                // if it chains, no need to wait for window close - refresh that info now
                ChainAdventure(advID);
            }
            else
            {
                btnClose.Enabled = true;
                btnClose.Show();
                if (bFightFlag){ btnClose.Text = "Commence the bakedown"; }
                else { btnClose.Text = "Get me out of here"; }
                
                //TODO: remove buttons, strip out actions
            }

        }

        private void ChainAdventure(int anAdvID)
        {
            //chaining choices without closing the window (hopefully):
            //clear the flavor panel
            bChoice.Dispose();

            //get the new adventure object and generate a new panel
            clsChoiceAdventure newAdventure = sGameScreen.gChoiceList.Find(x => x.AdvID == anAdvID);
            bChoice = new ChoiceBoard(newAdventure);

            //set all the properties to the new adventure:
            cChoice = newAdventure;

            //add the panel
            Controls["pChoiceArea"].Controls.Add(bChoice);
            bChoice.Parent = this;
            bChoice.Show();

            //reset the buttons. 
            // TO DO: dynamically add/remove buttons without reloading the window, not just change text
            btnChoiceOne.Text = cChoice.Btn1;
            btnChoiceTwo.Text = cChoice.Btn2;

            if (cChoice.Btn3 != null && cChoice.Btn3 != "")
            {
                Button aButton = new Button();
                Point p = new Point();
                p.X = btnChoiceTwo.Location.X;
                p.Y = btnChoiceTwo.Location.Y + 40;

                aButton.Size = new Size(250, 30);
                aButton.Location = p;
                aButton.Name = "btnChoiceThree";
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

                p.X = btnChoiceTwo.Location.X;
                if (btnChoiceThree != null) { p.Y = btnChoiceThree.Location.Y + 40; }
                else { p.Y = btnChoiceTwo.Location.Y + 40; }

                aButton.Size = new Size(250, 30);
                aButton.Location = p;
                aButton.Name = "btnChoiceFour";
                aButton.Text = cChoice.Btn4;
                btnChoiceFour = aButton;

                this.Controls.Add(btnChoiceFour);
                btnChoiceFour.Click += new EventHandler(BtnFourClick);
                btnChoiceFour.Show();
            }
        }


        private void btnChoiceOne_Click(object sender, EventArgs e)
        {
            // button 1 clicked
            lResultData = cChoice.GetResults(1);
            ResolveChoice();
        }

        private void btnChoiceTwo_Click(object sender, EventArgs e)
        {
            // button 2 clicked 
            lResultData = cChoice.GetResults(2);
            ResolveChoice();
        }

        private void BtnThreeClick(object sender, EventArgs e)
        {
            // when Button 3 is clicked
            lResultData = cChoice.GetResults(3);
            ResolveChoice();
        }

        private void BtnFourClick (object sender, EventArgs e)
        {
            // when Button 4 is clicked
            lResultData = cChoice.GetResults(4);
            ResolveChoice();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (bFightFlag == true)
            {
                sGameScreen.ChoiceFight(iMonID);
            }
            this.Close();
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Point p = new Point(65, 10);
            sGameScreen.Show();
            sGameScreen.Location = p;
        }
    }
}
