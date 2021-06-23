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


        // for item libraries - avoid pulling too much game data, but this should increase new and load game performance 
        public List<clsConsumable> mConsumableLib { get; set; }
        public List<clsCombatItem> mCombatLib { get; set; }
        public List<clsChoiceAdventure> mChoiceLib { get; set; }

        public List<clsMonster> mMonsterList { get; set; }

        public MainScreen()
        {
            InitializeComponent();

            BreadDB breadConn = new BreadDB();
            mMonsterList = breadConn.LoadMonsterList();
            mConsumableLib = breadConn.LoadConsumablesLib();
            mCombatLib = breadConn.LoadCombatLib();
            mChoiceLib = breadConn.LoadChoiceList();

            scrGame = new GameScreen(this, -1, mMonsterList, mConsumableLib, mCombatLib, mChoiceLib);
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

        //New Game TS
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (scrGame != null)
            {
                scrGame.Close();
                scrGame = new GameScreen(this, 0, mMonsterList, mConsumableLib, mCombatLib, mChoiceLib);
                scrGame.MdiParent = this;

                /*
                //maybe not needed? Mage class needed libraries for item count updates, but worked around without them. Will they be necessary?
                scrGame.gConsumableLib = mConsumableLib;
                scrGame.gCombatLib = mCombatLib;
                scrGame.gMonsterList = mMonsterList;

                scrGame.gMage.myConsumableLib = mConsumableLib;
                scrGame.gMage.myCombatLib = mCombatLib;
                */
            }
            Point p = new Point(65, 10);
            scrGame.Show();
            scrGame.Location = p;
        }

        //Load Game TS
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: IMPLEMENT actually picting a save ID
            if (scrGame != null)
            {
                scrGame.Close();
                scrGame = new GameScreen(this, 1, mMonsterList, mConsumableLib, mCombatLib, mChoiceLib);
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
