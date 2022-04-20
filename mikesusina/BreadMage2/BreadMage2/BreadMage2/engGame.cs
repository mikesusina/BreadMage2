using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadMage2.Controls;
using BreadMage2.Screens;
using System.Data.OleDb;
using System.Windows.Forms;


namespace BreadMage2
{
    public class engGame
    {
        public MainScreen gMain;
        public GameScreen gGS;
        public SettingsScreen gSettings;

        public clsMage gMage { get; set; }
        public clsMonster gMonster { get; set; }
        public clsChoiceAdventure gChoice { get; set; }
        public clsTownLot gActiveStore { get; set; }
        public clsMonster gChatBot { get; set; } //for holding some universal chatterbox values to sprinkle in with specific ones
        public clsMonster gMageChatBot { get; set; } //same, but for mage generic attacks
        public clsMonster gNPCChatBot { get; set; } //"" but for townNPC random chatter

        //TODO: implement a "getboard" and just use this to hold all the game boards
        public List<Control> gameBoards { get; set; }

        public BreadMage bMage => gGS.bMage;
        public ExtraBoard bExtra => gGS.bExtra;
        public FightBoard bFight => gGS.bFight;
        public QuickBoard bQuick => gGS.bQuick;
        public ChoiceBoard bChoice => gGS.bChoice;
        public TownBoard bTown => gGS.bTown;
        public MapBoard bMap => gGS.bMap;
        public SubGameBoard bSubGame => gGS.bSubGame;


        public clsGameLibs GameLibraries { get; set; } = new clsGameLibs();
        public Random gRandom { get; set; }

        public engGLog gLog { get; set; }

        public bool gLock { get; set; } = false;
        public ToolTip gTT { get; set; } = new ToolTip();


        public engBattle BattleEngine;
        public engBattleChatter ChatEngine;
        public engChoice ChoiceEngine;
        public engTown TownEngine;
        public engEffects EffectHelper { get; set; }



        public engGame(MainScreen mainScreen)
        {
            gMain = mainScreen;
            BreadDB breadConn = new BreadDB();
            GameLibraries = breadConn.LoadLibraries();

        }

        public void BootGame()
        {
            gGS = new GameScreen(this);
            gSettings = new SettingsScreen();
            gGS.MdiParent = gMain;
            gSettings.MdiParent = gMain;

            gRandom = new Random();

            EffectHelper = new engEffects(this);
            gMage = new clsMage();
        }

        public void NewGame()
        {
            BreadDB BreadNet = new BreadDB();
            if (GameLibraries is null)
            {
                //load various data from DB - hopefully this is in memory already from program boot
                GameLibraries = BreadNet.LoadLibraries();
            }
            if (gChatBot is null) { if (GameLibraries.MonsterLib().Exists(x => x.monID == 7)) { gChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 7); } }
            if (gMageChatBot is null) { if (GameLibraries.MonsterLib().Exists(x => x.monID == 12)) { gMageChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 12); } }
            if (gNPCChatBot is null) { if (GameLibraries.MonsterLib().Exists(x => x.monID == 13)) { gNPCChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 13); } }

            //
            // at some point, interject the new mage screen around here, before loading the game screen
            //
            gMage = new clsMage();
            GrantSpell(GetSpell("Freshly Baked"), true);

            if (gGS != null)
            {
                gGS.Close();
                //scrGame = new GameScreen(this, 0, mMonsterList, mItemBook, mChoiceLib, mEffectChatter, mSpellBook);
                gGS = new GameScreen(this);
                gGS.MdiParent = gMain;
            }
            System.Drawing.Point p = new System.Drawing.Point(65, 10);
            gGS.Show();
            gGS.Location = p;

            SetPlayerBoards();
            gLog.Add("Welcome to Bread Mage 2!!!");

            //for updating item count stuff
            gMage.RefreshInvNumbers = gGS.UpdateQuickBoard;

        }

        public void LoadGame(int saveID)
        {
            BreadDB BreadNet = new BreadDB();
            if (GameLibraries is null)
            {
                //load various data from DB - hopefully this is in memory already from program boot
                GameLibraries = BreadNet.LoadLibraries();
            }
            if (gChatBot is null) { if (GameLibraries.MonsterLib().Exists(x => x.monID == 7)) { gChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 7); } }
            if (gMageChatBot is null) { if (GameLibraries.MonsterLib().Exists(x => x.monID == 12)) { gMageChatBot = GameLibraries.MonsterLib().Find(x => x.monID == 12); } }

            if (gGS != null)
            {
                gGS.Close();
                gGS = new GameScreen(this);
                gGS.MdiParent = gMain;
            }
            System.Drawing.Point p = new System.Drawing.Point(65, 10);
            gGS.Show();
            gGS.Location = p;

            try
            {
                // Clear any mage info from the panel first
                if (gGS.Controls["pMageZone"].Controls != null) { gGS.Controls["pMageZone"].Controls.Clear(); }
                gMage.SaveID = saveID;
                gMage.myGameFlags = BreadNet.LoadGameFlags();

                ///adding a spell
                GrantSpellbyID(1);
                GrantSpellbyID(2);
                GrantSpellbyID(5);
            }
            catch (ApplicationException ex)
            {
                string s = "You mage didn't come out of the oven correctly" + Environment.NewLine + ex.InnerException.ToString();
            }

            //for updating item count stuff
            SetPlayerBoards();
            gLog.Add("Welcome back, " + gMage.GetMageName() + "!"); ;

            gMage.RefreshInvNumbers = UpdateQuickBoard;
        }

        private void SetPlayerBoards()
        {
            // Clear any mage info from the panel first
            if (gGS.Controls["pMageZone"].Controls != null) { gGS.Controls["pMageZone"].Controls.Clear(); }
            gGS.LoadBoard("player");
            gGS.LoadBoard("extra");
            gGS.LoadBoard("quick");
            gLog = new engGLog((ListBox)gGS.Controls["lbLog"]);
            gLog.ClearLog();
        }



        ///
        ///World interaction stuff
        ///

        public void AdjustYeast(int iAmount)
        {
            gMage.Stats.Yeast += iAmount;
            if (gMage.Stats.Yeast < 0) { gMage.Stats.Yeast = 0; }
        }
        public void AddEXP(int iAmount)
        {
            gMage.Stats.EXP += iAmount;
            if (gMage.Stats.EXP > Math.Floor(50*Math.Pow((gMage.Stats.Level - 1), 1.5)))
            {
                //level up
            }
               

        }

        public void ChangeLocation(int locID)
        {
            gMage.Location = locID;
            clsLocation l = GameLibraries.LocationLib().Find(x => x.LocationID == locID);
            if (l != null)
            {
                switch (l.LocationType)
                {
                    case "wander":
                        //general zone, wait for wandering.
                        break;
                    case "town":
                        EnterTown(locID);
                        break;
                }
            }
        }

        public void TickDay(int iAmount = 1)
        {
            gMage.myGameFlags.DayTracker += iAmount;
            if (gMage.myGameFlags.DayTracker > 26) { gMage.myGameFlags.DayTracker = 26; }

            gMage.TickMageDayEffects(iAmount);

            if (gMage.myGameFlags.DayTracker == 26)
            {
                MessageBox.Show("The day is coming to a close, time to head to bed!");
                PortToHome();
            }
        }

        public void NewDay(bool saveFlag)
        {
            if (saveFlag)
            {
                //save game
            }
            gMage.myGameFlags.DayTracker = 1;
            gMage.Stats.SetEffects(new List<clsEffect>());
            RefreshMage();
            MessageBox.Show("a new day begins");
        }

        public void PortToHome()
        {
            gMage.Location = gMage.myGameFlags.TownHome;
            gGS.LoadBoard("town");
            TownEngine = new engTown(this);
            TownEngine.LoadTown();
            TownEngine.LoadButtons();
            gActiveStore = TownEngine.TownBuildings.Find(x => x.TownType == 3);
            TownEngine.EnterShop(gActiveStore);
        }




        /// <summary>
        ///  Mage interaction stuff
        /// </summary>
        public void GrantSpellbyID(int aSpellID, bool bQuickEquip = false)
        {
            if (gMage.AllSpells().Contains(aSpellID) == false)
            {
                gMage.AllSpells().Add(aSpellID);
                if (bQuickEquip) { EquipSpell(GetSpellByID(aSpellID)); }
            }
        }
        public void GrantSpell(clsSpell aSpell, bool bQuickEquip = false)
        {
            if (gMage.AllSpells().Contains(aSpell.spellID) == false) { gMage.AllSpells().Add(aSpell.spellID); }
            if (bQuickEquip) { EquipSpell(aSpell); }
        }

        public void EquipSpell(clsSpell s)
        {
            //all validation is at the magestats level
            gMage.Stats.EquipSpell(s);
        }


        public void UnequipSpell(clsSpell s, bool bForget = false)
        {
            //all validation is at the magestats level
            gMage.Stats.UnequipSpell(s, bForget);
        }
        public void UnequipSpellByID(int i)
        {
            clsSpell s = new clsSpell();
            if (gMage.Stats.CurrentEQSpells().Find(x => x.spellID == i) != null)
            {
                UnequipSpell(gMage.Stats.CurrentEQSpells().Find(x => x.spellID == i));
            }
            RefreshMage();
        }
        public void EquipSpellSet(List<clsSpell> e)
        {
            gMage.Stats.SetEQSpells(e);
            RefreshMage();
        }
        public void UnlearnSpell(int iID)
        {
            if (gMage.Stats.AllSpells().Contains(iID))
                { gMage.Stats.AllSpells().Remove(iID); }
        }



        public void GrantUniqueItem(int anItemID)
        {
            if (gMage.AllItems().Contains(anItemID) == false) { gMage.AllItems().Add(anItemID); }
        }

        public void GrantUniqueItem(clsUniqueItem anItem)
        {
            if (gMage.AllItems().Contains(anItem.itemID) == false)
            {
                gMage.AllItems().Add(anItem.itemID);
            }
            else
            {
                foreach (string s in anItem.ResourceComponents)
                {
                    //string itemCode =  ;
                    //int iType = Convert.ToInt32(ResourceComponents.Find(x => x.Substring(0, 3) == itemCode).Substring(4));
                    switch (s.Substring(0, 3))
                    {
                        case "ING":
                            gMage.AdjustComponent(1, Convert.ToInt32(s.Substring(4)));
                            break;
                        case "CSM":
                            gMage.AdjustComponent(2, Convert.ToInt32(s.Substring(4)));
                            break;
                        case "EMO":
                            gMage.AdjustComponent(3, Convert.ToInt32(s.Substring(4)));
                            break;
                    }
                }
            }
        }


        public void EquipItem(clsEquipment e)
        {
            /* this might be unnecessary - trying to always set equipment all at once?
            clsEquipment oldE = gMage.Stats.CurrentEquipment().Find(x => x.Slot == e.Slot);
            if (oldE != null && oldE.PassiveEffect() != 0 && gMage.Stats.CurrentEQSpells().Exists(x => x.spellID == oldE.PassiveEffect()))
            {
                UnequipSpellByID(oldE.PassiveEffect());
                gMage.Stats.CurrentEquipment().Remove(oldE);
            }
            gMage.Stats.CurrentEquipment().Add(e);
            RefreshMage();
            */
        }
        public void EquipItemSet(List<clsEquipment> newEquip)
        {
            foreach (clsEquipment o in gMage.Stats.CurrentEquipment())
            {
                if (o.EQSpell != null && o.EQSpell.spellID > 0)
                {
                    UnequipSpell(GetSpellByID(o.EQSpell.spellID), true);
                }
            }
            gMage.Stats.SetEquipment(newEquip);
            RefreshMage();
        }

        public void UnequipItem(clsEquipment e)
        {
            clsEquipment oldE = gMage.Stats.CurrentEquipment().Find(x => x.Slot == e.Slot);
            if (oldE != null && oldE.PassiveEffect() != 0 && gMage.Stats.CurrentEQSpells().Exists(x => x.spellID == oldE.PassiveEffect()))
            {
                UnequipSpellByID(oldE.PassiveEffect());
                gMage.Stats.CurrentEquipment().Remove(oldE);
            }
            gMage.Stats.CurrentEquipment().Add(e);
            RefreshMage();
        }





        /// <summary>
        ///  Item, Equipment, and Spell stuff
        /// </summary>


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


        public clsSpell GetSpellByID(int anID)
        {
            return GameLibraries.SpellLib().Find(x => x.spellID == anID);
        }
        public clsSpell GetSpell(string aSpellName)
        {
            return GameLibraries.SpellLib().Find(x => x.spellName == aSpellName);
        }
        public List<clsSpell> GetItemSpells()
        {
            return GameLibraries.SpellLib().FindAll(x => x.spellType == "I");
        }
        public List<clsSpell> GetAllKnownMageSpells(string sType = "all")
        {
            List<clsSpell> returnSpells = new List<clsSpell>();
            foreach (int i in gMage.AllSpells())
            {
                returnSpells.Add(GetSpellByID(i));
            }
            returnSpells = Program.FilterSpellsByType(returnSpells, sType);
            return returnSpells;
        }






        public List<clsUniqueItem> GetShopInventory()
        {
            List<clsUniqueItem> returnItems = new List<clsUniqueItem>();
            if (TownEngine != null && TownEngine.activeStore != null)
            {
                foreach (int i in TownEngine.activeStore.TownInvIDs)
                {
                    if (!gMage.GetSaveData().gottenItems.Contains(i))
                    { returnItems.Add(GetUniqueItem(i)); }
                }
            }
            return returnItems;
        }
        public List<clsUniqueItem> GetSaleableComponentItems()
        {
            //base this on player level maybe? max spell tier? currently these aren't made, using existing items
            List<clsUniqueItem> returnItems = new List<clsUniqueItem>();
            returnItems.Add(GetUniqueItem(1));
            returnItems.Add(GetUniqueItem(2));
            returnItems.Add(GetUniqueItem(8));
            return returnItems;
        }

        public List<clsSpell> GetSkillShopInventory()
        {
            List<clsSpell> returnSpells = new List<clsSpell>();
            if (TownEngine != null && TownEngine.activeStore != null)
            {
                foreach (int i in TownEngine.activeStore.TownInvIDs)
                {
                    returnSpells.Add(GetSpellByID(i));
                }
            }
            return returnSpells;
        }

        public bool BuyItem(clsUniqueItem anItem)
        {
            bool b = true;
            if (gMage.AllItems().Contains(anItem.itemID) == true)
            {
                b = false;
                if (anItem.ResourceComponents.Count > 0)
                {
                    b = true;
                }
            }
            if (gMage.Stats.Yeast < anItem.Yeast) { b = false; }
            
            if (b)
            {
                GrantUniqueItem(anItem);
                AdjustYeast(anItem.Yeast * -1);
            }
            return b;
        }

        public bool BuySpell(clsSpell aSpell)
        {
            bool b = true;
            if (gMage.AllSpells().Contains(aSpell.spellID) == true) { b = false; }
            if (gMage.Stats.Yeast < aSpell.YeastCost) { b = false; }

            if (b)
            {
                GrantSpell(aSpell);
                AdjustYeast(aSpell.YeastCost * -1);
            }
            return b;
        }


        /// <summary>
        /// Encounter mechanics
        /// </summary>

        public void Wander()
        {
            if (!gLock)
            {

                //logic for deciding between combat or noncombat, superlikelies?
                if ((gRandom.Next())%2 == 0) 
                {
                    BeginCombatEncounter();
                }
                else 
                {
                    BeginCombatEncounter();
                    /*
                    if (bExtra.Controls["textBox1"].Text == "test")
                    {
                        BeginChoiceEncounter(4);
                    }
                    else if (bExtra.Controls["textBox1"].Text == "fish")
                    {
                        BeginSubGame("fish");
                    }
                    else
                    {
                        BeginChoiceEncounter(); 
                    }
                    */
                }
            }

            else { MessageBox.Show("There's something in the way"); }
        }


        public void BeginCombatEncounter(int aMonID = 0)
        {
            gMonster = null;
            gGS.LoadBoard("combat");
            gGS.Controls["pMidBar"].Controls.Clear();
            // if the local full monster set is empty load it
            if (GameLibraries.MonsterLib() is null || GameLibraries.MonsterLib().Count == 0)
            {
                GameLibraries.SetMonsterLib((new BreadDB()).LoadMonsterList());
            }

            //load by ID
            if (aMonID != 0 && GameLibraries.MonsterLib().Exists(x => x.monID == aMonID))
            {
                gMonster = GameLibraries.MonsterLib().Find(x => x.monID == aMonID).ShallowCopy();
            }
            //load from location pool
            else if (GameLibraries.MonsterLib().FindIndex(x => x.Location == gMage.Location) >= 0)
            {
                //Get list of local monsters
                List<clsMonster> locMonsters = GameLibraries.MonsterLib().FindAll(x => x.Location == gMage.Location);
                //possible work in to make more common or less common encounters? maybe roll a d20 or something and make rare flag on 20?
                gMonster = locMonsters.ElementAt(gRandom.Next(0, (locMonsters.Count))).ShallowCopy();
            }

            if (gMonster != null)
            {
                gMonster.RefreshMonster();
                ChatEngine = new engBattleChatter(this);
                ChatEngine.LoadMonsterInfo(gMonster);
                ChatEngine.FightBox = (gGS.bFight.Controls["rtbChatter"] as RichTextBox);
                
                //create the battle engine
                BattleEngine = new engBattle(this);
                bFight.InitializeBoard();

                //remember to unlock/lock quick spells/items when combat starts and ends

                BattleEngine.LoadFight();
                //BattleEngine.WaitForMageInput();
            }
            else { AbortWander("monster"); }
        }

        public void Engage(int AtkType)
        {
            gGS.Controls["pMidBar"].Controls.Clear();
            if (BattleEngine != null) { BattleEngine.MageAttack(AtkType); bMage.UpdateBars(); }
        }


        public void BeginChoiceEncounter(int anAdvID = 0)
        {
            gChoice = null;
            //load the board and engine
            gGS.LoadBoard("choice");
            ChoiceEngine = new engChoice(this);


            //load adventure by ID
            if (anAdvID != 0 && GameLibraries.ChoiceLib().Exists(x => x.AdvID == anAdvID))
            {
                gChoice = GameLibraries.ChoiceLib().Find(x => x.AdvID == anAdvID).ShallowCopy();
            }
            //... or from location pool
            else if (GameLibraries.ChoiceLib().FindIndex(x => x.Location == gMage.Location) >= 0)
            {
                //Get list of local noncombats
                List<clsChoiceAdventure> locNCs = GameLibraries.ChoiceLib().FindAll(x => x.Location == gMage.Location);
                gChoice = locNCs.ElementAt(gRandom.Next(0, (locNCs.Count))).ShallowCopy();
            }

            if (gChoice != null)
            {
                //check if the selected adventure needs to be replaced
                if (gChoice.ReplaceCondition != null && ChoiceEngine.CheckReplacement() == true)
                {
                    int replaceID = gChoice.ReplaceID;
                    gChoice = GameLibraries.ChoiceLib().Find(x => x.AdvID == replaceID).ShallowCopy();
                }
                ChoiceEngine.InitializeBoard(); ;
                //once the board has been set, the only thing to do is wait for user input
            }
            else { AbortWander("choice"); }
        }

        public void BeginSubGame(string sType)
        {
            gGS.LoadSubGame(sType);
        }

        public void OpenCastBoard() { gGS.LoadBoard("cast"); }
        public void OpenSpellbookBoard() { gGS.LoadBoard("spellbook"); }
        public void OpenEquipBoard() { gGS.LoadBoard("equip"); }
        public void OpenMap() { gGS.LoadBoard("map"); }


        public void EnterTown(int aTownID)
        {
            gGS.LoadBoard("town");
            TownEngine = new engTown(this);
            TownEngine.LoadTown();
            TownEngine.LoadButtons();
        }

        public void BackToStore()
        {
            if (gActiveStore != null && GameLibraries.TownLocationsLib().Find(x => x.ID == gActiveStore.ID) != null)
            {
                gMage.Location = GameLibraries.TownLocationsLib().Find(x => x.ID == gActiveStore.ID).LocationID;
                gGS.LoadBoard("town");
                TownEngine = new engTown(this);
                TownEngine.LoadTown();
                TownEngine.LoadButtons();
                gActiveStore = TownEngine.TownBuildings.Find(x => x.ID == gActiveStore.ID);
                TownEngine.EnterShop(gActiveStore);
            }
        }

       

        public void EventEffects(string sType)
        {
            EffectHelper.EventBased(sType);
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
            //need to hide/close current action pane
            //idea: just make a game over one programatically, simple text box and display?
        }

        public void AbortWander(string sType)
        {
            MessageBox.Show("Hey - I tried boss, there's no " + sType + " items here");
        }

        public void SaveGame()
        {
            BreadDB BN = new BreadDB();
            gMage.PrepSaveData();
            BN.SaveData(gMage.GetSaveData());
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

        public void RefreshMage()
        {
            foreach (clsEquipment e in gMage.Stats.CurrentEquipment())
            {
                if (e.EQSpell != null && e.EQSpell.spellID > 1)
                {
                     GrantSpell(e.EQSpell, true);
                }
            }
            gMage.RefreshStats();
            bMage.UpdateBars();
            //loop through ticking buffs/debuffs
        }
    }
}
