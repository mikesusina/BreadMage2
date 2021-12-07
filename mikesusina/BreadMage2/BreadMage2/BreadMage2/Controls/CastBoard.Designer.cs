namespace BreadMage2.Controls
{
    partial class CastBoard
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTier = new System.Windows.Forms.Label();
            this.cbTier = new System.Windows.Forms.ComboBox();
            this.lbSpellName = new System.Windows.Forms.Label();
            this.lbActiveSP = new System.Windows.Forms.Label();
            this.rtbSpellDesc = new System.Windows.Forms.RichTextBox();
            this.boxPassives = new System.Windows.Forms.ListBox();
            this.btnCast = new System.Windows.Forms.Button();
            this.boxSpells = new System.Windows.Forms.ListBox();
            this.barActivePoints = new System.Windows.Forms.ProgressBar();
            this.tkCombatSpells = new System.Windows.Forms.CheckBox();
            this.pnlSpellSwitcher = new System.Windows.Forms.Panel();
            this.radioItems = new System.Windows.Forms.RadioButton();
            this.radioSpells = new System.Windows.Forms.RadioButton();
            this.pnlSPBar = new System.Windows.Forms.Panel();
            this.pnlComponents = new System.Windows.Forms.Panel();
            this.lblElementalMotes = new System.Windows.Forms.Label();
            this.lblCosmicEnergy = new System.Windows.Forms.Label();
            this.lblIngredients = new System.Windows.Forms.Label();
            this.pbElementalMotesIcon = new System.Windows.Forms.PictureBox();
            this.pbIngredientsIcon = new System.Windows.Forms.PictureBox();
            this.pbCosmicEnergyIcon = new System.Windows.Forms.PictureBox();
            this.pbSpellIcon = new System.Windows.Forms.PictureBox();
            this.pnlSpellSwitcher.SuspendLayout();
            this.pnlSPBar.SuspendLayout();
            this.pnlComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbElementalMotesIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIngredientsIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCosmicEnergyIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpellIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(322, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 51);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(322, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 51);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lbTier
            // 
            this.lbTier.AutoSize = true;
            this.lbTier.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTier.Location = new System.Drawing.Point(136, 175);
            this.lbTier.Name = "lbTier";
            this.lbTier.Size = new System.Drawing.Size(30, 18);
            this.lbTier.TabIndex = 28;
            this.lbTier.Text = "Tier";
            // 
            // cbTier
            // 
            this.cbTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTier.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTier.FormattingEnabled = true;
            this.cbTier.Location = new System.Drawing.Point(132, 197);
            this.cbTier.Name = "cbTier";
            this.cbTier.Size = new System.Drawing.Size(39, 26);
            this.cbTier.TabIndex = 27;
            // 
            // lbSpellName
            // 
            this.lbSpellName.AutoSize = true;
            this.lbSpellName.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpellName.Location = new System.Drawing.Point(328, 175);
            this.lbSpellName.Name = "lbSpellName";
            this.lbSpellName.Size = new System.Drawing.Size(68, 18);
            this.lbSpellName.TabIndex = 26;
            this.lbSpellName.Text = "SpellName";
            // 
            // lbActiveSP
            // 
            this.lbActiveSP.AutoSize = true;
            this.lbActiveSP.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActiveSP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbActiveSP.Location = new System.Drawing.Point(20, 1);
            this.lbActiveSP.Name = "lbActiveSP";
            this.lbActiveSP.Size = new System.Drawing.Size(142, 18);
            this.lbActiveSP.TabIndex = 25;
            this.lbActiveSP.Text = "Active Skill Points: X/Y";
            // 
            // rtbSpellDesc
            // 
            this.rtbSpellDesc.BackColor = System.Drawing.Color.Black;
            this.rtbSpellDesc.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSpellDesc.ForeColor = System.Drawing.Color.Lime;
            this.rtbSpellDesc.Location = new System.Drawing.Point(235, 230);
            this.rtbSpellDesc.Name = "rtbSpellDesc";
            this.rtbSpellDesc.Size = new System.Drawing.Size(215, 141);
            this.rtbSpellDesc.TabIndex = 23;
            this.rtbSpellDesc.Text = "";
            // 
            // boxPassives
            // 
            this.boxPassives.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxPassives.FormattingEnabled = true;
            this.boxPassives.ItemHeight = 20;
            this.boxPassives.Location = new System.Drawing.Point(13, 397);
            this.boxPassives.Name = "boxPassives";
            this.boxPassives.Size = new System.Drawing.Size(210, 164);
            this.boxPassives.TabIndex = 22;
            this.boxPassives.SelectedIndexChanged += new System.EventHandler(this.boxPassives_SelectedIndexChanged);
            this.boxPassives.Enter += new System.EventHandler(this.boxPassives_Enter);
            // 
            // btnCast
            // 
            this.btnCast.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCast.Location = new System.Drawing.Point(35, 172);
            this.btnCast.Name = "btnCast";
            this.btnCast.Size = new System.Drawing.Size(91, 51);
            this.btnCast.TabIndex = 21;
            this.btnCast.Text = "Cast";
            this.btnCast.UseVisualStyleBackColor = true;
            // 
            // boxSpells
            // 
            this.boxSpells.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSpells.FormattingEnabled = true;
            this.boxSpells.ItemHeight = 20;
            this.boxSpells.Location = new System.Drawing.Point(35, 33);
            this.boxSpells.Name = "boxSpells";
            this.boxSpells.Size = new System.Drawing.Size(361, 124);
            this.boxSpells.TabIndex = 20;
            this.boxSpells.SelectedIndexChanged += new System.EventHandler(this.boxSpells_SelectedIndexChanged);
            this.boxSpells.Enter += new System.EventHandler(this.boxSpells_Enter);
            // 
            // barActivePoints
            // 
            this.barActivePoints.ForeColor = System.Drawing.Color.Lime;
            this.barActivePoints.Location = new System.Drawing.Point(3, 22);
            this.barActivePoints.Name = "barActivePoints";
            this.barActivePoints.Size = new System.Drawing.Size(175, 20);
            this.barActivePoints.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barActivePoints.TabIndex = 32;
            // 
            // tkCombatSpells
            // 
            this.tkCombatSpells.AutoSize = true;
            this.tkCombatSpells.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tkCombatSpells.Location = new System.Drawing.Point(163, 8);
            this.tkCombatSpells.Name = "tkCombatSpells";
            this.tkCombatSpells.Size = new System.Drawing.Size(136, 22);
            this.tkCombatSpells.TabIndex = 33;
            this.tkCombatSpells.Text = "Show Combat Spells";
            this.tkCombatSpells.UseVisualStyleBackColor = true;
            this.tkCombatSpells.CheckedChanged += new System.EventHandler(this.tkCombatSpells_CheckedChanged);
            // 
            // pnlSpellSwitcher
            // 
            this.pnlSpellSwitcher.Controls.Add(this.radioItems);
            this.pnlSpellSwitcher.Controls.Add(this.radioSpells);
            this.pnlSpellSwitcher.Location = new System.Drawing.Point(35, 1);
            this.pnlSpellSwitcher.Name = "pnlSpellSwitcher";
            this.pnlSpellSwitcher.Size = new System.Drawing.Size(125, 32);
            this.pnlSpellSwitcher.TabIndex = 34;
            // 
            // radioItems
            // 
            this.radioItems.AutoSize = true;
            this.radioItems.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioItems.Location = new System.Drawing.Point(63, 7);
            this.radioItems.Name = "radioItems";
            this.radioItems.Size = new System.Drawing.Size(59, 22);
            this.radioItems.TabIndex = 1;
            this.radioItems.TabStop = true;
            this.radioItems.Text = "Items";
            this.radioItems.UseVisualStyleBackColor = true;
            this.radioItems.CheckedChanged += new System.EventHandler(this.radioItems_CheckedChanged);
            // 
            // radioSpells
            // 
            this.radioSpells.AutoSize = true;
            this.radioSpells.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSpells.Location = new System.Drawing.Point(3, 7);
            this.radioSpells.Name = "radioSpells";
            this.radioSpells.Size = new System.Drawing.Size(59, 22);
            this.radioSpells.TabIndex = 0;
            this.radioSpells.TabStop = true;
            this.radioSpells.Text = "Spells";
            this.radioSpells.UseVisualStyleBackColor = true;
            this.radioSpells.CheckedChanged += new System.EventHandler(this.radioSpells_CheckedChanged);
            // 
            // pnlSPBar
            // 
            this.pnlSPBar.Controls.Add(this.barActivePoints);
            this.pnlSPBar.Controls.Add(this.lbActiveSP);
            this.pnlSPBar.Location = new System.Drawing.Point(26, 254);
            this.pnlSPBar.Name = "pnlSPBar";
            this.pnlSPBar.Size = new System.Drawing.Size(182, 51);
            this.pnlSPBar.TabIndex = 36;
            // 
            // pnlComponents
            // 
            this.pnlComponents.Controls.Add(this.lblElementalMotes);
            this.pnlComponents.Controls.Add(this.lblCosmicEnergy);
            this.pnlComponents.Controls.Add(this.pbElementalMotesIcon);
            this.pnlComponents.Controls.Add(this.pbIngredientsIcon);
            this.pnlComponents.Controls.Add(this.pbCosmicEnergyIcon);
            this.pnlComponents.Controls.Add(this.lblIngredients);
            this.pnlComponents.Location = new System.Drawing.Point(25, 233);
            this.pnlComponents.Name = "pnlComponents";
            this.pnlComponents.Size = new System.Drawing.Size(178, 94);
            this.pnlComponents.TabIndex = 37;
            // 
            // lblElementalMotes
            // 
            this.lblElementalMotes.AutoSize = true;
            this.lblElementalMotes.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElementalMotes.Location = new System.Drawing.Point(37, 68);
            this.lblElementalMotes.Name = "lblElementalMotes";
            this.lblElementalMotes.Size = new System.Drawing.Size(99, 18);
            this.lblElementalMotes.TabIndex = 26;
            this.lblElementalMotes.Text = "Elemental Motes";
            // 
            // lblCosmicEnergy
            // 
            this.lblCosmicEnergy.AutoSize = true;
            this.lblCosmicEnergy.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosmicEnergy.Location = new System.Drawing.Point(37, 39);
            this.lblCosmicEnergy.Name = "lblCosmicEnergy";
            this.lblCosmicEnergy.Size = new System.Drawing.Size(87, 18);
            this.lblCosmicEnergy.TabIndex = 25;
            this.lblCosmicEnergy.Text = "Cosmic Energy";
            // 
            // lblIngredients
            // 
            this.lblIngredients.AutoSize = true;
            this.lblIngredients.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredients.Location = new System.Drawing.Point(37, 8);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(70, 18);
            this.lblIngredients.TabIndex = 21;
            this.lblIngredients.Text = "Ingredients";
            // 
            // pbElementalMotesIcon
            // 
            this.pbElementalMotesIcon.Location = new System.Drawing.Point(7, 68);
            this.pbElementalMotesIcon.Name = "pbElementalMotesIcon";
            this.pbElementalMotesIcon.Size = new System.Drawing.Size(20, 20);
            this.pbElementalMotesIcon.TabIndex = 24;
            this.pbElementalMotesIcon.TabStop = false;
            // 
            // pbIngredientsIcon
            // 
            this.pbIngredientsIcon.Location = new System.Drawing.Point(7, 8);
            this.pbIngredientsIcon.Name = "pbIngredientsIcon";
            this.pbIngredientsIcon.Size = new System.Drawing.Size(20, 20);
            this.pbIngredientsIcon.TabIndex = 23;
            this.pbIngredientsIcon.TabStop = false;
            // 
            // pbCosmicEnergyIcon
            // 
            this.pbCosmicEnergyIcon.Location = new System.Drawing.Point(7, 39);
            this.pbCosmicEnergyIcon.Name = "pbCosmicEnergyIcon";
            this.pbCosmicEnergyIcon.Size = new System.Drawing.Size(20, 20);
            this.pbCosmicEnergyIcon.TabIndex = 22;
            this.pbCosmicEnergyIcon.TabStop = false;
            // 
            // pbSpellIcon
            // 
            this.pbSpellIcon.Location = new System.Drawing.Point(272, 172);
            this.pbSpellIcon.Name = "pbSpellIcon";
            this.pbSpellIcon.Size = new System.Drawing.Size(50, 50);
            this.pbSpellIcon.TabIndex = 24;
            this.pbSpellIcon.TabStop = false;
            // 
            // CastBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlComponents);
            this.Controls.Add(this.pnlSPBar);
            this.Controls.Add(this.pnlSpellSwitcher);
            this.Controls.Add(this.tkCombatSpells);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTier);
            this.Controls.Add(this.cbTier);
            this.Controls.Add(this.lbSpellName);
            this.Controls.Add(this.pbSpellIcon);
            this.Controls.Add(this.rtbSpellDesc);
            this.Controls.Add(this.boxPassives);
            this.Controls.Add(this.btnCast);
            this.Controls.Add(this.boxSpells);
            this.Name = "CastBoard";
            this.Size = new System.Drawing.Size(450, 585);
            this.pnlSpellSwitcher.ResumeLayout(false);
            this.pnlSpellSwitcher.PerformLayout();
            this.pnlSPBar.ResumeLayout(false);
            this.pnlSPBar.PerformLayout();
            this.pnlComponents.ResumeLayout(false);
            this.pnlComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbElementalMotesIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIngredientsIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCosmicEnergyIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpellIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTier;
        private System.Windows.Forms.ComboBox cbTier;
        private System.Windows.Forms.Label lbSpellName;
        private System.Windows.Forms.Label lbActiveSP;
        private System.Windows.Forms.PictureBox pbSpellIcon;
        private System.Windows.Forms.RichTextBox rtbSpellDesc;
        private System.Windows.Forms.ListBox boxPassives;
        private System.Windows.Forms.Button btnCast;
        private System.Windows.Forms.ListBox boxSpells;
        private System.Windows.Forms.ProgressBar barActivePoints;
        private System.Windows.Forms.CheckBox tkCombatSpells;
        private System.Windows.Forms.Panel pnlSpellSwitcher;
        private System.Windows.Forms.RadioButton radioItems;
        private System.Windows.Forms.RadioButton radioSpells;
        private System.Windows.Forms.Panel pnlSPBar;
        private System.Windows.Forms.Panel pnlComponents;
        private System.Windows.Forms.Label lblElementalMotes;
        private System.Windows.Forms.Label lblCosmicEnergy;
        private System.Windows.Forms.PictureBox pbElementalMotesIcon;
        private System.Windows.Forms.PictureBox pbIngredientsIcon;
        private System.Windows.Forms.PictureBox pbCosmicEnergyIcon;
        private System.Windows.Forms.Label lblIngredients;
    }
}
