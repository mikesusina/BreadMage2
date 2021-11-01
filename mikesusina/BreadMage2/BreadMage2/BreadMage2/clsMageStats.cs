using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadMage2
{
    public class clsMageStats
    {
        public int Level { get; set; }
        public int EXP { get; set; }
        public int BasePAtk { get; set; }
        public int BaseMAtk { get; set; }
        public int BaseDef { get; set; }
        public int BaseRes { get; set; }
        public int ModPAtk { get; set; } = 0;
        public int ModMAtk { get; set; } = 0;
        public int ModDef { get; set; } = 0;
        public int ModRes { get; set; } = 0;

        private int HealItems { get; set; } = 0;
        private int CombatItems { get; set; } = 0;
        private int RestoreItems { get; set; } = 0;
        private int MPItems { get; set; } = 0;

        public List<clsMageEffect> myEffects = new List<clsMageEffect>();

        public clsMageStats()
        {
            BasePAtk = 13;
            BaseMAtk = 13;
            BaseDef = 3;
            BaseRes = 6;


            HealItems = 3;
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
            /*
            if (myBuffList != null && myBuffList.Count > 0)
            {
                foreach (clsMageEffect b in myBuffList)
                {
                    double mod = 0;
                       switch (b.sPower)
                    {
                        case "D":
                            mod = .1;
                            break;
                        case "C":
                            mod = .25;
                            break;
                        case "B":
                            mod = .5;
                            break;
                        case "A":
                            mod = 1;
                            break;
                        case "S":
                            mod = 2.5;
                            break;
                    }

                    if (b.sType == "D") { mod *= -1; }
                    switch (b.sTarget)
                    {
                        case "A": //p [A]tk
                            aModPAtk += (int)Math.Ceiling(mod * BasePAtk);
                            break;
                        case "D": //[D]efence
                            aModDef += (int)Math.Ceiling(mod * BaseDef);
                            break;
                        case "M": //[M]agic atk
                            aModMAtk+= (int)Math.Ceiling(mod * BaseMAtk);
                            break;
                        case "R": //[R]esist
                            aModRes += (int)Math.Ceiling(mod * BaseMAtk);
                            break;
                        case "Y": //ph[Y]sical stats/ pak+def
                            aModPAtk += (int)Math.Ceiling(mod * BasePAtk);
                            aModDef += (int)Math.Ceiling(mod * BaseDef);
                            break;
                        case "G": //ma[G]ic stats/ mak+res
                            aModRes += (int)Math.Ceiling(mod * BaseMAtk);
                            aModRes += (int)Math.Ceiling(mod * BaseRes);
                            break;
                        case "O": //[O]ffensive stats
                            aModPAtk += (int)Math.Ceiling(mod * BasePAtk);
                            aModPAtk += (int)Math.Ceiling(mod * BasePAtk);
                            break;
                        case "V": //defensi[V]e stats
                            aModDef += (int)Math.Ceiling(mod * BaseDef);
                            aModRes += (int)Math.Ceiling(mod * BaseRes);
                            break;
                    }
                }
            }
            */
            ModPAtk = aModPAtk;
            ModMAtk = aModMAtk;
            ModDef = aModDef;
            ModRes = aModRes;
        }


        public int ComponentCount(int aType)
        {
            int i = 0;
            switch (aType)
            {
                case 1:
                    return HealItems;
                case 2:
                    return CombatItems;
                case 3:
                    return RestoreItems;
                case 4:
                    return MPItems;
                default:
                    break;
            }
            return i;
        }

        public void AddComponents(int aType, int anAmount)
        {
            switch (aType)
            {
                case 1:
                    HealItems += anAmount;
                    break;
                case 2:
                    CombatItems += anAmount;
                    break;
                case 3:
                    RestoreItems += anAmount;
                    break;
                case 4:
                    MPItems += anAmount;
                    break;
                default:
                    break;
            }
        }
    }
}
