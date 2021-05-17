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
using BreadMage2.Controls;

namespace BreadMage2
{
    public partial class GameScreen : Form
    {
        public MainScreen scrMain;

        public clsMage gMage { get; set; }
        public clsMonster gMonster { get; set; }

        public BreadMage bMage {get; set;}
        public ExtraBoard bExtra { get; set; }
        public FightBoard bFight { get; set; }
        
        public List<clsMonster> gMonsterList { get; set; }

        // for item libraries
        public List<clsConsumable> gConsumableLib { get; set; }
        public List<clsCombatItem> gCombatLib { get; set; }

        // for player inventory
        public DataSet gPlayerInv { get; set; }
        
        public Random gRandom { get; set; }

        public engGLog gLog { get; set; }


        public GameScreen(MainScreen scrMainScreen, int iLoadFlag)
        {
            InitializeComponent();
            scrMain = scrMainScreen;
            this.FormClosing += Form1_FormClosing;

            //LoadFlag 0  = new game
            //LoadFlag 1  = load game
            //LoadFlag -1 = fresh boot, don't create a mage object yet 

            gRandom = new Random();
            BreadDB BreadNet = new BreadDB();

            switch (iLoadFlag)
            {
                case 0:
                    clsMage gMage = new clsMage();
                    // Clear any mage info from the panel first
                    if (pMageZone.Controls != null) { pMageZone.Controls.Clear(); }
                    bMage = new BreadMage(gMage);
                    pMageZone.Controls.Add(bMage);
                    bMage.Show();
                    // clear the Log
                    //lbLog.Items.Clear();
                    gLog = new engGLog(lbLog);
                    gLog.Add("Welcome to Bread Mage 2!!!");

                    //load various data from DB
                    gMonsterList = BreadNet.LoadMonsterList();
                    gConsumableLib = BreadNet.LoadConsumablesLib();
                    gCombatLib = BreadNet.LoadCombatLib();


                    if (pExtraInfo != null) { pExtraInfo.Controls.Clear(); }
                    this.gMage = gMage;
                    bExtra = new ExtraBoard(this);
                    pExtraInfo.Controls.Add(bExtra);
                    bExtra.Show();
                    break;
                case 1:
                    break;
                case -1:
                    break;
            }


            //for implementinvg SaveIDs
            int iSaveID = 1;
            gPlayerInv = BreadNet.LoadPlayerInv(iSaveID);
        }


        public void GameOver()
        {
            //update image to skull
            bMage.GameOverImage();
            bMage.pbHP.Value = 0;
            bMage.ZeroHPtag();

            // messagebox
            MessageBox.Show("TOASTED");

            //close game screen? leave the dead mage but dispose
            bFight.Dispose();
            bExtra.Dispose();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }


        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            string s = DateTime.Now.ToString("MM/DD/yy h:mm:ss");
            s = s.Substring(s.Length - 1, 1);
            int i = int.Parse(s);

            if (i >= 5) { s = "You'll lose all those hard earned croutons"; }
            else { s = "I can't undo your bad choices"; }
            if (MessageBox.Show(s, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
