namespace BreadMage2.Controls
{
    partial class ChoiceBoard
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
            this.pbChoicePic = new System.Windows.Forms.PictureBox();
            this.tbChoiceText = new System.Windows.Forms.TextBox();
            this.btnChoiceOne = new System.Windows.Forms.Button();
            this.btnChoiceTwo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbChoicePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pbChoicePic
            // 
            this.pbChoicePic.Location = new System.Drawing.Point(125, 2);
            this.pbChoicePic.Margin = new System.Windows.Forms.Padding(0);
            this.pbChoicePic.Name = "pbChoicePic";
            this.pbChoicePic.Size = new System.Drawing.Size(200, 200);
            this.pbChoicePic.TabIndex = 0;
            this.pbChoicePic.TabStop = false;
            // 
            // tbChoiceText
            // 
            this.tbChoiceText.BackColor = System.Drawing.Color.Black;
            this.tbChoiceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChoiceText.ForeColor = System.Drawing.Color.Lime;
            this.tbChoiceText.Location = new System.Drawing.Point(0, 202);
            this.tbChoiceText.Margin = new System.Windows.Forms.Padding(0);
            this.tbChoiceText.Multiline = true;
            this.tbChoiceText.Name = "tbChoiceText";
            this.tbChoiceText.ReadOnly = true;
            this.tbChoiceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChoiceText.ShortcutsEnabled = false;
            this.tbChoiceText.Size = new System.Drawing.Size(450, 231);
            this.tbChoiceText.TabIndex = 1;
            // 
            // btnChoiceOne
            // 
            this.btnChoiceOne.Location = new System.Drawing.Point(100, 436);
            this.btnChoiceOne.Name = "btnChoiceOne";
            this.btnChoiceOne.Size = new System.Drawing.Size(250, 30);
            this.btnChoiceOne.TabIndex = 2;
            this.btnChoiceOne.Text = "btnChoiceOne";
            this.btnChoiceOne.UseVisualStyleBackColor = true;
            this.btnChoiceOne.Click += new System.EventHandler(this.btnChoiceOne_Click);
            // 
            // btnChoiceTwo
            // 
            this.btnChoiceTwo.Location = new System.Drawing.Point(100, 476);
            this.btnChoiceTwo.Name = "btnChoiceTwo";
            this.btnChoiceTwo.Size = new System.Drawing.Size(250, 30);
            this.btnChoiceTwo.TabIndex = 3;
            this.btnChoiceTwo.Text = "btnChoiceTwo";
            this.btnChoiceTwo.UseVisualStyleBackColor = true;
            this.btnChoiceTwo.Click += new System.EventHandler(this.btnChoiceTwo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(14, 459);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 69);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ChoiceBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChoiceTwo);
            this.Controls.Add(this.btnChoiceOne);
            this.Controls.Add(this.tbChoiceText);
            this.Controls.Add(this.pbChoicePic);
            this.Name = "ChoiceBoard";
            this.Size = new System.Drawing.Size(450, 585);
            ((System.ComponentModel.ISupportInitialize)(this.pbChoicePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbChoicePic;
        private System.Windows.Forms.TextBox tbChoiceText;
        private System.Windows.Forms.Button btnChoiceOne;
        private System.Windows.Forms.Button btnChoiceTwo;
        private System.Windows.Forms.Button btnClose;
    }
}
