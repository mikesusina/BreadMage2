using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BreadMage2
{
    public class engEffects
    {
        //private GameScreen myGS;
        private engGame myGame;
        private int DayTracker => myGame.gMage.myGameFlags.DayTracker;

        public engEffects(engGame aGame)
        {
            myGame = aGame;
        }
        public void SetGame(engGame aGame) { myGame = aGame; }





        public List<clsSpell> AddWeaponSkills()
        {
            List<clsSpell> list = new List<clsSpell>();

            foreach (clsEquipment e in myGame.gMage.Stats.CurrentEquipment())
            {
                if (e.CombatSkill() != 0 && myGame.gMage.EQSpells().Find(x => x.spellID == e.CombatSkill()) != null)
                {
                    list.Add(myGame.GetSpellByID(e.CombatSkill()));
                }
            }
            return list;
        }

        public void ReadBuff(int anID)
        {
            clsEffect e = myGame.GameLibraries.EffectLib().Find(x => x.iID == anID);

        }

        public void PassiveEffect(int anID)
        {
            clsSpell e = myGame.GameLibraries.SpellLib().Find(x => x.spellID== anID);

            if (e.spellID == 9) 
            {
                FreshBaked();
            }
            else if (e.spellID == 7)
            {
                Jamtastic();
            }

        }

        public void EventBased(string anEvent)
        {
            if (anEvent == "combatEnd")
            {
                if (myGame.gMage.EQSpells("passive").Contains(myGame.GetSpell("Freshly Baked"))) { FreshBaked(); }
            }
        }

        public bool ParryMonsterAttack()
        {

            return false;
        }

        private void FreshBaked()
        {
            myGame.gMage.AdjustHP(5);
            myGame.RefreshMage();
        }

        private void Jamtastic()
        {
            MessageBox.Show("Hey you got a the jamtastic effect and this is what is does");
        }

        public void RefreshBuffs(GameScreen sGS)
        {

        }

    }
}
