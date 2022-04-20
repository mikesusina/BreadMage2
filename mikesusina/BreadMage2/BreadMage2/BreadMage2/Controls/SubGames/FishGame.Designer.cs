namespace BreadMage2.Controls.SubGames
{
    partial class FishGame
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFish = new System.Windows.Forms.Button();
            this.FishTimer = new System.Windows.Forms.Timer(this.components);
            this.rtbFishChatter = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(78, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 126);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnFish
            // 
            this.btnFish.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFish.Location = new System.Drawing.Point(103, 144);
            this.btnFish.Name = "btnFish";
            this.btnFish.Size = new System.Drawing.Size(92, 75);
            this.btnFish.TabIndex = 1;
            this.btnFish.Text = "Cast!";
            this.btnFish.UseVisualStyleBackColor = true;
            this.btnFish.Click += new System.EventHandler(this.btnFish_Click);
            // 
            // FishTimer
            // 
            this.FishTimer.Interval = 1000;
            this.FishTimer.Tick += new System.EventHandler(this.FishTimer_Tick);
            // 
            // rtbFishChatter
            // 
            this.rtbFishChatter.BackColor = System.Drawing.Color.Black;
            this.rtbFishChatter.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbFishChatter.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.rtbFishChatter.HideSelection = false;
            this.rtbFishChatter.Location = new System.Drawing.Point(36, 225);
            this.rtbFishChatter.Name = "rtbFishChatter";
            this.rtbFishChatter.ReadOnly = true;
            this.rtbFishChatter.Size = new System.Drawing.Size(221, 90);
            this.rtbFishChatter.TabIndex = 10;
            this.rtbFishChatter.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // FishGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbFishChatter);
            this.Controls.Add(this.btnFish);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FishGame";
            this.Size = new System.Drawing.Size(300, 400);
            this.Load += new System.EventHandler(this.FishGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFish;
        private System.Windows.Forms.Timer FishTimer;
        private System.Windows.Forms.RichTextBox rtbFishChatter;
        private System.Windows.Forms.Label label1;
    }
}
