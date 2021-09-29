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
        private GameScreen myGS;



        public TownBoard(GameScreen aGS)
        {
            InitializeComponent();
            myGS = aGS;
        }

        private void btnItemShop_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlTownZone.Enabled == false)
                {
                    pbTownImage.Hide();
                    pbTownImage.Enabled = false;
                    pnlTownZone.Enabled = true;
                }
                pnlTownZone.Controls.Clear();
                ShopItems newShop = new ShopItems(myGS);
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
