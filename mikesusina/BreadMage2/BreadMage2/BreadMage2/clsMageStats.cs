using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadMage2
{
    public class clsMageStats
    {
        public int HP { get; set; }
        public int HPMax { get; set; }
        public int MaxSP { get; set; }      
        public int CurrentMaxSP { get; set; }
        public int BasePAtk { get; set; }
        public int BaseMAtk { get; set; }
        public int BaseDef { get; set; }
        public int BaseRes { get; set; }
        public int ModPAtk { get; set; } = 0;
        public int ModMAtk { get; set; } = 0;
        public int ModDef { get; set; } = 0;
        public int ModRes { get; set; } = 0;
        public int ModHP { get; set; } = 0;


        public int EQPAtk { get; set; } = 0;
        public int EQMAtk { get; set; } = 0;
        public int EQDef { get; set; } = 0;
        public int EQRes { get; set; } = 0;
        public int EQHP { get; set; } = 0;

        private int Ingredients { get; set; } = 0;
        private int CosmicEnergy { get; set; } = 0;
        private int ElementalMotes { get; set; } = 0;
        //private int MPItems { get; set; } = 0;

        private List<clsMageEffect> myEffects = new List<clsMageEffect>();
        private List<clsEquipment> myEquipment = new List<clsEquipment>();
        private List<clsSpell> myEquippedSpells = new List<clsSpell>();

        public clsMageStats()
        {
            HPMax = 30;
            HP = HPMax;
            BasePAtk = 13;
            BaseMAtk = 13;
            BaseDef = 3;
            BaseRes = 6;

            MaxSP = 10;
            CurrentMaxSP = 10;
        }

        public int PAtk() { return BasePAtk + ModPAtk; }
        public int MAtk() { return BaseMAtk + ModMAtk; }
        public int Def() { return BaseDef + ModDef; }
        public int Res() { return BaseRes + ModRes; }

        public List<clsMageEffect> CurrentEffects() { return myEffects; }
        public List<clsEquipment> CurrentEquipment() { return myEquipment; }
        public List<clsSpell> CurrentEQSpells() { return myEquippedSpells; }

        public clsEquipment myEquipmentBySlot(int iSlot)
        {
            try
            {
                if (myEquipment.Find(x => x.Slot == iSlot) != null) { return myEquipment.Find(x => x.Slot == iSlot); }
                else { return null; }
            }
            catch { throw new ArgumentOutOfRangeException("I think you tried to search for a bad equip slot"); };
            
        }

        public List<clsSpell> mySpellsByType(int iType = 0)
        {
            List<clsSpell> returnSpells = new List<clsSpell>();
            switch (iType)
            {
                case 0: //return all
                    returnSpells = CurrentEQSpells();
                    break;
                case 1: //[C]ombat
                    returnSpells = CurrentEQSpells().FindAll(x => x.spellType == "C");
                    break;
                case 2: //[P]assive
                    returnSpells = CurrentEQSpells().FindAll(x => x.spellType == "P");
                    break;
                case 3: //[G]eneral / "out of combat castable"
                    returnSpells = CurrentEQSpells().FindAll(x => x.spellType == "G");
                    break;
                case 4: //castable spells
                    returnSpells.AddRange(CurrentEQSpells().FindAll(x => x.spellType == "C"));
                    returnSpells.AddRange(CurrentEQSpells().FindAll(x => x.spellType == "G"));
                    break;
                case 5: //Item spells - return blank, these aren't "equipped" but this keeps consistency with master known spells
                    break;
            }
            return returnSpells;
        }

        public void SetBuffedStats()
        {
            int aModPAtk = 0;
            int aModMAtk = 0;
            int aModDef = 0;
            int aModRes = 0;
            int aModHP = 0;

            if (myEquipment != null && myEquipment.Count > 0)
            {
                foreach (clsEquipment e in myEquipment)
                {
                    aModPAtk += e.PAtk();
                    aModMAtk += e.MAtk();
                    aModDef += e.Def();
                    aModRes += e.Res();
                    aModHP += e.HP();
                }
            }
            ModPAtk = aModPAtk;
            ModMAtk = aModMAtk;
            ModDef = aModDef;
            ModRes = aModRes;
        }

        public void AddEffect(int anID, int aValue)
        {
            var obj = myEffects.FirstOrDefault(x => x.iID == anID);
            if (obj != null) { obj.iValue += aValue; }
            else { myEffects.Add(new clsMageEffect(anID, aValue)); }
        }

        public void SetEffects(List<clsMageEffect> someEffects)
        {
            myEffects = someEffects;
        }
        public void SetEquipment(List<clsEquipment> someEquipment)
        {
            myEquipment = someEquipment;
        }
        public void SetEQSpells(List<clsSpell> someSpells)
        {
            myEquippedSpells = someSpells;
        }


        public int ComponentCount(int aType)
        {
            int i = 0;
            switch (aType)
            {
                case 1:
                    return Ingredients;
                case 2:
                    return CosmicEnergy;
                case 3:
                    return ElementalMotes;
                //case 4:
                //    return MPItems;
                default:
                    break;
            }
            return i;
        }

        public int EquippedSP()
        {
            int iReturn = 0;
            if (CurrentEQSpells().Count > 0)
            {
                foreach (clsSpell s in CurrentEQSpells())
                {
                    iReturn += s.SPCost;
                }
            }
            return iReturn;
        }

        public void AddComponents(int aType, int anAmount)
        {
            switch (aType)
            {
                case 1:
                    Ingredients += anAmount;
                    break;
                case 2:
                    CosmicEnergy += anAmount;
                    break;
                case 3:
                    ElementalMotes += anAmount;
                    break;
                //case 4:
                //    MPItems += anAmount;
                //    break;
                default:
                    break;
            }
        }

    }
}
