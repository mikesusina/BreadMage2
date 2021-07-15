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
        //
        //
        // pull controls and monster/PC
        // interact
        // dispose of this where it's called when combat ends

        private BreadMage bMage { get; set; }
        //private FightBoard bFight { get; set; }
        private clsMage myMage { get; set; }
        private clsMonster myMonster { get; set; }
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
        }

        /// <summary>
        /// Mage Attack logic starts here
        /// </summary>
        /// <param name="MageAttacks"></param>


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
                    bdamage = myMage.PAtk() - myMonster.PDef;
                    myMonster.HP = myMonster.HP - bdamage;
                    myGameScr.bFight.UpdateBars(myMonster.HP);
                    break;
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
            myGameScr.gMonster.HP -= damage;
            myGameScr.bFight.UpdateBars(myGameScr.gMonster.HP);
            return damage;
        }

        //private void MageAbility { }

        //private void MageItem { }

        //private void MageSpell { }

        //private void MageDefend { }





        /// <summary>
        /// Monster Attack logic starts here
        /// </summary>
        /// <param name="MonsterAttacks"></param>

        private void MonsterAttack(int AtkType = 1)
        {

            int bdamage = 0;

            //potential moves:
            // attack
            // defend
            // ability (if available? all monsters have at least one?)
            // ideas: monster healing, adding DoT attacks? enrage



            //placeholder - utilizing m and p attack
            int i = myGameScr.gRandom.Next(2);
            if (i == 0) { AtkType = 1; }
            else { AtkType = 2; }

            switch (AtkType)
            {
                case 1: //patk
                    bdamage = MonsterPAttack();
                    break;
                case 2: //matk
                    bdamage = MonsterMAttack();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }


            if (myGameScr.gMage.HP <= 0)
            { myGameScr.GameOver(); }
            else if (bdamage <= 0)
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
                }
                s += " shrugs off their attack.";
                myGameScr.bFight.AddChatter(s);
            }
            else
            {
                //ability to manipulate all mage bars at once - HP, MP, SP - update to new value
                myGameScr.bMage.UpdateBars(myGameScr.gMage.HP, 0, 0);
                string s = "";
                if (AtkType == 1) { s = "it rustled your jimmies for " + bdamage.ToString() + " damage!"; }
                else { s = "it magically singes you for " + bdamage.ToString() + " damage!"; }
                myGameScr.bFight.AddChatter(s);
            }

        }

        private int MonsterPAttack()
        {
            int damage = myGameScr.gMonster.PAtk - myGameScr.gMage.Def();
            if (damage > 0 )
            {
                myGameScr.gMage.HP = myGameScr.gMage.HP - damage;
            }
            else { damage = 0; }
            return damage;
        }

        private int MonsterMAttack()
        {
            int damage = myGameScr.gMonster.MAtk - myGameScr.gMage.Res();
            if (damage > 0)
            {
                myGameScr.gMage.HP = myGameScr.gMage.HP - damage;
            }
            else { damage = 0; }
            return damage;
        }


        /// <summary>
        /// Post Combat logic starts here
        /// </summary>
        /// <param name="PostCombat"></param>

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
