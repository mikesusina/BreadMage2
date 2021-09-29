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
            this.pbMonster = new System.Windows.Forms.PictureBox();
            this.btnPAtk = new System.Windows.Forms.Button();
            this.btnMAtk = new System.Windows.Forms.Button();
            this.btnDef = new System.Windows.Forms.Button();
            this.btnSpell = new System.Windows.Forms.Button();
            this.pbMonHP = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChatter = new System.Windows.Forms.TextBox();
            this.rtbChatter = new System.Windows.Forms.RichTextBox();
            this.lstSpellBook = new System.Windows.Forms.ComboBox();
            this.lstSpellTier = new System.Windows.Forms.ComboBox();
            this.cbxMaxSpellTier = new System.Windows.Forms.CheckBox();
            this.btnItem = new System.Windows.Forms.Button();
            this.lstItem = new System.Windows.Forms.ComboBox();
            this.lstItemTier = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pbMoldIcon = new System.Windows.Forms.PictureBox();
            this.pbZestIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblMoldCounter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbSpellBox = new System.Windows.Forms.RichTextBox();
            this.pbActionDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoldIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZestIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActionDisplay)).BeginInit();
            this.SuspendLayout();
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
            // btnPAtk
            // 
            this.btnPAtk.Location = new System.Drawing.Point(30, 230);
            this.btnPAtk.Name = "btnPAtk";
            this.btnPAtk.Size = new System.Drawing.Size(50, 50);
            this.btnPAtk.TabIndex = 1;
            this.btnPAtk.Text = "P Attack";
            this.btnPAtk.UseVisualStyleBackColor = true;
            this.btnPAtk.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // btnMAtk
            // 
            this.btnMAtk.Location = new System.Drawing.Point(105, 230);
            this.btnMAtk.Name = "btnMAtk";
            this.btnMAtk.Size = new System.Drawing.Size(50, 50);
            this.btnMAtk.TabIndex = 2;
            this.btnMAtk.Text = "M Attack";
            this.btnMAtk.UseVisualStyleBackColor = true;
            this.btnMAtk.Click += new System.EventHandler(this.btnMAtk_Click);
            // 
            // btnDef
            // 
            this.btnDef.Location = new System.Drawing.Point(180, 230);
            this.btnDef.Name = "btnDef";
            this.btnDef.Size = new System.Drawing.Size(50, 50);
            this.btnDef.TabIndex = 3;
            this.btnDef.Text = "Defend";
            this.btnDef.UseVisualStyleBackColor = true;
            this.btnDef.Click += new System.EventHandler(this.btnDef_Click);
            // 
            // btnSpell
            // 
            this.btnSpell.Location = new System.Drawing.Point(12, 301);
            this.btnSpell.Name = "btnSpell";
            this.btnSpell.Size = new System.Drawing.Size(68, 21);
            this.btnSpell.TabIndex = 4;
            this.btnSpell.Text = "Spell";
            this.btnSpell.UseVisualStyleBackColor = true;
            this.btnSpell.Click += new System.EventHandler(this.btnSpell_Click);
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
            this.lstSpellBook.Location = new System.Drawing.Point(86, 301);
            this.lstSpellBook.Name = "lstSpellBook";
            this.lstSpellBook.Size = new System.Drawing.Size(214, 21);
            this.lstSpellBook.TabIndex = 10;
            this.lstSpellBook.SelectedIndexChanged += new System.EventHandler(this.lstSpellBook_SelectedIndexChanged);
            // 
            // lstSpellTier
            // 
            this.lstSpellTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstSpellTier.FormattingEnabled = true;
            this.lstSpellTier.Location = new System.Drawing.Point(306, 301);
            this.lstSpellTier.Name = "lstSpellTier";
            this.lstSpellTier.Size = new System.Drawing.Size(55, 21);
            this.lstSpellTier.TabIndex = 11;
            // 
            // cbxMaxSpellTier
            // 
            this.cbxMaxSpellTier.AutoSize = true;
            this.cbxMaxSpellTier.Location = new System.Drawing.Point(370, 303);
            this.cbxMaxSpellTier.Name = "cbxMaxSpellTier";
            this.cbxMaxSpellTier.Size = new System.Drawing.Size(67, 17);
            this.cbxMaxSpellTier.TabIndex = 12;
            this.cbxMaxSpellTier.Text = "Max Tier";
            this.cbxMaxSpellTier.UseVisualStyleBackColor = true;
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(12, 338);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(68, 21);
            this.btnItem.TabIndex = 13;
            this.btnItem.Text = "Item";
            this.btnItem.UseVisualStyleBackColor = true;
            // 
            // lstItem
            // 
            this.lstItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstItem.FormattingEnabled = true;
            this.lstItem.Location = new System.Drawing.Point(86, 339);
            this.lstItem.Name = "lstItem";
            this.lstItem.Size = new System.Drawing.Size(214, 21);
            this.lstItem.TabIndex = 14;
            // 
            // lstItemTier
            // 
            this.lstItemTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstItemTier.FormattingEnabled = true;
            this.lstItemTier.Location = new System.Drawing.Point(306, 338);
            this.lstItemTier.Name = "lstItemTier";
            this.lstItemTier.Size = new System.Drawing.Size(55, 21);
            this.lstItemTier.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(367, 338);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(60, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // pbMoldIcon
            // 
            this.pbMoldIcon.Location = new System.Drawing.Point(266, 68);
            this.pbMoldIcon.Name = "pbMoldIcon";
            this.pbMoldIcon.Size = new System.Drawing.Size(25, 25);
            this.pbMoldIcon.TabIndex = 18;
            this.pbMoldIcon.TabStop = false;
            // 
            // pbZestIcon
            // 
            this.pbZestIcon.Location = new System.Drawing.Point(325, 68);
            this.pbZestIcon.Name = "pbZestIcon";
            this.pbZestIcon.Size = new System.Drawing.Size(25, 25);
            this.pbZestIcon.TabIndex = 19;
            this.pbZestIcon.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(389, 68);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "100";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "100";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rtbSpellBox
            // 
            this.rtbSpellBox.BackColor = System.Drawing.Color.Black;
            this.rtbSpellBox.ForeColor = System.Drawing.Color.White;
            this.rtbSpellBox.Location = new System.Drawing.Point(245, 179);
            this.rtbSpellBox.Name = "rtbSpellBox";
            this.rtbSpellBox.Size = new System.Drawing.Size(191, 100);
            this.rtbSpellBox.TabIndex = 24;
            this.rtbSpellBox.Text = "";
            // 
            // pbActionDisplay
            // 
            this.pbActionDisplay.Location = new System.Drawing.Point(311, 123);
            this.pbActionDisplay.Name = "pbActionDisplay";
            this.pbActionDisplay.Size = new System.Drawing.Size(50, 50);
            this.pbActionDisplay.TabIndex = 25;
            this.pbActionDisplay.TabStop = false;
            // 
            // FightBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbActionDisplay);
            this.Controls.Add(this.rtbSpellBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMoldCounter);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pbZestIcon);
            this.Controls.Add(this.pbMoldIcon);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lstItemTier);
            this.Controls.Add(this.lstItem);
            this.Controls.Add(this.btnItem);
            this.Controls.Add(this.cbxMaxSpellTier);
            this.Controls.Add(this.lstSpellTier);
            this.Controls.Add(this.lstSpellBook);
            this.Controls.Add(this.rtbChatter);
            this.Controls.Add(this.txtChatter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbMonHP);
            this.Controls.Add(this.btnSpell);
            this.Controls.Add(this.btnDef);
            this.Controls.Add(this.btnMAtk);
            this.Controls.Add(this.btnPAtk);
            this.Controls.Add(this.pbMonster);
            this.Name = "FightBoard";
            this.Size = new System.Drawing.Size(450, 585);
            ((System.ComponentModel.ISupportInitialize)(this.pbMonster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoldIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZestIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActionDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMonster;
        private System.Windows.Forms.Button btnPAtk;
        private System.Windows.Forms.Button btnMAtk;
        private System.Windows.Forms.Button btnDef;
        private System.Windows.Forms.Button btnSpell;
        public System.Windows.Forms.ProgressBar pbMonHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChatter;
        private System.Windows.Forms.RichTextBox rtbChatter;
        private System.Windows.Forms.ComboBox lstSpellBook;
        private System.Windows.Forms.ComboBox lstSpellTier;
        private System.Windows.Forms.CheckBox cbxMaxSpellTier;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.ComboBox lstItem;
        private System.Windows.Forms.ComboBox lstItemTier;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pbMoldIcon;
        private System.Windows.Forms.PictureBox pbZestIcon;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblMoldCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbSpellBox;
        private System.Windows.Forms.PictureBox pbActionDisplay;
    }
}
