namespace BreadMage2.Controls
{
    partial class FightBoard
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
            this.btnMAtk = new System.Windows.Forms.Button();
            this.btnDef = new System.Windows.Forms.Button();
            this.btnCast = new System.Windows.Forms.Button();
            this.pbMonHP = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChatter = new System.Windows.Forms.TextBox();
            this.rtbChatter = new System.Windows.Forms.RichTextBox();
            this.lstSpellBook = new System.Windows.Forms.ComboBox();
            this.lstSpellTier = new System.Windows.Forms.ComboBox();
            this.cbxMaxSpellTier = new System.Windows.Forms.CheckBox();
            this.btnItem = new System.Windows.Forms.Button();
            this.lstItem = new System.Windows.Forms.ComboBox();
            this.lblMoldCounter = new System.Windows.Forms.Label();
            this.lblZestCounter = new System.Windows.Forms.Label();
            this.lblTensionCounter = new System.Windows.Forms.Label();
            this.rtbSpellBox = new System.Windows.Forms.RichTextBox();
            this.lbActiveSP = new System.Windows.Forms.Label();
            this.boxSpells = new System.Windows.Forms.ListBox();
            this.radioSpells = new System.Windows.Forms.RadioButton();
            this.radioItems = new System.Windows.Forms.RadioButton();
            this.lblElementalMotes = new System.Windows.Forms.Label();
            this.lblIngredients = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barActivePoints = new System.Windows.Forms.ProgressBar();
            this.pbActionDisplay = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbZestIcon = new System.Windows.Forms.PictureBox();
            this.pbMoldIcon = new System.Windows.Forms.PictureBox();
            this.btnPAtk = new System.Windows.Forms.Button();
            this.pbMonster = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbActionDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZestIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoldIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMAtk
            // 
            this.btnMAtk.Image = global::BreadMage2.Properties.Resources.matk;
            this.btnMAtk.Location = new System.Drawing.Point(102, 225);
            this.btnMAtk.Name = "btnMAtk";
            this.btnMAtk.Size = new System.Drawing.Size(45, 45);
            this.btnMAtk.TabIndex = 2;
            this.btnMAtk.UseVisualStyleBackColor = true;
            this.btnMAtk.Click += new System.EventHandler(this.btnMAtk_Click);
            // 
            // btnDef
            // 
            this.btnDef.Image = global::BreadMage2.Properties.Resources.defend;
            this.btnDef.Location = new System.Drawing.Point(175, 225);
            this.btnDef.Name = "btnDef";
            this.btnDef.Size = new System.Drawing.Size(45, 45);
            this.btnDef.TabIndex = 3;
            this.btnDef.UseVisualStyleBackColor = true;
            this.btnDef.Click += new System.EventHandler(this.btnDef_Click);
            // 
            // btnCast
            // 
            this.btnCast.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCast.Location = new System.Drawing.Point(12, 306);
            this.btnCast.Name = "btnCast";
            this.btnCast.Size = new System.Drawing.Size(68, 37);
            this.btnCast.TabIndex = 4;
            this.btnCast.Text = "Cast";
            this.btnCast.UseVisualStyleBackColor = true;
            this.btnCast.Click += new System.EventHandler(this.btnSpell_Click);
            // 
            // pbMonHP
            // 
            this.pbMonHP.BackColor = System.Drawing.SystemColors.Control;
            this.pbMonHP.ForeColor = System.Drawing.Color.Red;
            this.pbMonHP.Location = new System.Drawing.Point(250, 31);
            this.pbMonHP.Name = "pbMonHP";
            this.pbMonHP.Size = new System.Drawing.Size(177, 26);
            this.pbMonHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMonHP.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // txtChatter
            // 
            this.txtChatter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtChatter.BackColor = System.Drawing.Color.Black;
            this.txtChatter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatter.ForeColor = System.Drawing.Color.Lime;
            this.txtChatter.Location = new System.Drawing.Point(410, 3);
            this.txtChatter.Multiline = true;
            this.txtChatter.Name = "txtChatter";
            this.txtChatter.ReadOnly = true;
            this.txtChatter.Size = new System.Drawing.Size(27, 22);
            this.txtChatter.TabIndex = 8;
            // 
            // rtbChatter
            // 
            this.rtbChatter.BackColor = System.Drawing.Color.Black;
            this.rtbChatter.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChatter.ForeColor = System.Drawing.Color.Lime;
            this.rtbChatter.HideSelection = false;
            this.rtbChatter.Location = new System.Drawing.Point(12, 396);
            this.rtbChatter.Name = "rtbChatter";
            this.rtbChatter.ReadOnly = true;
            this.rtbChatter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbChatter.Size = new System.Drawing.Size(418, 179);
            this.rtbChatter.TabIndex = 9;
            this.rtbChatter.Text = "";
            // 
            // lstSpellBook
            // 
            this.lstSpellBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstSpellBook.FormattingEnabled = true;
            this.lstSpellBook.IntegralHeight = false;
            this.lstSpellBook.Location = new System.Drawing.Point(329, 5);
            this.lstSpellBook.Name = "lstSpellBook";
            this.lstSpellBook.Size = new System.Drawing.Size(35, 21);
            this.lstSpellBook.TabIndex = 10;
            this.lstSpellBook.SelectedIndexChanged += new System.EventHandler(this.lstSpellBook_SelectedIndexChanged);
            // 
            // lstSpellTier
            // 
            this.lstSpellTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstSpellTier.FormattingEnabled = true;
            this.lstSpellTier.Location = new System.Drawing.Point(12, 369);
            this.lstSpellTier.Name = "lstSpellTier";
            this.lstSpellTier.Size = new System.Drawing.Size(61, 21);
            this.lstSpellTier.TabIndex = 11;
            // 
            // cbxMaxSpellTier
            // 
            this.cbxMaxSpellTier.AutoSize = true;
            this.cbxMaxSpellTier.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaxSpellTier.Location = new System.Drawing.Point(12, 349);
            this.cbxMaxSpellTier.Name = "cbxMaxSpellTier";
            this.cbxMaxSpellTier.Size = new System.Drawing.Size(70, 20);
            this.cbxMaxSpellTier.TabIndex = 12;
            this.cbxMaxSpellTier.Text = "Max Tier";
            this.cbxMaxSpellTier.UseVisualStyleBackColor = true;
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(289, 4);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(34, 21);
            this.btnItem.TabIndex = 13;
            this.btnItem.Text = "Item";
            this.btnItem.UseVisualStyleBackColor = true;
            // 
            // lstItem
            // 
            this.lstItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstItem.FormattingEnabled = true;
            this.lstItem.Location = new System.Drawing.Point(370, 5);
            this.lstItem.Name = "lstItem";
            this.lstItem.Size = new System.Drawing.Size(44, 21);
            this.lstItem.TabIndex = 14;
            this.lstItem.SelectedIndexChanged += new System.EventHandler(this.lstItem_SelectedIndexChanged);
            // 
            // lblMoldCounter
            // 
            this.lblMoldCounter.AutoSize = true;
            this.lblMoldCounter.Location = new System.Drawing.Point(265, 96);
            this.lblMoldCounter.Name = "lblMoldCounter";
            this.lblMoldCounter.Size = new System.Drawing.Size(25, 13);
            this.lblMoldCounter.TabIndex = 21;
            this.lblMoldCounter.Text = "100";
            this.lblMoldCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblZestCounter
            // 
            this.lblZestCounter.AutoSize = true;
            this.lblZestCounter.Location = new System.Drawing.Point(324, 96);
            this.lblZestCounter.Name = "lblZestCounter";
            this.lblZestCounter.Size = new System.Drawing.Size(25, 13);
            this.lblZestCounter.TabIndex = 22;
            this.lblZestCounter.Text = "100";
            this.lblZestCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTensionCounter
            // 
            this.lblTensionCounter.AutoSize = true;
            this.lblTensionCounter.Location = new System.Drawing.Point(389, 96);
            this.lblTensionCounter.Name = "lblTensionCounter";
            this.lblTensionCounter.Size = new System.Drawing.Size(25, 13);
            this.lblTensionCounter.TabIndex = 23;
            this.lblTensionCounter.Text = "100";
            this.lblTensionCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rtbSpellBox
            // 
            this.rtbSpellBox.BackColor = System.Drawing.Color.Black;
            this.rtbSpellBox.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSpellBox.ForeColor = System.Drawing.Color.White;
            this.rtbSpellBox.Location = new System.Drawing.Point(256, 170);
            this.rtbSpellBox.Name = "rtbSpellBox";
            this.rtbSpellBox.Size = new System.Drawing.Size(191, 100);
            this.rtbSpellBox.TabIndex = 24;
            this.rtbSpellBox.Text = "";
            // 
            // lbActiveSP
            // 
            this.lbActiveSP.AutoSize = true;
            this.lbActiveSP.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActiveSP.ForeColor = System.Drawing.Color.Red;
            this.lbActiveSP.Location = new System.Drawing.Point(301, 338);
            this.lbActiveSP.Name = "lbActiveSP";
            this.lbActiveSP.Size = new System.Drawing.Size(94, 18);
            this.lbActiveSP.TabIndex = 34;
            this.lbActiveSP.Text = "Skill Points: X/Y";
            // 
            // boxSpells
            // 
            this.boxSpells.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSpells.FormattingEnabled = true;
            this.boxSpells.ItemHeight = 20;
            this.boxSpells.Location = new System.Drawing.Point(88, 306);
            this.boxSpells.Name = "boxSpells";
            this.boxSpells.Size = new System.Drawing.Size(182, 84);
            this.boxSpells.TabIndex = 33;
            // 
            // radioSpells
            // 
            this.radioSpells.AutoSize = true;
            this.radioSpells.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSpells.Location = new System.Drawing.Point(3, 5);
            this.radioSpells.Name = "radioSpells";
            this.radioSpells.Size = new System.Drawing.Size(57, 22);
            this.radioSpells.TabIndex = 37;
            this.radioSpells.TabStop = true;
            this.radioSpells.Text = "Spells";
            this.radioSpells.UseVisualStyleBackColor = true;
            this.radioSpells.CheckedChanged += new System.EventHandler(this.radioSpells_CheckedChanged);
            // 
            // radioItems
            // 
            this.radioItems.AutoSize = true;
            this.radioItems.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioItems.Location = new System.Drawing.Point(61, 5);
            this.radioItems.Name = "radioItems";
            this.radioItems.Size = new System.Drawing.Size(55, 22);
            this.radioItems.TabIndex = 38;
            this.radioItems.TabStop = true;
            this.radioItems.Text = "Items";
            this.radioItems.UseVisualStyleBackColor = true;
            this.radioItems.CheckedChanged += new System.EventHandler(this.radioItems_CheckedChanged);
            // 
            // lblElementalMotes
            // 
            this.lblElementalMotes.AutoSize = true;
            this.lblElementalMotes.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElementalMotes.ForeColor = System.Drawing.Color.Red;
            this.lblElementalMotes.Location = new System.Drawing.Point(301, 365);
            this.lblElementalMotes.Name = "lblElementalMotes";
            this.lblElementalMotes.Size = new System.Drawing.Size(114, 18);
            this.lblElementalMotes.TabIndex = 40;
            this.lblElementalMotes.Text = "Elemental Motes: X";
            this.lblElementalMotes.Visible = false;
            // 
            // lblIngredients
            // 
            this.lblIngredients.AutoSize = true;
            this.lblIngredients.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngredients.ForeColor = System.Drawing.Color.Red;
            this.lblIngredients.Location = new System.Drawing.Point(301, 311);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(85, 18);
            this.lblIngredients.TabIndex = 42;
            this.lblIngredients.Text = "Ingredients: X";
            this.lblIngredients.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioSpells);
            this.panel1.Controls.Add(this.radioItems);
            this.panel1.Location = new System.Drawing.Point(88, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 30);
            this.panel1.TabIndex = 43;
            // 
            // barActivePoints
            // 
            this.barActivePoints.ForeColor = System.Drawing.Color.Lime;
            this.barActivePoints.Location = new System.Drawing.Point(283, 322);
            this.barActivePoints.Name = "barActivePoints";
            this.barActivePoints.Size = new System.Drawing.Size(147, 15);
            this.barActivePoints.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barActivePoints.TabIndex = 36;
            // 
            // pbActionDisplay
            // 
            this.pbActionDisplay.Location = new System.Drawing.Point(326, 112);
            this.pbActionDisplay.Name = "pbActionDisplay";
            this.pbActionDisplay.Size = new System.Drawing.Size(50, 50);
            this.pbActionDisplay.TabIndex = 25;
            this.pbActionDisplay.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(389, 68);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // pbZestIcon
            // 
            this.pbZestIcon.Location = new System.Drawing.Point(325, 68);
            this.pbZestIcon.Name = "pbZestIcon";
            this.pbZestIcon.Size = new System.Drawing.Size(25, 25);
            this.pbZestIcon.TabIndex = 19;
            this.pbZestIcon.TabStop = false;
            // 
            // pbMoldIcon
            // 
            this.pbMoldIcon.Location = new System.Drawing.Point(266, 68);
            this.pbMoldIcon.Name = "pbMoldIcon";
            this.pbMoldIcon.Size = new System.Drawing.Size(25, 25);
            this.pbMoldIcon.TabIndex = 18;
            this.pbMoldIcon.TabStop = false;
            // 
            // btnPAtk
            // 
            this.btnPAtk.Image = global::BreadMage2.Properties.Resources.patk;
            this.btnPAtk.Location = new System.Drawing.Point(35, 225);
            this.btnPAtk.Name = "btnPAtk";
            this.btnPAtk.Size = new System.Drawing.Size(45, 45);
            this.btnPAtk.TabIndex = 1;
            this.btnPAtk.UseVisualStyleBackColor = true;
            this.btnPAtk.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // pbMonster
            // 
            this.pbMonster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbMonster.Location = new System.Drawing.Point(30, 15);
            this.pbMonster.Name = "pbMonster";
            this.pbMonster.Size = new System.Drawing.Size(200, 200);
            this.pbMonster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMonster.TabIndex = 0;
            this.pbMonster.TabStop = false;
            // 
            // FightBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblIngredients);
            this.Controls.Add(this.lblElementalMotes);
            this.Controls.Add(this.barActivePoints);
            this.Controls.Add(this.lbActiveSP);
            this.Controls.Add(this.boxSpells);
            this.Controls.Add(this.pbActionDisplay);
            this.Controls.Add(this.rtbSpellBox);
            this.Controls.Add(this.lblTensionCounter);
            this.Controls.Add(this.lblZestCounter);
            this.Controls.Add(this.lblMoldCounter);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pbZestIcon);
            this.Controls.Add(this.pbMoldIcon);
            this.Controls.Add(this.lstItem);
            this.Controls.Add(this.btnItem);
            this.Controls.Add(this.cbxMaxSpellTier);
            this.Controls.Add(this.lstSpellTier);
            this.Controls.Add(this.lstSpellBook);
            this.Controls.Add(this.rtbChatter);
            this.Controls.Add(this.txtChatter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbMonHP);
            this.Controls.Add(this.btnCast);
            this.Controls.Add(this.btnDef);
            this.Controls.Add(this.btnMAtk);
            this.Controls.Add(this.btnPAtk);
            this.Controls.Add(this.pbMonster);
            this.Name = "FightBoard";
            this.Size = new System.Drawing.Size(450, 585);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbActionDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZestIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoldIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMonster;
        private System.Windows.Forms.Button btnPAtk;
        private System.Windows.Forms.Button btnMAtk;
        private System.Windows.Forms.Button btnDef;
        private System.Windows.Forms.Button btnCast;
        public System.Windows.Forms.ProgressBar pbMonHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChatter;
        private System.Windows.Forms.RichTextBox rtbChatter;
        private System.Windows.Forms.ComboBox lstSpellBook;
        private System.Windows.Forms.ComboBox lstSpellTier;
        private System.Windows.Forms.CheckBox cbxMaxSpellTier;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.ComboBox lstItem;
        private System.Windows.Forms.PictureBox pbMoldIcon;
        private System.Windows.Forms.PictureBox pbZestIcon;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblMoldCounter;
        private System.Windows.Forms.Label lblZestCounter;
        private System.Windows.Forms.Label lblTensionCounter;
        private System.Windows.Forms.RichTextBox rtbSpellBox;
        private System.Windows.Forms.PictureBox pbActionDisplay;
        private System.Windows.Forms.Label lbActiveSP;
        private System.Windows.Forms.ListBox boxSpells;
        private System.Windows.Forms.RadioButton radioSpells;
        private System.Windows.Forms.RadioButton radioItems;
        private System.Windows.Forms.Label lblElementalMotes;
        private System.Windows.Forms.Label lblIngredients;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar barActivePoints;
    }
}
