namespace BreadMage2.Controls.TownBoards
{
    partial class TownSave
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
            this.btnSave = new System.Windows.Forms.Button();
            this.rtbShopChatter = new System.Windows.Forms.RichTextBox();
            this.pbClerk = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEQSpells = new System.Windows.Forms.Button();
            this.btnEQMent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbClerk)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(268, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 70);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save and Rest";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rtbShopChatter
            // 
            this.rtbShopChatter.BackColor = System.Drawing.Color.Black;
            this.rtbShopChatter.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbShopChatter.ForeColor = System.Drawing.Color.White;
            this.rtbShopChatter.Location = new System.Drawing.Point(96, 178);
            this.rtbShopChatter.Name = "rtbShopChatter";
            this.rtbShopChatter.Size = new System.Drawing.Size(275, 90);
            this.rtbShopChatter.TabIndex = 14;
            this.rtbShopChatter.Text = "";
            // 
            // pbClerk
            // 
            this.pbClerk.Location = new System.Drawing.Point(154, 22);
            this.pbClerk.Name = "pbClerk";
            this.pbClerk.Size = new System.Drawing.Size(150, 150);
            this.pbClerk.TabIndex = 13;
            this.pbClerk.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(282, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 50);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEQSpells
            // 
            this.btnEQSpells.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEQSpells.Location = new System.Drawing.Point(77, 302);
            this.btnEQSpells.Name = "btnEQSpells";
            this.btnEQSpells.Size = new System.Drawing.Size(101, 62);
            this.btnEQSpells.TabIndex = 11;
            this.btnEQSpells.Text = "Equip Spells";
            this.btnEQSpells.UseVisualStyleBackColor = true;
            // 
            // btnEQMent
            // 
            this.btnEQMent.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEQMent.Location = new System.Drawing.Point(77, 384);
            this.btnEQMent.Name = "btnEQMent";
            this.btnEQMent.Size = new System.Drawing.Size(101, 62);
            this.btnEQMent.TabIndex = 16;
            this.btnEQMent.Text = "Equip Spells";
            this.btnEQMent.UseVisualStyleBackColor = true;
            // 
            // TownSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEQMent);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbShopChatter);
            this.Controls.Add(this.pbClerk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEQSpells);
            this.Name = "TownSave";
            this.Size = new System.Drawing.Size(450, 500);
            ((System.ComponentModel.ISupportInitialize)(this.pbClerk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtbShopChatter;
        private System.Windows.Forms.PictureBox pbClerk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEQSpells;
        private System.Windows.Forms.Button btnEQMent;
    }
}
