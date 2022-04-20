namespace BreadMage2
{
    partial class TownShop
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
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblYeast = new System.Windows.Forms.Label();
            this.pbClerk = new System.Windows.Forms.PictureBox();
            this.rtbShopChatter = new System.Windows.Forms.RichTextBox();
            this.lbShopInventory = new System.Windows.Forms.ListBox();
            this.pbSelectedItem = new System.Windows.Forms.PictureBox();
            this.rtbSelectedInfo = new System.Windows.Forms.RichTextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.btnEquip = new System.Windows.Forms.Button();
            this.radioInfo = new System.Windows.Forms.RadioButton();
            this.radioAbout = new System.Windows.Forms.RadioButton();
            this.lblSelectedName = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.gbSelectedText = new System.Windows.Forms.GroupBox();
            this.radioStock = new System.Windows.Forms.RadioButton();
            this.radioGeneric = new System.Windows.Forms.RadioButton();
            this.gbInventory = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbClerk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedItem)).BeginInit();
            this.gbSelectedText.SuspendLayout();
            this.gbInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuy
            // 
            this.btnBuy.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuy.Location = new System.Drawing.Point(370, 319);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 50);
            this.btnBuy.TabIndex = 0;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(370, 441);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 50);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblYeast
            // 
            this.lblYeast.AutoSize = true;
            this.lblYeast.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYeast.Location = new System.Drawing.Point(284, 447);
            this.lblYeast.MinimumSize = new System.Drawing.Size(60, 0);
            this.lblYeast.Name = "lblYeast";
            this.lblYeast.Size = new System.Drawing.Size(60, 36);
            this.lblYeast.TabIndex = 3;
            this.lblYeast.Text = "Yeast:\r\n N";
            this.lblYeast.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pbClerk
            // 
            this.pbClerk.Location = new System.Drawing.Point(15, 10);
            this.pbClerk.Name = "pbClerk";
            this.pbClerk.Size = new System.Drawing.Size(150, 150);
            this.pbClerk.TabIndex = 4;
            this.pbClerk.TabStop = false;
            // 
            // rtbShopChatter
            // 
            this.rtbShopChatter.BackColor = System.Drawing.Color.Black;
            this.rtbShopChatter.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbShopChatter.ForeColor = System.Drawing.Color.White;
            this.rtbShopChatter.Location = new System.Drawing.Point(170, 10);
            this.rtbShopChatter.Name = "rtbShopChatter";
            this.rtbShopChatter.Size = new System.Drawing.Size(275, 90);
            this.rtbShopChatter.TabIndex = 5;
            this.rtbShopChatter.Text = "";
            // 
            // lbShopInventory
            // 
            this.lbShopInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShopInventory.FormattingEnabled = true;
            this.lbShopInventory.ItemHeight = 16;
            this.lbShopInventory.Location = new System.Drawing.Point(81, 319);
            this.lbShopInventory.Name = "lbShopInventory";
            this.lbShopInventory.Size = new System.Drawing.Size(285, 116);
            this.lbShopInventory.TabIndex = 6;
            this.lbShopInventory.SelectedIndexChanged += new System.EventHandler(this.lbShopInventory_SelectedIndexChanged);
            this.lbShopInventory.Enter += new System.EventHandler(this.lbShopInventory_Enter);
            // 
            // pbSelectedItem
            // 
            this.pbSelectedItem.Location = new System.Drawing.Point(170, 106);
            this.pbSelectedItem.Name = "pbSelectedItem";
            this.pbSelectedItem.Size = new System.Drawing.Size(50, 50);
            this.pbSelectedItem.TabIndex = 7;
            this.pbSelectedItem.TabStop = false;
            // 
            // rtbSelectedInfo
            // 
            this.rtbSelectedInfo.BackColor = System.Drawing.Color.Black;
            this.rtbSelectedInfo.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSelectedInfo.ForeColor = System.Drawing.Color.White;
            this.rtbSelectedInfo.Location = new System.Drawing.Point(81, 166);
            this.rtbSelectedInfo.Name = "rtbSelectedInfo";
            this.rtbSelectedInfo.Size = new System.Drawing.Size(364, 145);
            this.rtbSelectedInfo.TabIndex = 8;
            this.rtbSelectedInfo.Text = "";
            // 
            // tbAmount
            // 
            this.tbAmount.BackColor = System.Drawing.Color.Black;
            this.tbAmount.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmount.ForeColor = System.Drawing.Color.Red;
            this.tbAmount.Location = new System.Drawing.Point(206, 461);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.ReadOnly = true;
            this.tbAmount.Size = new System.Drawing.Size(60, 27);
            this.tbAmount.TabIndex = 9;
            // 
            // btnEquip
            // 
            this.btnEquip.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquip.Location = new System.Drawing.Point(370, 380);
            this.btnEquip.Name = "btnEquip";
            this.btnEquip.Size = new System.Drawing.Size(75, 50);
            this.btnEquip.TabIndex = 10;
            this.btnEquip.Text = "Equip";
            this.btnEquip.UseVisualStyleBackColor = true;
            this.btnEquip.Click += new System.EventHandler(this.btnEquip_Click);
            // 
            // radioInfo
            // 
            this.radioInfo.AutoSize = true;
            this.radioInfo.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInfo.Location = new System.Drawing.Point(6, 33);
            this.radioInfo.Name = "radioInfo";
            this.radioInfo.Size = new System.Drawing.Size(47, 22);
            this.radioInfo.TabIndex = 11;
            this.radioInfo.TabStop = true;
            this.radioInfo.Text = "Info";
            this.radioInfo.UseVisualStyleBackColor = true;
            this.radioInfo.CheckedChanged += new System.EventHandler(this.radioSelectedText_CheckChanged);
            // 
            // radioAbout
            // 
            this.radioAbout.AutoSize = true;
            this.radioAbout.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAbout.Location = new System.Drawing.Point(6, 74);
            this.radioAbout.Name = "radioAbout";
            this.radioAbout.Size = new System.Drawing.Size(59, 22);
            this.radioAbout.TabIndex = 12;
            this.radioAbout.TabStop = true;
            this.radioAbout.Text = "About";
            this.radioAbout.UseVisualStyleBackColor = true;
            this.radioAbout.CheckedChanged += new System.EventHandler(this.radioSelectedText_CheckChanged);
            // 
            // lblSelectedName
            // 
            this.lblSelectedName.AutoSize = true;
            this.lblSelectedName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedName.Location = new System.Drawing.Point(226, 120);
            this.lblSelectedName.Name = "lblSelectedName";
            this.lblSelectedName.Size = new System.Drawing.Size(47, 20);
            this.lblSelectedName.TabIndex = 13;
            this.lblSelectedName.Text = "label1";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("OCR A Extended", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(210, 441);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(53, 17);
            this.lblCost.TabIndex = 14;
            this.lblCost.Text = "Cost:";
            // 
            // gbSelectedText
            // 
            this.gbSelectedText.Controls.Add(this.radioAbout);
            this.gbSelectedText.Controls.Add(this.radioInfo);
            this.gbSelectedText.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSelectedText.Location = new System.Drawing.Point(5, 166);
            this.gbSelectedText.Name = "gbSelectedText";
            this.gbSelectedText.Size = new System.Drawing.Size(70, 145);
            this.gbSelectedText.TabIndex = 15;
            this.gbSelectedText.TabStop = false;
            // 
            // radioStock
            // 
            this.radioStock.AutoSize = true;
            this.radioStock.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioStock.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioStock.Location = new System.Drawing.Point(8, 25);
            this.radioStock.Name = "radioStock";
            this.radioStock.Size = new System.Drawing.Size(43, 35);
            this.radioStock.TabIndex = 12;
            this.radioStock.TabStop = true;
            this.radioStock.Text = "Stock";
            this.radioStock.UseVisualStyleBackColor = true;
            this.radioStock.CheckedChanged += new System.EventHandler(this.radioStock_CheckChanged);
            // 
            // radioGeneric
            // 
            this.radioGeneric.AutoSize = true;
            this.radioGeneric.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioGeneric.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGeneric.Location = new System.Drawing.Point(3, 74);
            this.radioGeneric.Name = "radioGeneric";
            this.radioGeneric.Size = new System.Drawing.Size(56, 35);
            this.radioGeneric.TabIndex = 11;
            this.radioGeneric.TabStop = true;
            this.radioGeneric.Text = "Generic";
            this.radioGeneric.UseVisualStyleBackColor = true;
            this.radioGeneric.CheckedChanged += new System.EventHandler(this.radioStock_CheckChanged);
            // 
            // gbInventory
            // 
            this.gbInventory.Controls.Add(this.radioStock);
            this.gbInventory.Controls.Add(this.radioGeneric);
            this.gbInventory.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInventory.Location = new System.Drawing.Point(5, 313);
            this.gbInventory.Name = "gbInventory";
            this.gbInventory.Size = new System.Drawing.Size(70, 125);
            this.gbInventory.TabIndex = 16;
            this.gbInventory.TabStop = false;
            // 
            // TownShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbInventory);
            this.Controls.Add(this.gbSelectedText);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblSelectedName);
            this.Controls.Add(this.btnEquip);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.rtbSelectedInfo);
            this.Controls.Add(this.pbSelectedItem);
            this.Controls.Add(this.lbShopInventory);
            this.Controls.Add(this.rtbShopChatter);
            this.Controls.Add(this.pbClerk);
            this.Controls.Add(this.lblYeast);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBuy);
            this.Name = "TownShop";
            this.Size = new System.Drawing.Size(450, 500);
            ((System.ComponentModel.ISupportInitialize)(this.pbClerk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedItem)).EndInit();
            this.gbSelectedText.ResumeLayout(false);
            this.gbSelectedText.PerformLayout();
            this.gbInventory.ResumeLayout(false);
            this.gbInventory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblYeast;
        private System.Windows.Forms.PictureBox pbClerk;
        private System.Windows.Forms.RichTextBox rtbShopChatter;
        private System.Windows.Forms.ListBox lbShopInventory;
        private System.Windows.Forms.PictureBox pbSelectedItem;
        private System.Windows.Forms.RichTextBox rtbSelectedInfo;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Button btnEquip;
        private System.Windows.Forms.RadioButton radioInfo;
        private System.Windows.Forms.RadioButton radioAbout;
        private System.Windows.Forms.Label lblSelectedName;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.GroupBox gbSelectedText;
        private System.Windows.Forms.RadioButton radioStock;
        private System.Windows.Forms.RadioButton radioGeneric;
        private System.Windows.Forms.GroupBox gbInventory;
    }
}
