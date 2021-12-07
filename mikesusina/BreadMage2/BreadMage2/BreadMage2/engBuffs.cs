using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BreadMage2
{
    public class engBuffs
    {
        private GameScreen myGS;

        public engBuffs()
        {

        }
        public void SetGame(GameScreen aGS) { myGS = aGS; }


        public void ReadBuff(int anID)
        {
            clsEffect e = myGS.GameLibraries.EffectLib().Find(x => x.iID == anID);

        }

        public void PassiveEffect(int anID)
        {
            clsSpell e = myGS.GameLibraries.SpellBook().Find(x => x.spellID== anID);

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
                if (myGS.gMage.EQSpells(2).Contains(myGS.GetSpell("Freshly Baked"))) { FreshBaked(); }
            }
        }

        private void FreshBaked()
        {
            int i = myGS.gMage.Stats.HP + 5;
            if (i > myGS.gMage.Stats.HPMax) { myGS.gMage.Stats.HP = myGS.gMage.Stats.HPMax; }
            else { myGS.gMage.Stats.HP += 5; }
            myGS.bMage.UpdateBars();
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
