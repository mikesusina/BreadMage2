namespace BreadMage2
{
    partial class BreadMage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbHP = new System.Windows.Forms.ProgressBar();
            this.pbMP = new System.Windows.Forms.ProgressBar();
            this.lblHPDisplay = new System.Windows.Forms.Label();
            this.lblMPDisplay = new System.Windows.Forms.Label();
            this.lblMoldCount = new System.Windows.Forms.Label();
            this.lblZestCount = new System.Windows.Forms.Label();
            this.pnBuffs = new System.Windows.Forms.Panel();
            this.lblEffect = new System.Windows.Forms.Label();
            this.pbEffectIcon = new System.Windows.Forms.PictureBox();
            this.radioEffects = new System.Windows.Forms.RadioButton();
            this.radioPassives = new System.Windows.Forms.RadioButton();
            this.boxSpells = new System.Windows.Forms.ListBox();
            this.lblYeast = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblElementalMotes = new System.Windows.Forms.Label();
            this.lblCosmicEnergy = new System.Windows.Forms.Label();
            this.lblIngredients = new System.Windows.Forms.Label();
            this.pbElementalMotesIcon = new System.Windows.Forms.PictureBox();
            this.pbIngredientsIcon = new System.Windows.Forms.PictureBox();
            this.pbCosmicEnergyIcon = new System.Windows.Forms.PictureBox();
            this.pbMoldIcon = new System.Windows.Forms.PictureBox();
            this.pbMage = new System.Windows.Forms.PictureBox();
            this.lblMoldTick = new System.Windows.Forms.Label();
            this.pnlMold = new System.Windows.Forms.Panel();
            this.pnlZest = new System.Windows.Forms.Panel();
            this.pbZestIcon = new System.Windows.Forms.PictureBox();
            this.lblZestTick = new System.Windows.Forms.Label();
            this.pnlTension = new System.Windows.Forms.Panel();
            this.pbTensionIcon = new System.Windows.Forms.PictureBox();
            this.lblTensionCount = new System.Windows.Forms.Label();
            this.lblTensionTick = new System.Windows.Forms.Label();
            this.lblMageName = new System.Windows.Forms.Label();
            this.barIngredients = new System.Windows.Forms.ProgressBar();
            this.barCosmicEnergy = new System.Windows.Forms.ProgressBar();
            this.barElementalMotes = new System.Windows.Forms.ProgressBar();
            this.pnBuffs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEffectIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbElementalMotesIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIngredientsIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCosmicEnergyIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoldIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMage)).BeginInit();
            this.pnlMold.SuspendLayout();
            this.pnlZest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZestIcon)).BeginInit();
            this.pnlTension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTensionIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHP
            // 
            this.pbHP.BackColor = System.Drawing.SystemColors.Control;
            this.pbHP.ForeColor = System.Drawing.Color.Red;
            this.pbHP.Location = new System.Drawing.Point(8, 23);
            this.pbHP.Name = "pbHP";
            this.pbHP.Size = new System.Drawing.Size(153, 22);
            this.pbHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbHP.TabIndex = 1;
            // 
            // pbMP
            // 
            this.pbMP.BackColor = System.Drawing.SystemColors.Control;
            this.pbMP.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pbMP.Location = new System.Drawing.Point(188, 221);
            this.pbMP.Name = "pbMP";
            this.pbMP.Size = new System.Drawing.Size(120, 15);
            this.pbMP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMP.TabIndex = 2;
            // 
            // lblHPDisplay
            // 
            this.lblHPDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHPDisplay.AutoSize = true;
            this.lblHPDisplay.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHPDisplay.Location = new System.Drawing.Point(11, 48);
            this.lblHPDisplay.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblHPDisplay.Name = "lblHPDisplay";
            this.lblHPDisplay.Size = new System.Drawing.Size(150, 20);
            this.lblHPDisplay.TabIndex = 4;
            this.lblHPDisplay.Text = "42/42";
            this.lblHPDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMPDisplay
            // 
            this.lblMPDisplay.AutoSize = true;
            this.lblMPDisplay.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMPDisplay.Location = new System.Drawing.Point(175, 198);
            this.lblMPDisplay.Name = "lblMPDisplay";
            this.lblMPDisplay.Size = new System.Drawing.Size(158, 20);
            this.lblMPDisplay.TabIndex = 5;
            this.lblMPDisplay.Text = "Indicator for day cycle";
            // 
            // lblMoldCount
            // 
            this.lblMoldCount.AutoSize = true;
            this.lblMoldCount.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoldCount.Location = new System.Drawing.Point(1, 2);
            this.lblMoldCount.Name = "lblMoldCount";
            this.lblMoldCount.Size = new System.Drawing.Size(35, 18);
            this.lblMoldCount.TabIndex = 6;
            this.lblMoldCount.Text = "Mold";
            // 
            // lblZestCount
            // 
            this.lblZestCount.AutoSize = true;
            this.lblZestCount.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZestCount.Location = new System.Drawing.Point(1, 2);
            this.lblZestCount.Name = "lblZestCount";
            this.lblZestCount.Size = new System.Drawing.Size(32, 18);
            this.lblZestCount.TabIndex = 10;
            this.lblZestCount.Text = "Zest";
            // 
            // pnBuffs
            // 
            this.pnBuffs.AutoScroll = true;
            this.pnBuffs.Controls.Add(this.lblEffect);
            this.pnBuffs.Controls.Add(this.pbEffectIcon);
            this.pnBuffs.Controls.Add(this.radioEffects);
            this.pnBuffs.Controls.Add(this.radioPassives);
            this.pnBuffs.Controls.Add(this.boxSpells);
            this.pnBuffs.Location = new System.Drawing.Point(8, 254);
            this.pnBuffs.Name = "pnBuffs";
            this.pnBuffs.Size = new System.Drawing.Size(186, 178);
            this.pnBuffs.TabIndex = 12;
            // 
            // lblEffect
            // 
            this.lblEffect.AutoSize = true;
            this.lblEffect.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEffect.Location = new System.Drawing.Point(40, 15);
            this.lblEffect.Name = "lblEffect";
            this.lblEffect.Size = new System.Drawing.Size(41, 18);
            this.lblEffect.TabIndex = 41;
            this.lblEffect.Text = "Effect";
            // 
            // pbEffectIcon
            // 
            this.pbEffectIcon.Location = new System.Drawing.Point(4, 9);
            this.pbEffectIcon.Name = "pbEffectIcon";
            this.pbEffectIcon.Size = new System.Drawing.Size(30, 30);
            this.pbEffectIcon.TabIndex = 29;
            this.pbEffectIcon.TabStop = false;
            // 
            // radioEffects
            // 
            this.radioEffects.AutoSize = true;
            this.radioEffects.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEffects.Location = new System.Drawing.Point(4, 45);
            this.radioEffects.Name = "radioEffects";
            this.radioEffects.Size = new System.Drawing.Size(64, 22);
            this.radioEffects.TabIndex = 39;
            this.radioEffects.TabStop = true;
            this.radioEffects.Text = "Effects";
            this.radioEffects.UseVisualStyleBackColor = true;
            this.radioEffects.CheckedChanged += new System.EventHandler(this.effectDisplay_CheckChanged);
            // 
            // radioPassives
            // 
            this.radioPassives.AutoSize = true;
            this.radioPassives.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPassives.Location = new System.Drawing.Point(69, 45);
            this.radioPassives.Name = "radioPassives";
            this.radioPassives.Size = new System.Drawing.Size(68, 22);
            this.radioPassives.TabIndex = 40;
            this.radioPassives.TabStop = true;
            this.radioPassives.Text = "Passives";
            this.radioPassives.UseVisualStyleBackColor = true;
            this.radioPassives.CheckedChanged += new System.EventHandler(this.effectDisplay_CheckChanged);
            // 
            // boxSpells
            // 
            this.boxSpells.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSpells.FormattingEnabled = true;
            this.boxSpells.ItemHeight = 20;
            this.boxSpells.Location = new System.Drawing.Point(3, 67);
            this.boxSpells.Name = "boxSpells";
            this.boxSpells.Size = new System.Drawing.Size(166, 104);
            this.boxSpells.TabIndex = 39;
            this.boxSpells.SelectedIndexChanged += new System.EventHandler(this.boxSpells_SelectedIndexChanged);
            // 
            // lblYeast
            // 
            this.lblYeast.AutoSize = true;
            this.lblYeast.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYeast.Location = new System.Drawing.Point(113, 78);
            this.lblYeast.Name = "lblYeast";
            this.lblYeast.Size = new System.Drawing.Size(35, 16);
            this.lblYeast.TabIndex = 13;
            this.lblYeast.Text = "Yeast";
            // 
            // lblLevel
            // 
            this.lblLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(122, 3);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(43, 20);
            this.lblLevel.TabIndex = 14;
            this.lblLevel.Text = "Level";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblElementalMotes
            // 
            this.lblElementalMotes.AutoSize = true;
            this.lblElementalMotes.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElementalMotes.Location = new System.Drawing.Point(220, 383);
            this.lblElementalMotes.Name = "lblElementalMotes";
            this.lblElementalMotes.Size = new System.Drawing.Size(99, 18);
            this.lblElementalMotes.TabIndex = 20;
            this.lblElementalMotes.Text = "Elemental Motes";
            // 
            // lblCosmicEnergy
            // 
            this.lblCosmicEnergy.AutoSize = true;
            this.lblCosmicEnergy.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosmicEnergy.Location = new System.Drawing.Point(221, 338);
            this.lblCosmicEnergy.Name = "lblCosmicEnergy";
            this.lblCosmicEnergy.Size = new System.Drawing.Size(87, 18);
            this.lblCosmicEnergy.TabIndex = 19;
            this.lblCosmicEnergy.Text = "Cosmic Energy";
            // 
            // lblIngredients
            // 
            this.lblIngredients.AutoSize = true;
            this.lblIngredients.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredients.Location = new System.Drawing.Point(220, 293);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(70, 18);
            this.lblIngredients.TabIndex = 15;
            this.lblIngredients.Text = "Ingredients";
            // 
            // pbElementalMotesIcon
            // 
            this.pbElementalMotesIcon.Location = new System.Drawing.Point(200, 390);
            this.pbElementalMotesIcon.Name = "pbElementalMotesIcon";
            this.pbElementalMotesIcon.Size = new System.Drawing.Size(20, 20);
            this.pbElementalMotesIcon.TabIndex = 18;
            this.pbElementalMotesIcon.TabStop = false;
            // 
            // pbIngredientsIcon
            // 
            this.pbIngredientsIcon.Location = new System.Drawing.Point(200, 300);
            this.pbIngredientsIcon.Name = "pbIngredientsIcon";
            this.pbIngredientsIcon.Size = new System.Drawing.Size(20, 20);
            this.pbIngredientsIcon.TabIndex = 17;
            this.pbIngredientsIcon.TabStop = false;
            // 
            // pbCosmicEnergyIcon
            // 
            this.pbCosmicEnergyIcon.Location = new System.Drawing.Point(200, 345);
            this.pbCosmicEnergyIcon.Name = "pbCosmicEnergyIcon";
            this.pbCosmicEnergyIcon.Size = new System.Drawing.Size(20, 20);
            this.pbCosmicEnergyIcon.TabIndex = 16;
            this.pbCosmicEnergyIcon.TabStop = false;
            // 
            // pbMoldIcon
            // 
            this.pbMoldIcon.Location = new System.Drawing.Point(3, 20);
            this.pbMoldIcon.Name = "pbMoldIcon";
            this.pbMoldIcon.Size = new System.Drawing.Size(20, 20);
            this.pbMoldIcon.TabIndex = 8;
            this.pbMoldIcon.TabStop = false;
            // 
            // pbMage
            // 
            this.pbMage.Location = new System.Drawing.Point(176, 13);
            this.pbMage.Name = "pbMage";
            this.pbMage.Size = new System.Drawing.Size(150, 150);
            this.pbMage.TabIndex = 0;
            this.pbMage.TabStop = false;
            // 
            // lblMoldTick
            // 
            this.lblMoldTick.AutoSize = true;
            this.lblMoldTick.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoldTick.Location = new System.Drawing.Point(27, 23);
            this.lblMoldTick.Name = "lblMoldTick";
            this.lblMoldTick.Size = new System.Drawing.Size(28, 16);
            this.lblMoldTick.TabIndex = 24;
            this.lblMoldTick.Text = "Tick";
            // 
            // pnlMold
            // 
            this.pnlMold.Controls.Add(this.lblMoldCount);
            this.pnlMold.Controls.Add(this.pbMoldIcon);
            this.pnlMold.Controls.Add(this.lblMoldTick);
            this.pnlMold.Location = new System.Drawing.Point(8, 58);
            this.pnlMold.Name = "pnlMold";
            this.pnlMold.Size = new System.Drawing.Size(75, 45);
            this.pnlMold.TabIndex = 26;
            // 
            // pnlZest
            // 
            this.pnlZest.Controls.Add(this.pbZestIcon);
            this.pnlZest.Controls.Add(this.lblZestTick);
            this.pnlZest.Controls.Add(this.lblZestCount);
            this.pnlZest.Location = new System.Drawing.Point(8, 104);
            this.pnlZest.Name = "pnlZest";
            this.pnlZest.Size = new System.Drawing.Size(75, 45);
            this.pnlZest.TabIndex = 27;
            // 
            // pbZestIcon
            // 
            this.pbZestIcon.Location = new System.Drawing.Point(3, 20);
            this.pbZestIcon.Name = "pbZestIcon";
            this.pbZestIcon.Size = new System.Drawing.Size(20, 20);
            this.pbZestIcon.TabIndex = 26;
            this.pbZestIcon.TabStop = false;
            // 
            // lblZestTick
            // 
            this.lblZestTick.AutoSize = true;
            this.lblZestTick.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZestTick.Location = new System.Drawing.Point(27, 23);
            this.lblZestTick.Name = "lblZestTick";
            this.lblZestTick.Size = new System.Drawing.Size(28, 16);
            this.lblZestTick.TabIndex = 24;
            this.lblZestTick.Text = "Tick";
            // 
            // pnlTension
            // 
            this.pnlTension.Controls.Add(this.pbTensionIcon);
            this.pnlTension.Controls.Add(this.lblTensionCount);
            this.pnlTension.Controls.Add(this.lblTensionTick);
            this.pnlTension.Location = new System.Drawing.Point(8, 150);
            this.pnlTension.Name = "pnlTension";
            this.pnlTension.Size = new System.Drawing.Size(75, 45);
            this.pnlTension.TabIndex = 27;
            // 
            // pbTensionIcon
            // 
            this.pbTensionIcon.Location = new System.Drawing.Point(3, 20);
            this.pbTensionIcon.Name = "pbTensionIcon";
            this.pbTensionIcon.Size = new System.Drawing.Size(20, 20);
            this.pbTensionIcon.TabIndex = 27;
            this.pbTensionIcon.TabStop = false;
            // 
            // lblTensionCount
            // 
            this.lblTensionCount.AutoSize = true;
            this.lblTensionCount.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTensionCount.Location = new System.Drawing.Point(1, 2);
            this.lblTensionCount.Name = "lblTensionCount";
            this.lblTensionCount.Size = new System.Drawing.Size(50, 18);
            this.lblTensionCount.TabIndex = 26;
            this.lblTensionCount.Text = "Tension";
            // 
            // lblTensionTick
            // 
            this.lblTensionTick.AutoSize = true;
            this.lblTensionTick.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTensionTick.Location = new System.Drawing.Point(27, 23);
            this.lblTensionTick.Name = "lblTensionTick";
            this.lblTensionTick.Size = new System.Drawing.Size(28, 16);
            this.lblTensionTick.TabIndex = 24;
            this.lblTensionTick.Text = "Tick";
            // 
            // lblMageName
            // 
            this.lblMageName.AutoSize = true;
            this.lblMageName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMageName.Location = new System.Drawing.Point(4, 3);
            this.lblMageName.Name = "lblMageName";
            this.lblMageName.Size = new System.Drawing.Size(48, 20);
            this.lblMageName.TabIndex = 28;
            this.lblMageName.Text = "Name";
            this.lblMageName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // barIngredients
            // 
            this.barIngredients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(53)))));
            this.barIngredients.Location = new System.Drawing.Point(222, 311);
            this.barIngredients.Name = "barIngredients";
            this.barIngredients.Size = new System.Drawing.Size(100, 12);
            this.barIngredients.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barIngredients.TabIndex = 29;
            // 
            // barCosmicEnergy
            // 
            this.barCosmicEnergy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(32)))), ((int)(((byte)(110)))));
            this.barCosmicEnergy.Location = new System.Drawing.Point(222, 356);
            this.barCosmicEnergy.Name = "barCosmicEnergy";
            this.barCosmicEnergy.Size = new System.Drawing.Size(100, 12);
            this.barCosmicEnergy.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barCosmicEnergy.TabIndex = 30;
            // 
            // barElementalMotes
            // 
            this.barElementalMotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(167)))), ((int)(((byte)(150)))));
            this.barElementalMotes.Location = new System.Drawing.Point(222, 401);
            this.barElementalMotes.Name = "barElementalMotes";
            this.barElementalMotes.Size = new System.Drawing.Size(100, 12);
            this.barElementalMotes.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barElementalMotes.TabIndex = 31;
            // 
            // BreadMage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barElementalMotes);
            this.Controls.Add(this.barCosmicEnergy);
            this.Controls.Add(this.barIngredients);
            this.Controls.Add(this.lblMageName);
            this.Controls.Add(this.pnlTension);
            this.Controls.Add(this.pnlZest);
            this.Controls.Add(this.pnlMold);
            this.Controls.Add(this.lblElementalMotes);
            this.Controls.Add(this.lblCosmicEnergy);
            this.Controls.Add(this.pbElementalMotesIcon);
            this.Controls.Add(this.pbIngredientsIcon);
            this.Controls.Add(this.pbCosmicEnergyIcon);
            this.Controls.Add(this.lblIngredients);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblYeast);
            this.Controls.Add(this.pnBuffs);
            this.Controls.Add(this.lblMPDisplay);
            this.Controls.Add(this.lblHPDisplay);
            this.Controls.Add(this.pbMP);
            this.Controls.Add(this.pbHP);
            this.Controls.Add(this.pbMage);
            this.Name = "BreadMage";
            this.Size = new System.Drawing.Size(350, 450);
            this.pnBuffs.ResumeLayout(false);
            this.pnBuffs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEffectIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbElementalMotesIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIngredientsIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCosmicEnergyIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoldIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMage)).EndInit();
            this.pnlMold.ResumeLayout(false);
            this.pnlMold.PerformLayout();
            this.pnlZest.ResumeLayout(false);
            this.pnlZest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZestIcon)).EndInit();
            this.pnlTension.ResumeLayout(false);
            this.pnlTension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTensionIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMage;
        public System.Windows.Forms.ProgressBar pbHP;
        public System.Windows.Forms.ProgressBar pbMP;
        private System.Windows.Forms.Label lblHPDisplay;
        private System.Windows.Forms.Label lblMPDisplay;
        private System.Windows.Forms.Label lblMoldCount;
        private System.Windows.Forms.PictureBox pbMoldIcon;
        private System.Windows.Forms.Label lblZestCount;
        private System.Windows.Forms.Panel pnBuffs;
        private System.Windows.Forms.Label lblYeast;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblElementalMotes;
        private System.Windows.Forms.Label lblCosmicEnergy;
        private System.Windows.Forms.PictureBox pbElementalMotesIcon;
        private System.Windows.Forms.PictureBox pbIngredientsIcon;
        private System.Windows.Forms.PictureBox pbCosmicEnergyIcon;
        private System.Windows.Forms.Label lblIngredients;
        private System.Windows.Forms.Label lblMoldTick;
        private System.Windows.Forms.Panel pnlMold;
        private System.Windows.Forms.Panel pnlZest;
        private System.Windows.Forms.PictureBox pbZestIcon;
        private System.Windows.Forms.Label lblZestTick;
        private System.Windows.Forms.Panel pnlTension;
        private System.Windows.Forms.PictureBox pbTensionIcon;
        private System.Windows.Forms.Label lblTensionCount;
        private System.Windows.Forms.Label lblTensionTick;
        private System.Windows.Forms.Label lblMageName;
        private System.Windows.Forms.ListBox boxSpells;
        private System.Windows.Forms.RadioButton radioEffects;
        private System.Windows.Forms.RadioButton radioPassives;
        private System.Windows.Forms.Label lblEffect;
        private System.Windows.Forms.PictureBox pbEffectIcon;
        private System.Windows.Forms.ProgressBar barIngredients;
        private System.Windows.Forms.ProgressBar barCosmicEnergy;
        private System.Windows.Forms.ProgressBar barElementalMotes;
    }
}
