using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using BreadMage2.Controls;

namespace BreadMage2.Screens
{
    public partial class ChoiceScreen : Form
    {
        /// 
        /// 
        /// Currently this form is not in use! replaced with a custom control!
        /// 
        /// 


        public GameScreen myGameScr { get; set; }

        private Button btnChoiceThree { get; set; }
        private Button btnChoiceFour { get; set; }

        public ChoiceScreen(GameScreen aGS)
        {


        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Point p = new Point(65, 10);
            myGameScr.Show();
            myGameScr.Location = p;
        }
    }
}
