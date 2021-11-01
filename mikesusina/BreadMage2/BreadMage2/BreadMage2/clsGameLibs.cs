using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadMage2
{
    public class clsGameLibs
    {
        // for libraries
        private List<clsMonster> gMonsterList { get; set; } = new List<clsMonster>();
        private List<clsUniqueItem> gItemBook { get; set; } = new List<clsUniqueItem>();
        private List<clsSpell> gSpellBook { get; set; } = new List<clsSpell>();
        private List<clsChoiceAdventure> gChoiceList { get; set; } = new List<clsChoiceAdventure>();
        private List<EffectChatter> gEffectChatter { get; set; } = new List<EffectChatter>();
        private List<SpellChatter> gSpellChatter { get; set; } = new List<SpellChatter>();
        private List<clsLocation> gLocationList { get; set; } = new List<clsLocation>();
        private List<clsEffect> gEffectLib { get; set; } = new List<clsEffect>();

        public clsGameLibs()
        {

        }


        public List<clsChoiceAdventure> ChoiceLib() { return gChoiceList; }
        public void SetChoiceLib(List<clsChoiceAdventure> l) { gChoiceList = l; }

        public List<EffectChatter> EffectChatterLib() { return gEffectChatter; }
        public void SetEffectChatterLib(List<EffectChatter> l) { gEffectChatter = l; }

        public List<SpellChatter> SpellChatterLib() { return gSpellChatter; }
        public void SetSpellChatterLib(List<SpellChatter> l) { gSpellChatter = l; }

        public List<clsUniqueItem> ItemLib() { return gItemBook; }
        public void SetItemLib(List<clsUniqueItem> l) { gItemBook = l; }

        public List<clsLocation> LocationLib() { return gLocationList; }
        public void SetLocationLib(List<clsLocation> l) { gLocationList = l; }

        public List<clsMonster> MonsterLib() { return gMonsterList; }
        public void SetMonsterLib(List<clsMonster> l) { gMonsterList = l; }

        public List<clsSpell> SpellBook() { return gSpellBook; }
        public void SetSpellLib(List<clsSpell> l) { gSpellBook = l; }

        public List<clsEffect> EffectLib() { return gEffectLib; }
        public void SetEffectLib(List<clsEffect> l) { gEffectLib = l; }

    }
}
