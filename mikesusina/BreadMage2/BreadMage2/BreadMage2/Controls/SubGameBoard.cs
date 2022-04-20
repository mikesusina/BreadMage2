using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BreadMage2.Controls.SubGames;

namespace BreadMage2.Controls
{
    //this board holds smaller controls that will serve as interactable "minigames"
    public partial class SubGameBoard : UserControl
    {
        public Control currentGame;
        public engGame myGame;
        public SubGameBoard(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }

        public void openGame(string sType)
        {
            switch (sType.ToUpper())
            {
                case "FISH":

                    currentGame = new FishGame();
                    (currentGame as FishGame).setRandom(myGame.gRandom);
                    break;
                default:
                    currentGame = null;
                    break;
            }
            if (currentGame != null)
            {
                currentGame.Left = (this.Width - currentGame.Width)/ 2;
                currentGame.Top = (this.Height - currentGame.Height) / 2;
                this.Controls.Add(currentGame);
                currentGame.Show();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            myGame.gLock = false;
            currentGame.Dispose();
            this.Dispose();
        }
    }
}
