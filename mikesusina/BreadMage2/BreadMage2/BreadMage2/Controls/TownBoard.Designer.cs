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
            this.btnItemShop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            // btnItemShop
            // 
            this.btnItemShop.Location = new System.Drawing.Point(29, 11);
            this.btnItemShop.Name = "btnItemShop";
            this.btnItemShop.Size = new System.Drawing.Size(50, 50);
            this.btnItemShop.TabIndex = 1;
            this.btnItemShop.Text = "Items";
            this.btnItemShop.UseVisualStyleBackColor = true;
            this.btnItemShop.Click += new System.EventHandler(this.btnItemShop_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 58);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(217, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 47);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TownBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnItemShop);
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
        private System.Windows.Forms.Button btnItemShop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
