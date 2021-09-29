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
    public partial class ShopItems : UserControl
    {
        private GameScreen myGS;
        private int shopType = 1;

        public ShopItems(GameScreen aGameScreen, int iType = 1)
        {
            InitializeComponent();
            myGS = aGameScreen;
            shopType = iType;
        }
    }
}
