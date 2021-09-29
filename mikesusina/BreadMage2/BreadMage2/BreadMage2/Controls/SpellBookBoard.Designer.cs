namespace BreadMage2
{
    partial class SpellBookBoard
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblEquipCap = new System.Windows.Forms.Label();
            this.barSkillCap = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // boxKnown
            // 
            this.boxKnown.FormattingEnabled = true;
            this.boxKnown.Location = new System.Drawing.Point(83, 287);
            this.boxKnown.Name = "boxKnown";
            this.boxKnown.Size = new System.Drawing.Size(182, 69);
            this.boxKnown.TabIndex = 2;
            this.boxKnown.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // boxEquipped
            // 
            this.boxEquipped.FormattingEnabled = true;
            this.boxEquipped.Location = new System.Drawing.Point(83, 513);
            this.boxEquipped.Name = "boxEquipped";
            this.boxEquipped.Size = new System.Drawing.Size(182, 69);
            this.boxEquipped.TabIndex = 3;
            this.boxEquipped.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "↓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 39);
            this.button2.TabIndex = 5;
            this.button2.Text = "↑";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblEquipCap
            // 
            this.lblEquipCap.AutoSize = true;
            this.lblEquipCap.Location = new System.Drawing.Point(167, 391);
            this.lblEquipCap.Name = "lblEquipCap";
            this.lblEquipCap.Size = new System.Drawing.Size(82, 13);
            this.lblEquipCap.TabIndex = 6;
            this.lblEquipCap.Text = "Skill points: X/Y";
            // 
            // barSkillCap
            // 
            this.barSkillCap.Location = new System.Drawing.Point(96, 426);
            this.barSkillCap.Name = "barSkillCap";
            this.barSkillCap.Size = new System.Drawing.Size(152, 20);
            this.barSkillCap.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barSkillCap.TabIndex = 7;
            // 
            // SpellBookBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barSkillCap);
            this.Controls.Add(this.lblEquipCap);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.boxEquipped);
            this.Controls.Add(this.boxKnown);
            this.Name = "SpellBookBoard";
            this.Size = new System.Drawing.Size(450, 585);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox boxKnown;
        private System.Windows.Forms.ListBox boxEquipped;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblEquipCap;
        private System.Windows.Forms.ProgressBar barSkillCap;
    }
}
