using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadMage2.Controls;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BreadMage2
{
    class engBattle
    {
        private GameScreen myGameScr;
        private int MageDefend = 0;

        public engBattle(GameScreen aGameScr)
        {

            myGameScr = aGameScr;
            myGameScr.bMage.UpdateBars(myGameScr.gMage);


            // roll initiative - do better than a flip
            int i = int.Parse(DateTime.Now.ToString("MM/DD/yy h:mm:ss").Substring(DateTime.Now.ToString("MM/DD/yy h:mm:ss").Length - 1, 1));
            bool bEven = (i != 0 && i != 2 && i != 4 && i != 6 && i != 8);
            // lost initiative - monster attacks first
            if (bEven)
            {
                MessageBox.Show("Oh no! It gets the jump!");
                MonsterAttack();
            }
            else
            {
                //assumption being wait for action, but first check any "on turn start" effects
                MageTurn();
            }
        }

        /// <summary>
        /// Mage logic starts here
        /// </summary>
        /// <param name="MageAttacks"></param>

        public void MageTurn()
        {
            //poison ticks "on start of turn" so just tick it now 
            //*** this is where you'd implement a poison save spell - add it ass a buff? consume ticks no timer?, cast grants > 1
            TickPoison(1);
            QuickAttack();

            //update the bars one final time
            myGameScr.bMage.UpdateBars(myGameScr.gMage);
        }
        
        public void MageAttack(int AtkType = 1)
        {

            int bdamage = 0;

            // attack types//
            // 1 = p attack
            // 2 = m attack
            // 3 = ??
            // attack
            // defend
            // spellbook
            // item uses a turn?
            // quick actions
            if (myGameScr.gMage.isStunned())
            {
                //skip attack and clear status 
                myGameScr.gMage.RemoveEffect("SS");
                string s = Environment.NewLine + "That smarts! you're stunned!";
                myGameScr.bFight.AddChatter(s);
                MonsterAttack();
            }
            else
            {
                switch (AtkType)
                {

                    case 1: // regular attack
                        bdamage = MagePAttack();
                        break;
                    case 2:
                        bdamage = MageMAttack();
                        break;
                    case 3:
                        MageDefend = 1;
                        bdamage = 0;
                        break;
                    default:
                        bdamage = myGameScr.gMage.PAtk() - myGameScr.gMonster.PDef;
                        HitMonster(bdamage);
                        myGameScr.bFight.UpdateBars(myGameScr.gMonster);
                        break;
                }
            }

            if (myGameScr.gMonster.HP <= 0)
            {
                EndCombat();
            }
            else if (bdamage > 0)
            {
                //need some "mage chatter" stuff. Maybe use another monster?
                string s = "You gooshed it good for " + bdamage.ToString() + " damage!";
                myGameScr.bFight.AddChatter(s);
                // monster turn
                MonsterAttack();
            }
            else { MonsterAttack(); }
        }

        private int MagePAttack()
        {
            int damage = myGameScr.gMage.PAtk() - myGameScr.gMonster.PDef;
            HitMonster(damage);
            myGameScr.bFight.UpdateBars(myGameScr.gMonster);
            return damage;
        }

        private int MageMAttack()
        {
            int damage = myGameScr.gMage.MAtk() - myGameScr.gMonster.MDef;
            HitMonster(damage);
            myGameScr.bFight.UpdateBars(myGameScr.gMonster);
            return damage;
        }

        //this is called from FightBoard when spell is clicked
        public void MageSpell(string spellname = "", int tier = 1)
        {
            try
            {
                clsSpell spell = new clsSpell();
                if (myGameScr.gSpellBook.Exists(x => x.spellName == spellname)) { spell = myGameScr.gSpellBook.Find(x => x.spellName == spellname); }
                if (spell.spellName != "")
                {
                    CastSpell(spell, tier);
                }
            }
            catch
            {
                string s = "didn't quite catch that spell, friendo";
                MessageBox.Show(s);
            }
        }

        private void CastSpell(clsSpell aSpell, int aTier = 1)
        {

        }

        //private void MageAbility { }

        //private void MageItem { }

        //private void MageSpell { }

        //private void MageDefend { }

        /// <summary>
        /// Monster Attack logic starts here
        /// </summary>
        /// <param name="MonsterAttacks"></param>

        public void MonsterAttack(int AtkType = 1)
        {
            int bdamage = 0;

            //potential moves:
            // attack
            // defend
            // ability (if available? all monsters have at least one?)
            // ideas: monster healing, adding DoT attacks? enrage

            //check for stun status and block an attack
            //stun stuff

            //tick poison on turn start
            TickPoison(2);

            //placeholder - utilizing m and p attack
            /*int i = myGameScr.gRandom.Next(7);
            if (i == 6) { AtkType = 8; }
            else if (i == 5 ) { AtkType = 5; }
            else if (i == 0 || i == 2|| i == 4 ) { AtkType = 1; }
            else { AtkType = 2; }
            */
            //AtkType = 5;
            switch (AtkType)
            {
                case 1: //patk
                    bdamage = MonsterPAttack();
                    break;
                case 2: //matk
                    bdamage = MonsterMAttack();
                    break;
                case 3: // miss
                    break;
                case 4: // defend
                    // bdamage = half damage? block attack completely?
                    break;
                case 5: //mold
                    bdamage = MonsterEffAttack("MP");
                    break;
                case 6: //zest
                    break;
                case 7: // tension
                    break;
                case 8: // stun
                    myGameScr.gMage.AddEffect("SS", 1, 1);
                    break;
                case 9:
                    break;

            }

            HitMage(bdamage);
            if (myGameScr.gMage.HP > 0)
            {
                myGameScr.bFight.AddMonsterChatter(AtkType, bdamage);
                MageTurn();
            }
        }

        private int MonsterPAttack()
        {
            int damage = myGameScr.gMonster.PAtk - myGameScr.gMage.Def();
            if (damage < 0 ) { damage = 0; }
            return damage;
        }

        private int MonsterMAttack()
        {
            int damage = myGameScr.gMonster.MAtk - myGameScr.gMage.Res();
            if (damage < 0) { damage = 0; }
            return damage;
        }

        private int MonsterEffAttack(string effType)
        {
            double baseDamage = (myGameScr.gMonster.MAtk - myGameScr.gMage.Res()) / 3;
            if (baseDamage < 0) { baseDamage = 0; }
            int damage = (int)Math.Floor(baseDamage);

            //int iStack = 3;
            int iStack = myGameScr.gRandom.Next(4, 8);
            myGameScr.gMage.AddEffect(effType, iStack, 3);

            string s = "";
            switch (effType)
            {
                case "MP":
                    s = "mold";
                    break;
                case "ZC":
                    s = "zest";
                    break;
                case "TS":
                    s = "tension";
                    break;
                default:
                    s = "something goofed up";
                    break;
            }
            //again, effect chatter
            s = "Ugh! That's " + iStack.ToString() + " " + s + " for you!";
            myGameScr.bFight.AddChatter(s);
            return damage;
        }


        /// <summary>
        /// Misc logic starts here
        /// </summary>
        /// <param name="PostCombat"></param>


        private void TickBuffs()
        {

        }

        private void HitMage(int someDamage)
        {
            if (MageDefend == 1) { someDamage = someDamage / 2; MageDefend = 0; }
            someDamage = (int)Math.Floor((double)someDamage);
            myGameScr.gMage.HP -= someDamage;
            if (myGameScr.gMage.HP <= 0) { myGameScr.gMage.HP = 0; myGameScr.GameOver(); }
        }

        private void HitMonster(int someDamage)
        {
            myGameScr.gMonster.HP -= someDamage;
            myGameScr.bFight.UpdateBars(myGameScr.gMonster);
        }

        private void TickPoison(int i = 0)
        {
            //these chatter additions are going to use a different chatter type
            int pdamage = 0;

            if (i == 1)
            {
                pdamage = myGameScr.gMage.TickMagePoison();
                HitMage(pdamage);
                myGameScr.bMage.UpdateBars(myGameScr.gMage);
                if (pdamage > 0 && myGameScr.gMage.HP > 0)
                {
                    string s = "You quiver with " + pdamage.ToString() + " mold damage";
                    myGameScr.bFight.AddChatter(s);
                }
            }
            else if (i == 2)
            {
                pdamage = myGameScr.gMonster.TickMonPoison();
                myGameScr.bFight.UpdateBars(myGameScr.gMonster);
                if (pdamage > 0)
                {
                    string s = "The " + myGameScr.gMonster.MonName + " shakes with " + pdamage.ToString() + " mold damage";
                    myGameScr.bFight.AddChatter(s);
                }
            }
        }

        private void QuickAttack()
        {
            if (myGameScr.gMage.hasQuickAttack())
            {
               //do this thing
                int pdamage1 = MagePAttack();
                int pdamage2 = MageMAttack();
                int fdamage = 0;
                if (pdamage1 >= pdamage2) { fdamage = pdamage1; }
                else { fdamage = pdamage2; }

                string s = "Your lightning speed allows you to get a free hit in! Bif!";
                myGameScr.bFight.AddChatter(s);

                HitMonster(fdamage);
            }
        }

        private void ResolveTurn()
        {
            foreach ( clsMageEffect e in myGameScr.gMage.myStatEffects)
            {

            } 
        }



        private void EndCombat()
        {
            MessageBox.Show("It's croutons!");
            string s = "Nice work, you got " + myGameScr.gMonster.EXP.ToString() + " EXP!";
            myGameScr.gLog.Add(s);

            myGameScr.gMage.TickBuffs();

            

            //give post battle info, item drops before disposing. new pop up window?
            myGameScr.gLock = false;
            myGameScr.bFight.Hide();
            myGameScr.bFight.Dispose();


        }
    }
}
