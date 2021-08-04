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
            this.pbSP = new System.Windows.Forms.ProgressBar();
            this.pbMage = new System.Windows.Forms.PictureBox();
            this.lblHPDisplay = new System.Windows.Forms.Label();
            this.lblMPDisplay = new System.Windows.Forms.Label();
            this.lblMoldCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbHP
            // 
            this.pbHP.BackColor = System.Drawing.SystemColors.Control;
            this.pbHP.ForeColor = System.Drawing.Color.Red;
            this.pbHP.Location = new System.Drawing.Point(114, 218);
            this.pbHP.Name = "pbHP";
            this.pbHP.Size = new System.Drawing.Size(120, 13);
            this.pbHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbHP.TabIndex = 1;
            // 
            // pbMP
            // 
            this.pbMP.BackColor = System.Drawing.SystemColors.Control;
            this.pbMP.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pbMP.Location = new System.Drawing.Point(114, 242);
            this.pbMP.Name = "pbMP";
            this.pbMP.Size = new System.Drawing.Size(120, 15);
            this.pbMP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMP.TabIndex = 2;
            // 
            // pbSP
            // 
            this.pbSP.BackColor = System.Drawing.SystemColors.Control;
            this.pbSP.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbSP.ForeColor = System.Drawing.Color.Lime;
            this.pbSP.Location = new System.Drawing.Point(114, 268);
            this.pbSP.Name = "pbSP";
            this.pbSP.Size = new System.Drawing.Size(120, 15);
            this.pbSP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbSP.TabIndex = 3;
            // 
            // pbMage
            // 
            this.pbMage.Location = new System.Drawing.Point(100, 22);
            this.pbMage.Name = "pbMage";
            this.pbMage.Size = new System.Drawing.Size(150, 150);
            this.pbMage.TabIndex = 0;
            this.pbMage.TabStop = false;
            // 
            // lblHPDisplay
            // 
            this.lblHPDisplay.AutoSize = true;
            this.lblHPDisplay.Location = new System.Drawing.Point(240, 218);
            this.lblHPDisplay.Name = "lblHPDisplay";
            this.lblHPDisplay.Size = new System.Drawing.Size(36, 13);
            this.lblHPDisplay.TabIndex = 4;
            this.lblHPDisplay.Text = "42/42";
            // 
            // lblMPDisplay
            // 
            this.lblMPDisplay.AutoSize = true;
            this.lblMPDisplay.Location = new System.Drawing.Point(240, 243);
            this.lblMPDisplay.Name = "lblMPDisplay";
            this.lblMPDisplay.Size = new System.Drawing.Size(23, 13);
            this.lblMPDisplay.TabIndex = 5;
            this.lblMPDisplay.Text = "MP";
            // 
            // lblMoldCount
            // 
            this.lblMoldCount.AutoSize = true;
            this.lblMoldCount.Location = new System.Drawing.Point(240, 268);
            this.lblMoldCount.Name = "lblMoldCount";
            this.lblMoldCount.Size = new System.Drawing.Size(30, 13);
            this.lblMoldCount.TabIndex = 6;
            this.lblMoldCount.Text = "Mold";
            // 
            // BreadMage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMoldCount);
            this.Controls.Add(this.lblMPDisplay);
            this.Controls.Add(this.lblHPDisplay);
            this.Controls.Add(this.pbSP);
            this.Controls.Add(this.pbMP);
            this.Controls.Add(this.pbHP);
            this.Controls.Add(this.pbMage);
            this.Name = "BreadMage";
            this.Size = new System.Drawing.Size(350, 450);
            ((System.ComponentModel.ISupportInitialize)(this.pbMage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMage;
        public System.Windows.Forms.ProgressBar pbHP;
        public System.Windows.Forms.ProgressBar pbMP;
        public System.Windows.Forms.ProgressBar pbSP;
        private System.Windows.Forms.Label lblHPDisplay;
        private System.Windows.Forms.Label lblMPDisplay;
        private System.Windows.Forms.Label lblMoldCount;
    }
}
