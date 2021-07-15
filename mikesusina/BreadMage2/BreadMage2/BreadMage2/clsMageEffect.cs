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

    public class clsMageEffect
    {
        public int iType { get; set; } = 0;
        public int iTimer { get; set; } = 0;
        public int iValue { get; set; } = 0;
        public string sEffectName { get; set; }

        public clsMageEffect()
        {

        }

        public void Tick()
        {
            if (iTimer > 0) { iTimer =- 1; }
        }
    }
}
