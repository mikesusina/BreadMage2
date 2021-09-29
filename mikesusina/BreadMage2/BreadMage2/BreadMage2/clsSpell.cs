using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BreadMage2
{
    public class clsSpell : IEquatable<clsSpell>
    {
        public int spellID { get; set; }
        public string spellName { get; set; }
        public string spellDescription { get; set; }
        public string ImgURL { get; set; }
        public int spellType { get; set; }
        public int YeastCost { get; set; }
        public int SPCost { get; set; }

        public List<string> SpellBlocks { get; set; } = new List<string>();

        /// <summary>
        /// "spelltype" wil determine effect, based on int
        /// spell "tier" is going to be independent of the spells themselves
        /// 
        /// 
        /// 
        /// 
        /// </summary>


        public clsSpell(DataTable dt)
        {
            spellID = Convert.ToInt32(dt.Rows[0]["SpellID"].ToString());
            spellName = dt.Rows[0]["SpellName"].ToString();
            spellType = Convert.ToInt32(dt.Rows[0]["SpellType"].ToString());
            ImgURL = dt.Rows[0]["ImgURL"].ToString();
            spellDescription = dt.Rows[0]["SpellDescription"].ToString();
            YeastCost = Convert.ToInt32(dt.Rows[0]["YeastCost"].ToString());
            SPCost = Convert.ToInt32(dt.Rows[0]["SPCost"].ToString());
            ParseBlocks(dt.Rows[0]["Blocks"].ToString());
        }

        public clsSpell(DataRow dr)
        {
            spellID = Convert.ToInt32(dr["SpellID"].ToString());
            spellName = dr["SpellName"].ToString();
            spellType = Convert.ToInt32(dr["SpellType"].ToString());
            ImgURL = dr["ImgURL"].ToString();
            spellDescription = dr["SpellDescription"].ToString();
            YeastCost = Convert.ToInt32(dr["YeastCost"].ToString());
            SPCost = Convert.ToInt32(dr["SPCost"].ToString());
            ParseBlocks(dr["Blocks"].ToString());
        }

        public clsSpell()
        {

        }


        private void ParseBlocks(string rawBlocks)
        {
            string s = rawBlocks;
            while (s.IndexOf("|") > 0)
            {
                //tags are all two characters
                string temp = s.Substring(0, s.IndexOf("|"));
                SpellBlocks.Add(temp);
                s = s.Substring(s.IndexOf("|") + 1);
            }
            SpellBlocks.Add(s);
        }




        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsSpell objAsSpell = obj as clsSpell;
            if (objAsSpell == null) return false;
            else return Equals(objAsSpell);
        }

        public override int GetHashCode()
        {
            return spellID;
        }

        public bool Equals(clsSpell other)
        {
            if (other == null) return false;
            return (this.spellID.Equals(other.spellID));
        }
    }
}
