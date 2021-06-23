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
    public partial class ChoiceBoard : UserControl
    {
        public ChoiceBoard(clsChoiceAdventure anAdventure)
        {
            InitializeComponent();

            tbChoiceText.Text = anAdventure.AdvText;

            //load image
            //pbMonster.Image = Properties.Resources.[URL];
            object o = Properties.Resources.ResourceManager.GetObject(anAdventure.ImageURL);
            if (o is Image) { pbChoicePic.Image = o as Image; }
            else { pbChoicePic.Image = Properties.Resources.BreadMage2; }
            pbChoicePic.Show();
        }
    }
}
