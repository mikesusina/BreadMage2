using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace BreadMage2
{
    public class Mage
    {
        //the Mage object, this is the PC

        public int HP { get; set; }
        public int HPmax { get; set; }
        public int MP { get; set; }
        public int MPmax { get; set; }
        public int SP { get; set; }
        public int SPmax { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Location { get; set; }

       public Mage()
        {

            HPmax = 100;
            HP = HPmax;
            MPmax = 100;
            MP = MPmax;
            SPmax = 100;
            SP = SPmax;
            Atk = 10;
            Def = 2;
            Location = 1;
        }
    }
}
