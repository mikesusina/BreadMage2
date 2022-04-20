using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace BreadMage2.Controls
{
    public partial class ChoiceBoard : UserControl
    {
        public engGame myGame { get; set; }
        public clsChoiceAdventure cChoice => myGame.gChoice;

        public ChoiceBoard(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }

        public void SetInitUI()
        {
            // wait for user input

            //load the image
            object o = Properties.Resources.ResourceManager.GetObject(cChoice.ImgURL);
            if (o is Image) { pbChoicePic.Image = o as Image; }
            else { pbChoicePic.Image = Properties.Resources.BreadMage2; }
            pbChoicePic.Show();

            lblTitle.Text = TextFixer(cChoice.AdvName);
            SetText(cChoice.AdvText);


            btnClose.Enabled = false;
            btnClose.Hide();



            // generate buttons needed
            /* locations:
             * 1 5, 470
             * 2 230 470
             * 3 5, 525
             * 4 230, 525
             * 
             * close 117, 497
             * */
            int i = 1;
            Point p = new Point();
            while (i < 5)
            {
                if (cChoice.AdventureResults.Find(x => x.SlotID == i) != null)
                {
                    ResultItem r = cChoice.AdventureResults.Find(x => x.SlotID == i);
                    if (r.ConditionMet)
                    {
                        Button btn = new Button();
                        btn.Size = new Size(215, 55);
                        btn.MaximumSize = btn.Size;
                        btn.Font = new Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        btn.Name = "btnChoice" + i.ToString();

                        switch (i)
                        {
                            case 1:
                                btn.Location = new Point(5, 470);
                                break;
                            case 2:
                                btn.Location = new Point(230, 470);
                                break;
                            case 3:
                                btn.Location = new Point(5, 525);
                                break;
                            case 4:
                                btn.Location = new Point(230, 525);
                                break;
                        }
                        btn.TextAlign = ContentAlignment.MiddleCenter;
                        btn.Text = TextFixer(r.ButtonText);
                        btn.Click += new EventHandler(btnResult_Click);

                        cChoice.AdventureResults.Find(x => x.SlotID == i).ResultButton = btn;
                        this.Controls.Add(btn);
                        btn.Show();
                    }
                    i++;
                }
            }

        }
       
        public void SetText(string someText)
        {
            rtbChoiceText.Text = TextFixer(someText);
        }

        public void SetCloseButton()
        {
            foreach (ResultItem r in cChoice.AdventureResults)
            {
                if (r.ResultButton != null)
                {
                    r.ResultButton.Hide();
                    r.ResultButton.Enabled = false;
                }
            }

            if (myGame.ChoiceEngine.bFightFlag) { btnClose.Text = "Commence the bakedown!"; }
            else { btnClose.Text = "Click to continue..."; }
            btnClose.Enabled = true;
            btnClose.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            myGame.gLock = false;
            if (myGame.ChoiceEngine.bFightFlag == true)
            {
                myGame.BeginCombatEncounter(myGame.ChoiceEngine.MonsterIDtoChain);
            }
            else { this.Hide(); }
        }
        private bool RareRoll()
        {
            bool b = false;
            if (myGame.gRandom.Next(1, 11) == 10) { b = true; }
            return b;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            //does this correctly give an int to the resolve choice? is an int the best idea for this?
            myGame.ChoiceEngine.ResolveChoice(Convert.ToInt32((sender as Button).Name.Substring((sender as Button).Name.Length - 1)));
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
            if (myGame.gRandom.Next(2) == 1) { myGame.ChoiceEngine.MonsterIDtoChain = 4; myGame.ChoiceEngine.bFightFlag = true; }
            else { myGame.gLog.Add("Whew, missed that one"); }
        }


        private string TextFixer(string s)
        {
            //there will probably be more here, but jsut to get this started - 
            s = s.Replace("%n", myGame.gMage.GetSaveData().mageName);
            return s;
        }


    }
}
