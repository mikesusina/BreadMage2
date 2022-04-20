using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2
{
    public partial class TownBoard : UserControl
    {
        private engGame myGame;
        public Panel BuildingPanel => pnlTownZone;
        public clsTownLot activeStore => myGame.TownEngine.activeStore;


        public TownBoard(engGame aGame, int townID = 0)
        {
            InitializeComponent();
            myGame = aGame;

        }

        public void LoadTown()
        {
            pbTownImage.Image = myGame.GameLibraries.LocationLib().Find(x => x.LocationID == myGame.gMage.Location).MapTile;
        }

        public void TownLocation_Click(object sender, EventArgs e)
        {
            myGame.TownEngine.EnterShop((clsTownLot)(sender as Button).Tag);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myGame.gLock = false;
            this.Hide();
            this.Dispose();
        }
    }
}
