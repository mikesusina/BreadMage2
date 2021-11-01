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
        public string spellType { get; set; }
        public string chatType { get; set; } = "D";
        public int YeastCost { get; set; }
        public int SPCost { get; set; }
        public string Power { get; set; }

        public List<string> SpellBlocks { get; set; } = new List<string>();
        public List<SpellChatter> SpellChatter { get; set; } = new List<SpellChatter>();

        /// <summary>
        /// "spelltype" - 999 is item spells, use an int to base the reference for determining values [ie patk, def, etc...])
        /// /long term - components are going to be mixed values, so each item spell will have to have a unique-ish cost. Like restoring. cost for 1 cast = whatever, determine by spell blocks?
        /// spell "tier" is going to be independent of the spells themselves
        /// 
        /// SpellBlock Decoder ring: XY = 
        /// X action & target
        ///     Y effect
        ///     Value TBD!
        /// 
        ///[A]pply/[R]emove
        ///     [D]amage
        ///     [M]old
        ///     [Z]est
        ///     [T]ension
        ///     [S]tun
        ///     [Q]uick attack
        ///     h[E]al
        ///
        ///     c[H]arge
        ///     [P]arry
        ///     [B]lock (block parry are the same, parry is high roll? Zest says yes)
        ///     si[L] ence? Maybe an effect?
        ///
        ///[C]onsume/con[V]ert
        ///     [M]old
        ///     [Z]est
        ///     [T]ension
        ///     [I]tem??? AKA Stealing

        /// </summary>


        public clsSpell(DataTable dt)
        {
            spellID = Convert.ToInt32(dt.Rows[0]["SpellID"].ToString());
            spellName = dt.Rows[0]["SpellName"].ToString();
            spellType = dt.Rows[0]["SpellType"].ToString();
            ImgURL = dt.Rows[0]["ImgURL"].ToString();
            chatType = dt.Rows[0]["ChatType"].ToString();
            spellDescription = dt.Rows[0]["SpellDescription"].ToString();
            YeastCost = Convert.ToInt32(dt.Rows[0]["YeastCost"].ToString());
            SPCost = Convert.ToInt32(dt.Rows[0]["SPCost"].ToString());
            ParseBlocks(dt.Rows[0]["Blocks"].ToString());
            Power = dt.Rows[0]["Power"].ToString();
            AddChatter(dt.Rows[0]["Chatter"].ToString());
        }

        public clsSpell(DataRow dr)
        {
            spellID = Convert.ToInt32(dr["SpellID"].ToString());
            spellName = dr["SpellName"].ToString();
            spellType = dr["SpellType"].ToString();
            chatType = dr["ChatType"].ToString();
            ImgURL = dr["ImgURL"].ToString();
            spellDescription = dr["SpellDescription"].ToString();
            YeastCost = Convert.ToInt32(dr["YeastCost"].ToString());
            SPCost = Convert.ToInt32(dr["SPCost"].ToString());
            ParseBlocks(dr["Blocks"].ToString());
            Power = dr["Power"].ToString();
            AddChatter(dr["Chatter"].ToString());
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

        private void AddChatter(string sText)
        {
            //full chatters are # delimited, so ability to do pre/post test is still | delmited

            string s = sText;
            while (s.IndexOf("#") > 0)
            {
                string temp = s.Substring(0, s.IndexOf("#"));
                SpellChatter.Add(new SpellChatter(temp, spellType, "O", chatType, true));
                s = s.Substring(s.IndexOf("#")+ 1);
            }
            SpellChatter.Add(new SpellChatter(s, spellType, "O", chatType, true));
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
