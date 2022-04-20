using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadMage2
{
    public class clsGameFlags
    {
        public int QuestTracker { get; set; } = 1;
        public string MageClass { get; set; } = "Mold";
        public int DayTracker { get; set; } = 0;
        public int TownHome { get; set; } = 3;
        public bool thing2 { get; set; } = true;
        public bool thing3 { get; set; } = true;
        public bool thing4 { get; set; } = true;
        public bool thing5 { get; set; } = true;
        public clsTest atest { get; set; } = new clsTest();
    }
}
