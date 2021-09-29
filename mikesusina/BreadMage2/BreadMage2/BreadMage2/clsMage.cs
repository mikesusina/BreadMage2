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
        public List<clsMageEffect> myStatEffects { get; set; } = new List<clsMageEffect>();
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
        public List<clsItem> myInv { get; set; } = new List<clsItem>();

        public List<clsEquipment> myEquipList { get; set; }

        //public list<clsBuff> myBuffList {get;set;}
        public List<int> myQuickIDs { get; set; }

        private clsSaveData mySaveData { get; set; } = new clsSaveData();

       public clsMage()
        {

            HPmax = 100;
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

        public void AddItem(int aType, int anAmount)
        {
            //this method is for adding generic item types to the inventory
            int i = 0;
            foreach (clsItem e in myInv)
            {
                if (e.itemType == aType) { e.AddItem(anAmount);  i = 1; }
            }
            if (i == 0) { myInv.Add(new clsItem(aType, anAmount)); }
            this.RefreshInvNumbers();

            /* OLD SYSTEM
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
            
            */
        }

        

        public void AddEffect(string aType, int aValue, int aTimer)
        {
            int iFlag = 0;
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
        }

        public void RemoveEffect (string aType)
        {
            List<clsMageEffect> newEffects = new List<clsMageEffect>();
            foreach (clsMageEffect e in myStatEffects)
            {
                if (e.sType != aType) { newEffects.Add(e); }
            }
            this.myStatEffects = newEffects;
        }

        public void TickBuffs()
        {
            int iFlag = 0;
            if(myStatEffects != null && myStatEffects.Count > 0 )
            {
                foreach (clsMageEffect e in myStatEffects)
                {
                    if (e.iTimer > 0)
                    {
                        if (e.sType == "MP" || e.sType == "ZC" || e.sType == "TS") { /* do nothing - these tick in battle */ }
                        else { }
                        e.iTimer -= 1;
                        if (e.iTimer <= 0)
                        {
                            e.iTimer = 0;
                            iFlag = 1;
                        }
                    }
                }
                if (iFlag == 1)
                {
                    Stats.SetBuffedStats(myEquipList, myStatEffects);
                }
            }
        }

        public int TickMagePoison()
        {
            int damage = 0;
            foreach (clsMageEffect e in myStatEffects)
            {
                if (e.sType == "MP") 
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
                        RemoveEffect("MP");
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
            int i = 0;
            foreach (clsMageEffect e in myStatEffects) { if (e.sType == "MP") { return e.iValue; } }
            return i;
        }
        public int MoldTimer()
        {
            int i = 0;
            foreach (clsMageEffect e in myStatEffects) { if (e.sType == "MP") { return e.iTimer; } }
            return i;
        }

        public int ZestCount()
        {
            int i = 0;
            foreach (clsMageEffect e in myStatEffects) { if (e.sType == "ZC") { return e.iValue; } }
            return i;
        }
        public int ZestTimer()
        {
            int i = 0;
            foreach (clsMageEffect e in myStatEffects) { if (e.sType == "ZC") { return e.iTimer; } }
            return i;
        }
        public int TensionCount()
        {
            int i = 0;
            foreach (clsMageEffect e in myStatEffects) { if (e.sType == "TS") { return e.iValue; } }
            return i;
        }
        public int TensionTimer()
        {
            int i = 0;
            foreach (clsMageEffect e in myStatEffects) { if (e.sType == "TS") { return e.iTimer; } }
            return i;
        }


        public bool hasQuickAttack()
        {
            try
            {
                clsMageEffect a = myStatEffects.Find(x => x.sType.Contains("QA"));
                if (a.iTimer > 0 || a.iValue > 0)
                {
                    return true;
                }
            }
            catch { return false; }
            return false;
        }


        public int GetItemCount(int anItemType)
        {
            foreach (clsItem e in myInv)
            {
                if (anItemType == e.itemType) { return e.iCount; }
            }
            return 0;

            /* OLD SYSTEM
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
                clsMageEffect a = myStatEffects.Find(x => x.sType.Contains("SS"));
                if (a.iTimer > 0 || a.iValue > 0)
                {
                    return true;
                }
            }
            catch  { return false; }
            return false;
        }

        private void SetGameFlags(clsGameFlags loadedFlags)
        {
            myGameFlags = loadedFlags;
        }


        private void SetEquipStats()
        {
            if(myEquipList != null && myEquipList.Count() > 0)
            {
                Stats.SetBuffedStats(myEquipList, myStatEffects);
            }
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


        public void equipspell(clsSpell s)
        {
            mySaveData.equippedSpells.Add(s);
        }
    }

}
