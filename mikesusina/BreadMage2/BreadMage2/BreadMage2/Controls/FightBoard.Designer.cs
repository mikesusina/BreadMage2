﻿namespace BreadMage2.Controls
{
    partial class FightBoard
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
            this.pbMonster = new System.Windows.Forms.PictureBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pbMonHP = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChatter = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMonster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMonster
            // 
            this.pbMonster.Location = new System.Drawing.Point(150, 37);
            this.pbMonster.Name = "pbMonster";
            this.pbMonster.Size = new System.Drawing.Size(150, 150);
            this.pbMonster.TabIndex = 0;
            this.pbMonster.TabStop = false;
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(100, 243);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 1;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 272);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(275, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(275, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // pbMonHP
            // 
            this.pbMonHP.BackColor = System.Drawing.SystemColors.Control;
            this.pbMonHP.ForeColor = System.Drawing.Color.Red;
            this.pbMonHP.Location = new System.Drawing.Point(165, 221);
            this.pbMonHP.Name = "pbMonHP";
            this.pbMonHP.Size = new System.Drawing.Size(120, 15);
            this.pbMonHP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbMonHP.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // txtChatter
            // 
            this.txtChatter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtChatter.BackColor = System.Drawing.Color.Black;
            this.txtChatter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatter.ForeColor = System.Drawing.Color.Lime;
            this.txtChatter.Location = new System.Drawing.Point(12, 301);
            this.txtChatter.Multiline = true;
            this.txtChatter.Name = "txtChatter";
            this.txtChatter.ReadOnly = true;
            this.txtChatter.Size = new System.Drawing.Size(418, 147);
            this.txtChatter.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(125, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // FightBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtChatter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbMonHP);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.pbMonster);
            this.Name = "FightBoard";
            this.Size = new System.Drawing.Size(450, 585);
            ((System.ComponentModel.ISupportInitialize)(this.pbMonster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMonster;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.ProgressBar pbMonHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChatter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
