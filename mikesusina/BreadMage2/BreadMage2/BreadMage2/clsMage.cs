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
        public clsGameFlags myGameFlags { get; set; } = new clsGameFlags();


        public int Location { get; set; } = 1;
        public int SaveID { get; set; }
        public Action RefreshInvNumbers;

        //public list<clsBuff> myBuffList {get;set;}
        public List<int> myQuickIDs { get; set; } = new List<int>();

        private clsSaveData mySaveData { get; set; } = new clsSaveData();

        public clsMage()
        {
            
        }


        public void RefreshStats()
        {
            Stats.SetBuffedStats();
        }


        /// <summary>
        /// Tick stuff
        /// </summary>
        /// <returns></returns>

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

        public int TickMod(int iType = 1)
        {
            //if ticking harder makes it in, this will determine how much bonus tick to do
            int iMod = 0;
            if (iType == 1) { iMod = 2 + (int)Math.Floor((double)(MAtk() / Stats.BaseMAtk)); } //mold
            else if (iType == 2) { iMod = (int)Math.Floor((double)(Res() / Stats.BaseRes)); } //zest
            else if (iType == 3) { iMod = (int)Math.Floor((double)(Def() / Stats.BaseDef)); } //tension

            return iMod;
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

                if (e.iValue <= 0 ) { GetStatEffects().Remove(e); }

                tickInfo.Add(new KeyValuePair<string, int>("damage", damage));
                //the tick value returned should be negative, since from here on it's for chat info
                tickInfo.Add(new KeyValuePair<string, int>("tick", iTick * -1));
            }

            return tickInfo;
        }

        public void TickEffect(int anID)
        {
            //this is used to tick effects that tick once (dodge, stun, quick attack, silence? inherent actions on tick, not determining a number of ticks to consume
            clsMageEffect e = GetStatEffects().Find(x => x.iID == anID);
            if (e != null && e.iValue >= 1)
            {
                e.iValue -= 1;
                if (e.iValue <= 0 ) { GetStatEffects().Remove(e); }
            }

        }

        /// <summary>
        /// Stats and info
        /// </summary>
        /// <returns></returns>
        
        public string GetMageName()
        {
            return mySaveData.mageName;
        }

        public int PAtk() { return Stats.PAtk(); }
        public int MAtk() { return Stats.MAtk(); }
        public int Def() { return Stats.Def(); }
        public int Res() { return Stats.Res(); }

        public int MoldCount()
        {
            if (GetStatEffects().Exists(x => x.iID == 1)) { return GetStatEffects().Find(x => x.iID == 1).iValue; }
            else return 0;
        }
        public int ZestCount()
        {
            if (GetStatEffects().Exists(x => x.iID == 2)) { return GetStatEffects().Find(x => x.iID == 2).iValue; }
            else return 0;
        }
        public int TensionCount()
        {
            if (GetStatEffects().Exists(x => x.iID == 3)) { return GetStatEffects().Find(x => x.iID == 3).iValue; }
            else return 0;
        }

        public void GetComponents(int aType, int anAmount = 1)
        {
            Stats.AddComponents(aType, anAmount);
            this.RefreshInvNumbers();
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



        /// <summary>
        /// Effects
        /// </summary>
        /// <param name="anID"></param>
        /// <param name="aValue"></param>




        public void AddEffect(int anID, int aValue)
        {
            var obj = GetStatEffects().FirstOrDefault(x => x.iID == anID);
            if (obj != null) { obj.iValue += aValue; }
            else { Stats.AddEffect(anID, aValue); }
        }

        public void RemoveEffect(int anID)
        {
            if (GetStatEffects().Find(x => x.iID == anID) != null) { GetStatEffects().Remove(GetStatEffects().Find(x => x.iID == anID)); }
        }


        public List<clsMageEffect> GetStatEffects()
        {
            return Stats.CurrentEffects();
        }

        public void SetStatEffects(List<clsMageEffect> e)
        {
            Stats.SetEffects(e);
        }
        public bool hasEffect(int anID)
        {
            if (Stats.CurrentEffects().Find(x => x.iID == anID) != null) { return true; }
            else { return false; }
        }


        public bool hasQuickAttack()
        {
            try
            {
                clsMageEffect a = GetStatEffects().Find(x => x.iID == 7);
                if (a.iValue > 0)
                {
                    return true;
                }
            }
            catch { return false; }
            return false;
        }

        public bool isStunned()
        {
            try
            {
                clsMageEffect a = GetStatEffects().Find(x => x.iID == 8);
                if (a.iValue > 0)
                {
                    return true;
                }
            }
            catch  { return false; }
            return false;
        }

        //////
        /// SaveData stuff
        //////
        ///





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

        public void GetUniqueItem(int anItemID)
        {
            if (mySaveData.gottenItems.Contains(anItemID) == false) { mySaveData.gottenItems.Add(anItemID); }
        }

        


        public int EquippedSP()
        {
            return Stats.EquippedSP();
        }

        public clsSaveData GetSaveData()
        {
            return mySaveData;
        }




        public List<int> AllSpells()
        {
            return mySaveData.knownSpells;
        }
        public List<clsSpell> EQSpells(int iType = 0)
        {
            return Stats.mySpellsByType(iType);
            //0: return all
            //1: [C]ombat
            //2: [P]assive
            //3: [G]eneral (castable in and out of combat)
            //4: castable spells (C and G)
        }



        public void GrantSpell(int aSpellID)
        {
            if (mySaveData.knownSpells.Contains(aSpellID) == false)
            {
                mySaveData.knownSpells.Add(aSpellID);
            }
        }
        public void GrantSpell(clsSpell aSpell)
        {
            if (mySaveData.knownSpells.Contains(aSpell.spellID) == false) { mySaveData.knownSpells.Add(aSpell.spellID); }
        }


        public void EquipSpell(clsSpell s)
        {
            if (mySaveData.equippedSpells.Contains(s) == false)
            {
                mySaveData.equippedSpells.Add(s);
                Stats.SetEQSpells(mySaveData.equippedSpells);
                RefreshStats();
            }
        }

        public void UnequipSpell(int i)
        {
            clsSpell s = new clsSpell();
            foreach (clsSpell o in mySaveData.equippedSpells)
            {
                if (o.spellID == i) { s = o; }
            }
            UnequipSpell(s);
        }
        public void UnequipSpell(clsSpell s)
        {
            if (mySaveData.equippedSpells.Contains(s))
            {
                mySaveData.equippedSpells.Remove(s);
                Stats.SetEQSpells(mySaveData.equippedSpells);
                RefreshStats();
            }
        }

        public void EquipSpellSet(List<clsSpell> e)
        {
            mySaveData.equippedSpells = e;
            Stats.SetEQSpells(e);
            RefreshStats();
        }


        public void EquipItem(clsEquipment e)
        {
            clsEquipment oldE = mySaveData.equippedMent.Find(x => x.Slot == e.Slot);
            if (oldE != null && oldE.PassiveEffect() != 0 && EQSpells().Exists(x => x.spellID == oldE.PassiveEffect()))
            {
                UnequipSpell(oldE.PassiveEffect());
                mySaveData.equippedMent.Remove(mySaveData.equippedMent.Find(x => x.Slot == e.Slot));
            }
            mySaveData.equippedMent.Add(e);
            Stats.SetEquipment(mySaveData.equippedMent);
            RefreshStats();
        }
        public void UnequipItem(clsEquipment e)
        {
            if (mySaveData.equippedMent.Contains(e))
            {
                mySaveData.equippedMent.Remove(e);
                if (e.PassiveEffect() != 0 && EQSpells().Exists(x => x.spellID == e.PassiveEffect()))
                {
                    UnequipSpell(e.PassiveEffect());
                }
            }
            Stats.SetEquipment(mySaveData.equippedMent);
            RefreshStats();
        }

        public void EquipItemSet(List<clsEquipment> e)
        {
            foreach (clsEquipment o in mySaveData.equippedMent)
            {
                if (o.PassiveEffect() != 0 && EQSpells().Exists(x => x.spellID == o.PassiveEffect()) && e.Contains(o) == false)
                {
                    UnequipSpell(EQSpells().Find(x => x.spellID == o.PassiveEffect()));
                }
            }
            mySaveData.equippedMent = e;
            Stats.SetEquipment(mySaveData.equippedMent);
            RefreshStats();
        }

        public List<clsEquipment> myEquipment()
        {
            return mySaveData.equippedMent;
        }
        public clsEquipment myEquipBySlot(int iSlot)
        {
            try
            {
                if (mySaveData.equippedMent.Find(x => x.Slot == iSlot) != null) { return mySaveData.equippedMent.Find(x => x.Slot == iSlot); }
                else { return null; }
            }
            catch { throw new ArgumentOutOfRangeException("I think you tried to search for a bad equip slot"); };

        }


        public void PrepSaveData()
        {
            mySaveData.stats = Stats;
        }
    }

}
