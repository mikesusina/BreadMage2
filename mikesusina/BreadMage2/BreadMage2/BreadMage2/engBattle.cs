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
        private int spellTier;
        private int bDamage;
        private int bStackInfo;
        private int iMonModifier = 1; // the mob "personality"
        private string sTurn;

        private clsMonster currentMonster;
        private clsSpell spellSlinger;
        private DamageInfoChatter currentDamageInfo;

        public engBattle(GameScreen aGameScr)
        {
            myGameScr = aGameScr;
            myGameScr.bMage.UpdateBars(myGameScr.gMage);
            currentMonster = aGameScr.gMonster;
            spellSlinger = new clsSpell();
            spellSlinger = null;
            currentDamageInfo = new DamageInfoChatter();
            spellTier = 0;
        }

        public void LoadFight()
        {
            // roll initiative - do better than a flip
            int i = int.Parse(DateTime.Now.ToString("MM/DD/yy h:mm:ss").Substring(DateTime.Now.ToString("MM/DD/yy h:mm:ss").Length - 1, 1));
            bool bEven = (i != 0 && i != 2 && i != 4 && i != 6 && i != 8);
            // lost initiative - monster attacks first

            //override to lose init
            //WHATEVER IS SET HERE ACTUALLY LOSES INIT
            //first turn flips on battle begin to add chat notification
            //bEven = false;

            if (bEven)
            {
                sTurn = "Monster";
            }
            else
            {
                sTurn = "Mage";
            }


            //generate the monster personality (int)
            //common:               rare:
            //1: patk lean          6: berzerker (phys or mag boosts + lean)
            //2  matk lean          7: stout (+ hp)
            //3  ability lean       8: lucky (flay % to dodge and separately bonus damage
            //4  defender                   

            //low roll:
            //5  over it                   

            List<int> lTypes = new List<int>();

            //14-19: rare type
            if (myGameScr.gRandom.Next(21) > 14) {lTypes.AddRange(new List<int>() { 6, 7, 8 }); }
            //2-13: common type
            else if (myGameScr.gRandom.Next(21) > 2) { lTypes.AddRange(new List<int>() { 1, 2, 3, 4 }); }
            //0-1: over it
            else { lTypes.Add(5); }

            //iMonModifier = lTypes.ElementAt(myGameScr.gRandom.Next(lTypes.Count - 1));
           //iMonModifier = 7;

            if (iMonModifier == 6)
            {
                if (currentMonster.PAtk > currentMonster.MAtk)
                {
                    currentMonster.ModStat(1, "C");
                    currentMonster.ModStat(3, "C");
                }
                else
                {
                    currentMonster.ModStat(2, "C");
                    currentMonster.ModStat(4, "C");
                }
                currentMonster.ModStat(6, "D");
            }
            else if (iMonModifier == 7)
            {
                currentMonster.ModStat(5, "D");
                myGameScr.bFight.UpdateBars(currentMonster);
            }
        }

        private void ChangeTurn()
        {
            if (sTurn == "Mage") { sTurn = "Monster"; }
            else { sTurn = "Mage"; }
            myGameScr.bFight.AddTurnChatter();
        }



        public string GetTurn()
        {
            return sTurn;
        }

        public DamageInfoChatter GetDamageInfo()
        {
            return currentDamageInfo;
        }
        public clsMonster GetMonster()
        {
            return currentMonster;
        }
        /// <summary>
        /// Mage logic starts here
        /// </summary>
        /// <param name="MageAttacks"></param>

        public void MageTurn()
        {
            ChangeTurn();
            //poison ticks "on start of turn" so just tick it now 
            //*** this is where you'd implement a poison save spell - add it ass a buff? consume ticks no timer?, cast grants > 1
            TickPoison(1);
            QuickAttack();

            //update the bars one final time
            myGameScr.bMage.UpdateBars(myGameScr.gMage);
        }
        
        public void MageAttack(int AtkType = 1)
        {
            try
            {
                currentDamageInfo.ClearInfo();

                // attack types//
                // 1 = p attack
                // 2 = m attack
                // 3 = spell
                // attack
                // defend
                // spellbook
                // item uses a turn?
                // quick actions
                if (myGameScr.gMage.isStunned())
                {
                    //skip attack and clear status 
                    myGameScr.gMage.RemoveEffect(8);
                    myGameScr.bFight.nextEffectChatter("S");
                    MonsterAttack();
                }
                else
                {
                    switch (AtkType)
                    {

                        case 1: // regular attack
                            currentDamageInfo = MagePAttack();
                            break;
                        case 2:
                            currentDamageInfo = MageMAttack();
                            break;
                        case 3:
                            ComboBox b = (ComboBox)myGameScr.bFight.Controls["lstSpellBook"];
                            ComboBox t = (ComboBox)myGameScr.bFight.Controls["lstSpellTier"];
                            spellSlinger = b.SelectedItem as clsSpell;
                            currentDamageInfo = CastSpell(spellSlinger, 1); // Convert.ToInt32(t.SelectedItem.ToString()));
                            break;
                        default:
                            currentDamageInfo = MagePAttack();
                            break;
                    }
                }

                if (currentMonster.HP <= 0)
                {
                    EndCombat();
                }
                else if (currentDamageInfo.iDamage > 0 || currentDamageInfo.iTick > 0)
                {
                    if (spellSlinger != null && spellSlinger.spellName != "")
                    {
                        myGameScr.bFight.AddSpellChatter(spellSlinger, bDamage);
                    }
                    else
                    { 
                        //need some "mage chatter" stuff. Maybe use another monster?
                        string s = "You gooshed it good!";
                        myGameScr.bFight.AddChatterString(s);
                        myGameScr.bFight.AddChatter(currentDamageInfo);
                    }
                
                    // monster turn
                    MonsterAttack();
                }
                //else if (currentDamageInfo.iDamage > 0) { /*miss stuff*/ }
                else { spellSlinger = null;  MonsterAttack(); }
            }

            catch (ApplicationException ex)
            {
                MessageBox.Show("Hey something didn't happen right with this..." + Environment.NewLine + Environment.NewLine + ex.InnerException.Message.ToString());
            }
        }

        private int MagePAtkInt() { return myGameScr.gMage.PAtk() - currentMonster.PDef; }
        private DamageInfoChatter MagePAttack()
        {
            currentDamageInfo.ClearInfo();
            currentDamageInfo.UpdateInfo(myGameScr.gMage.PAtk() - currentMonster.PDef, 0, "D");
            HitMonster(currentDamageInfo);
            return currentDamageInfo;
        }

        private int MageMAtkInt() { return myGameScr.gMage.MAtk() - currentMonster.MDef; }
        private DamageInfoChatter MageMAttack()
        {
            currentDamageInfo.ClearInfo();
            currentDamageInfo.UpdateInfo(myGameScr.gMage.MAtk() - currentMonster.MDef, 0, "G");
            HitMonster(currentDamageInfo);
            return currentDamageInfo;
        }

        private DamageInfoChatter CastSpell(clsSpell aSpell, int aTier = 1)
        {
            currentDamageInfo.ClearInfo();
            currentDamageInfo.effType = "G";
            foreach (string s in aSpell.SpellBlocks)
            {
                if (s == "AD")
                {
                    int damage = MageMAtkInt();
                    if (aSpell.Power == "D") { currentDamageInfo.iDamage = (int)Math.Ceiling(damage * .5); }
                    else if (aSpell.Power == "C") { currentDamageInfo.iDamage = (int)Math.Ceiling(damage * .7); }
                    else { currentDamageInfo.iDamage = (int)Math.Ceiling(damage * .9); }
                }
                else if (s == "AM")
                {
                    currentDamageInfo.iTick = (int)Math.Floor((double)(myGameScr.gMage.TickMod(1)));
                    currentMonster.MoldCount += currentDamageInfo.iTick;
                    currentDamageInfo.effType = "M";
                }
                else if (s == "AZ")
                {
                    currentDamageInfo.iTick = (int)Math.Floor((double)(myGameScr.gMage.TickMod(2)));
                    currentMonster.ZestCount += currentDamageInfo.iTick;
                    currentDamageInfo.effType = "Z";
                }
                else if (s == "AT")
                {
                    currentDamageInfo.iTick = (int)Math.Floor((double)(myGameScr.gMage.TickMod(3)));
                    currentMonster.TensionCount += currentDamageInfo.iTick;
                    currentDamageInfo.effType = "T";
                }

            }
            if (currentDamageInfo.iDamage != 0 || currentDamageInfo.iTick != 0)
            {
                HitMonster(currentDamageInfo);
            }
            return currentDamageInfo;

            /*
            iApply = 0;

            foreach (string s in aSpell.SpellBlocks)
            {
                switch (s.Substring(0, 1)) //first char
                {
                    case "A": //applying. How to "self apply" damage?
                        break;
                    case "R": //removing
                        break;
                    case "C": //consuming (removing defender's stack for effect - if you want to consume your own, use remove and additional effect
                        break;
                    case "V": //converting (stealing defender's stack at rate)
                        break;
                    case "S": //applying self-damage?
                        break;
                }
                switch (s.Substring(1)) //seocnd char
                {
                    case "D": //damage
                        break;
                    case "M": //mold
                        break;
                    case "Z": //zest
                        break;
                    case "T": //tension
                        break;
                    case "S": //stun
                        break;
                    case "Q": //quick attack
                        break;
                    case "B": //block
                        break;
                    case "L": //silence
                        break;
                }
                */
            //add spell results to pass lots of info back to main combat method? 

            /* blocks are going to reqire some work
            int damageFlag = 0; // 1 = enemy, 2 = self, 3 = both
            int effectType = 0; // 1 = mold, 2 = zest, 3 = tension
            bool 

            foreach (string s in aSpell.SpellBlocks)
            {
                if (s.Substring(1, 1) == "D") { damageFlag = true; }
            }

            */
            
        }

        //private void MageAbility { }

        //private void MageItem { }

        //private void MageSpell { }

        //private void MageDefend { }

        /// <summary>
        /// Monster Attack logic starts here
        /// </summary>
        /// <param name="MonsterAttacks"></param>


        public void MonsterTurn()
        {
            currentDamageInfo.ClearInfo();
            bDamage = 0;
            bStackInfo = 0;
            ChangeTurn();
        }


        public void MonsterAttack(int AtkType = 1)
        {
            currentDamageInfo.ClearInfo();
            //bDamage = 0;
            //bStackInfo = 0;
            ChangeTurn();

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
                    currentDamageInfo = MonsterPAttack();
                    break;
                case 2: //matk
                    currentDamageInfo = MonsterMAttack();
                    break;
                case 3: // miss
                    break;
                case 4: // defend
                    // bdamage = half damage? block attack completely?
                    break;
                case 5: //mold
                    currentDamageInfo = MonsterEffAttack("M");
                    break;
                case 6: //zest
                    break;
                case 7: // tension
                    break;
                case 8: // stun
                    myGameScr.gMage.AddEffect(8, 1, 1);
                    break;
                case 9: //charge
                    break;
                case 10: // restore heal
                    break;
            }

            HitMage(currentDamageInfo);

            if (myGameScr.gMage.HP > 0)
            {
                MonsterChatter b = myGameScr.bFight.nextMonsterChatter(AtkType);
                myGameScr.bFight.AddChatter(b);
                myGameScr.bFight.AddChatter(currentDamageInfo);
                MageTurn();
            }
        }

        private DamageInfoChatter MonsterPAttack()
        {
            currentDamageInfo.ClearInfo();
            int damage = currentMonster.PAtk - myGameScr.gMage.Def();
            if (damage < 0 ) { damage = 0; }
            currentDamageInfo.UpdateInfo(damage, 0, "P");
            return currentDamageInfo;
        }

        private DamageInfoChatter MonsterMAttack()
        {
            currentDamageInfo.ClearInfo();
            int damage = currentMonster.MAtk - myGameScr.gMage.Res();
            if (damage < 0) { damage = 0; }
            currentDamageInfo.UpdateInfo(damage, 0, "G");
            return currentDamageInfo;
        }

        private DamageInfoChatter MonsterEffAttack(string effType)
        {
            currentDamageInfo.ClearInfo();
            int iID = 0;
            switch (effType)
            {
                case "M":
                    iID = 1;
                    break;
                case "Z":
                    iID = 2;
                    break;
                case "T":
                    iID = 3;
                    break;
                case "S":
                    iID = 8;
                    break;
                case "B":
                    iID = 10;
                    break;
                case "L":
                    iID = 11;
                    break;
            }
            double baseDamage = (currentMonster.MAtk - myGameScr.gMage.Res()) / 3;
            if (baseDamage < 0) { baseDamage = 0; }
            int damage = (int)Math.Floor(baseDamage);

            //int iStack = 3;
            bStackInfo = myGameScr.gRandom.Next(4, 8);
            myGameScr.gMage.AddEffect(iID, bStackInfo, 3);
            currentDamageInfo.UpdateInfo(damage, bStackInfo, effType);

            return currentDamageInfo;
        }


        /// <summary>
        /// Misc logic starts here
        /// </summary>
        /// <param name="PostCombat"></param>


        private void TickBuffs()
        {

        }

        private void HitMage(DamageInfoChatter someInfo)
        {
            // number has to be final here, no more math
            if (someInfo.iDamage != 0) { myGameScr.gMage.HP -= someInfo.iDamage; }
            if (myGameScr.gMage.HP <= 0)
            {
                myGameScr.gMage.HP = 0;
                myGameScr.GameOver();
            }
        }

        private void HitMonster(DamageInfoChatter someInfo)
        {
            currentMonster.HP -= someInfo.iDamage;
            myGameScr.bFight.UpdateBars(currentMonster);
        }

        private void TickPoison(int i = 0)
        {
            //these chatter additions are going to use a different chatter type
            bDamage = 0;

            if (i == 1)
            {
                var list = new List<KeyValuePair<string, int>>();
                list = myGameScr.gMage.TickMagePoison();
                bDamage = list.Find(x => x.Key == "damage").Value;
                int iTick = list.Find(x => x.Key == "tick").Value;

                if (bDamage > 0 || iTick > 0)
                {
                    currentDamageInfo.UpdateInfo(bDamage, iTick, "M");
                    myGameScr.bFight.AddChatter(myGameScr.bFight.nextEffectChatter("M"));
                    myGameScr.bFight.AddChatter(currentDamageInfo);
                }
                HitMage(currentDamageInfo);
                myGameScr.bMage.UpdateBars(myGameScr.gMage);
            }
            else if (i == 2)
            {
                currentDamageInfo = currentMonster.TickPoison();
                HitMonster(currentDamageInfo);
                if (currentDamageInfo.iDamage > 0)
                {
                    myGameScr.bFight.AddChatter(myGameScr.bFight.nextEffectChatter("M"));
                    myGameScr.bFight.AddChatter(currentDamageInfo);
                }
            }
        }

        private void QuickAttack()
        {
            if (myGameScr.gMage.hasQuickAttack())
            {
                currentDamageInfo.ClearInfo();
                //do this thing
                int pdamage1 = myGameScr.gMage.PAtk() - currentMonster.PDef;
                int pdamage2 = myGameScr.gMage.MAtk() - currentMonster.MDef;
                if (pdamage1 >= pdamage2)
                {
                    currentDamageInfo.iDamage = pdamage1;
                    currentDamageInfo.effType = "D";
                }
                else
                {
                    currentDamageInfo.iDamage = pdamage2;
                    currentDamageInfo.effType = "G";
                }

                EffectChatter e = myGameScr.bFight.nextEffectChatter("Q");
                myGameScr.bFight.AddChatter(e);
                currentDamageInfo.effType = "Q";
                myGameScr.bFight.AddChatter(currentDamageInfo);

                HitMonster(currentDamageInfo);
            }
        }

        private void ResolveTurn()
        {
            /*
            List<clsMageEffect> effList = myGameScr.gMage.GetStatEffects();
            foreach ( clsMageEffect e in effList)
            {
                e.iTimer -= 1;
            }
            effList.RemoveAll(x => x.iTimer <= 0);
            */
        }



        private void EndCombat()
        {
            currentMonster.HP = 0;
            MessageBox.Show("It's croutons!");
            string s = "Nice work, you got " + currentMonster.EXP.ToString() + " EXP!";
            myGameScr.gLog.Add(s);

            myGameScr.gMage.TickBuffs();

            

            //give post battle info, item drops before disposing. new pop up window?
            myGameScr.gLock = false;
            myGameScr.bFight.Hide();
            myGameScr.bFight.Dispose();
        }


        /// <summary>
        /// staring effect decoding things
        /// </summary>


        /// <summary>
        /// staring spell decoding things?
        /// </summary>



    }
}
