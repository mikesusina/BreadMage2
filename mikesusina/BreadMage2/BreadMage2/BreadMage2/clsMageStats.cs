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
        public int Yeast { get; set; } = 3000;
        public int Level = 1;
        public int EXP { get; set; }
        public List<Stat> PlayerStats { get; set; } = new List<Stat>() { new Stat("PAK", 1), new Stat("MAK", 1), new Stat("DEF", 1), new Stat("RES", 1) };
        public int ModHP { get; set; } = 0;

        public int MaxSpellTier = 1;
        private int Ingredients { get; set; } = 0;
        private int CosmicEnergy { get; set; } = 0;
        private int ElementalMotes { get; set; } = 0;
        

        private List<clsEffect> myEffects = new List<clsEffect>();
        private List<clsEquipment> myEquipMent = new List<clsEquipment>();
        private List<clsSpell> myEquippedSpells = new List<clsSpell>();
        private List<int> myKnownSpells = new List<int>();
        private List<int> myCollectedItems = new List<int>();

        public clsMageStats()
        {
            HPMax = 30;
            HP = HPMax;
            PlayerStats.Find(x => x.Name == "PAK").BaseVal = 13;
            PlayerStats.Find(x => x.Name == "MAK").BaseVal = 13;
            PlayerStats.Find(x => x.Name == "DEF").BaseVal = 3;
            PlayerStats.Find(x => x.Name == "RES").BaseVal = 6;

            MaxSP = 10;
            CurrentMaxSP = 10;
        }

        public List<clsEffect> CurrentEffects(string sType = "all") 
        {
            List<clsEffect> rList = new List<clsEffect>();
            switch (sType.ToLower())
            {
                case "all": return myEffects;
                case "effect":
                    return myEffects.FindAll(x => x.sCat == "E");
                case "buff":
                    return myEffects.FindAll(x => x.sCat == "B");
                case "debuff":
                    return myEffects.FindAll(x => x.sCat == "D");
                case "proc":
                    return myEffects.FindAll(x => x.sCat == "P");
                case "daytick":
                    rList.AddRange(myEffects.FindAll(x => x.sCat == "B"));
                    rList.AddRange(myEffects.FindAll(x => x.sCat == "D"));
                    return rList;
            }

            return myEffects; 
        }
        public List<clsEquipment> CurrentEquipment() { return myEquipMent; }
        public List<clsSpell> CurrentEQSpells() { return myEquippedSpells; }
        public List<int> AllSpells() { return myKnownSpells; }

        public clsEquipment myEquipmentBySlot(int iSlot)
        {
            try
            {
                if (myEquipMent.Find(x => x.Slot == iSlot) != null) { return myEquipMent.Find(x => x.Slot == iSlot); }
                else { return null; }
            }
            catch { throw new ArgumentOutOfRangeException("I think you tried to search for a bad equip slot"); };
            
        }

        public List<clsSpell> mySpellsByType(string sType = "all")
        {
            List<clsSpell> returnSpells = CurrentEQSpells();
            if (sType.ToLower() != "all") { returnSpells = Program.FilterSpellsByType(returnSpells, sType); }
            return returnSpells;
        }

        public void SetEquipStats()
        {
            foreach (Stat s in PlayerStats) { s.EquipVals = 0; }
            int aModHP = 0;

            if (myEquipMent != null && myEquipMent.Count > 0)
            {
                foreach (clsEquipment e in myEquipMent)
                {
                    PlayerStats.Find(x => x.Name == "PAK").EquipVals += e.PAtk();
                    PlayerStats.Find(x => x.Name == "MAK").EquipVals += e.MAtk();
                    PlayerStats.Find(x => x.Name == "DEF").EquipVals += e.Def();
                    PlayerStats.Find(x => x.Name == "RES").EquipVals += e.Res();
                    aModHP += e.HP();
                }
            }
        }

        private int GetEquipStat(string sType)
        {
            int iReturn = 0;

            switch (sType.ToLower())
            {
                case "patk":
                    break;
                case "matk":
                    break;
                case "PDef":
                    break;
                case "Patk":
                    break;
            }
            return iReturn;
        }

        public void SetEffectStats(List<clsEffect> aList)
        {
            myEffects = aList;
        }



        public void AddEffect(clsEffect anEffect)
        {
            if (myEffects.Find(x => x.iID == anEffect.iID) != null)
            {
                myEffects.Find(x => x.iID == anEffect.iID).Tick += anEffect.Tick;
            }
            else { myEffects.Add(anEffect); }
        }

        public void SetEffects(List<clsEffect> someEffects)
        {
            myEffects = someEffects;
        }
        public void SetEquipment(List<clsEquipment> someEquipment)
        {
            myEquipMent = someEquipment;
        }


        /*
        public void LearnSpell(clsSpell aSpell, bool bUnlearn = false)
        {
            if (!bUnlearn)
            {
                if (myKnownSpells.Contains(aSpell.spellID) == false)
                    { myKnownSpells.Add(aSpell.spellID); }
            }
            else //if unlearning...
            {
                if (myKnownSpells.Contains(aSpell.spellID))
                    { myKnownSpells.Remove(aSpell.spellID); }
            }
        }
        public void LearnSpellbyID(int aSpellID, bool bUnlearn = false)
        {
            if (!bUnlearn)
            {
                if (myKnownSpells.Contains(aSpellID) == false)
                { myKnownSpells.Add(aSpellID); }
            }
            else //if unlearning...
            {
                if (myKnownSpells.Contains(aSpellID))
                { myKnownSpells.Remove(aSpellID); }
            }
        }
        */

        public void EquipSpell(clsSpell aSpell) 
        {
            if (myEquippedSpells.Find(x => x.spellID == aSpell.spellID) == null)
                { myEquippedSpells.Add(aSpell.ShallowCopy()); }
        }
        public void UnequipSpell(clsSpell aSpell, bool bForget = false)
        {
            if (myEquippedSpells.Find(x => x.spellID == aSpell.spellID) != null)
            {
                myEquippedSpells.Remove(myEquippedSpells.Find(x => x.spellID == aSpell.spellID));
                if (bForget && myKnownSpells.Contains(aSpell.spellID)) { myKnownSpells.Remove(aSpell.spellID); }
            }
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

        public void AdjustComponent(int aType, int anAmount)
        {
            switch (aType)
            {
                case 1:
                    Ingredients += anAmount;
                    if (Ingredients < 0) { Ingredients = 0; }
                    else if (Ingredients > (50 * MaxSpellTier))
                        { Ingredients = (50 * MaxSpellTier); }
                    break;
                case 2:
                    CosmicEnergy += anAmount;
                    if (CosmicEnergy < 0) { CosmicEnergy = 0; }
                    else if (CosmicEnergy > (50 * MaxSpellTier))
                    { CosmicEnergy = (50 * MaxSpellTier); }
                    break;
                case 3:
                    ElementalMotes += anAmount;
                    if (ElementalMotes < 0) { ElementalMotes = 0; }
                    else if (ElementalMotes > (50 * MaxSpellTier))
                    { ElementalMotes = (50 * MaxSpellTier); }
                    break;
                default:
                    break;
            }
        }

    }

    public class Stat
    {
        public string Name { get; set; }
        public int BaseVal { get; set; }
        public int EquipVals { get; set; } = 0;
        public double StatMod { get; set; } = 1;
        public Stat() { }
        public Stat(string aName, int aBaseVal) { Name = aName; BaseVal = aBaseVal; }

        public int BuffedVal()
        {
            return (int)Math.Ceiling((BaseVal * StatMod)+ EquipVals);
        }
    }



}
