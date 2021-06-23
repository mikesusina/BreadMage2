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
        public QuickBoard bQuick { get; set; }
        
        public List<clsMonster> gMonsterList { get; set; }

        // for libraries
        public List<clsConsumable> gConsumableLib { get; set; }
        public List<clsCombatItem> gCombatLib { get; set; }
        public List<clsChoiceAdventure> gChoiceList { get; set; }

        public Random gRandom { get; set; }

        public engGLog gLog { get; set; }


        

        public GameScreen(MainScreen scrMainScreen, int iLoadFlag, List<clsMonster> aMonsterList, List<clsConsumable> aConsumableLib, List<clsCombatItem> aCombatLib, List<clsChoiceAdventure> aChoiceLib)
        {
            InitializeComponent();
            scrMain = scrMainScreen;
            this.FormClosing += Form1_FormClosing;


            gMonsterList = aMonsterList;
            gConsumableLib = aConsumableLib;
            gCombatLib = aCombatLib;
            gChoiceList = aChoiceLib;

            //LoadFlag 0  = new game
            //LoadFlag N  = load game (N will be save game ID)
            //LoadFlag -1 = fresh boot, don't create a mage object yet 

            gRandom = new Random();
            BreadDB BreadNet = new BreadDB();

            if (iLoadFlag == 0)
            {
                clsMage gMage = new clsMage();
                // Clear any mage info from the panel first
                if (pMageZone.Controls != null) { pMageZone.Controls.Clear(); }
                bMage = new BreadMage(gMage);
                pMageZone.Controls.Add(bMage);

                //for implementinvg SaveIDs
                //int iSaveID = 1;
                //gMage.myInv = BreadNet.LoadPlayerInv(iSaveID);


                bMage.Show();
                // clear the Log
                //lbLog.Items.Clear();
                gLog = new engGLog(lbLog);
                gLog.Add("Welcome to Bread Mage 2!!!");

                //for updating item count stuff
                gMage.RefreshInvNumbers = UpdateQuickBoard;



                if (gMonsterList is null || gCombatLib is null || gConsumableLib is null || gChoiceList is null)
                {
                    //load various data from DB
                    //hopefully this is in memory already from program boot
                    gMonsterList = BreadNet.LoadMonsterList();
                    gConsumableLib = BreadNet.LoadConsumablesLib();
                    gCombatLib = BreadNet.LoadCombatLib();
                    gChoiceList = BreadNet.LoadChoiceList();
                    gMage.myConsumableLib = gConsumableLib;
                    gMage.myCombatLib = gCombatLib;
                    
                }



                //boards
                if (pExtraInfo != null) { pExtraInfo.Controls.Clear(); }
                this.gMage = gMage;
                bExtra = new ExtraBoard(this);
                pExtraInfo.Controls.Add(bExtra);
                bExtra.Show();

                if (pQuickBoard != null) { pQuickBoard.Controls.Clear(); }
                this.gMage = gMage;
                bQuick = new QuickBoard(this);
                pQuickBoard.Controls.Add(bQuick);
                bQuick.Show();
            }

            else if (iLoadFlag == -1)
            { }
            else if (iLoadFlag == 1)
            {
                //load test saveID
                clsMage gMage = new clsMage();
                // Clear any mage info from the panel first
                if (pMageZone.Controls != null) { pMageZone.Controls.Clear(); }
                bMage = new BreadMage(gMage);
                pMageZone.Controls.Add(bMage);

                gMage.SaveID = 1;
                gMage.myInv = BreadNet.LoadPlayerInv(1);


                bMage.Show();
                // clear the Log
                //lbLog.Items.Clear();
                gLog = new engGLog(lbLog);
                gLog.Add("Welcome to Bread Mage 2!!!");

                //for updating item count stuff
                gMage.RefreshInvNumbers = UpdateQuickBoard;



                if (gMonsterList is null || gCombatLib is null || gConsumableLib is null || gChoiceList is null)
                {
                    //load various data from DB
                    //hopefully this is in memory already from program boot
                    gMonsterList = BreadNet.LoadMonsterList();
                    gConsumableLib = BreadNet.LoadConsumablesLib();
                    gCombatLib = BreadNet.LoadCombatLib();
                    gChoiceList = BreadNet.LoadChoiceList();
                    gMage.myConsumableLib = gConsumableLib;
                    gMage.myCombatLib = gCombatLib;

                }



                //boards
                if (pExtraInfo != null) { pExtraInfo.Controls.Clear(); }
                this.gMage = gMage;
                bExtra = new ExtraBoard(this);
                pExtraInfo.Controls.Add(bExtra);
                bExtra.Show();

                if (pQuickBoard != null) { pQuickBoard.Controls.Clear(); }
                this.gMage = gMage;
                bQuick = new QuickBoard(this);
                pQuickBoard.Controls.Add(bQuick);
                bQuick.Show();
            }
            else
            { }
        }

        public void ChoiceFight(int anID)
        {
            if (this.Controls["pArea"].Controls["FightBoard"] == null)
            {
                try
                {
                    Control FightZone = new Control();
                    bFight = new FightBoard(this, anID);
                    Controls["pArea"].Controls.Add(bFight);
                    bFight.Show();

                    //FightZone = Controls["pArea"];
                    //FightZone.Controls.Add(bFight);
                    //bFight = bFight;
                }
                catch (ArgumentException e)
                {
                    throw e;
                }

            }
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

        public DataTable GetPlayerInv()
        {
            return gMage.myInv;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        private void UpdateQuickBoard()
        {
            if (bQuick != null)
            {
                bQuick.UpdateItemCount();
            }
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
