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
        private Mage myMage { get; set; }
        private Monster myMonster { get; set; }
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

                case 1:
                    bdamage = MageWeaponAttack();
                    break;
                case 2:
                    //bdamage = MageSpellAttack(probably int for spellID)
                    break;
                case 3:
                    break;
                default:
                    bdamage = myMage.Atk - myMonster.PDef;
                    myMonster.HP = myMonster.HP - bdamage;
                    myGameScr.bFight.UpdateBars(myMonster.HP);
                    break;
            }

            if (myGameScr.gMonster.HP <= 0)
            {
                MessageBox.Show("It's croutons!");
                string s = "Nice work, you got " + myGameScr.gMonster.EXP.ToString() + " EXP!";
                myGameScr.gLog.Add(s);

                //give post battle info, item drops before disposing. new pop up window?
                myGameScr.bFight.Hide();
                myGameScr.bFight.Dispose();
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
            int damage = myGameScr.gMage.Atk - myGameScr.gMonster.PDef;
            myGameScr.gMonster.HP = myGameScr.gMonster.HP - damage;
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
            //potential moves:
            // attack
            // defend
            // ability (if available? all monsters have at least one?)
            // ideas: monster healing, adding DoT attacks? enrage

            //placeholder
            //notes - peep the build in ability to manipulate all mage bars at once - HP, MP, SP

            //

            /* using global object */
            int damage = myGameScr.gMonster.PAtk - myGameScr.gMage.Def;
            myGameScr.gMage.HP = myGameScr.gMage.HP - damage;

            if (myGameScr.gMage.HP <= 0)
            { myGameScr.GameOver(); }
            else
            {
                myGameScr.bMage.UpdateBars(myGameScr.gMage.HP, 0, 0);
                string s = "it rustled your jimmies for " + damage.ToString() + " damage!";
                myGameScr.bFight.AddChatter(s);
            }

        }

    }
}
