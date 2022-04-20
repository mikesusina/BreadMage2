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
        public string Class { get; set; } = "A";
        public string effectCat { get; set; }
        public int YeastCost { get; set; }
        public int SPCost { get; set; }
        public int Power { get; set; }


        public List<string> SpellBlocks { get; set; } = new List<string>();
        public List<KeyValuePair<string, string>> SpellEffects { get; set; } = new List<KeyValuePair<string, string>>();
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


        public clsSpell() { }
        public clsSpell(DataRow dr)
        {
            spellID = Convert.ToInt32(dr["SpellID"].ToString());
            spellName = dr["SpellName"].ToString();
            spellType = dr["SpellType"].ToString();
            chatType = dr["ChatType"].ToString();
            Class = dr["Class"].ToString();
            effectCat = dr["EffectCategory"].ToString();
            ImgURL = dr["ImgURL"].ToString();
            spellDescription = dr["SpellDescription"].ToString();
            YeastCost = Convert.ToInt32(dr["YeastCost"].ToString());
            SPCost = Convert.ToInt32(dr["SPCost"].ToString());
            foreach (string sBlock in Program.ParseDelimitedStringToString(dr["Blocks"].ToString()))
            {
                SpellEffects.Add(new KeyValuePair<string, string>(sBlock.Substring(0, sBlock.IndexOf(":")), sBlock.Substring(sBlock.IndexOf(":") + 1)));
            }
            Power = Convert.ToInt32(dr["Power"].ToString());
            AddChatter(dr["Chatter"].ToString());
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

        public clsSpell ShallowCopy()
        {
            return (clsSpell)this.MemberwiseClone();
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
