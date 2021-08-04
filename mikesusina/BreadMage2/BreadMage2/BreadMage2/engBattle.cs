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
        //a class to handle the combat logic
        
        private GameScreen myGameScr;

        public engBattle(GameScreen aGameScr)
        {

            myGameScr = aGameScr;

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
            TickPoison(myGameScr.gMage);
            QuickAttack(myGameScr.gMage);

            //update the bars one final time
            myGameScr.bMage.UpdateBars(myGameScr.gMage);
        }
        
        public void MageAttack(int AtkType = 1)
        {

            int bdamage = 0;

            // attack types//
            // 1 = regular attack
            // 2 = ??
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
            }
            else
            {
                switch (AtkType)
                {

                    case 1: // regular attack
                        bdamage = MageWeaponAttack();
                        break;
                    case 2:
                        //bdamage = MageSpellAttack(probably int for spellID)
                        break;
                    case 3:
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
            else
            {
                string s = "You gooshed it good for " + bdamage.ToString() + " damage!";
                myGameScr.bFight.AddChatter(s);
                // monster turn
                MonsterAttack(1);
            }
        }

        private int MageWeaponAttack()
        {
            int damage = myGameScr.gMage.PAtk() - myGameScr.gMonster.PDef;
            HitMonster(damage);
            myGameScr.bFight.UpdateBars(myGameScr.gMonster);
            return damage;
        }

        //private void MageAbility { }

        //private void MageItem { }

        //private void MageSpell { }

        //private void MageDefend { }



        private void HitMage(int someDamage)
        {
            myGameScr.gMage.HP -= someDamage;
            if (myGameScr.gMage.HP <= 0) { myGameScr.GameOver(); }
        }

        private void HitMonster(int someDamage)
        {
            myGameScr.gMonster.HP -= someDamage;
        }


        /// <summary>
        /// Monster Attack logic starts here
        /// </summary>
        /// <param name="MonsterAttacks"></param>

        private void MonsterAttack(int AtkType = 1)
        {

            int bdamage = 0;
            int chatType = 0;

            //potential moves:
            // attack
            // defend
            // ability (if available? all monsters have at least one?)
            // ideas: monster healing, adding DoT attacks? enrage

            //tick poison on turn start
            TickPoison(myGameScr.gMonster);

            //placeholder - utilizing m and p attack
            int i = myGameScr.gRandom.Next(6);
            if (i == 5 ) { AtkType = 3; }
            else if (i == 0 || i == 2|| i == 4 ) { AtkType = 1; }
            else { AtkType = 2; }

            switch (AtkType)
            {
                case 1: //patk
                    bdamage = MonsterPAttack();
                    chatType = 1;
                    break;
                case 2: //matk
                    bdamage = MonsterMAttack();
                    chatType = 2;
                    break;
                case 3: // poison
                    bdamage = MonsterEffAttack("MP");
                    chatType = 5;
                    break;
                case 4: // pinata
                    break;
                case 5:
                    break;
            }

            HitMage(bdamage);
            myGameScr.bFight.AddMonsterChatter(chatType, bdamage);

            /* placeholder chatter - 
            if (bdamage <= 0)
            {
                string s = "Your incredible ";
                switch (AtkType)
                {
                    case 1: //patk
                        s += "might";
                        break;
                    case 2: //matk
                        s += "resistence";
                        break;
                    case 3: //mold. This needs to be reworked
                        s += "mold immunity??";
                        break;
                }
                s += " shrugs off their attack.";
                myGameScr.bFight.AddChatter(s);
            }
            else
            {
                //ability to manipulate all mage bars at once - HP, MP, SP - update to new value
                string s = "";
                if (AtkType == 1) { s = myGameScr.bFight.AddMonsterChatter(1); } //s = "it rustled your jimmies for " + bdamage.ToString() + " damage!"; }
                else if (AtkType == 2) { s = "it magically singes you for " + bdamage.ToString() + " damage!"; }
                else { s = "The mold! It burns! For " + bdamage.ToString() + " damage!"; }
                myGameScr.bFight.AddChatter(s);
            }

            */

            MageTurn();
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
                case "PP":
                    s = "pinata";
                    break;
                default:
                    s = "something goofed up";
                    break;
            }
            s = "Ugh! That's " + iStack.ToString() + " " + s + " for you!";
            myGameScr.bFight.AddChatter(s);
            return damage;
        }


        /// <summary>
        /// Misc logic starts here
        /// </summary>
        /// <param name="PostCombat"></param>


        private void TickPoison(object o)
        {
            int pdamage = 0;
            if (o is clsMage)
            {
                pdamage = myGameScr.gMage.TickMagePoison();
                HitMage(pdamage);
                myGameScr.bMage.UpdateBars(myGameScr.gMage);
                if (pdamage > 0)
                {
                    string s = "You quiver with " + pdamage.ToString() + " mold damage";
                    myGameScr.bFight.AddChatter(s);
                }
            }
            else if (o is clsMonster)
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

        private void QuickAttack(clsMage aMage)
        {
            //do this thing
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
