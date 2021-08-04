using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BreadMage2
{
    public partial class BreadMage : UserControl
    {
        private clsMage thisMage;

        public BreadMage(clsMage aMage)
        {
            InitializeComponent();
            thisMage = aMage;
            LoadImage();
            SetBars();


        }

        private void LoadImage()
        {
            pbMage.Image = Properties.Resources.BreadMage2;
            pbMage.Show();
        }
        private void SetBars()
        {
            pbHP.Minimum = 0;
            pbHP.Maximum = thisMage.HPmax;
            pbHP.Value = thisMage.HP;
            pbMP.Minimum = 0;
            pbMP.Maximum = thisMage.MPmax;
            pbMP.Value = thisMage.MP;

            string s = "HP: " + thisMage.HP.ToString() + "/" + thisMage.HPmax.ToString();
            lblHPDisplay.Text = s;

            s = "Mold: " + thisMage.MoldCount().ToString() + Environment.NewLine + "Timer: " + thisMage.MoldTimer().ToString();
            lblMoldCount.Text = s;

            //this may get reused
            pbSP.Minimum = 0;
            pbSP.Maximum = 100;
            pbSP.Value = 0;

        }

        public void UpdateBars(clsMage aMage)
        {
            thisMage = aMage;
            SetBars();
            
            /*
            try
            {
                if (aMage.HP != pbHP.Value) { Set pbHP.Value! = aMage.HP }


                if (HP != 0 && HP <= pbHP.Maximum) { pbHP.Value = HP; lblHPDisplay.Text = "HP: " + pbHP.Value.ToString() + "/" + pbHP.Maximum.ToString(); }
                    else if (HP > pbHP.Maximum) { pbHP.Value = pbHP.Maximum; lblHPDisplay.Text = "HP: " + pbHP.Value.ToString() + "/" + pbHP.Maximum.ToString(); }
                if (MP != 0 && MP <= pbMP.Maximum) { pbMP.Value = MP; }
                    else if (MP > pbMP.Maximum) { pbMP.Value = pbMP.Maximum; }
                
                if (SP != 0 && SP <= pbSP.Maximum) { pbSP.Value = SP; }
                    else if (SP > pbSP.Maximum) { pbSP.Value = pbSP.Maximum; }
                
            }
            catch { throw new ArgumentOutOfRangeException(); }
            */
        }

        public void GameOverImage()
        {
            pbMage.Image = Properties.Resources.dead;
        }

        public void ZeroHPtag()
        {
            this.lblHPDisplay.Text = "HP: 0/" + pbHP.Maximum.ToString();
            this.pbHP.Value = 0;
        }
        
        public clsMage GetMage() { return thisMage; }

    }
}
