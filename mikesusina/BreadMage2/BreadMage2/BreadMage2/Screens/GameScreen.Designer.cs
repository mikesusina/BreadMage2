namespace BreadMage2
{
    partial class GameScreen
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
            this.pMageZone = new System.Windows.Forms.Panel();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.pArea = new System.Windows.Forms.Panel();
            this.pExtraInfo = new System.Windows.Forms.Panel();
            this.pQuickBoard = new System.Windows.Forms.Panel();
            this.pSB = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pMageZone
            // 
            this.pMageZone.Location = new System.Drawing.Point(265, 14);
            this.pMageZone.Name = "pMageZone";
            this.pMageZone.Size = new System.Drawing.Size(250, 350);
            this.pMageZone.TabIndex = 1;
            // 
            // lbLog
            // 
            this.lbLog.BackColor = System.Drawing.Color.Black;
            this.lbLog.ForeColor = System.Drawing.Color.White;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(10, 374);
            this.lbLog.Name = "lbLog";
            this.lbLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbLog.Size = new System.Drawing.Size(505, 134);
            this.lbLog.TabIndex = 2;
            // 
            // pArea
            // 
            this.pArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pArea.Location = new System.Drawing.Point(740, 14);
            this.pArea.Name = "pArea";
            this.pArea.Size = new System.Drawing.Size(350, 350);
            this.pArea.TabIndex = 4;
            // 
            // pExtraInfo
            // 
            this.pExtraInfo.Location = new System.Drawing.Point(10, 14);
            this.pExtraInfo.Name = "pExtraInfo";
            this.pExtraInfo.Size = new System.Drawing.Size(250, 350);
            this.pExtraInfo.TabIndex = 7;
            // 
            // pQuickBoard
            // 
            this.pQuickBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pQuickBoard.Location = new System.Drawing.Point(740, 374);
            this.pQuickBoard.Name = "pQuickBoard";
            this.pQuickBoard.Size = new System.Drawing.Size(350, 134);
            this.pQuickBoard.TabIndex = 8;
            // 
            // pSB
            // 
            this.pSB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pSB.Location = new System.Drawing.Point(540, 124);
            this.pSB.Name = "pSB";
            this.pSB.Size = new System.Drawing.Size(175, 100);
            this.pSB.TabIndex = 9;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 521);
            this.Controls.Add(this.pSB);
            this.Controls.Add(this.pQuickBoard);
            this.Controls.Add(this.pExtraInfo);
            this.Controls.Add(this.pArea);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.pMageZone);
            this.Location = new System.Drawing.Point(65, 10);
            this.MinimumSize = new System.Drawing.Size(1120, 560);
            this.Name = "GameScreen";
            this.Text = "Bread Mage 2";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pMageZone;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Panel pArea;
        private System.Windows.Forms.Panel pExtraInfo;
        private System.Windows.Forms.Panel pQuickBoard;
        private System.Windows.Forms.Panel pSB;
    }
}

