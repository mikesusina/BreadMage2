using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadMage2
{
    public class clsGameFlags
    {
        public int SpellTier { get; set; } = 1;
        public int QuestTracker { get; set; } = 1;

        public bool thing1 { get; set; } = true;
        public bool thing2 { get; set; } = true;
        public bool thing3 { get; set; } = true;
        public bool thing4 { get; set; } = true;
        public bool thing5 { get; set; } = true;
        public clsTest atest { get; set; } = new clsTest();
        public List<clsSpell> aspellbook {get; set;} = new List<clsSpell>();
    }
}
