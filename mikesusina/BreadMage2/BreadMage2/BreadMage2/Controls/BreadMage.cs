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
        private engGame myGame;

        private BindingSource effectBS = new BindingSource();
        private BindingSource passiveBS = new BindingSource();

        public BreadMage(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }
        public void setGame(engGame aGame)
        {
            myGame = aGame;
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
            pbHP.Maximum = myGame.gMage.Stats.HPMax;
            pbHP.Value = myGame.gMage.Stats.HP;
            string s = "HP: " + myGame.gMage.Stats.HP.ToString() + "/" + myGame.gMage.Stats.HPMax.ToString();
            lblHPDisplay.Text = s;

            /*
            pbMP.Minimum = 0;
            pbMP.Maximum = thisMage.MPmax;
            pbMP.Value = thisMage.MP;
            */


            //effects
            lblMoldTick.Text = myGame.gMage.MoldCount().ToString();
            lblZestTick.Text = myGame.gMage.ZestCount().ToString();
            lblTensionTick.Text = myGame.gMage.TensionCount().ToString();

            //items
            barIngredients.Maximum = (myGame.gMage.Stats.MaxSpellTier * 50);
            barIngredients.Value = myGame.gMage.GetComponentCount(1);
            barCosmicEnergy.Maximum = (myGame.gMage.Stats.MaxSpellTier * 50);
            barCosmicEnergy.Value = myGame.gMage.GetComponentCount(2);
            barElementalMotes.Maximum = (myGame.gMage.Stats.MaxSpellTier * 50);
            barElementalMotes.Value = myGame.gMage.GetComponentCount(3);

            setEffectBox();

            s = "PATK: " + myGame.gMage.BuffedStat("PAK").ToString();
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
            List<clsEffect> MageEffects = myGame.gMage.GetStatEffects("daytick");
            List<clsSpell> MagePassives = myGame.gMage.EQSpells("passive");

            passiveBS.DataSource = MagePassives;
            effectBS.DataSource = MageEffects;
            boxSpells.DataSource = passiveBS;
            boxSpells.DisplayMember = "spellName";
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
        
        public void BuffStuff()
        {
            if (myGame.gMage.GetStatEffects().Count > 0)
            {
                int iX = 10;
                int iY = 10;

                List<clsEffect> types = myGame.GameLibraries.EffectLib().FindAll(x => x.sType == "B");
                types.AddRange(myGame.GameLibraries.EffectLib().FindAll(x => x.sType == "D"));
                types.AddRange(myGame.GameLibraries.EffectLib().FindAll(x => x.sType == "P"));

                foreach (clsEffect e in myGame.gMage.GetStatEffects())
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

        private void effectDisplay_CheckChanged(object sender, EventArgs e)
        {
            RadioButton b = sender as RadioButton;

            if (b.Focused && b.Checked)
            {
                boxSpells.ClearSelected();
                if (b == radioEffects) 
                {
                    boxSpells.DataSource = effectBS;
                    boxSpells.DisplayMember = "sEffectName";
                    effectBS.ResetBindings(false);
                }
                else if (b == radioPassives) 
                {
                    boxSpells.DataSource = passiveBS; 
                    boxSpells.DisplayMember = "spellName";
                    passiveBS.ResetBindings(false);

                }
                pbEffectIcon.Image = null;
                lblEffect.Text = "";
                myGame.gTT.SetToolTip(pbEffectIcon, null);
            }
        }

        private void boxSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxSpells.Focused && boxSpells.SelectedItem != null)
            {
                try
                {
                    clsSpell s = boxSpells.SelectedItem as clsSpell;
                    pbEffectIcon.Image = Program.GetImage(s.ImgURL);
                    pbEffectIcon.Show();
                    myGame.gTT.SetToolTip(pbEffectIcon, s.spellDescription);
                }
                catch { throw new FormatException("this thing isnt right"); }
            }
        }
    }
}
