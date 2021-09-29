namespace BreadMage2
{
    partial class ShopItems
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblYeast = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbShopChatter = new System.Windows.Forms.RichTextBox();
            this.lbShopInventory = new System.Windows.Forms.ListBox();
            this.pbSelectedItem = new System.Windows.Forms.PictureBox();
            this.rtbMoreInfo = new System.Windows.Forms.RichTextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(148, 447);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(52, 37);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Buy";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(223, 447);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(58, 37);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Buy and Exit";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(311, 447);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 37);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblYeast
            // 
            this.lblYeast.AutoSize = true;
            this.lblYeast.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYeast.Location = new System.Drawing.Point(36, 455);
            this.lblYeast.Name = "lblYeast";
            this.lblYeast.Size = new System.Drawing.Size(63, 18);
            this.lblYeast.TabIndex = 3;
            this.lblYeast.Text = "Yeast: X";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // rtbShopChatter
            // 
            this.rtbShopChatter.BackColor = System.Drawing.Color.Black;
            this.rtbShopChatter.ForeColor = System.Drawing.Color.White;
            this.rtbShopChatter.Location = new System.Drawing.Point(30, 13);
            this.rtbShopChatter.Name = "rtbShopChatter";
            this.rtbShopChatter.Size = new System.Drawing.Size(150, 96);
            this.rtbShopChatter.TabIndex = 5;
            this.rtbShopChatter.Text = "";
            // 
            // lbShopInventory
            // 
            this.lbShopInventory.FormattingEnabled = true;
            this.lbShopInventory.Location = new System.Drawing.Point(30, 287);
            this.lbShopInventory.Name = "lbShopInventory";
            this.lbShopInventory.Size = new System.Drawing.Size(364, 108);
            this.lbShopInventory.TabIndex = 6;
            // 
            // pbSelectedItem
            // 
            this.pbSelectedItem.Location = new System.Drawing.Point(302, 13);
            this.pbSelectedItem.Name = "pbSelectedItem";
            this.pbSelectedItem.Size = new System.Drawing.Size(50, 50);
            this.pbSelectedItem.TabIndex = 7;
            this.pbSelectedItem.TabStop = false;
            // 
            // rtbMoreInfo
            // 
            this.rtbMoreInfo.BackColor = System.Drawing.Color.Black;
            this.rtbMoreInfo.ForeColor = System.Drawing.Color.White;
            this.rtbMoreInfo.Location = new System.Drawing.Point(244, 83);
            this.rtbMoreInfo.Name = "rtbMoreInfo";
            this.rtbMoreInfo.Size = new System.Drawing.Size(180, 182);
            this.rtbMoreInfo.TabIndex = 8;
            this.rtbMoreInfo.Text = "";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(39, 418);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.ReadOnly = true;
            this.tbAmount.Size = new System.Drawing.Size(60, 20);
            this.tbAmount.TabIndex = 9;
            // 
            // ShopItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.rtbMoreInfo);
            this.Controls.Add(this.pbSelectedItem);
            this.Controls.Add(this.lbShopInventory);
            this.Controls.Add(this.rtbShopChatter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblYeast);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnContinue);
            this.Name = "ShopItems";
            this.Size = new System.Drawing.Size(450, 500);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblYeast;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtbShopChatter;
        private System.Windows.Forms.ListBox lbShopInventory;
        private System.Windows.Forms.PictureBox pbSelectedItem;
        private System.Windows.Forms.RichTextBox rtbMoreInfo;
        private System.Windows.Forms.TextBox tbAmount;
    }
}
