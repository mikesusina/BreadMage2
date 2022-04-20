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
            this.pMidBar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pMageZone
            // 
            this.pMageZone.Location = new System.Drawing.Point(166, 14);
            this.pMageZone.Name = "pMageZone";
            this.pMageZone.Size = new System.Drawing.Size(350, 450);
            this.pMageZone.TabIndex = 1;
            // 
            // lbLog
            // 
            this.lbLog.BackColor = System.Drawing.Color.Black;
            this.lbLog.Font = new System.Drawing.Font("Moire", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLog.ForeColor = System.Drawing.Color.White;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 18;
            this.lbLog.Location = new System.Drawing.Point(9, 470);
            this.lbLog.Name = "lbLog";
            this.lbLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbLog.Size = new System.Drawing.Size(507, 130);
            this.lbLog.TabIndex = 2;
            // 
            // pArea
            // 
            this.pArea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pArea.Location = new System.Drawing.Point(795, 14);
            this.pArea.Name = "pArea";
            this.pArea.Size = new System.Drawing.Size(450, 585);
            this.pArea.TabIndex = 4;
            // 
            // pExtraInfo
            // 
            this.pExtraInfo.Location = new System.Drawing.Point(10, 14);
            this.pExtraInfo.Name = "pExtraInfo";
            this.pExtraInfo.Size = new System.Drawing.Size(150, 450);
            this.pExtraInfo.TabIndex = 7;
            // 
            // pQuickBoard
            // 
            this.pQuickBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pQuickBoard.Location = new System.Drawing.Point(758, 14);
            this.pQuickBoard.Name = "pQuickBoard";
            this.pQuickBoard.Size = new System.Drawing.Size(22, 13);
            this.pQuickBoard.TabIndex = 8;
            // 
            // pMidBar
            // 
            this.pMidBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pMidBar.AutoScroll = true;
            this.pMidBar.Location = new System.Drawing.Point(530, 135);
            this.pMidBar.Name = "pMidBar";
            this.pMidBar.Size = new System.Drawing.Size(250, 461);
            this.pMidBar.TabIndex = 9;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 611);
            this.Controls.Add(this.pMidBar);
            this.Controls.Add(this.pQuickBoard);
            this.Controls.Add(this.pExtraInfo);
            this.Controls.Add(this.pArea);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.pMageZone);
            this.Location = new System.Drawing.Point(65, 10);
            this.MinimumSize = new System.Drawing.Size(1270, 650);
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
        private System.Windows.Forms.Panel pMidBar;
    }
}

