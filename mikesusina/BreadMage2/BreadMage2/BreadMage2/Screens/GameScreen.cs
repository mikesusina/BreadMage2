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
        public clsMonster gChatBot { get; set; } //for holding some universal chatterbox values to sprinkle in with specific ones

        public BreadMage bMage { get; set; }
        public ExtraBoard bExtra { get; set; }
        public FightBoard bFight { get; set; }
        public QuickBoard bQuick { get; set; }
        public ChoiceBoard bChoice { get; set; }

        public List<clsMonster> gMonsterList { get; set; }

        // for libraries
        public List<clsUniqueItem> gItemBook { get; set; }
        public List<clsChoiceAdventure> gChoiceList { get; set; }

        public Random gRandom { get; set; }

        public engGLog gLog { get; set; }

        public bool gLock { get; set; }

        

        public GameScreen(MainScreen scrMainScreen, int iLoadFlag, List<clsMonster> aMonsterList, List<clsUniqueItem> aItemBook, List<clsChoiceAdventure> aChoiceLib)
        {
            InitializeComponent();
            scrMain = scrMainScreen;
            this.FormClosing += Form1_FormClosing;


            gMonsterList = aMonsterList;
            gItemBook = aItemBook;
            gChoiceList = aChoiceLib;
            gLock = false;

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



                if (gMonsterList is null || gItemBook is null || gChoiceList is null)
                {
                    //load various data from DB
                    //hopefully this is in memory already from program boot
                    gMonsterList = BreadNet.LoadMonsterList();
                    gItemBook = BreadNet.LoadUniqueItemsList();
                    gChoiceList = BreadNet.LoadChoiceList();
                    gMage.myItemBook = gItemBook;
                }

                if (gChatBot is null)
                {
                    if (gMonsterList.Exists(x => x.monID == 7)) { gChatBot = gMonsterList.Find(x => x.monID == 7); }
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
                gMage.myInv = BreadNet.LoadPlayerInv(1);
                gMage.myStatEffects = BreadNet.LoadMageEffectsList(1);
                gMage.SaveID = 1;

                bMage = new BreadMage(gMage);
                pMageZone.Controls.Add(bMage);
                bMage.Show();
                // clear the Log
                //lbLog.Items.Clear();
                gLog = new engGLog(lbLog);
                gLog.Add("Welcome to Bread Mage 2!!!");

                //for updating item count stuff
                gMage.RefreshInvNumbers = UpdateQuickBoard;



                if (gMonsterList is null || gItemBook is null || gChoiceList is null)
                {
                    //load various data from DB
                    //hopefully this is in memory already from program boot
                    gMonsterList = BreadNet.LoadMonsterList();
                    gItemBook = BreadNet.LoadUniqueItemsList();
                    gChoiceList = BreadNet.LoadChoiceList();
                    gMage.myItemBook = gItemBook;
                }

                if (gChatBot is null)
                {
                    if (gMonsterList.Exists(x => x.monID == 7)) { gChatBot = gMonsterList.Find(x => x.monID == 7); }
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

        public string GetItemName(int anID)
        {
            string s = "";
            if (gItemBook.Exists(x => x.itemID == anID))
            {
                clsUniqueItem o = gItemBook.Find(x => x.itemID == anID);
                s = o.ItemName;
            }
            return s;
        }

        public void ChoiceChain(clsChoiceAdventure anAdv)
        {
            this.Controls["pArea"].Controls.Clear();
            try
            {
                bChoice = new ChoiceBoard(this, anAdv);
                Controls["pArea"].Controls.Add(bChoice);
                gLock = true;
                bChoice.Show();
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        public void ChoiceFight(int anID)
        {
            this.Controls["pArea"].Controls.Clear();
            try
            {
                Control FightZone = new Control();
                bFight = new FightBoard(this, anID);
                Controls["pArea"].Controls.Add(bFight);
                gLock = true;
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

        public List<clsItem> GetPlayerInv()
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
