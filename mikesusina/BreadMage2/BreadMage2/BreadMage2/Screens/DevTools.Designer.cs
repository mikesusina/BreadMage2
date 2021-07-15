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
            this.button1 = new System.Windows.Forms.Button();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.btnQuickSlots = new System.Windows.Forms.Button();
            this.tbItemID = new System.Windows.Forms.TextBox();
            this.cbQuickSlot = new System.Windows.Forms.ComboBox();
            this.lblQuickItemID = new System.Windows.Forms.Label();
            this.lblQuickItemAmt = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 61);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(28, 212);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(100, 20);
            this.tbAmount.TabIndex = 7;
            // 
            // btnQuickSlots
            // 
            this.btnQuickSlots.Location = new System.Drawing.Point(22, 238);
            this.btnQuickSlots.Name = "btnQuickSlots";
            this.btnQuickSlots.Size = new System.Drawing.Size(117, 23);
            this.btnQuickSlots.TabIndex = 8;
            this.btnQuickSlots.Text = "Give me some stuff";
            this.btnQuickSlots.UseVisualStyleBackColor = true;
            this.btnQuickSlots.Click += new System.EventHandler(this.btnQuickSlots_Click);
            // 
            // tbItemID
            // 
            this.tbItemID.Location = new System.Drawing.Point(28, 186);
            this.tbItemID.Name = "tbItemID";
            this.tbItemID.Size = new System.Drawing.Size(100, 20);
            this.tbItemID.TabIndex = 9;
            // 
            // cbQuickSlot
            // 
            this.cbQuickSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuickSlot.FormattingEnabled = true;
            this.cbQuickSlot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbQuickSlot.Location = new System.Drawing.Point(22, 267);
            this.cbQuickSlot.Name = "cbQuickSlot";
            this.cbQuickSlot.Size = new System.Drawing.Size(117, 21);
            this.cbQuickSlot.TabIndex = 10;
            // 
            // lblQuickItemID
            // 
            this.lblQuickItemID.AutoSize = true;
            this.lblQuickItemID.Location = new System.Drawing.Point(129, 190);
            this.lblQuickItemID.Name = "lblQuickItemID";
            this.lblQuickItemID.Size = new System.Drawing.Size(38, 13);
            this.lblQuickItemID.TabIndex = 11;
            this.lblQuickItemID.Text = "ItemID";
            // 
            // lblQuickItemAmt
            // 
            this.lblQuickItemAmt.AutoSize = true;
            this.lblQuickItemAmt.Location = new System.Drawing.Point(129, 215);
            this.lblQuickItemAmt.Name = "lblQuickItemAmt";
            this.lblQuickItemAmt.Size = new System.Drawing.Size(43, 13);
            this.lblQuickItemAmt.TabIndex = 12;
            this.lblQuickItemAmt.Text = "Amount";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(640, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "InvStatus";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(643, 110);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 29);
            this.button3.TabIndex = 14;
            this.button3.Text = "SaveInv";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(658, 176);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 36);
            this.button4.TabIndex = 15;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbDisplay
            // 
            this.tbDisplay.Location = new System.Drawing.Point(549, 218);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDisplay.Size = new System.Drawing.Size(239, 222);
            this.tbDisplay.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(368, 165);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 40);
            this.button5.TabIndex = 17;
            this.button5.Text = "CheckParsing";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DevTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblQuickItemAmt);
            this.Controls.Add(this.lblQuickItemID);
            this.Controls.Add(this.cbQuickSlot);
            this.Controls.Add(this.tbItemID);
            this.Controls.Add(this.btnQuickSlots);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Button btnQuickSlots;
        private System.Windows.Forms.TextBox tbItemID;
        private System.Windows.Forms.ComboBox cbQuickSlot;
        private System.Windows.Forms.Label lblQuickItemID;
        private System.Windows.Forms.Label lblQuickItemAmt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.Windows.Forms.Button button5;
    }
}