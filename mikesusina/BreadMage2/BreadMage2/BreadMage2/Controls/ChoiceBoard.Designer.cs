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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbChoiceText = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbChoicePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pbChoicePic
            // 
            this.pbChoicePic.Location = new System.Drawing.Point(122, 28);
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
            this.tbChoiceText.Location = new System.Drawing.Point(346, 72);
            this.tbChoiceText.Margin = new System.Windows.Forms.Padding(0);
            this.tbChoiceText.Multiline = true;
            this.tbChoiceText.Name = "tbChoiceText";
            this.tbChoiceText.ReadOnly = true;
            this.tbChoiceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChoiceText.ShortcutsEnabled = false;
            this.tbChoiceText.Size = new System.Drawing.Size(76, 54);
            this.tbChoiceText.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(117, 497);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(215, 55);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 3);
            this.lblTitle.MaximumSize = new System.Drawing.Size(585, 0);
            this.lblTitle.MinimumSize = new System.Drawing.Size(450, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 22);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "The Power and/or Choice is YOURS!";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbChoiceText
            // 
            this.rtbChoiceText.BackColor = System.Drawing.Color.Black;
            this.rtbChoiceText.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChoiceText.ForeColor = System.Drawing.Color.Lime;
            this.rtbChoiceText.HideSelection = false;
            this.rtbChoiceText.Location = new System.Drawing.Point(5, 235);
            this.rtbChoiceText.Name = "rtbChoiceText";
            this.rtbChoiceText.ReadOnly = true;
            this.rtbChoiceText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbChoiceText.Size = new System.Drawing.Size(450, 231);
            this.rtbChoiceText.TabIndex = 10;
            this.rtbChoiceText.Text = "";
            // 
            // ChoiceBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbChoiceText);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbChoiceText);
            this.Controls.Add(this.pbChoicePic);
            this.Controls.Add(this.lblTitle);
            this.Name = "ChoiceBoard";
            this.Size = new System.Drawing.Size(450, 585);
            ((System.ComponentModel.ISupportInitialize)(this.pbChoicePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbChoicePic;
        private System.Windows.Forms.TextBox tbChoiceText;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox rtbChoiceText;
    }
}
