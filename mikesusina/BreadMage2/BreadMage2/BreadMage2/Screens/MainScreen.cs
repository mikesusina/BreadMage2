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
        public GameScreen scrGame;
        public SettingsScreen scrSettings;

        public MainScreen()
        {
            InitializeComponent();
            scrGame = new GameScreen(this, -1);
            scrSettings = new SettingsScreen(this);
            scrGame.MdiParent = this;
            scrSettings.MdiParent = this;

            //////
            //boot game immediately rather than new game, for testing
            //////
            /*
              Point p = new Point(65, 10);
              scrGame.Show();
              scrGame.Location = p;
            */
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (scrGame != null)
                {
                scrGame.Close();
                scrGame = new GameScreen(this, 0);
                scrGame.MdiParent = this;
                }
            Point p = new Point(65, 10);
            scrGame.Show();
            scrGame.Location = p;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (scrSettings != null)
            {
                scrSettings.Close();
                scrSettings = new SettingsScreen(this)
                { MdiParent = this };
                if (scrGame.Visible) { scrGame.Hide(); }
                /*
                if (scrGame.WindowState != FormWindowState.Minimized)
                { scrGame.WindowState = FormWindowState.Minimized; }
                */
            }
            Point p = new Point(100, 10);
            scrSettings.Show();
            scrSettings.Location = p;
        }

        private void devToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(scrGame != null)
            {
                Form myform = new DevTools(scrGame);
                myform.Show();
            }
            else { MessageBox.Show("You need a game to hack"); }
        }
    }
}
