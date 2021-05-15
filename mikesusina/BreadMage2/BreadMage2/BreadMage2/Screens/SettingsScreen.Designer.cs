namespace BreadMage2.Screens
{
    partial class SettingsScreen
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
            this.lbLTS = new System.Windows.Forms.ListBox();
            this.tbLTS = new System.Windows.Forms.TextBox();
            this.lLogTxtSize = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLTS
            // 
            this.lbLTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLTS.FormattingEnabled = true;
            this.lbLTS.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24"});
            this.lbLTS.Location = new System.Drawing.Point(23, 48);
            this.lbLTS.Name = "lbLTS";
            this.lbLTS.Size = new System.Drawing.Size(40, 95);
            this.lbLTS.TabIndex = 0;
            this.lbLTS.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // tbLTS
            // 
            this.tbLTS.Location = new System.Drawing.Point(23, 25);
            this.tbLTS.Name = "tbLTS";
            this.tbLTS.Size = new System.Drawing.Size(40, 20);
            this.tbLTS.TabIndex = 1;
            // 
            // lLogTxtSize
            // 
            this.lLogTxtSize.AutoSize = true;
            this.lLogTxtSize.Location = new System.Drawing.Point(8, 9);
            this.lLogTxtSize.Name = "lLogTxtSize";
            this.lLogTxtSize.Size = new System.Drawing.Size(72, 13);
            this.lLogTxtSize.TabIndex = 2;
            this.lLogTxtSize.Text = "Log Text Size";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 329);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lLogTxtSize);
            this.Controls.Add(this.tbLTS);
            this.Controls.Add(this.lbLTS);
            this.Name = "SettingsScreen";
            this.Text = "Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbLTS;
        private System.Windows.Forms.TextBox tbLTS;
        private System.Windows.Forms.Label lLogTxtSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}