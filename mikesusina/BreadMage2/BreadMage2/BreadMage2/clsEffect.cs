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
        public string sType { get; set; }
        public string sEffectName { get; set; }
        public string sDescription { get; set; }
        public string sQuickDesc { get; set; }
        public string ImgURL { get; set; }


        // for de/buffs
        public string sPower;
        public string sTarget;


        public clsEffect()
        {


        }

        public clsEffect(DataTable ds)
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

        public clsEffect(DataRow dr)
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
