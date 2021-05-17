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
            pbSP.Minimum = 0;
            pbSP.Maximum = thisMage.SPmax;
            pbSP.Value = thisMage.SP;

        }

        public void UpdateBars(int HP, int MP, int SP)
        {
            // constructor values are new current values, gMage is already updated when this is called - just update the bars. 
            // Any negative amounts should have been checked before here
            try
            {
                if (HP != 0 && HP <= pbHP.Maximum) { pbHP.Value = HP; lblHPDisplay.Text = "HP: " + pbHP.Value.ToString() + "/" + pbHP.Maximum.ToString(); }
                    else if (HP > pbHP.Maximum) { pbHP.Value = pbHP.Maximum; lblHPDisplay.Text = "HP: " + pbHP.Value.ToString() + "/" + pbHP.Maximum.ToString(); }
                if (MP != 0 && MP <= pbMP.Maximum) { pbMP.Value = MP; }
                    else if (MP > pbMP.Maximum) { pbMP.Value = pbMP.Maximum; }
                if (SP != 0 && SP <= pbSP.Maximum) { pbSP.Value = SP; }
                    else if (SP > pbSP.Maximum) { pbSP.Value = pbSP.Maximum; }
            }
            catch { throw new ArgumentOutOfRangeException(); }
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
