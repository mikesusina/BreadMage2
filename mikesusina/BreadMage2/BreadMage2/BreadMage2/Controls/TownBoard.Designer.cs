namespace BreadMage2
{
    partial class TownBoard
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
            this.pnlTownZone = new System.Windows.Forms.Panel();
            this.pbTownImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlTownZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTownImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTownZone
            // 
            this.pnlTownZone.Controls.Add(this.pbTownImage);
            this.pnlTownZone.Enabled = false;
            this.pnlTownZone.Location = new System.Drawing.Point(0, 86);
            this.pnlTownZone.Name = "pnlTownZone";
            this.pnlTownZone.Size = new System.Drawing.Size(450, 500);
            this.pnlTownZone.TabIndex = 0;
            this.pnlTownZone.Visible = false;
            // 
            // pbTownImage
            // 
            this.pbTownImage.Location = new System.Drawing.Point(131, 143);
            this.pbTownImage.Name = "pbTownImage";
            this.pbTownImage.Size = new System.Drawing.Size(200, 200);
            this.pbTownImage.TabIndex = 1;
            this.pbTownImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TownBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlTownZone);
            this.Name = "TownBoard";
            this.Size = new System.Drawing.Size(450, 585);
            this.pnlTownZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTownImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTownZone;
        private System.Windows.Forms.PictureBox pbTownImage;
        private System.Windows.Forms.Button button1;
    }
}
