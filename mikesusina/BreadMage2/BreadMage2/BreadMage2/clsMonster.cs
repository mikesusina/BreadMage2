using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace BreadMage2
{
    public class clsMonster : IEquatable<clsMonster>
    {
        //Monster objec

        public int monID { get; set; } = 7;
        public string MonName { get; set; } = "Chatter Box";
        public int HP { get; set; } = 1;
        public int HPmax { get; set; } = 1;
        public int PAtk { get; set; } = 1;
        public int MAtk { get; set; } = 1;
        public int PDef { get; set; } = 1;
        public int MDef { get; set; } = 1;
        public int EXP { get; set; } = 0;
        public bool isCharging = false;
        public int MoldCount()
        {
            if (MonsterEffects.Find(x => x.iID == 1) != null) { return MonsterEffects.Find(x => x.iID == 1).Tick; }
            else return 0; ;
        }
        public int ZestCount() {
            if (MonsterEffects.Find(x => x.iID == 2) != null) { return MonsterEffects.Find(x => x.iID == 2).Tick; } 
            else return 0; ; }
        public int TensionCount()
        {
            if (MonsterEffects.Find(x => x.iID == 3) != null) { return MonsterEffects.Find(x => x.iID == 3).Tick; }
            else return 0; ;
        }
        //public int StunCount => MonsterEffects.Find(x => x.iID == 8).Tick;
        public int StunCount = 0;
        public string ImgURL { get; set; } = "BreadMage2";
        public string IntroChatter { get; set; } = "";
        public int Location { get; set; } = 1;

        public List<clsEffect> MonsterEffects = new List<clsEffect>();
        public List<MonsterChatter> ChatterList { get; set; } = new List<MonsterChatter>();
        public List<String> EffTypeList { get; set; }
        public  DataTable DropList { get; set; }

        public clsMonster() { }

        public clsMonster(DataRow dr, List<MonsterChatter> someChatter)
        {
            MonName = dr["MonName"].ToString();
            HPmax = cInt(dr["HP"].ToString());
            HP = HPmax;
            PAtk = cInt(dr["PATK"].ToString());
            MAtk = cInt(dr["MATK"].ToString());
            PDef = cInt(dr["PDEF"].ToString());
            MDef = cInt(dr["MDEF"].ToString());
            EXP = cInt(dr["EXP"].ToString());
            ImgURL = dr["ImgURL"].ToString();
            IntroChatter = dr["IntroChatter"].ToString();
            Location = cInt(dr["Location"].ToString());
            monID = cInt(dr["MonsterID"].ToString());
            MakeDropTable(dr["Drops"].ToString());
            EffTypeList = Program.ParseDelimitedStringToString(dr["EffType"].ToString(), "|");
            ChatterList = someChatter;

            RefreshMonster();
        }

        public clsMonster ShallowCopy()
        {
            return (clsMonster)this.MemberwiseClone();
        }

        public void AddEffect(clsEffect anEffect)
        {
            if (MonsterHasEffect(anEffect.iID, out clsEffect activeEffect))
            {

                activeEffect.Tick += anEffect.Tick;
                if (activeEffect.Tick <= 0)
                    { MonsterEffects.Remove(activeEffect); }
            }
            else { MonsterEffects.Add(anEffect.ShallowCopy()); }

        }
        public void AdjustEffect(int anID, int aTick)
        {
            if (MonsterHasEffect(anID, out clsEffect activeEffect))
            {
                activeEffect.Tick += aTick;
                if (activeEffect.Tick <= 0)
                { MonsterEffects.Remove(activeEffect); }
            }
        }

        private bool MonsterHasEffect(int iID, out clsEffect ActiveEffect)
        {
            ActiveEffect = null;
            if (MonsterEffects == null || MonsterEffects.Count == 0) { return false; }
            else if (MonsterEffects.Find(x => x.iID == iID) != null)
            {
                ActiveEffect = MonsterEffects.Find(x => x.iID == iID);
                return true;
            }
            return false;
        }

        public void RefreshMonster()
        {
            // if the monsters in the library get their stats goofed around
            HP = HPmax;
            MonsterEffects.Clear();
            isCharging = false;
        }

        public List<KeyValuePair<string, int>> TickMonsterPoison()
        {
            List<KeyValuePair<string, int>> tickInfo = new List<KeyValuePair<string, int>>();
            int damage = 0;
            int iTick = 1;


            if (MoldCount() > 0)
            {
                if (MoldCount() > 2)
                {
                    iTick = (int)Math.Ceiling(Convert.ToDouble(MoldCount()) / 2);
                }
                damage = 2 * iTick;
                MonsterEffects.Find(x=>x.iID == 1).Tick -= iTick;
                if (MoldCount() < 0) { MonsterEffects.Find(x => x.iID == 1).Tick = 0; }

                tickInfo.Add(new KeyValuePair<string, int>("damage", damage));
                //the tick value returned should be negative, since from here on it's for chat info
                tickInfo.Add(new KeyValuePair<string, int>("tick", iTick * -1));
            }

            return tickInfo;
        }

        public DamageInfoChatter TickPoison()
        {
            DamageInfoChatter c = new DamageInfoChatter();


            if (MoldCount() <= 0) { return c; }
            else
            {
                c.iTick = 1;
                c.chatType = "mold";
                if (MoldCount() > 2)
                {
                    c.iTick = (int)Math.Ceiling(Convert.ToDouble(MoldCount()) / 2);
                }
                c.iDamage = 2 * c.iTick;
                AdjustEffect(1, (c.iTick * -1));
                
                return c;
            }
        }

        public void ModStat(int aType, string aPower, bool isBuff = true)
        {
            double dMod = 1;
            switch (isBuff)
            {
                //buffs
                case true:
                    switch (aPower)
                    {
                        case "S":
                            dMod = 2.25;
                            break;
                        case "A":
                            dMod = 2;
                            break;
                        case "B":
                            dMod = 1.75;
                            break;
                        case "C":
                            dMod = 1.5;
                            break;
                        case "D":
                            dMod = 1.25;
                            break;
                        case "F":
                            dMod = 1.1;
                            break;
                    }
                    break;
                //debuff
                case false:
                    switch (aPower)
                    {
                        case "S":
                            dMod = .6;
                            break;
                        case "A":
                            dMod = .65;
                            break;
                        case "B":
                            dMod = .7;
                            break;
                        case "C":
                            dMod = .75;
                            break;
                        case "D":
                            dMod = .85;
                            break;
                        case "F":
                            dMod = .92;
                            break;
                    }
                    break;
            }

            switch (aType)
            {
                case 1:
                    PAtk *= (int)Math.Floor(PAtk * dMod);
                    break;
                case 2:
                    MAtk *= (int)Math.Floor(MAtk * dMod);
                    break;
                case 3:
                    PDef *= (int)Math.Floor(PDef * dMod);
                    break;
                case 4:
                    MDef *= (int)Math.Floor(MDef * dMod);
                    break;
                case 5:
                    HPmax = (int)Math.Floor(HPmax * dMod);
                    break;
                case 6:
                    EXP *= (int)Math.Floor(EXP* dMod);
                    break;
            }
        }

        public List<string> PullAttackList()
        {
            List<string> returnList = new List<string>()
            {
                "physical", "magic", "miss", "miss"
            };

            if (PAtk > MAtk) { returnList.Add("physical"); }
            else { returnList.Add("magic"); }
            
            foreach (string s in EffTypeList) 
            {
                returnList.Add("ability");
            }
            
            return returnList;
        }

        private void MakeDropTable(string rawData)
        {
            DropList = new DataTable();
            DropList.Columns.Add("ID");
            DropList.Columns.Add("Rate");

            if (rawData != null && rawData != "")
            {
                string t = rawData;
                while (t.IndexOf("|") > 0)
                {
                    //every item drop will have an ID and a [drop] Rate (out of 100%), monsters can drop multiple items
                    //take all info for one item:

                    /* this isn't working right now - it doesn't bring the rate to the below function 
                     * idk how to make sure how to account for multiple items plus variable ID lengths yet 
                    string temp = t.Substring(0, t.IndexOf("|"));
                    AddItemToDropTable(temp);
                    t = t.Substring(t.IndexOf("|") + 1);
                    */
                    AddItemToDropTable(t);
                    t = "";
                }
                //AddItemToDropTable(t);
            }
        }

        private void AddItemToDropTable(string s)
        {
            int tID = 0;
            int tRate = 0;
            tID = Convert.ToInt32(s.Substring(s.IndexOf("ID=") + 3, s.IndexOf("RT") - 4));
            tRate = Convert.ToInt32(s.Substring(s.IndexOf("RT=") + 3));
            DropList.Rows.Add(new Object[]{
                                    tID,
                                    tRate});
        }        


        private int cInt(string s)
        {
            try
            {
                return Convert.ToInt32(s);
            }
            catch { return 0; }
        }

        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsMonster objAsMonster = obj as clsMonster;
            if (objAsMonster == null) return false;
            else return Equals(objAsMonster);
        }

        public override int GetHashCode()
        {
            return monID;
        }

        public bool Equals(clsMonster other)
        {
            if (other == null) return false;
            return (this.monID.Equals(other.monID));
        }


    }
}
