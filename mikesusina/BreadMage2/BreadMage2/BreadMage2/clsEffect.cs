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
    public class clsEffect : IEquatable<clsEffect>
    {
        //this is the class for holding info related to effects
        public int iID { get; set; }
        
        // [E]ffects, [B]uff/[D]ebuff, [P]roc effects
        public string sCat;
        public string sType { get; set; }
        public int Tick {get; set;}
        public string sEffectName { get; set; }
        public string sDescription { get; set; }
        public string sQuickDesc { get; set; }
        public string ImgURL { get; set; }


        // for de/buffs
        public int Power;


        public clsEffect()
        {

        }

        public clsEffect(DataRow dr)
        {
            iID = Convert.ToInt32(dr["ID"].ToString());
            //the "effect type" column is for category, so the Target column is usually the "effect type" within it's category
            sCat = dr["EffectType"].ToString();
            sType = dr["Target"].ToString();
            sEffectName = dr["EffectName"].ToString();
            sDescription = dr["EffectDescription"].ToString();
            sQuickDesc = dr["QuickDesc"].ToString();
            ImgURL = dr["ImgURL"].ToString();
            Power = Convert.ToInt32(dr["Power"].ToString());
        }


        public clsEffect ShallowCopy()
        {
            return (clsEffect)this.MemberwiseClone();
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsEffect objAsChoice = obj as clsEffect;
            if (objAsChoice == null) return false;
            else return Equals(objAsChoice);
        }

        public override int GetHashCode()
        {
            return iID;
        }

        public bool Equals(clsEffect other)
        {
            if (other == null) return false;
            return (this.iID.Equals(other.iID));
        }

    }
}
