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
        public engGame myGame { get; set; }
        public clsMage gMage => myGame.gMage;
        public clsMonster gMonster => myGame.gMonster;

        //TODO: implement a "getboard" and just use this to hold all the game boards
        public List<UserControl> UserBoards => new List<UserControl>() { bMage, bExtra, bQuick };
        public List<UserControl> ActionBoards  => new List<UserControl>() { bFight, bChoice, bEquip, bCast, bSpellbook, bTown, bMap, bSubGame };

        //static boards
        public BreadMage bMage { get; set; }
        public ExtraBoard bExtra { get; set; }
        public QuickBoard bQuick { get; set; }

        //action boards
        public FightBoard bFight { get; set; }
        public ChoiceBoard bChoice { get; set; }
        public EquipBoard bEquip { get; set; }
        public CastBoard bCast { get; set; }
        public SpellbookBoard bSpellbook { get; set; }
        public TownBoard bTown { get; set; }
        public MapBoard bMap { get; set; }
        public SubGameBoard bSubGame { get; set; }


        public clsGameLibs GameLibraries => myGame.GameLibraries;
        public ToolTip gTT => myGame.gTT;

        

        //public GameScreen(MainScreen scrMainScreen, int iLoadFlag, List<clsMonster> aMonsterList, List<clsUniqueItem> aItemBook, List<clsChoiceAdventure> aChoiceLib, List<EffectChatter> aEffectChatterList, List<clsSpell> aSpellBook)
        public GameScreen(engGame aGame)
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            
            myGame = aGame;

            myGame.gLock = false;
        }

        public void LoadBoard(string boardType, int moreInfo = 0)
        {
            switch (boardType)
            {
                case "player":
                    bMage = new BreadMage(myGame);
                    pMageZone.Controls.Add(bMage);
                    bMage.LoadScreen();
                    bMage.Show();
                    break;
                case "extra":
                    if (pExtraInfo.Controls != null) { pExtraInfo.Controls.Clear(); }
                    bExtra = new ExtraBoard(myGame);
                    pExtraInfo.Controls.Add(bExtra);
                    bExtra.Show();
                    break;
                case "quick":
                    if (pQuickBoard != null) { pQuickBoard.Controls.Clear(); }
                    bQuick = new QuickBoard(myGame);
                    pQuickBoard.Controls.Add(bQuick);
                    bQuick.Show();
                    break;
                case "combat":
                    foreach (Control c in pArea.Controls) { c.Hide();}
                    try
                    {
                        if (bFight is null || bFight.IsDisposed)
                        {
                            bFight = new FightBoard(myGame);
                            pArea.Controls.Add(bFight);
                        }
                        myGame.gLock = true;
                        bFight.Show();
                    }
                    catch (ArgumentException e)
                    {
                        throw e;
                    }
                    break;
                case "choice":
                    foreach (Control c in pArea.Controls) { c.Hide();}
                    try
                    {
                        if (bChoice is null || bChoice.IsDisposed)
                        {
                            bChoice = new ChoiceBoard(myGame);
                            pArea.Controls.Add(bChoice);
                        }
                        myGame.gLock = true;
                        bChoice.Show();
                    }
                    catch (ArgumentException e)
                    {
                        throw e;
                    }
                    break;
                case "cast":
                    foreach (Control c in pArea.Controls) { c.Hide();}
                    try
                    {
                        if (bCast is null || bCast.IsDisposed)
                        {
                            bCast = new CastBoard(myGame);
                            pArea.Controls.Add(bCast);
                        }
                        bCast.LoadBoard();
                        myGame.gLock = true;
                        bCast.Show();
                    }
                    catch (ArgumentException e)
                    {
                        throw e;
                    }
                    break;
                case "spellbook":
                    foreach (Control c in pArea.Controls) { c.Hide();}
                    try
                    {
                        if (bSpellbook is null || bSpellbook.IsDisposed)
                        {
                            bSpellbook = new SpellbookBoard(myGame);
                            pArea.Controls.Add(bSpellbook);
                        }
                        myGame.gLock = true;
                        bSpellbook.LoadBoard();
                        bSpellbook.Show();
                    }
                    catch (ArgumentException e)
                    {
                        throw e;
                    }
                    break;
                case "equip":
                    foreach (Control c in pArea.Controls) { c.Hide();}
                    try
                    {
                        if (bEquip is null || bEquip.IsDisposed)
                        {
                            bEquip = new EquipBoard(myGame);
                            pArea.Controls.Add(bEquip);
                        }
                        myGame.gLock = true;
                        bEquip.LoadBoard();
                        bEquip.Show();
                    }
                    catch (ArgumentException e)
                    {
                        throw e;
                    }
                    break;
                case "map":
                    foreach (Control c in pArea.Controls) { c.Hide();}
                    try
                    {
                        if (bMap is null || bMap.IsDisposed)
                        {
                            bMap = new MapBoard(myGame);
                            pArea.Controls.Add(bMap);
                        }
                        bMap.LoadBoard();
                        myGame.gLock = true;
                        bMap.Show();
                    }
                    catch (ArgumentException e)
                    {
                        throw e;
                    }
                    break;
                case "town":
                    foreach (Control c in pArea.Controls) { c.Hide();}
                    try
                    {
                        if (bTown is null || bTown.IsDisposed)
                        {
                            bTown = new TownBoard(myGame);
                            pArea.Controls.Add(bTown);
                        }
                        bTown.LoadTown();
                        myGame.gLock = true;
                        bTown.Show();
                    }
                    catch (ArgumentException e)
                    {
                        throw e;
                    }
                    break;
            }
        }

        public void LoadSubGame(string aType)
        {
            bSubGame = new SubGameBoard(myGame);
            pArea.Controls.Add(bSubGame);
            
            bSubGame.openGame(aType);
            myGame.gLock = true;
            bSubGame.Show();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        public void UpdateQuickBoard()
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
