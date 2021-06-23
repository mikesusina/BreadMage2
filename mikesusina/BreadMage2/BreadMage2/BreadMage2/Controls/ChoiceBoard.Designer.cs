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
            ((System.ComponentModel.ISupportInitialize)(this.pbChoicePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pbChoicePic
            // 
            this.pbChoicePic.Location = new System.Drawing.Point(300, 0);
            this.pbChoicePic.Margin = new System.Windows.Forms.Padding(0);
            this.pbChoicePic.Name = "pbChoicePic";
            this.pbChoicePic.Size = new System.Drawing.Size(250, 350);
            this.pbChoicePic.TabIndex = 0;
            this.pbChoicePic.TabStop = false;
            // 
            // tbChoiceText
            // 
            this.tbChoiceText.BackColor = System.Drawing.Color.Black;
            this.tbChoiceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChoiceText.ForeColor = System.Drawing.Color.Lime;
            this.tbChoiceText.Location = new System.Drawing.Point(0, 0);
            this.tbChoiceText.Margin = new System.Windows.Forms.Padding(0);
            this.tbChoiceText.Multiline = true;
            this.tbChoiceText.Name = "tbChoiceText";
            this.tbChoiceText.ReadOnly = true;
            this.tbChoiceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChoiceText.ShortcutsEnabled = false;
            this.tbChoiceText.Size = new System.Drawing.Size(300, 350);
            this.tbChoiceText.TabIndex = 1;
            // 
            // ChoiceBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbChoiceText);
            this.Controls.Add(this.pbChoicePic);
            this.Name = "ChoiceBoard";
            this.Size = new System.Drawing.Size(550, 350);
            ((System.ComponentModel.ISupportInitialize)(this.pbChoicePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbChoicePic;
        private System.Windows.Forms.TextBox tbChoiceText;
    }
}
