using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2.Controls.SubGames
{
    public partial class FishGame : UserControl
    {
        private int fishTick = 0;
        private string fishState = "off";
        private Random fishRandom;
        public void setRandom(Random r) { fishRandom = r; }
        public FishGame()
        {
            InitializeComponent();
            FishTimer.Stop();
            fishState = "off";
        }

        private void FishGame_Load(object sender, EventArgs e)
        {

        }

        private void btnFish_Click(object sender, EventArgs e)
        {
            switch (fishState)
            {
                case "off":
                    fishState = "fishing";
                    FishTimer.Interval = fishRandom.Next(2500, 5000);
                    fishTick = 1;
                    btnFish.Text = "Fishing...";

                    WriteLine("Line out!");
                    FishTimer.Start();
                    break;
                case "fishing":
                    fishState = "off";
                    fishTick = 0;
                    FishTimer.Stop();
                    btnFish.Text = "Cast";
                    WriteLine("No fish!");
                    break;
                case "hooked":
                    fishState = "off";
                    fishTick = 0;
                    FishTimer.Stop();
                    btnFish.Text = "Cast";
                    WriteLine("GOT FISH!");
                    break;
            }
            updateLabel();
        }

        private void FishTimer_Tick(object sender, EventArgs e)
        {
            bool hooked = false;
            int iRoll = 3;
            if (fishState == "fishing")
            {
                if (fishTick == 1) { iRoll = 5; }
                else if (fishTick == 2) { iRoll = 4; }

                if (fishRandom.Next(iRoll) == 0) { hooked = true; }
                if (hooked)
                {
                    fishState = "hooked";
                    FishTimer.Interval = fishRandom.Next(750, 1500);
                    FishTimer.Start();
                }
                fishTick++;
            }
            else if (fishState == "hooked")
            {
                fishState = "off";
                FishTimer.Stop();
                btnFish.Text = "Cast";
                WriteLine("Fish away :(");
            }
            updateLabel();
        }

        private void WriteLine(string s)
        {
            rtbFishChatter.Clear();
            rtbFishChatter.AppendText(s);
        }

        private void updateLabel()
        {
            switch (fishState)
            {
                case ("fishing"):
                    if (fishTick%2 == 0) { label1.Text = "wait..."; }
                    else { label1.Text = "wait.."; }
                    break;
                case ("hooked"):
                    label1.Text = "HOOKED GET IT NOW!";
                    break;
                case ("off"):
                    label1.Text = "fish off";
                    break;
            }
        }
    }
}
