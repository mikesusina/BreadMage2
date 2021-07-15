namespace BreadMage2.Controls
{
    partial class QuickBoard
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
            this.pbQS1 = new System.Windows.Forms.PictureBox();
            this.btnQS1 = new System.Windows.Forms.Button();
            this.lblQS1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQS1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbQS1
            // 
            this.pbQS1.Location = new System.Drawing.Point(40, 15);
            this.pbQS1.Name = "pbQS1";
            this.pbQS1.Size = new System.Drawing.Size(30, 30);
            this.pbQS1.TabIndex = 0;
            this.pbQS1.TabStop = false;
            // 
            // btnQS1
            // 
            this.btnQS1.Location = new System.Drawing.Point(20, 50);
            this.btnQS1.Name = "btnQS1";
            this.btnQS1.Size = new System.Drawing.Size(75, 23);
            this.btnQS1.TabIndex = 1;
            this.btnQS1.Text = "QS1";
            this.btnQS1.UseVisualStyleBackColor = true;
            // 
            // lblQS1
            // 
            this.lblQS1.AutoSize = true;
            this.lblQS1.Location = new System.Drawing.Point(42, 76);
            this.lblQS1.Name = "lblQS1";
            this.lblQS1.Size = new System.Drawing.Size(28, 13);
            this.lblQS1.TabIndex = 2;
            this.lblQS1.Text = "QS1";
            // 
            // QuickBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblQS1);
            this.Controls.Add(this.btnQS1);
            this.Controls.Add(this.pbQS1);
            this.Name = "QuickBoard";
            this.Size = new System.Drawing.Size(250, 333);
            ((System.ComponentModel.ISupportInitialize)(this.pbQS1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbQS1;
        private System.Windows.Forms.Button btnQS1;
        private System.Windows.Forms.Label lblQS1;
    }
}
