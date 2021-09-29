namespace BreadMage2.Screens
{
    partial class EquipScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbMagePic = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMagePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMagePic
            // 
            this.pbMagePic.Location = new System.Drawing.Point(457, 89);
            this.pbMagePic.Name = "pbMagePic";
            this.pbMagePic.Size = new System.Drawing.Size(150, 150);
            this.pbMagePic.TabIndex = 0;
            this.pbMagePic.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(502, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 47);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(673, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 50);
            this.button2.TabIndex = 14;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // EquipScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbMagePic);
            this.Name = "EquipScreen";
            this.Text = "EquipScreen";
            this.Load += new System.EventHandler(this.EquipScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMagePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMagePic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}