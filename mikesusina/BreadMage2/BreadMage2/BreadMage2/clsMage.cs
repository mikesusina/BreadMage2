using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using BreadMage2.Screens;

namespace BreadMage2
{
    public class clsMage
    {
        //the Mage object, this is the PC
        public clsMageStats Stats { get; set; } = new clsMageStats();
        //private List<StatusEffect> myStatEffects { get; set; } = new List<StatusEffect>();
        //private List<ActiveEffect> myActiveEffects { get; set; } = new List<ActiveEffect>();
        //private List<PassiveEffect> myPassiveEffects { get; set; } = new List<PassiveEffect>();
        public clsGameFlags myGameFlags { get; set; } = new clsGameFlags();


        public int HP { get; set; }
        public int HPmax { get; set; }
        public int MP { get; set; }
        public int MPmax { get; set; }
        public int SP { get; set; }
        public int Location { get; set; } = 1;
        public int SaveID { get; set; }
        public Action RefreshInvNumbers;

        //public DataTable myInv { get; set; }
        public List<clsGenericItem> myInv { get; set; } = new List<clsGenericItem>();

        public List<clsEquipment> myEquipList { get; set; }

        //public list<clsBuff> myBuffList {get;set;}
        public List<int> myQuickIDs { get; set; }

        private clsSaveData mySaveData { get; set; } = new clsSaveData();

        public clsMage()
        {

            HPmax = 30;
            HP = HPmax;
            MPmax = 100;
            MP = MPmax;
            SP = 10;

            Location = 1;
            myQuickIDs = new List<int>();
            /*
            myInv = new DataTable();
            myInv.Columns.Add("MageID");
            myInv.Columns.Add("ID");
            myInv.Columns.Add("ItemCount");

            //Status flag is for DB cooperation - 0 = DB fresh info/ignore update, 1 = new row, 2 = updated count
            myInv.Columns.Add("StatusFlag");
            myInv.Columns["StatusFlag"].DefaultValue = 0;

            
            Stats = new clsMageStats();
            myStatEffects = new List<clsMageEffect>();
            myInv = new List<clsItem>();
            */

        }

        public void GetComponents(int aType, int anAmount = 1)
        {
            Stats.AddComponents(aType, anAmount);
            this.RefreshInvNumbers();
        }

        /* This was for generics, now components? 
        public void AddItem(int aType, int anAmount)
        {
            //this method is for adding generic item types to the inventory
            int i = 0;
            foreach (clsGenericItem e in myInv)
            {
                if (e.itemType == aType) { e.AddItem(anAmount);  i = 1; }
            }
            if (i == 0) { myInv.Add(new clsGenericItem(aType, anAmount)); }
            this.RefreshInvNumbers();

            // OLD SYSTEM
            int i = 0;
            bool b = false;
            foreach (DataRow d in this.myInv.Rows)
            {
                if (Convert.ToInt32(myInv.Rows[i]["ID"].ToString()) == anID)
                {
                    this.myInv.Rows[i]["ItemCount"] = (Convert.ToInt32(this.myInv.Rows[i]["ItemCount"].ToString()) + anAmount);
                    if (Convert.ToInt32(this.myInv.Rows[i]["StatusFlag"].ToString()) == 0) { this.myInv.Rows[i]["StatusFlag"] = 2; }
                    //tell board to update counts
                    //THIS IS SET IN THE GAMESCREEN WHEN THE MAIN MAGE IS GENERATED
                    this.RefreshInvNumbers();
                    b = true;
                    break;
                }
                i++;
            }
            //if loop finishes the item ID wasn't found - insert as a new row
            if( b==false )
            {
                this.myInv.Rows.Add(new Object[]{
                                    SaveID,
                                    anID,
                                    anAmount,
                                    1});
            }
            
        }
        */


        public void AddEffect(int anID, int aValue, int aTimer)
        {
            var obj = GetStatEffects().FirstOrDefault(x => x.iID == anID);
            if (obj != null) { obj.iValue += aValue; }
            else { Stats.myEffects.Add(new clsMageEffect(anID, aValue, aTimer)); }

            /*int iFlag = 0;
                    foreach (clsMageEffect e in myStatEffects)
                    {
                        if (e.sType == aType)
                        {
                            if (e.sType == "MP" || e.sType == "ZC" || e.sType == "TS")
                            {
                                e.iValue += aValue;
                                if (e.iTimer < aTimer) { e.iTimer = aTimer;  }
                                iFlag = 1;
                            }
                            else if (e.iValue < aValue)
                            {
                                e.iValue = aValue;
                                e.iTimer += aTimer;
                                iFlag = 1;
                            }
                        }
                    }
                    if (iFlag == 0) { myStatEffects.Add(new clsMageEffect(aType, aValue, aTimer)); }
                    */
        }

        public void RemoveEffect(int anID)
        {
            if (GetStatEffects().Find(x => x.iID == anID) != null) { GetStatEffects().Remove(GetStatEffects().Find(x => x.iID == anID)); }
        }

        public void TickBuffs()
        {


            /* I need to think about ticks and timers a little more
             * Battle timers tick down each combat turn, stacks are indepoendant
             * active timers tick down on "adventure" (end of combat or noncombat/move/etc...), stacks don't matter? can you get more of the same buff? seems op. Lock at 1?)
            if(myStatEffects != null && myStatEffects.Count > 0 )
            {
                foreach (StatusEffect e in myStatEffects)
                {
                    if (e.sType == "B") { e.iTimer -= 1; }
                }
                myStatEffects.RemoveAll(x => x.iTimer <= 0);
            }


            Stats.SetBuffedStats(myEquipList, myStatEffects);

            */
        }

        public List<KeyValuePair<string, int>> TickMagePoison()
        {
            List<KeyValuePair<string, int>> tickInfo = new List<KeyValuePair<string, int>>();
            int damage = 0;
            int iTick = 1;
            

            clsMageEffect e = GetStatEffects().Find(x => x.iID == 1);
            if (e != null )
            {
                if (e.iValue > 2) { iTick = (int)(Math.Ceiling(Convert.ToDouble(e.iValue) / 2)); }
                damage = 3 * iTick; //resist?
                e.iValue -= iTick;
                //battletimer battle timer ??
                e.iTimer -= 1;

                if (e.iValue <= 0 || e.iTimer <= 0) { GetStatEffects().Remove(e); }

                tickInfo.Add(new KeyValuePair<string, int>("damage", damage));
                //the tick value returned should be negative, since from here on it's for chat info
                tickInfo.Add(new KeyValuePair<string, int>("tick", iTick * -1));
            }

            return tickInfo;
        }

        public int TickMagePoisonOld()
        {
            int damage = 0;
            foreach (clsMageEffect e in GetStatEffects())
            {
                if (e.iID == 1) 
                {
                    int iTick = 1;
                    if (e.iValue > 2)
                    {
                        iTick = (int)(Math.Ceiling(Convert.ToDouble(e.iValue) / 2));
                    }
                    damage = 3 * iTick;
                    e.iValue -= iTick;
                    e.iTimer -= 1;
                    if (e.iValue <= 0 || e.iTimer <= 0)
                    {
                        RemoveEffect(1);
                        break;
                    }
                }
            }
            return damage;
        }



        public int PAtk()
        {
            return Stats.PAtk();
        }

        public int MAtk()
        {
            return Stats.MAtk();
        }

        public int Def()
        {
            return Stats.Def();
        }

        public int Res()
        {
            return Stats.Res();
        }

        public int MoldCount()
        {
            if (GetStatEffects().Exists(x => x.iID == 1)) { return GetStatEffects().Find(x => x.iID == 1).iValue; }
            else return 0;
        }
        public int MoldTimer()
        {
            if (GetStatEffects().Exists(x => x.iID == 1)) { return GetStatEffects().Find(x => x.iID == 1).iTimer; }
            else return 0;
        }

        public int ZestCount()
        {
            if (GetStatEffects().Exists(x => x.iID == 2)) { return GetStatEffects().Find(x => x.iID == 2).iValue; }
            else return 0;
        }
        public int ZestTimer()
        {
            if (GetStatEffects().Exists(x => x.iID == 2)) { return GetStatEffects().Find(x => x.iID == 2).iTimer; }
            else return 0;
        }
        public int TensionCount()
        {
            if (GetStatEffects().Exists(x => x.iID == 3)) { return GetStatEffects().Find(x => x.iID == 3).iValue; }
            else return 0;
        }
        public int TensionTimer()
        {
            if (GetStatEffects().Exists(x => x.iID == 3)) { return GetStatEffects().Find(x => x.iID == 3).iTimer; }
            else return 0;
        }


        public string GetMageName()
        {
            return mySaveData.mageName;
        }



        public int TickMod(int iType = 1)
        {
            //if ticking harder makes it in, this will determine how much bonus tick to do
            int iMod = 0;
            if (iType == 1) { iMod = 2+ (int)Math.Floor((double)(MAtk() / Stats.BaseMAtk)); } //mold
            else if (iType == 2) { iMod = (int)Math.Floor((double)(Res() / Stats.BaseRes)); } //zest
            else if (iType == 3) { iMod = (int)Math.Floor((double)(Def() / Stats.BaseDef)); } //tension

            return iMod;
        }
        public List<clsMageEffect> GetStatEffects()
        {
            return Stats.myEffects;
        }

        public void SetStatEffects(List<clsMageEffect> e)
        {
            Stats.myEffects = e;
        }

        public bool hasQuickAttack()
        {
            try
            {
                clsMageEffect a = GetStatEffects().Find(x => x.iID == 7);
                if (a.iTimer > 0 || a.iValue > 0)
                {
                    return true;
                }
            }
            catch { return false; }
            return false;
        }


        public int GetComponentCount(int anItemType)
        {
            return Stats.ComponentCount(anItemType);

                    /* OLD
                    foreach (clsGenericItem e in myInv)
                    {
                        if (anItemType == e.itemType) { return e.iCount; }
                    }
                    return 0;

                    /* OLDER SYSTEM
                    string searchExpression = "ID = " + anItemID;
                    if (myInv != null && myInv.Rows.Count > 0)
                    {
                        DataRow r = this.myInv.Select(searchExpression).FirstOrDefault();
                        if (r != null) { return Convert.ToInt32(this.myInv.Select(searchExpression)[0]["ItemCount"].ToString()); }
                        else { return 0; }
                    }
                    else { return 0; }
                    */
            }

        

        public bool isStunned()
        {
            try
            {
                clsMageEffect a = GetStatEffects().Find(x => x.iID == 8);
                if (a.iTimer > 0 || a.iValue > 0)
                {
                    return true;
                }
            }
            catch  { return false; }
            return false;
        }


        public void RefreshStats()
        {

        }


        private void SetGameFlags(clsGameFlags loadedFlags)
        {
            myGameFlags = loadedFlags;
        }


        private void SetEquipStats()
        {
            /* again, more work, am I passing in a lot of differnet info?
            if(myEquipList != null && myEquipList.Count() > 0)
            {
                Stats.SetBuffedStats(myEquipList, myStatEffects);
            }
            */
        }

        //////
        /// SaveData stuff
        //////
        ///

        public void GetUniqueItem(int anItemID)
        {
            if (mySaveData.gottenItems.Contains(anItemID) == false) { mySaveData.gottenItems.Add(anItemID); }
        }

        public void GrantSpell(int aSpellID)
        {
            if (mySaveData.knownSpells.Contains(aSpellID) == false) { mySaveData.knownSpells.Add(aSpellID); }
        }

        public List<int> AllSpells()
        {
            return mySaveData.knownSpells;
        }
        public List<clsSpell> EQSpells()
        {
            return mySaveData.equippedSpells;
        }
        public int EquippedSP()
        {
            int i = 0;
            foreach (clsSpell s in mySaveData.equippedSpells)
            {
                i += s.SPCost;
            }
            return i;
        }

        public clsSaveData GetSaveData()
        {
            return mySaveData;
        }

        public void equipspell(clsSpell s)
        {
            mySaveData.equippedSpells.Add(s);
        }


        public void PrepSaveData()
        {
            mySaveData.stats = Stats;
        }
    }

}
