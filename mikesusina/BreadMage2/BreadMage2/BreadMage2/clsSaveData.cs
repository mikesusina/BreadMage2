﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BreadMage2
{
    class clsSaveData
    {
        public int saveID { get; set; }
        public string saveName { get; set; }
        public List<int> knownSpells { get; set; } = new List<int>();
        public List<int> gottenItems { get; set; } = new List<int>();
        public List<int> gottenEquipment { get; set; } = new List<int>();
        public List<clsSpell> equippedSpells { get; set; } = new List<clsSpell>();
        public List<clsEquipment> equippedMent { get; set; } = new List<clsEquipment>();


        public clsSaveData()
        {

        }
    }

}
