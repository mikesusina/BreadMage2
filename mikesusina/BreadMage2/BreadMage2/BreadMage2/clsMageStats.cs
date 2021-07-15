using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadMage2
{
    public class clsMageStats
    {
        public int BasePAtk { get; set; }
        public int BaseMAtk { get; set; }
        public int BaseDef { get; set; }
        public int BaseRes { get; set; }
        public int ModPAtk { get; set; } = 0;
        public int ModMAtk { get; set; } = 0;
        public int ModDef { get; set; } = 0;
        public int ModRes { get; set; } = 0;

        public clsMageStats()
        {
            BasePAtk = 10;
            BaseMAtk = 15;
            BaseDef = 5;
            BaseRes = 7;
        }

        public int PAtk()
        {
            return BasePAtk + ModPAtk;
        }

        public int MAtk()
        {
            return BaseMAtk + ModMAtk;
        }

        public int Def()
        {
            return BaseDef + ModDef;
        }

        public int Res()
        {
            return BaseRes + ModRes;
        }


        public void SetBuffedStats(List<clsEquipment> myEquipList, List<clsMageEffect> myBuffList)
        {
            int aModPAtk = 0;
            int aModMAtk = 0;
            int aModDef = 0;
            int aModRes = 0;

            if (myEquipList != null && myEquipList.Count > 0)
            {
                foreach (clsEquipment e in myEquipList)
                {
                    aModPAtk += e.PAtk();
                    aModMAtk += e.MAtk();
                    aModDef += e.Def();
                    aModRes += e.Res();
                }
            }


            if (myBuffList != null && myBuffList.Count > 0)
            {
                foreach (clsMageEffect b in myBuffList)
                {
                    // loop through buffs/debuffs and figure that out
                    /*
                    aModPAtk += b.PAtk();
                    aModMAtk += b.MAtk();
                    aModDef += b.Def();
                    aModRes += b.Res();
                    */
                }
            }

            ModPAtk = aModPAtk;
            ModMAtk = aModMAtk;
            ModDef = aModDef;
            ModRes = aModRes;
        }
    }
}
