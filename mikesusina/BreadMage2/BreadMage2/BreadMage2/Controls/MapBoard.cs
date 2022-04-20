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
    public partial class MapBoard : UserControl
    {
        public engGame myGame { get; set; }

        private int LocalLoc { get; set; } = 0;
        private int NewLoc { get; set; } = 0;
        private int LocalZone { get; set; } = 1;
        
        private List<clsLocation> LocalZoneLocs = new List<clsLocation>();
        private List<MapBox> MapTiles { get; set; } = new List<MapBox>();

        public MapBoard(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }
        
        public void LoadBoard()
        {

            // get the mage's current location, but leave as is
            if (myGame.GameLibraries.LocationLib().Find(x => x.LocationID == myGame.gMage.Location).Zone != 0)
            { LocalZone = myGame.GameLibraries.LocationLib().Find(x => x.LocationID == myGame.gMage.Location).Zone; }
            else
            {
                LocalZone = 0;
                return; //need to handle if mage is out of zone?
            }
            LocalLoc = myGame.gMage.Location;


            //get the local locations
            LocalZoneLocs = myGame.GameLibraries.LocationLib().FindAll(x => x.Zone == LocalZone);
            if (LocalZoneLocs.Count() > 0)
            {
                int i = 1;
                while (i < 13)
                {
                    MapBox box = new MapBox();
                    if (LocalZoneLocs.Find(x => x.ZoneLocation == i) != null)
                    {
                        box.MapLocation = (LocalZoneLocs.Find(x => x.ZoneLocation == i));
                    }
                    else
                    {
                        box.MapLocation = new clsLocation();
                    }

                    box.pbMapBox = (Controls["b" + i.ToString()] as PictureBox);
                    box.pbMapBox.Tag = box.MapLocation;

                    MapTiles.Add(box);
                    i++;
                }
            }

            //set the tiles
            foreach (MapBox m in MapTiles)
            {
                m.pbMapBox.Image = m.MapLocation.MapTile;
                m.pbMapBox.Click += new EventHandler(pbTile_Click);

                m.pbMapBox.Show();
            }
        }

        private void pbTile_Click(object sender, EventArgs e)
        {
            string s = "Headed to: " + ((sender as PictureBox).Tag as clsLocation).LocationName;
            NewLoc = ((sender as PictureBox).Tag as clsLocation).LocationID;
            prevLocTag.Text = s;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            myGame.gLock = false;
            if (NewLoc == 0) { NewLoc = LocalLoc; }
            myGame.ChangeLocation(NewLoc);
            this.Dispose();

        }
    }

}
namespace BreadMage2
{
    public class MapBox
    {
        public clsLocation MapLocation { get; set; }
        public PictureBox pbMapBox { get; set; }
        public MapBox()
        {

        }
    }
}
