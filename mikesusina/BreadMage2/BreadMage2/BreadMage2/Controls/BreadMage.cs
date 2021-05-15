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
        private Mage thisMage;

        public BreadMage(Mage aMage)
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
            if (HP != 0) { pbHP.Value = HP; lblHPDisplay.Text = "HP: " + pbHP.Value.ToString() + "/" + pbHP.Maximum.ToString(); }
            if (MP != 0) { pbMP.Value = MP; }
            if (SP != 0) { pbSP.Value = SP; }
            }
            catch { throw new ArgumentOutOfRangeException(); }
        }

        public void GameOverImage()
        {
            pbMage.Image = Properties.Resources.dead;
        }

        public void ZeroHPtag()
        {
            lblHPDisplay.Text = "HP: 0/" + pbHP.Maximum.ToString();
        }
        
        public Mage GetMage() { return thisMage; }

    }
}
