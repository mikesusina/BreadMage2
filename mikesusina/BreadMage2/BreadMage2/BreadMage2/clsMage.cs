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
        public clsMageStats Stats { get; set; }
        public List<clsMageEffect> StatEffects { get; set; }


        public int HP { get; set; }
        public int HPmax { get; set; }
        public int MP { get; set; }
        public int MPmax { get; set; }
        public int SP { get; set; }
        public int SPmax { get; set; }
        public int Location { get; set; }
        public int SaveID { get; set; }
        public Action RefreshInvNumbers;

        public DataTable myInv { get; set; }

        public List<clsConsumable> myConsumableLib { get; set; }
        public List<clsCombatItem> myCombatLib { get; set; }
        public List<clsEquipment> myEquipList { get; set; }

        //public list<clsBuff> myBuffList {get;set;}


        public List<int> myQuickIDs { get; set; }

       public clsMage()
        {

            HPmax = 100;
            HP = HPmax;
            MPmax = 100;
            MP = MPmax;
            SPmax = 100;
            SP = SPmax;

            Location = 1;
            myQuickIDs = new List<int>();
            myInv = new DataTable();
            myInv.Columns.Add("MageID");
            myInv.Columns.Add("ID");
            myInv.Columns.Add("ItemCount");

            //Status flag is for DB cooperation - 0 = DB fresh info/ignore update, 1 = new row, 2 = updated count
            myInv.Columns.Add("StatusFlag");
            myInv.Columns["StatusFlag"].DefaultValue = 0;
        }

        public void AddItem(int anID, int anAmount)
        {
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

        public void TickBuffs()
        {
            int iFlag = 0;
            if(StatEffects != null && StatEffects.Count > 0 )
            {
                foreach (clsMageEffect e in StatEffects)
                {
                    e.Tick();
                    if (e.iTimer == 0)
                    {
                        StatEffects.Remove(e);
                        iFlag = 1;
                    }
                }
                if (iFlag == 1)
                {
                    Stats.SetBuffedStats(myEquipList, StatEffects);
                }
            }
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

        public int GetItemCount(int anItemID)
        {
            string searchExpression = "ID = " + anItemID;
            if (myInv != null && myInv.Rows.Count > 0)
            {
                DataRow r = this.myInv.Select(searchExpression).FirstOrDefault();
                if (r != null) { return Convert.ToInt32(this.myInv.Select(searchExpression)[0]["ItemCount"].ToString()); }
                else { return 0; }
            }
            else { return 0; }
            
        }

        private void SetEquipStats()
        {
            if(myEquipList != null && myEquipList.Count() > 0)
            {
                Stats.SetBuffedStats(myEquipList, StatEffects);
            }
        }

    }

}
