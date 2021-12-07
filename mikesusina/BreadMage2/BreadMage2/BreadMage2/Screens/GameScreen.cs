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
        public clsMonster gMageChatBot { get; set; } //same, but for mage generic attacks

        public BreadMage bMage { get; set; }
        public ExtraBoard bExtra { get; set; }
        public FightBoard bFight { get; set; }
        public QuickBoard bQuick { get; set; }
        public ChoiceBoard bChoice { get; set; }
        public MapBoard bMap { get; set; }



        public clsGameLibs GameLibraries { get; set; } = new clsGameLibs();
        public Random gRandom { get; set; } 

        public engGLog gLog { get; set; }
        private engBuffs gBuffHelper { get; set; }

        public bool gLock { get; set; } = false;

        

        //public GameScreen(MainScreen scrMainScreen, int iLoadFlag, List<clsMonster> aMonsterList, List<clsUniqueItem> aItemBook, List<clsChoiceAdventure> aChoiceLib, List<EffectChatter> aEffectChatterList, List<clsSpell> aSpellBook)
        public GameScreen(MainScreen scrMainScreen, int iLoadFlag, clsGameLibs Libs)
        {
            InitializeComponent();
            scrMain = scrMainScreen;
            this.FormClosing += Form1_FormClosing;

            GameLibraries = Libs;
            /*
            gMonsterList = aMonsterList;
            gItemBook = aItemBook;
            gChoiceList = aChoiceLib;
            gSpellBook = aSpellBook;
            gEffectChatter = aEffectChatterList;
            */

            gRandom = new Random();
            gLock = false;
            gBuffHelper = new engBuffs();
            gBuffHelper.SetGame(this);
            gMage = new clsMage();

            //LoadFlag 0  = new game
            //LoadFlag N  = load game (N will be save game ID)
            //LoadFlag -1 = fresh boot, don't create a mage object yet 

            
            BreadDB BreadNet = new BreadDB();
            //gLocationList = BreadNet.LoadLocationList();

            if (iLoadFlag == 0)
            {
                // Clear any mage info from the panel first
                if (pMageZone.Controls != null) { pMageZone.Controls.Clear(); }
                bMage = new BreadMage(this);
                bMage.LoadScreen();
                pMageZone.Controls.Add(bMage);

                //for implementinvg SaveIDs
                //int iSaveID = 1;
                //gMage.myInv = BreadNet.LoadPlayerInv(iSaveID);


                bMage.Show();
                // clear the Log
                gLog = new engGLog(lbLog);
                gLog.Add("Welcome to Bread Mage 2!!!");

                //for updating item count stuff
                gMage.RefreshInvNumbers = UpdateQuickBoard;

                if (GameLibraries is null)
                {
                    //load various data from DB - hopefully this is in memory already from program boot
                    GameLibraries = BreadNet.LoadLibraries();
                }
                if (gChatBot is null) { if (GameLibraries.MonsterLib().Exists(x => x.monID == 7)) { gChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 7); } }
                if (gMageChatBot is null) { if (GameLibraries.MonsterLib().Exists(x => x.monID == 12)) { gMageChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 12); } }

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

                //new game logic - maybe a method?

                gMage.GrantSpell(GetSpell("Freshly Baked"));
                gMage.EquipSpell(GetSpell("Freshly Baked"));
            }

            else if (iLoadFlag == -1)
            { }
            else if (iLoadFlag == 1)
            {
                try
                {
                    //load test saveID
                    gMage = new clsMage();
                    // Clear any mage info from the panel first
                    if (pMageZone.Controls != null) { pMageZone.Controls.Clear(); }
                    gMage.myGameFlags = BreadNet.LoadGameFlags();
                    gMage.SaveID = iLoadFlag;

                    ///adding a spell
                    gMage.GrantSpell(1);
                    gMage.GrantSpell(2);
                    gMage.GrantSpell(5);

                    bMage = new BreadMage(this);
                    bMage.LoadScreen();
                    pMageZone.Controls.Add(bMage);
                    bMage.Show();
                    // clear the Log
                    //lbLog.Items.Clear();
                    gLog = new engGLog(lbLog);
                    gLog.Add("Welcome to Bread Mage 2!!!");

                    //for updating item count stuff
                    gMage.RefreshInvNumbers = UpdateQuickBoard;
                }
                catch (ApplicationException ex)
                {
                    string s = "You mage didn't come out of the over correctly" + Environment.NewLine + ex.InnerException.ToString();
                }




                if (GameLibraries is null)
                {
                    //load various data from DB
                    //hopefully this is in memory already from program boot
                    GameLibraries = BreadNet.LoadLibraries();
                    /*
                    gMonsterList = BreadNet.LoadMonsterList();
                    gItemBook = BreadNet.LoadUniqueItemsList();
                    gChoiceList = BreadNet.LoadChoiceList();
                    gSpellBook = BreadNet.LoadSpellList();
                    */
                }

                if (gChatBot is null)
                {
                    if (GameLibraries.MonsterLib().Exists(x => x.monID == 7)) { gChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 7); }
                }
                if (gMageChatBot is null)
                {
                    if (GameLibraries.MonsterLib().Exists(x => x.monID == 12)) { gMageChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 12); }
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
            if (GameLibraries.ItemLib().Exists(x => x.itemID == anID))
            {
                clsUniqueItem o = GameLibraries.ItemLib().Find(x => x.itemID == anID);
                s = o.ItemName;
            }
            return s;
        }
        public clsUniqueItem GetUniqueItem(int anID)
        {
            return GameLibraries.ItemLib().Find(x => x.itemID == anID);
        }
        public clsUniqueItem GetUniqueItem(string anItemName)
        {
            return GameLibraries.ItemLib().Find(x => x.ItemName == anItemName);
        }
        public clsEquipment GetEquipmentItem(int anID)
        {
            return GameLibraries.EquipLib().Find(x => x.equipID == anID);
        }
        public clsEquipment GetEquipmentItem(string anItemName)
        {
            return GameLibraries.EquipLib().Find(x => x.ItemName == anItemName);
        }

        public List<int> getObtainedEquipmentIDs()
        {
            List<int> iReturn = new List<int>();
            foreach (int i in gMage.GetSaveData().gottenItems)
            {
                if (GameLibraries.EquipLib().Exists(x => x.equipID == i)) { iReturn.Add(i); }
            }
            return iReturn;
        }


        public clsEquipment flopUniqueforEquip(clsUniqueItem aUnique)
        {
            return GameLibraries.EquipLib().Find(x => x.equipID == aUnique.itemID);
        }
        public clsUniqueItem flopEquipforUnique(clsEquipment anEquip)
        {
            return GameLibraries.ItemLib().Find(x => x.itemID == anEquip.equipID);
        }


        public clsSpell GetSpell(int anID)
        {
            return GameLibraries.SpellBook().Find(x => x.spellID == anID);
        }
        public clsSpell GetSpell(string aSpellName)
        {
            return GameLibraries.SpellBook().Find(x => x.spellName == aSpellName);
        }
        public List<clsSpell> GetItemSpells()
        {
            return GameLibraries.SpellBook().FindAll(x => x.spellType == "I");
        }
        public List<clsSpell> GetAllKnownMageSpells(string sType = "A")
        {
            List<clsSpell> returnSpells = new List<clsSpell>();
            foreach (int i in gMage.AllSpells())
            {
                returnSpells.Add(GetSpell(i));
            }
            if (sType == "I") { returnSpells = returnSpells.FindAll(x => x.spellType == "I"); }
            return returnSpells;
        }
        public engBuffs BuffHelper()
        {
            return gBuffHelper;
        }

        public void ChoiceChain(int anAdvID)
        {
            this.Controls["pArea"].Controls.Clear();
            try
            {
                bChoice = new ChoiceBoard(this, anAdvID);
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

        public void RefreshMage()
        {
            foreach (clsEquipment e in gMage.myEquipment())
            {
                if (e.PassiveEffect() != 0 && gMage.EQSpells().Contains(GameLibraries.SpellBook().Find(x => x.spellID == e.PassiveEffect())) == false)
                {
                    gMage.EquipSpell(GameLibraries.SpellBook().Find(x => x.spellID == e.PassiveEffect()));
                }
            }
            //loop through ticking buffs/debuffs

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
