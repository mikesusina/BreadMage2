using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BreadMage2
{
    public class clsSaveData
    {
        public int saveID { get; set; }
        public string saveName { get; set; }
        public string mageName { get; set; } = "Walnut";

        public int Yeast { get; set; }
        public int EXP { get; set; }

        public List<int> knownSpells { get; set; } = new List<int>();
        public List<int> gottenItems { get; set; } = new List<int>();
        public List<clsMageEffect> activeEffects { get; set; } = new List<clsMageEffect>();
        public List<clsSpell> equippedSpells { get; set; } = new List<clsSpell>();
        public List<clsEquipment> equippedMent { get; set; } = new List<clsEquipment>();
        public clsMageStats stats { get; set; } = new clsMageStats();

        public clsSaveData()
        {

        }

        public int Level()
        {
            // do your math to just figure out from here from raw EXP value?
            return 1;
        }
    }

}
