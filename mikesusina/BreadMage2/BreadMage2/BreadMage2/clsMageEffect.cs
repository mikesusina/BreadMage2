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
    //Class for the basic info for active effects on the player - the generic item to unique items

    public class clsMageEffect : IEquatable<clsMageEffect>
    {
        //the generic class will used to hold values for save/current values data
        public int iID { get; set; }
        public int iValue { get; set; } = 0; //the "tick"




        public clsMageEffect() { }

        public clsMageEffect(int anID, int aTick)
        {
            iID = anID;
            iValue = aTick;
            }


        public clsMageEffect(List<clsMageEffect> s, int anID = 1)
        {
            s.Find(x => x.iID == anID);
        }

        public bool tickType()
        {
            List<int> tickTypes = new List<int> {1, 2, 3, 7, 8, 10, 11, 12};
            if (tickTypes.Contains(iID)) { return true; }
            else return false;
        }
        
       
        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsMageEffect objAsChoice = obj as clsMageEffect;
            if (objAsChoice == null) return false;
            else return Equals(objAsChoice);
        }

        public override int GetHashCode()
        {
            return iID;
        }

        public bool Equals(clsMageEffect other)
        {
            if (other == null) return false;
            return (this.iID.Equals(other.iID));
        }
    }

    /*
    public class StatusEffect : clsMageEffect, IEquatable<StatusEffect>
    {

        //db info
        public string sType { get; set; }
        public string sEffectName { get; set; }
        public string sDescription { get; set; }
        public string sQuickDesc { get; set; }
        public string ImgURL { get; set; }


         *
         * [M]old
         * [Z]est
         * [T]ension
         * [S]tun
         * [Q]uick attack
         * [B]lock (block parry are the same, parry is high roll)
         * si[L]ence? Maybe an effect?
         *

        public StatusEffect()
        {

        }

        public StatusEffect(DataTable aMageEffData)
        {
            ParseEffData(aMageEffData);
        }

        public StatusEffect(DataRow aMageEffRow)
        {
            ParseEffData(aMageEffRow);
        }


        private void ParseEffData(DataTable ds)
        {
            iID = Convert.ToInt32(ds.Rows[0]["ID"].ToString());
            sType = ds.Rows[0]["Target"].ToString();
            sEffectName = ds.Rows[0]["EffectName"].ToString();
            sDescription = ds.Rows[0]["EffectDescription"].ToString();
            sQuickDesc = ds.Rows[0]["QuickDesc"].ToString();
            ImgURL = ds.Rows[0]["ImgURL"].ToString();
        }

        private void ParseEffData(DataRow dr)
        {
            iID = Convert.ToInt32(dr["ID"].ToString());
            sType = dr["EffectType"].ToString();
            sEffectName = dr["Target"].ToString();
            sDescription = dr["EffectDescription"].ToString();
            sQuickDesc = dr["QuickDesc"].ToString();
            ImgURL = dr["ImgURL"].ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            StatusEffect objAsChoice = obj as StatusEffect;
            if (objAsChoice == null) return false;
            else return Equals(objAsChoice);
        }

        public override int GetHashCode()
        {
            return iID;
        }

        public bool Equals(StatusEffect other)
        {
            if (other == null) return false;
            return (this.iID.Equals(other.iID));
        }
    }









    public class ActiveEffect : clsMageEffect, IEquatable<ActiveEffect>
    {

        //db info
        public string sType { get; set; }
        public string sEffectName { get; set; }
        public string sDescription { get; set; }
        public string sQuickDesc { get; set; }
        public string ImgURL { get; set; }


        // for de/buffs
        public string sPower;
        public string sTarget;


        public ActiveEffect()
        {

        }

        public ActiveEffect(DataTable aMageEffData)
        {
            ParseEffData(aMageEffData);
        }

        public ActiveEffect(DataRow aMageEffRow)
        {
            ParseEffData(aMageEffRow);
        }



        private void ParseEffData(DataTable ds)
        {
            iID = Convert.ToInt32(ds.Rows[0]["ID"].ToString());
            sType = ds.Rows[0]["EffectType"].ToString();
            sEffectName = ds.Rows[0]["EffectName"].ToString();
            sDescription = ds.Rows[0]["EffectDescription"].ToString();
            sQuickDesc = ds.Rows[0]["QuickDesc"].ToString();
            ImgURL = ds.Rows[0]["ImgURL"].ToString();
            sTarget = ds.Rows[0]["Target"].ToString();
            sPower = ds.Rows[0]["Power"].ToString();
        }

        private void ParseEffData(DataRow dr)
        {
            iID = Convert.ToInt32(dr["ID"].ToString());
            sType = dr["EffectType"].ToString();
            sEffectName = dr["EffectName"].ToString();
            sDescription = dr["EffectDescription"].ToString();
            sQuickDesc = dr["QuickDesc"].ToString();
            ImgURL = dr["ImgURL"].ToString();
            sTarget = dr["Target"].ToString();
            sPower = dr["Power"].ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ActiveEffect objAsChoice = obj as ActiveEffect;
            if (objAsChoice == null) return false;
            else return Equals(objAsChoice);
        }

        public override int GetHashCode()
        {
            return iID;
        }

        public bool Equals(ActiveEffect other)
        {
            if (other == null) return false;
            return (this.iID.Equals(other.iID));
        }
    }








    public class PassiveEffect : clsMageEffect, IEquatable<PassiveEffect>
    {

        //db info
        public string sType { get; set; }
        public string sEffectName { get; set; }
        public string sDescription { get; set; }
        public string sQuickDesc { get; set; }
        public string ImgURL { get; set; }



        public PassiveEffect()
        {

        }

        public PassiveEffect(DataTable aMageEffData)
        {
            ParseEffData(aMageEffData);
        }

        public PassiveEffect(DataRow aMageEffRow)
        {
            ParseEffData(aMageEffRow);
        }


        private void ParseEffData(DataTable ds)
        {
            iID = Convert.ToInt32(ds.Rows[0]["ID"].ToString());
            sType = ds.Rows[0]["EffectType"].ToString();
            sEffectName = ds.Rows[0]["EffectName"].ToString();
            sDescription = ds.Rows[0]["EffectDescription"].ToString();
            sQuickDesc = ds.Rows[0]["QuickDesc"].ToString();
            ImgURL = ds.Rows[0]["ImgURL"].ToString();
        }

        private void ParseEffData(DataRow dr)
        {
            iID = Convert.ToInt32(dr["ID"].ToString());
            sType = dr["EffectType"].ToString();
            sEffectName = dr["EffectName"].ToString();
            sDescription = dr["EffectDescription"].ToString();
            sQuickDesc = dr["QuickDesc"].ToString();
            ImgURL = dr["ImgURL"].ToString();
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            PassiveEffect objAsChoice = obj as PassiveEffect;
            if (objAsChoice == null) return false;
            else return Equals(objAsChoice);
        }

        public override int GetHashCode()
        {
            return iID;
        }

        public bool Equals(PassiveEffect other)
        {
            if (other == null) return false;
            return (this.iID.Equals(other.iID));
        }
    }
    */
}
