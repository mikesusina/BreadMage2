namespace BreadMage2
{
    partial class SpellbookBoard
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
            this.boxKnown = new System.Windows.Forms.ListBox();
            this.boxEquipped = new System.Windows.Forms.ListBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.lblEquipCap = new System.Windows.Forms.Label();
            this.barSkillCap = new System.Windows.Forms.ProgressBar();
            this.boxPassives = new System.Windows.Forms.ListBox();
            this.rtbSpellDesc = new System.Windows.Forms.RichTextBox();
            this.pbSpellIcon = new System.Windows.Forms.PictureBox();
            this.lbSpellName = new System.Windows.Forms.Label();
            this.cbTier = new System.Windows.Forms.ComboBox();
            this.lbTier = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpellIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // boxKnown
            // 
            this.boxKnown.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxKnown.FormattingEnabled = true;
            this.boxKnown.ItemHeight = 20;
            this.boxKnown.Location = new System.Drawing.Point(5, 8);
            this.boxKnown.Name = "boxKnown";
            this.boxKnown.Size = new System.Drawing.Size(215, 224);
            this.boxKnown.TabIndex = 2;
            this.boxKnown.SelectedValueChanged += new System.EventHandler(this.boxKnown_SelectedValueChanged);
            this.boxKnown.Enter += new System.EventHandler(this.boxKnown_Enter);
            // 
            // boxEquipped
            // 
            this.boxEquipped.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxEquipped.FormattingEnabled = true;
            this.boxEquipped.ItemHeight = 20;
            this.boxEquipped.Location = new System.Drawing.Point(10, 278);
            this.boxEquipped.Name = "boxEquipped";
            this.boxEquipped.Size = new System.Drawing.Size(215, 104);
            this.boxEquipped.TabIndex = 3;
            this.boxEquipped.SelectedIndexChanged += new System.EventHandler(this.boxEquipped_SelectedIndexChanged);
            this.boxEquipped.Enter += new System.EventHandler(this.boxEquipped_Enter);
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove.Location = new System.Drawing.Point(235, 189);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(66, 40);
            this.btnMove.TabIndex = 5;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // lblEquipCap
            // 
            this.lblEquipCap.AutoSize = true;
            this.lblEquipCap.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipCap.Location = new System.Drawing.Point(33, 235);
            this.lblEquipCap.Name = "lblEquipCap";
            this.lblEquipCap.Size = new System.Drawing.Size(159, 18);
            this.lblEquipCap.TabIndex = 6;
            this.lblEquipCap.Text = "Equipped Skill points: X/Y";
            // 
            // barSkillCap
            // 
            this.barSkillCap.ForeColor = System.Drawing.Color.Lime;
            this.barSkillCap.Location = new System.Drawing.Point(25, 253);
            this.barSkillCap.Name = "barSkillCap";
            this.barSkillCap.Size = new System.Drawing.Size(175, 20);
            this.barSkillCap.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barSkillCap.TabIndex = 7;
            // 
            // boxPassives
            // 
            this.boxPassives.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxPassives.FormattingEnabled = true;
            this.boxPassives.ItemHeight = 20;
            this.boxPassives.Location = new System.Drawing.Point(235, 278);
            this.boxPassives.Name = "boxPassives";
            this.boxPassives.Size = new System.Drawing.Size(210, 104);
            this.boxPassives.TabIndex = 8;
            this.boxPassives.SelectedIndexChanged += new System.EventHandler(this.boxPassives_SelectedIndexChanged);
            this.boxPassives.Enter += new System.EventHandler(this.boxPassives_Enter);
            // 
            // rtbSpellDesc
            // 
            this.rtbSpellDesc.BackColor = System.Drawing.Color.Black;
            this.rtbSpellDesc.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSpellDesc.ForeColor = System.Drawing.Color.Lime;
            this.rtbSpellDesc.Location = new System.Drawing.Point(10, 437);
            this.rtbSpellDesc.Name = "rtbSpellDesc";
            this.rtbSpellDesc.Size = new System.Drawing.Size(291, 112);
            this.rtbSpellDesc.TabIndex = 9;
            this.rtbSpellDesc.Text = "";
            // 
            // pbSpellIcon
            // 
            this.pbSpellIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbSpellIcon.Location = new System.Drawing.Point(10, 385);
            this.pbSpellIcon.Name = "pbSpellIcon";
            this.pbSpellIcon.Size = new System.Drawing.Size(50, 50);
            this.pbSpellIcon.TabIndex = 10;
            this.pbSpellIcon.TabStop = false;
            // 
            // lbSpellName
            // 
            this.lbSpellName.AutoSize = true;
            this.lbSpellName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpellName.Location = new System.Drawing.Point(66, 397);
            this.lbSpellName.Name = "lbSpellName";
            this.lbSpellName.Size = new System.Drawing.Size(84, 22);
            this.lbSpellName.TabIndex = 15;
            this.lbSpellName.Text = "SpellName";
            // 
            // cbTier
            // 
            this.cbTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTier.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTier.FormattingEnabled = true;
            this.cbTier.Location = new System.Drawing.Point(400, 203);
            this.cbTier.Name = "cbTier";
            this.cbTier.Size = new System.Drawing.Size(34, 26);
            this.cbTier.TabIndex = 16;
            // 
            // lbTier
            // 
            this.lbTier.AutoSize = true;
            this.lbTier.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTier.Location = new System.Drawing.Point(401, 182);
            this.lbTier.Name = "lbTier";
            this.lbTier.Size = new System.Drawing.Size(30, 18);
            this.lbTier.TabIndex = 17;
            this.lbTier.Text = "Tier";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(318, 441);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 51);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save and Exit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(318, 498);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 51);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(226, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(126, 26);
            this.comboBox1.TabIndex = 20;
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilter.Location = new System.Drawing.Point(226, 6);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(39, 18);
            this.lbFilter.TabIndex = 21;
            this.lbFilter.Text = "Filter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(156, 397);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // TownEquipSpells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbTier);
            this.Controls.Add(this.cbTier);
            this.Controls.Add(this.lbSpellName);
            this.Controls.Add(this.pbSpellIcon);
            this.Controls.Add(this.rtbSpellDesc);
            this.Controls.Add(this.boxPassives);
            this.Controls.Add(this.barSkillCap);
            this.Controls.Add(this.lblEquipCap);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.boxEquipped);
            this.Controls.Add(this.boxKnown);
            this.Name = "TownEquipSpells";
            this.Size = new System.Drawing.Size(450, 585);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpellIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox boxKnown;
        private System.Windows.Forms.ListBox boxEquipped;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Label lblEquipCap;
        private System.Windows.Forms.ProgressBar barSkillCap;
        private System.Windows.Forms.ListBox boxPassives;
        private System.Windows.Forms.RichTextBox rtbSpellDesc;
        private System.Windows.Forms.PictureBox pbSpellIcon;
        private System.Windows.Forms.Label lbSpellName;
        private System.Windows.Forms.ComboBox cbTier;
        private System.Windows.Forms.Label lbTier;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
