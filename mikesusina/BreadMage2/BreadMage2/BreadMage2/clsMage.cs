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
        public string LastLoc { get; set; } = "";
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
            Stats.SetEquipStats();
            
        }

        public void AdjustHP(int aValue)
        {
            Stats.HP += aValue;
            if (Stats.HP > Stats.HPMax) { Stats.HP = Stats.HPMax; }
            else if (Stats.HP < 0) { Stats.HP = 0; }
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

        public int TickMod(string sType)
        {
            //to do: check effects(?)/equipment for things that add to certain tick mods
            // base numbers are spell power based - this is just adding to them with equipped stuff
            int iMod = 0;
            if (sType.ToLower() == "mold") { iMod = 0; } //+ (int)Math.Floor((double)(MAtk() / Stats.BaseMAtk)); } //mold
            else if (sType.ToLower() == "zest") { iMod = 0; } //(int)Math.Floor((double)(Res() / Stats.BaseRes)); } //zest
            else if (sType.ToLower() == "tension") { iMod = 0; } //(int)Math.Floor((double)(Def() / Stats.BaseDef)); } //tension

            return iMod;
            }


                public void ProcEffect(int anID)
                {
                    //this is used to tick effects that tick once (dodge, stun, quick attack, silence? inherent actions on tick, not determining a number of ticks to consume
                    clsEffect e = GetStatEffects().Find(x => x.iID == anID);
                    if (e != null && e.Tick >= 1) { GetStatEffects().Remove(e); }

                }

                public void TickMageDayEffects(int anAmount)
                {
                    foreach (clsEffect e in Stats.CurrentEffects())
                    {
                        if (e.sType == "B" || e.sType == "D")
                        {
                            e.Tick -= anAmount;
                        }
                    }
                    Stats.CurrentEffects().RemoveAll(x => x.Tick <= 0);
                }

                /// <summary>
                /// Stats and info
                /// </summary>
                /// <returns></returns>

                public string GetMageName()
                {
                    return mySaveData.mageName;
                }

                public int BuffedStat(string aType) { return Stats.PlayerStats.Find(x => x.Name == aType).BuffedVal(); }

                public int MoldCount()
                {
                    if (GetStatEffects().Exists(x => x.iID == 1)) { return GetStatEffects().Find(x => x.iID == 1).Tick; }
                    else return 0;
                }
                public int ZestCount()
                {
                    if (GetStatEffects().Exists(x => x.iID == 2)) { return GetStatEffects().Find(x => x.iID == 2).Tick; }
                    else return 0;
                }
                public int TensionCount()
                {
                    if (GetStatEffects().Exists(x => x.iID == 3)) { return GetStatEffects().Find(x => x.iID == 3).Tick; }
                    else return 0;
                }

                public void AdjustComponent(int aType, int anAmount = 1)
                {
                    Stats.AdjustComponent(aType, anAmount);
                    RefreshInvNumbers();
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




                public void AddEffect(clsEffect anEffect, int aValue = 1)
                {
                    anEffect.Tick = aValue;
                    Stats.AddEffect(anEffect);
                }

                public void RemoveEffect(int anID)
                {
                    if (GetStatEffects().Find(x => x.iID == anID) != null) { GetStatEffects().Remove(GetStatEffects().Find(x => x.iID == anID)); }
                }


                public List<clsEffect> GetStatEffects(string sType = "all")
                {
                    return Stats.CurrentEffects(sType);
                }

                public void SetStatEffects(List<clsEffect> e)
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
                        if (Stats.CurrentEffects().Find(x => x.iID == 7) != null)
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
                        if (Stats.CurrentEffects().Find(x => x.iID == 8) != null)
                        {
                            return true;
                        }
                    }
                    catch { return false; }
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
                public List<int> AllItems()
                {
                    return mySaveData.gottenItems;
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
                    //NEEDS WORK FOR PASSIVES
                    return Stats.AllSpells();
                }
                public List<clsSpell> EQSpells(string sType = "all")
                {
                    return Stats.mySpellsByType(sType);
                    //"all": //return all
                    //"combat": //[C]ombat
                    //"passive": //[P]assive
                    //"global": //[G]eneral/global / "out of combat castable"
                    //"battle": //castable spells for the combat screen
                    //"item": //[I]tem spells
                    //"mold": //mold-tuned spells, for filtering
                    //"zest": //ditto, but zest
                    //"tension": //ditto but tension

                }


                public clsEquipment myEquipBySlot(int iSlot)
                {
                    try
                    {
                        if (Stats.CurrentEquipment().Find(x => x.Slot == iSlot) != null) { return Stats.CurrentEquipment().Find(x => x.Slot == iSlot); }
                        else { return null; }
                    }
                    catch { throw new ArgumentOutOfRangeException("I think you tried to search for a bad equip slot"); };

                }

                public void PrepSaveData()
                {
                    mySaveData.stats = Stats;
                    mySaveData.gameFlags = myGameFlags;
                }
                public void LoadSavedData(clsSaveData aSaveFile)
                {
                    Stats = mySaveData.stats;
                    myGameFlags = aSaveFile.gameFlags;
                }
            }

}
