using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2.Controls.TownBoards
{
    public partial class TownSave : UserControl
    {
        private engGame myGame;
        public TownSave(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            myGame.gActiveStore = null;
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            myGame.NewDay(true);
        }
    }
}
