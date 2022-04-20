using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadMage2.Controls;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace BreadMage2
{
    public class engTown
    {
        private engGame myGame { get; set; }
        public TownBoard bTown => myGame.bTown;
        public clsTownLot activeStore => myGame.gActiveStore;
        public Panel pnlTownZone => bTown.Controls["pnlTownZone"] as Panel;
        public Panel BuildingPanel => myGame.bTown.BuildingPanel;
        
        public int TownLocation { get; set; }
        public List<clsTownLot> TownBuildings = new List<clsTownLot>();
        public engTown(engGame aGame)
        {
            myGame = aGame;
        }

        public void LoadTown()
        {
            foreach (clsTownLot l in myGame.GameLibraries.TownLocationsLib())
            {
                if (myGame.gMage.Location == l.LocationID) { TownBuildings.Add(l.ShallowCopy()); }
            }
        }

        public void LoadButtons()
        {
            int i = 1;
            int xPos = 15;
            while (i < TownBuildings.Count)
            {
                clsTownLot l = TownBuildings.Find(x => x.TownLotNo == i);
                if (l != null /* && l.Condition is met */ )
                {
                    l.TownButton = new Button();
                    //if (l.Condition met)
                    l.TownButton.Size = new System.Drawing.Size(60, 60);
                    l.TownButton.Location = new System.Drawing.Point(xPos, 10);
                    string s = "";
                    switch (l.TownType)
                    {
                    // 1 = general items
                    // 2 = spells/skills
                    // 3 = equipment
                    // 4 = save?
                    // 5 = casino?
                        case 1:
                            s = "equipshop";
                            break;
                        case 2:
                            s = "skillshop";
                            break;
                        case 3:
                            s = "itemshop";
                            break;
                    }

                    if (s != "")
                    {
                        object o = Properties.Resources.ResourceManager.GetObject(s);
                        if (o is Image) { l.TownButton.Image = o as Image; }
                    }
                    else { l.TownButton.Text = l.TownName; }
                    l.TownButton.Tag = l;

                    bTown.Controls.Add(l.TownButton);
                    l.TownButton.Click += new EventHandler(bTown.TownLocation_Click);
                    l.TownButton.Show();
                    xPos += 75;
                    i++;
                }
            }
        }

        public void EnterShop(clsTownLot aLot)
        {
            myGame.gActiveStore = aLot;
            UserControl newShop = new UserControl();
            try
            {
                if (pnlTownZone.Enabled == false)
                {
                    (pnlTownZone.Controls["pbTownImage"] as PictureBox).Hide();
                    (pnlTownZone.Controls["pbTownImage"] as PictureBox).Enabled = false;
                    pnlTownZone.Enabled = true;
                }
                pnlTownZone.Controls.Clear();

                if (activeStore.TownType == 1)
                {
                    newShop = new TownShop(myGame);
                    (newShop as TownShop).shopInv.DataSource = myGame.GetShopInventory();
                    (newShop as TownShop).PopulateStock();
                }
                else if (activeStore.TownType == 2)
                {
                    newShop = new TownShop(myGame);
                    List<clsSpell> spells = new List<clsSpell>();
                    foreach (clsSpell s in myGame.GetSkillShopInventory())
                    {
                        if (!myGame.GetAllKnownMageSpells().Contains(s)) { spells.Add(s); }
                    }
                    (newShop as TownShop).shopInv.DataSource = spells;
                    (newShop as TownShop).secondaryInv.DataSource = myGame.GetSaleableComponentItems();
                    (newShop as TownShop).PopulateStock();
                }
                else if (activeStore.TownType == 3)
                {
                    newShop = new Controls.TownBoards.TownSave(myGame);
                }

                pnlTownZone.Controls.Add(newShop);
                pnlTownZone.Show();
                newShop.Enabled = true;
                newShop.Show();
            }
            catch (ApplicationException ex)
            {
                string s = "We beefed loading the shop good" + Environment.NewLine + ex.InnerException.ToString();
            }
        }

        
    }
}
