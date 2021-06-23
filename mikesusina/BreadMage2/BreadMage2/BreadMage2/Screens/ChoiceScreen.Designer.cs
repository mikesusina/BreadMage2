namespace BreadMage2.Screens
{
    partial class ChoiceScreen
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
            this.pChoiceArea = new System.Windows.Forms.Panel();
            this.btnChoiceOne = new System.Windows.Forms.Button();
            this.btnChoiceTwo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pChoiceArea
            // 
            this.pChoiceArea.Location = new System.Drawing.Point(17, 10);
            this.pChoiceArea.Name = "pChoiceArea";
            this.pChoiceArea.Size = new System.Drawing.Size(550, 350);
            this.pChoiceArea.TabIndex = 0;
            // 
            // btnChoiceOne
            // 
            this.btnChoiceOne.Location = new System.Drawing.Point(167, 376);
            this.btnChoiceOne.Name = "btnChoiceOne";
            this.btnChoiceOne.Size = new System.Drawing.Size(250, 30);
            this.btnChoiceOne.TabIndex = 1;
            this.btnChoiceOne.Text = "btnChoiceOne";
            this.btnChoiceOne.UseVisualStyleBackColor = true;
            this.btnChoiceOne.Click += new System.EventHandler(this.btnChoiceOne_Click);
            // 
            // btnChoiceTwo
            // 
            this.btnChoiceTwo.Location = new System.Drawing.Point(167, 416);
            this.btnChoiceTwo.Name = "btnChoiceTwo";
            this.btnChoiceTwo.Size = new System.Drawing.Size(250, 30);
            this.btnChoiceTwo.TabIndex = 2;
            this.btnChoiceTwo.Text = "btnChoiceTwo";
            this.btnChoiceTwo.UseVisualStyleBackColor = true;
            this.btnChoiceTwo.Click += new System.EventHandler(this.btnChoiceTwo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(26, 376);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 70);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ChoiceScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChoiceTwo);
            this.Controls.Add(this.btnChoiceOne);
            this.Controls.Add(this.pChoiceArea);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "ChoiceScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ChoiceScreen";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pChoiceArea;
        private System.Windows.Forms.Button btnChoiceOne;
        private System.Windows.Forms.Button btnChoiceTwo;
        private System.Windows.Forms.Button btnClose;
    }
}