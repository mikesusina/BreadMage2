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
        public GameScreen myGameScr { get; set; }

        private int LocalLoc { get; set; } = 0;
        private int LocalZone { get; set; } = 1;
        private List<PictureBox> MapTiles { get; set; } = new List<PictureBox>();

        public MapBoard(GameScreen aGS)
        {
            InitializeComponent();
            myGameScr = aGS;

            //create the list of tiles
            foreach (Control c in this.Controls) {
                if (c is PictureBox) { MapTiles.Add((PictureBox)c); }
            }

            // get the mage's current location, but leave as is
            LocalLoc = myGameScr.gMage.Location;
            
            //generate the map
            if (myGameScr.GameLibraries.LocationLib().Exists(x => x.LocID == LocalLoc))
            {
                LocalZone = myGameScr.GameLibraries.LocationLib().Find(x => x.LocID == LocalLoc).Zone;
            }

            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone ) { SetMapTile(o); }
            }

        }

        private void SetMapTile(clsLocation loc)
        {
            string TileLoc = "b" + loc.LocY + loc.LocX.ToString();
            foreach (PictureBox p in MapTiles)
            {
                if ( p.Name.ToString() == TileLoc)
                {
                    p.Image = loc.MapTile;
                    p.Show();
                    break;
                }
            }
        }

        private void ClickA1(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 1 && o.LocY == "A")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickA2(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 2 && o.LocY == "A")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickA3(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 3 && o.LocY == "A")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickB1(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 1 && o.LocY == "B")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickB2(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 2 && o.LocY == "B")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickB3(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 3 && o.LocY == "B")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickC1(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 1 && o.LocY == "C")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickC2(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 2 && o.LocY == "C")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickC3(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 3 && o.LocY == "C")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickD1(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 1 && o.LocY == "D")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickD2(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 2 && o.LocY == "D")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }

        private void ClickD3(object sender, EventArgs e)
        {
            foreach (clsLocation o in myGameScr.GameLibraries.LocationLib())
            {
                if (o.Zone == LocalZone && o.LocX == 3 && o.LocY == "D")
                {
                    string s = "Headed to: " + o.LocationName;
                    prevLocTag.Text = s;
                }
            }
        }


    }
}
