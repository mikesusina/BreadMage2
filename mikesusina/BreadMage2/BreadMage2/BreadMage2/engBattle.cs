using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BreadMage2
{
    public class engBattle
    {
        private engGame myGame;
        private int MageDefend = 0;
        private int spellTier;
        private int bStackInfo;
        private int battleSP = 0;
        private int iMonModifier = 1; // the mob "personality"
        private string sTurn;
        private string monsterStatus = "normal";
        public bool newTurn = false;
        public bool theJump = true;

        public string battleResult = "none";

        private clsMonster currentMonster => myGame.gMonster;
        private clsSpell spellSlinger;
        private DamageInfoChatter currentDamageInfo;

        public engBattle(engGame aGame)
        {
            myGame = aGame;
            myGame.bMage.UpdateBars();
            spellSlinger = new clsSpell();
            spellSlinger = null;
            currentDamageInfo = new DamageInfoChatter();
            spellTier = 0;
            battleSP = myGame.gMage.Stats.CurrentMaxSP;
        }

        public bool BothAlive()
        {
            if (myGame.gMonster.HP <= 0)
            {
                battleResult = "win";
                return false;
            }
            if (myGame.gMage.Stats.HP <= 0)
            {
                battleResult = "lose";
                return false;
            }
            return true;
        }

        public void LoadFight()
        {
            //generate the monster personality (int)
            //common:               rare:
            //1: patk lean          6: berzerker (phys or mag boosts + lean)
            //2  matk lean          7: stout (+ hp)
            //3  ability lean       8: lucky (flat % to dodge and separately bonus damage)
            //4  defender                   

            //low roll:
            //5  over it                   

            List<int> lTypes = new List<int>();

            //14-19: rare type
            if (myGame.gRandom.Next(21) > 14) { lTypes.AddRange(new List<int>() { 6, 7, 8 }); }
            //2-13: common type
            else if (myGame.gRandom.Next(21) > 2) { lTypes.AddRange(new List<int>() { 1, 2, 3, 4 }); }
            //0-1: over it
            else { lTypes.Add(5); }

            //iMonModifier = lTypes.ElementAt(myGame.gRandom.Next(lTypes.Count - 1));
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
                myGame.bFight.UpdateBars(currentMonster);
            }




            // do better than a flip for initative, but for now...
            int i = int.Parse(DateTime.Now.ToString("MM/DD/yy h:mm:ss").Substring(DateTime.Now.ToString("MM/DD/yy h:mm:ss").Length - 1, 1));
            bool bEven = (i != 0 && i != 2 && i != 4 && i != 6 && i != 8);


            if (bEven)
            {
                theJump = false;
                myGame.ChatEngine.AddIntroChatter(2);
                MonsterAttack();
            }
            else 
            { 
                theJump = true;
                myGame.ChatEngine.AddIntroChatter(1);
                TickPoison("mage");
                Console.WriteLine(myGame.ChatEngine.infoQueue.Count);
            }
            if (myGame.ChatEngine.infoQueue.Count > 0)
            {
                myGame.ChatEngine.PostChatterQueue();
                myGame.ChatEngine.ClearQueue();
            }

        }

        private void ChangeTurn()
        {

            //old, current
            //myGame.ChatEngine.AddTurnChatter();
            //currentDamageInfo.ClearDamageInfo();

            newTurn = true;
            
            TickPoison(sTurn);
            
            if (sTurn == "Mage")
            {
                
                //tick mold (+message queue)
                if (myGame.gMage.isStunned())
                {
                    //tick stun effect 
                    //queue message
                    //ChangeTurn();
                    //end mage turn?

                }
                //is charging?
                else
                {
                    WaitForMageInput();
                }

            }
            else if (sTurn == "Monster")
            {

                if (currentMonster.StunCount > 0)
                {
                    //add new "stun" react clsChatter item, 0damage/tick  myGame.ChatEngine.nextEffectReactChatter("stun");
                    currentMonster.AdjustEffect(8, -1);
                    return;
                }
                else
                {
                    MonsterAttack();
                }
            }
        }



        public string GetTurn()
        {
            return sTurn;
        }

        public DamageInfoChatter GetDamageInfo()
        {
            return currentDamageInfo;
        }
        public int GetBattleSP() { return battleSP; }

        public void setSpellSlinger(clsSpell aSpell) { spellSlinger = aSpell; }

        /// <summary>
        /// Mage logic starts here
        /// </summary>
        /// <param name="MageAttacks"></param>

        public void WaitForMageInput()
        {
            myGame.ChatEngine.PostChatterQueue();
            myGame.ChatEngine.ClearQueue();
            //update the bars one final time
            myGame.bMage.UpdateBars();
        }
        
        public void MageAttack(int AtkType = 1)
        {
            try
            {
                DamageInfoChatter queueItem = new DamageInfoChatter();
                currentDamageInfo.ClearDamageInfo();
                string chatType = "physical";

                // attack types//
                // 1 = p attack
                // 2 = m attack
                // 3 = spell
                // attack
                // defend
                // spellbook
                // item uses a turn?
                // quick actions
                switch (AtkType)
                {

                    case 1: // regular attack
                        queueItem = MagePAttack();
                        break;
                    case 2:
                        queueItem = MageMAttack();
                        break;
                    case 3:
                        if ((myGame.bFight.Controls["boxSpells"] as ListBox).SelectedItem != null)
                        {
                            spellSlinger = (myGame.bFight.Controls["boxSpells"] as ListBox).SelectedItem as clsSpell;
                            if (spellSlinger != null) { 
                            }


                        }//check that components/SP cost are okay before casting!
                        //todo : validate SP cost!
                        queueItem = CastMageSpell(spellSlinger, 1); // Convert.ToInt32(t.SelectedItem.ToString()));
                        //queueItem.UpdateDamageInfo(currentDamageInfo.iDamage, currentDamageInfo.iTick, currentDamageInfo.chatType);
                        break;
                    default:
                        currentDamageInfo = MagePAttack();
                        break;
                }

                if (currentMonster.HP <= 0)
                {
                    EndCombat();
                }
                else if (queueItem.iDamage > 0 || queueItem.iTick > 0)
                {
                    if (spellSlinger != null && spellSlinger.spellName != "")
                    {
                        
                        myGame.ChatEngine.nextSpellChatter(spellSlinger);
                        myGame.ChatEngine.AddChatter(queueItem);

                        queueItem.ChatText = myGame.ChatEngine.GetNextSpellChatter(spellSlinger);
                        myGame.ChatEngine.AddChatItemToQueue(queueItem, "mage");
                    }
                    else
                    {
                        myGame.ChatEngine.nextMageChatter(chatType);
                        myGame.ChatEngine.AddChatter(currentDamageInfo);

                        queueItem.ChatText = myGame.ChatEngine.GetNextMageChatter(queueItem.chatType);
                        myGame.ChatEngine.AddChatItemToQueue(queueItem, "mage");
                    }
                }
                spellSlinger = null;
                sTurn = "Monster";
                ChangeTurn();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show("Hey something didn't happen right with this..." + Environment.NewLine + Environment.NewLine + ex.InnerException.Message.ToString());
            }
        }

        private int MagePAtkInt() { return myGame.gMage.BuffedStat("PAK") - currentMonster.PDef; }
        private DamageInfoChatter MagePAttack()
        {
            currentDamageInfo.ClearDamageInfo();
            currentDamageInfo.UpdateDamageInfo(myGame.gMage.BuffedStat("PAK") - currentMonster.PDef, 0, "physical");
            HitMonster(currentDamageInfo.iDamage);
            return currentDamageInfo;
        }

        private int MageMAtkInt() { return myGame.gMage.BuffedStat("MAK") - currentMonster.MDef; }
        private DamageInfoChatter MageMAttack()
        {
            currentDamageInfo.ClearDamageInfo();
            currentDamageInfo.UpdateDamageInfo(myGame.gMage.BuffedStat("MAK") - currentMonster.MDef, 0, "magic");
            HitMonster(currentDamageInfo.iDamage);
            return currentDamageInfo;
        }

        private DamageInfoChatter CastMageSpell(clsSpell aSpell, int aTier = 1)
        {
            int FinalSP = aSpell.Power + (aTier - 1);

            //for casting spells and costs:
            //tiers bump up spell power by 1/2
            DamageInfoChatter spellDamageInfo = new DamageInfoChatter();
                spellDamageInfo.ClearDamageInfo();
            spellDamageInfo.chatType = "magic";
            int iSpellPowerTick = 0;
            double ValMod = 0;
            switch (FinalSP)
            {
                case 1:
                    iSpellPowerTick = 1;
                    ValMod = .5;
                    break;
                case 2:
                    iSpellPowerTick = 1;
                    ValMod = .7;
                    break;
                case 3:
                    iSpellPowerTick = 2;
                    ValMod = .9;
                    break;
                case 4:
                    iSpellPowerTick = 2;
                    ValMod = 1.2;
                    break;
                case 5:
                    iSpellPowerTick = 3;
                    ValMod = 1.75;
                    break;
            }

            foreach (KeyValuePair<string, string> inflictItem in aSpell.SpellEffects.FindAll(x => x.Key == "inflict"))
            {

                clsEffect toAdd = new clsEffect();
                switch (inflictItem.Value)
                {
                    case "physical":
                        spellDamageInfo.iDamage += MagePAtkInt();
                        if (spellDamageInfo.chatType == "N") { spellDamageInfo.chatType = "physical"; }

                        break;
                    case "magic":
                        spellDamageInfo.iDamage += MageMAtkInt();
                        if (spellDamageInfo.chatType == "N") { spellDamageInfo.chatType = "magic"; }
                        break;
                    case "mold":
                    case "zest":
                    case "tension":
                        toAdd = myGame.GameLibraries.EffectLib().Find(x => x.sEffectName.ToLower() == inflictItem.Value).ShallowCopy();
                        toAdd.Tick = myGame.gMage.TickMod(inflictItem.Value);
                        myGame.gMonster.AddEffect(toAdd);
                        spellDamageInfo.chatType = inflictItem.Value;
                        spellDamageInfo.iTick = toAdd.Tick;
                        break;
                    
                    case "stun":
                        toAdd = myGame.GameLibraries.EffectLib().Find(x => x.sEffectName.ToLower() == inflictItem.Value).ShallowCopy();
                        toAdd.Tick = 2;
                        myGame.gMonster.AddEffect(toAdd);
                        spellDamageInfo.chatType = inflictItem.Value;
                        break;

                    default:
                        if (int.TryParse(inflictItem.Value, out int outnum) == true)  //inflict the effect ID on the enemy - debuffs basically
                        {
                            toAdd = myGame.GameLibraries.EffectLib().Find(x => x.iID == outnum).ShallowCopy();
                            toAdd.Tick = 1;
                            myGame.gMonster.AddEffect(toAdd);
                        }
                        break;

                }
            }
            if (spellDamageInfo.iDamage != 0 || spellDamageInfo.iTick != 0)
            {
                HitMonster(spellDamageInfo.iDamage);
            }
            return spellDamageInfo;

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
                    case "B": //block/dodge
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
            ChangeTurn();
        }


        public void MonsterAttack(string AtkType = "none")
        {
            bool bDodge = false;
            bool bParry = false;
            clsChatterText queueItem = new clsChatterText();
            List<clsChatterText> followupQueue = new List<clsChatterText>();

            //bDamage = 0;
            //bStackInfo = 0;

            //potential moves:
            // attack
            // defend
            // ability (if available? all monsters have at least one?)
            // ideas: monster healing, adding DoT attacks? enrage

            List<string> AttackList = currentMonster.PullAttackList();
            //iMonModifier to be aware of:
            //common:               rare:
            //1: patk lean          
            //2  matk lean          
            //3  ability lean       8: lucky (flat % to dodge and separately bonus damage)
            //4  defender   
            switch (iMonModifier)
            {
                case 1:
                    AttackList.Add("physical");
                    break;
                case 2:
                    AttackList.Add("magic");
                    break;
                case 3:
                    AttackList.Add("ability");
                    break;
                case 4:
                    AttackList.Add("defend");
                    break;
            }


            //chat types are saved by the AtkType value - so 
            AtkType = AttackList[myGame.gRandom.Next(AttackList.Count - 1)];
            switch (AtkType)
            {
                case "physical": //patk
                    queueItem = MonsterPAttack();
                    break;
                case "magic": //matk
                    queueItem = MonsterMAttack();
                    break;
                case "miss": // miss
                    queueItem = new DamageInfoChatter(0, 0);
                    queueItem.chatType = AtkType;
                    break;
                case "defend": // defend
                    queueItem = new DamageInfoChatter(0, 0);
                    queueItem.chatType = AtkType;
                    // bdamage = half damage? block attack completely?
                    break;
                case "block": //mold
                    queueItem = new DamageInfoChatter(0, 0);
                    queueItem.chatType = AtkType;
                    //currentDamageInfo = MonsterEffAttack("M");
                    break;
                case "ability": //zest
                    queueItem = MonsterAbility();
                    break;
                case "restore": // restore heal
                    break;



            }

            //effect method? dodge chance(), parry chance()
            //if (effect helper check for zest effect parry/block)
            // passive effect check for dodge help
            if (myGame.gMage.hasEffect(10))
            {
                myGame.gMage.ProcEffect(10);
                if (myGame.gRandom.Next(3) == 2)
                {
                    bDodge = true;
                    clsChatterText newFollowup = new clsChatterText();
                    newFollowup.UpdateDamageInfo(0, 0, "dodge");
                    newFollowup.ChatText = myGame.ChatEngine.GetNextEffectReactChatter("dodge");
                    followupQueue.Add(newFollowup);
                    queueItem.UpdateDamageInfo(0, 0, queueItem.chatType);
                }
            }
            if (myGame.gMonster.ZestCount() > 0)
            {
                int Roll = (3 * myGame.gMonster.ZestCount());
                if (myGame.gRandom.Next(100) < Roll)
                {
                    bParry = true;
                    clsChatterText newFollowup = new clsChatterText();
                    newFollowup.UpdateDamageInfo((int)Math.Floor(queueItem.iDamage * .7), 0, "parry");
                    newFollowup.ChatText = myGame.ChatEngine.GetNextEffectReactChatter("parry");
                    followupQueue.Add(newFollowup);
                    queueItem.iDamage = (int)Math.Floor(queueItem.iDamage * .1);
                }
            }
            if (myGame.gMage.TensionCount() > 0 && false == true && queueItem.iDamage > 0)
            {
                //magic to figure out if it pops, and if so...
                clsChatterText newFollowup = new clsChatterText();
                // queueItem.UpdateDamageInfo((original damage + new tnesion pop damage), myGame.gMage.TensionCount() * -1, "tension");
                newFollowup.UpdateDamageInfo((int)Math.Floor(myGame.gMage.TensionCount() * 1.5), myGame.gMage.TensionCount(), "tension");
                newFollowup.ChatText = myGame.ChatEngine.GetNextEffectReactChatter("parry");
                followupQueue.Add((newFollowup));
                // newItem.ChatText = myGame.ChatEngine.GetNextEffectReactChatter("tension");
                //
                // tension = 0
            }


            if (currentMonster.HP <= 0) { EndCombat(); }
            else { HitMage(queueItem.iDamage); }

            if (myGame.gMage.Stats.HP > 0)
            {

                //myGame.ChatEngine.nextMonsterChatter(currentDamageInfo.chatType);
                //myGame.ChatEngine.AddChatter(currentDamageInfo);
                queueItem.ChatText = myGame.ChatEngine.GetNextMonsterChatter(queueItem.chatType);
                myGame.ChatEngine.AddChatItemToQueue(queueItem, "monster");
                if (followupQueue.Count > 0)
                {
                    foreach (clsChatterText c in followupQueue)
                        { myGame.ChatEngine.AddChatItemToQueue(c, "mage"); }
                }
            }
            sTurn = "Mage";
            ChangeTurn();
        }

        private DamageInfoChatter MonsterPAttack()
        {
            DamageInfoChatter r = new DamageInfoChatter();
            int damage = currentMonster.PAtk - myGame.gMage.BuffedStat("DEF");
            if (damage < 0 ) { damage = 0; }
            r.UpdateDamageInfo(damage, 0, "physical");
            return r;
        }

        private DamageInfoChatter MonsterMAttack()
        {
            DamageInfoChatter r = new DamageInfoChatter();
            int damage = currentMonster.MAtk - myGame.gMage.BuffedStat("RES");
            if (damage < 0) { damage = 0; }
            r.UpdateDamageInfo(damage, 0, "magic");
            return r;
        }

        private DamageInfoChatter MonsterAbility()
        {
            DamageInfoChatter r = new DamageInfoChatter();
            string effCode = currentMonster.EffTypeList[myGame.gRandom.Next((currentMonster.EffTypeList.Count - 1))];
            int bStackInfo = 1;


            double baseDamage = (currentMonster.MAtk - myGame.gMage.BuffedStat("MAK")) / 3;
            if (baseDamage < 0) { baseDamage = 0; }
            int damage = (int)Math.Floor(baseDamage);

            //int iStack = 3;
            clsEffect toAdd = myGame.GameLibraries.EffectLib().Find(x => x.sType == effCode).ShallowCopy();
            
            if (toAdd.sType == "M" || toAdd.sCat == "Z" || toAdd.sCat == "T") 
            {
                bStackInfo = myGame.gRandom.Next(4, 8); 
                myGame.gMage.AddEffect(toAdd, bStackInfo);
            }
            if (toAdd.sType == "H" || toAdd.sType == "U" || toAdd.sType == "B")
            {
                
            }
            r.UpdateDamageInfo(damage, bStackInfo, myGame.ChatEngine.getEffectNamefromCode(effCode));
            return r;
        }


        /// <summary>
        /// Misc logic starts here
        /// </summary>
        /// <param name="PostCombat"></param>


        private void TickBuffs()
        {

        }

        private void HitMage(int iDamage)
        {
            int finalDamage = iDamage;
            // number has to be final here, no more math
            if (iDamage != 0) 
            {
                myGame.gMage.AdjustHP(finalDamage*-1); 
            }
            if (myGame.gMage.Stats.HP <= 0)
            {
                myGame.gMage.Stats.HP = 0;
                myGame.GameOver();
            }
        }

        private void HitMonster(int iDamage)
        {
            currentMonster.HP -= iDamage;
            myGame.bFight.UpdateBars(currentMonster);
        }

        private void TickPoison(string Target = "")
        {
            clsChatterText newItem = new clsChatterText();
            //these chatter additions are going to use a different chatter type
            int bDamage = 0;
            var list = new List<KeyValuePair<string, int>>();

            if (Target.ToLower() == "mage")
            {
                list = TickMagePoison();
                bDamage = list.Find(x => x.Key == "damage").Value;
                int iTick = list.Find(x => x.Key == "tick").Value;

                if (bDamage > 0 || iTick > 0)
                {
                    newItem.UpdateDamageInfo(bDamage, iTick, "mold");
                    newItem.ChatText = myGame.ChatEngine.GetNextEffectReactChatter("mold");
                    myGame.ChatEngine.AddChatItemToQueue(newItem, "mage");

                    /*
                    currentDamageInfo.UpdateDamageInfo(bDamage, iTick, "magic");
                    myGame.ChatEngine.nextEffectReactChatter("mold");
                    myGame.ChatEngine.AddChatter(currentDamageInfo);
                    */
                }
                HitMage(newItem.iDamage);
                myGame.bMage.UpdateBars();
            }
            else if (Target.ToLower() == "monster")
            {
                list = currentMonster.TickMonsterPoison();
                bDamage = list.Find(x => x.Key == "damage").Value;
                int iTick = list.Find(x => x.Key == "tick").Value;
                //to remove:
                currentDamageInfo = currentMonster.TickPoison();

                if (bDamage > 0 || iTick > 0)
                {
                    newItem.UpdateDamageInfo(bDamage, iTick, "mold");
                    newItem.ChatText = myGame.ChatEngine.GetNextEffectReactChatter("mold");
                    myGame.ChatEngine.AddChatItemToQueue(newItem, "monster");


                    newItem.UpdateDamageInfo(bDamage, iTick, "magic");
                    //myGame.ChatEngine.nextEffectReactChatter("mold");
                    //myGame.ChatEngine.AddChatter(newItem);
                    HitMonster(newItem.iDamage);
                }
            }
        }

        public List<KeyValuePair<string, int>> TickMagePoison()
        {
            List<KeyValuePair<string, int>> tickInfo = new List<KeyValuePair<string, int>>();
            int damage = 0;
            int iTick = 1;


            clsEffect e = myGame.gMage.GetStatEffects().Find(x => x.iID == 1);
            if (e != null)
            {
                if (e.Tick > 2) { iTick = (int)(Math.Ceiling(Convert.ToDouble(e.Tick) / 2)); }
                damage = 3 * iTick; //resist?
                e.Tick -= iTick;

                if (e.Tick <= 0) { myGame.gMage.GetStatEffects().Remove(e); }

                tickInfo.Add(new KeyValuePair<string, int>("damage", damage));
                //the tick value returned should be negative, since from here on it's for chat info
                tickInfo.Add(new KeyValuePair<string, int>("tick", iTick * -1));
            }

            return tickInfo;
        }

            /*
        private void ResolveTurn()
        {
            List<clsMageEffect> effList = myGame.gMage.GetStatEffects();
            foreach ( clsMageEffect e in effList)
            {
                e.iTimer -= 1;
            }
            effList.RemoveAll(x => x.iTimer <= 0);
        }

            */


        private void EndCombat()
        {
            currentMonster.HP = 0;
            MessageBox.Show("It's croutons!");
            string s = "Nice work, you got " + currentMonster.EXP.ToString() + " EXP!";
            myGame.gLog.Add(s);

            myGame.gMage.TickBuffs();
            myGame.EventEffects("combatEnd");

            //give post battle info, item drops before disposing. new pop up window?
            myGame.gLock = false;
            myGame.bFight.Hide();
        }


        /// <summary>
        /// staring effect decoding things
        /// </summary>


        /// <summary>
        /// staring spell decoding things?
        /// </summary>



    }
}
