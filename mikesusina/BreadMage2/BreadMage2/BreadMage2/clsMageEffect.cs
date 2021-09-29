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
    //Class for holding buffs, debuffs, and status effects

    public class clsMageEffect : IEquatable<clsMageEffect>
    {

        public string sType { get; set; } = "NN";
        public int iValue { get; set; } = 0;
        public int iTimer { get; set; } = 0;


        public int iID { get; set; }
        public string sEffectName { get; set; }
        public string sDescription { get; set; }
        public string ImgURL { get; set; }

        public DataTable EffTable { get; set; }
        public DataRow EffRow { get; set; }

        /* 
        These values are not part of the library, but needed for active effects
        // a note about the values - for effects, this is the stack
        // for everything else, this is a rolling ticker like KoL buffs and should tick down after adventure
        */


        /* Effect Types:
        * MP = Mold/poison
        * ZC = Zest/Confusion
        * TS = Tension/Pinata
        * 
        * 
        * if possible, add these, possibly as a second 
        * /////
        * BA/M/D/R = Buff Atk/Matk/Def/Res
        * DA/M/D/R = Debuff ""
        * BE/DE = Buff and Debuff Evasion
        * /////
        * 
        * 
        * SS = Stun [note with stun - add this as a buff with one tick and remove when status effects tick in combat/post attack]
        * NN = none, default value, shouldn't be used
        * 
        * VALUES will always be set by:
        *  Mage: modifier attached to spell/item level (work in stats if spell??)
        *  Monster: % based on stat?
        */

        public clsMageEffect(string aType, int aValue, int aTick)
        {
            sType = aType;
            iValue = aValue;
            iTimer = aTick;


            switch (sType)
            {
                case "MP": //poison/mold
                    sEffectName = "Mold";
                    sDescription = "";
                    ImgURL = "";
                    break;
                case "ZC": //confusion/zest
                    sEffectName = "Zest";
                    sDescription = "";
                    ImgURL = "";
                    break;
                case "TS": //tension/pinata
                    sEffectName = "Tension";
                    sDescription = "";
                    ImgURL = "";
                    break;
                case "QA": //free hit before combat begins
                    sEffectName = "Quick Attack";
                    sDescription = "";
                    ImgURL = "";
                    break;
                case "SS":
                    sEffectName = "Stun";
                    sDescription = "";
                    ImgURL = "";
                    break;
                case "NN":
                    sEffectName = "None";
                    sDescription = "You shouldn't be here";
                    ImgURL = "";
                    break;
            }
        }

        public clsMageEffect(DataTable aMageEffData)
        {
            EffTable = aMageEffData;
            ParseEffData(EffTable);
        }

        public clsMageEffect(DataRow aMageEffRow)
        {
            EffRow = aMageEffRow;
            ParseEffData(EffRow);
        }
        
       
        private void ParseEffData(DataTable ds)
        {
            iID = Convert.ToInt32(ds.Rows[0]["ID"].ToString());
            sType = ds.Rows[0]["EffType"].ToString();
            sEffectName = ds.Rows[0]["EffName"].ToString();
            sDescription = ds.Rows[0]["Description"].ToString();
            ImgURL = ds.Rows[0]["ImgURL"].ToString();
        }

        private void ParseEffData(DataRow dr)
        {
            iID = Convert.ToInt32(dr["ID"].ToString());
            sType = dr["EffType"].ToString();
            sEffectName = dr["EffName"].ToString();
            sDescription = dr["Description"].ToString();
            ImgURL = dr["ImgURL"].ToString();
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
}
