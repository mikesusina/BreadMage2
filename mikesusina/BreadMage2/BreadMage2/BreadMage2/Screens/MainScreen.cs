using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BreadMage2.Screens;
using System.Data.OleDb;

namespace BreadMage2.Screens
{
    public partial class MainScreen : Form
    {
        public engGame mGame;
        public GameScreen scrGame;
        public SettingsScreen scrSettings;

        public MainScreen()
        {
            InitializeComponent();
            mGame = new engGame(this);
            mGame.BootGame();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mGame.NewGame();
        }

        //Load Game TS
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //will need to act
            mGame.LoadGame(1);
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (scrSettings != null)
            {
                scrSettings.Close();
                if (scrGame.Visible) { scrGame.Hide(); }
            }
            Point p = new Point(100, 10);
            scrSettings = new SettingsScreen() { MdiParent = this };
            scrSettings.Show();
            scrSettings.Location = p;
        }

        private void devToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(mGame != null)
            {
                Form myform = new DevTools(mGame);
                myform.Show();
            }
            else { MessageBox.Show("You need a game to hack"); }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<GameScreen>().Count() == 1)
            {
                this.Close();
            }
            else
            {
                string s = DateTime.Now.ToString("MM/DD/yy h:mm:ss");
                s = s.Substring(s.Length - 1, 1);
                int i = int.Parse(s);

                if (i >= 5) { s = "You'll lose all those hard earned croutons"; }
                else { s = "I can't undo your bad choices"; }
                if (MessageBox.Show(s, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                { this.Close(); }
            }
        }
    }
}
