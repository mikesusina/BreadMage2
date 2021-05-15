namespace BreadMage2.Screens
{
    partial class DevTools
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
            this.btnSetLoc = new System.Windows.Forms.Button();
            this.txbLoc = new System.Windows.Forms.TextBox();
            this.btnClrEventArea = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbHeal = new System.Windows.Forms.TextBox();
            this.btnHeal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetLoc
            // 
            this.btnSetLoc.Location = new System.Drawing.Point(12, 54);
            this.btnSetLoc.Name = "btnSetLoc";
            this.btnSetLoc.Size = new System.Drawing.Size(133, 44);
            this.btnSetLoc.TabIndex = 0;
            this.btnSetLoc.Text = "Set Location";
            this.btnSetLoc.UseVisualStyleBackColor = true;
            this.btnSetLoc.Click += new System.EventHandler(this.btnSetLoc_Click);
            // 
            // txbLoc
            // 
            this.txbLoc.Location = new System.Drawing.Point(48, 28);
            this.txbLoc.Name = "txbLoc";
            this.txbLoc.Size = new System.Drawing.Size(68, 20);
            this.txbLoc.TabIndex = 1;
            // 
            // btnClrEventArea
            // 
            this.btnClrEventArea.Location = new System.Drawing.Point(189, 54);
            this.btnClrEventArea.Name = "btnClrEventArea";
            this.btnClrEventArea.Size = new System.Drawing.Size(59, 27);
            this.btnClrEventArea.TabIndex = 2;
            this.btnClrEventArea.Text = "Poof";
            this.btnClrEventArea.UseVisualStyleBackColor = true;
            this.btnClrEventArea.Click += new System.EventHandler(this.btnClrEventArea_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 22);
            this.label1.MaximumSize = new System.Drawing.Size(65, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clear Event Area";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txbHeal
            // 
            this.txbHeal.Location = new System.Drawing.Point(337, 20);
            this.txbHeal.Name = "txbHeal";
            this.txbHeal.Size = new System.Drawing.Size(75, 20);
            this.txbHeal.TabIndex = 4;
            // 
            // btnHeal
            // 
            this.btnHeal.Location = new System.Drawing.Point(337, 51);
            this.btnHeal.Name = "btnHeal";
            this.btnHeal.Size = new System.Drawing.Size(74, 46);
            this.btnHeal.TabIndex = 5;
            this.btnHeal.Text = "Heal";
            this.btnHeal.UseVisualStyleBackColor = true;
            this.btnHeal.Click += new System.EventHandler(this.btnHeal_Click);
            // 
            // DevTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHeal);
            this.Controls.Add(this.txbHeal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClrEventArea);
            this.Controls.Add(this.txbLoc);
            this.Controls.Add(this.btnSetLoc);
            this.Name = "DevTools";
            this.Text = "DevTools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetLoc;
        private System.Windows.Forms.TextBox txbLoc;
        private System.Windows.Forms.Button btnClrEventArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbHeal;
        private System.Windows.Forms.Button btnHeal;
    }
}