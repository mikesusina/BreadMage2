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
        private GameScreen myGS;

        private BindingSource effectBS = new BindingSource();
        private BindingSource passiveBS = new BindingSource();

        public BreadMage(GameScreen aGS)
        {
            InitializeComponent();
            myGS = aGS;
        }
        public void setGame(GameScreen aGS)
        {
            myGS = aGS;
        }

        public void LoadScreen()
        {
            LoadImage();
            SetBars();
            setEffectBox();
            radioPassives.Checked = true;
            boxSpells.ClearSelected();
        }
        private void LoadImage()
        {
            pbMage.Image = Properties.Resources.BreadMage2;
            pbMage.Show();

            //effect icons
            pbMoldIcon.Image = Properties.Resources.moldico;
            pbMoldIcon.Show();
            pbZestIcon.Image = Properties.Resources.zestico;
            pbZestIcon.Show();
            pbTensionIcon.Image = Properties.Resources.tensionico;
            pbTensionIcon.Show();

            //item component boxes
            pbIngredientsIcon.Image = Properties.Resources.moldico;
            pbIngredientsIcon.Show();
            pbCosmicEnergyIcon.Image = Properties.Resources.zestico;
            pbCosmicEnergyIcon.Show();
            pbElementalMotesIcon.Image = Properties.Resources.tensionico;
            pbElementalMotesIcon.Show();

        }
        private void SetBars()
        {
            //hp
            pbHP.Minimum = 0;
            pbHP.Maximum = myGS.gMage.Stats.HPMax;
            pbHP.Value = myGS.gMage.Stats.HP;
            string s = "HP: " + myGS.gMage.Stats.HP.ToString() + "/" + myGS.gMage.Stats.HPMax.ToString();
            lblHPDisplay.Text = s;

            /*
            pbMP.Minimum = 0;
            pbMP.Maximum = thisMage.MPmax;
            pbMP.Value = thisMage.MP;
            */


            //effects
            lblMoldTick.Text = myGS.gMage.MoldCount().ToString();
            lblZestTick.Text = myGS.gMage.ZestCount().ToString();
            lblTensionTick.Text = myGS.gMage.TensionCount().ToString();

            //items
            lblIngredients.Text = "Ingredients: " + myGS.gMage.GetComponentCount(1);
            lblCosmicEnergy.Text = "Cosmic Energy: " + myGS.gMage.GetComponentCount(2);
            lblElementalMotes.Text = "Elemental Motes: " + myGS.gMage.GetComponentCount(3);

            setEffectBox();

            s = "PATK: " + myGS.gMage.PAtk().ToString();
            lblYeast.Text = s;
        }

        public void UpdateBars()
        {
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

        public void setEffectBox()
        {
            List<clsSpell> MageEffects = new List<clsSpell>();
            List<clsSpell> MagePassives = myGS.gMage.EQSpells(2);

            passiveBS.DataSource = MagePassives;
            effectBS.DataSource = MageEffects;
            boxSpells.DataSource = passiveBS;
            if (radioEffects.Checked == true) { boxSpells.DataSource = MageEffects; }
            else { boxSpells.DataSource = MagePassives; }

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
        
        public clsMage GetMage() { return myGS.gMage; }



        public void BuffStuff()
        {
            if (myGS.gMage.GetStatEffects().Count > 0)
            {
                int iX = 10;
                int iY = 10;

                List<clsEffect> types = myGS.GameLibraries.EffectLib().FindAll(x => x.sType == "B");
                types.AddRange(myGS.GameLibraries.EffectLib().FindAll(x => x.sType == "D"));
                types.AddRange(myGS.GameLibraries.EffectLib().FindAll(x => x.sType == "P"));

                foreach (clsMageEffect e in myGS.gMage.GetStatEffects())
                {
                    if (types.Find(x => x.iID == e.iID) != null)
                    {
                        clsEffect anEffect = types.Find(x => x.iID == e.iID);
                        PictureBox newBox = new PictureBox();
                        newBox.Size = new Size(30, 30);
                        newBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        Point p = new Point(iX, iY);
                        newBox.Location = p;

                        object o = Properties.Resources.ResourceManager.GetObject(anEffect.ImgURL);
                        if (o is Image) { newBox.Image = o as Image; }
                        ToolTip aTip = new ToolTip();
                        aTip.SetToolTip(newBox, anEffect.sQuickDesc);
                        pnBuffs.Controls.Add(newBox);
                        newBox.Show();

                        iY += 40;
                        //pnBuffs.Controls["newBox"]
                        //newBox
                    }
                }
            }
        }

        private Image GetSpellIconImage(clsSpell aSpell)
        {
            if (aSpell.ImgURL != null && aSpell.ImgURL != "")
            {
                object o = Properties.Resources.ResourceManager.GetObject(aSpell.ImgURL);
                if (o is Image) { return o as Image; }
                else return Properties.Resources.bomb;
            }
            else return Properties.Resources.bomb;
        }

        private void radioEffects_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEffects.Focused && radioEffects.Checked)
            {
                boxSpells.DataSource = effectBS;
                boxSpells.ClearSelected();
            }
        }

        private void radioPassives_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPassives.Focused && radioPassives.Checked)
            {
                boxSpells.DataSource = passiveBS;
                boxSpells.ClearSelected();
            }
        }

        private void boxSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxSpells.Focused && boxSpells.SelectedItem != null)
            {
                try
                {
                    clsSpell s = boxSpells.SelectedItem as clsSpell;
                    pbEffectIcon.Image = GetSpellIconImage(s);
                    pbEffectIcon.Show();
                }
                catch { throw new FormatException("this thing isnt right"); }
            }
        }
    }
}
