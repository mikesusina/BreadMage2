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
        public int MoldCount { get; set; } = 0;
        public int ZestCount { get; set; } = 0;
        public int TensionCount { get; set; } = 0;
        public string ImgURL { get; set; } = "BreadMage2";
        public string IntroChatter { get; set; } = "";
        public int Location { get; set; } = 1;

        private DataTable rawChatter;

        public List<MonsterChatter> ChatterList { get; set; } = new List<MonsterChatter>();

        public List<String> EffTypeList { get; set; }

        public  DataTable DropList { get; set; }

        //unique chatter? roll to use unique or common?


        public clsMonster(DataTable aMonData, DataTable someChatter)
        {
            rawChatter = someChatter;
            ParseMonsterData(aMonData);
            RefreshMonster();
        }

        public clsMonster(DataRow aMonRow, DataTable someChatter)
        {
            rawChatter = someChatter;
            ParseMonsterDataRow(aMonRow);
            RefreshMonster();
        }

        public clsMonster ShallowCopy()
        {
            return (clsMonster)this.MemberwiseClone();
        }

        //These should be coming straight from the full Monsters table
        private void ParseMonsterData(DataTable ds)
        {
            MonName = ds.Rows[0].ItemArray[0].ToString();
            HPmax = cInt(ds.Rows[0]["HP"].ToString());
            HP = HPmax;
            PAtk = cInt(ds.Rows[0]["PATK"].ToString());
            MAtk = cInt(ds.Rows[0]["MATK"].ToString());
            PDef = cInt(ds.Rows[0]["PDEF"].ToString());
            MDef = cInt(ds.Rows[0]["MDEF"].ToString());
            EXP = cInt(ds.Rows[0]["EXP"].ToString());
            ImgURL = ds.Rows[0]["ImgURL"].ToString();
            IntroChatter = ds.Rows[0]["IntroChatter"].ToString();
            Location = cInt(ds.Rows[0]["Location"].ToString());
            monID = cInt(ds.Rows[0]["MonsterID"].ToString());
            MakeDropTable(ds.Rows[0]["Drops"].ToString());
            MakeEffectList(ds.Rows[0]["EffType"].ToString());

            MakeChatterList(rawChatter);
        }

        private void ParseMonsterDataRow(DataRow dr)
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
            MakeEffectList(dr["EffType"].ToString());


            MakeChatterList(rawChatter);
        }

        public void RefreshMonster()
        {
            // if the monsters in the library get their stats goofed around
            HP = HPmax;
            MoldCount = 0;
            ZestCount = 0;
            TensionCount = 0;
            isCharging = false;
        }

        public DamageInfoChatter TickPoison()
        {
            DamageInfoChatter c = new DamageInfoChatter();

            if (MoldCount <= 0) { return c; }
            else
            {
                c.iTick = 1;
                c.effType = "M";
                if (MoldCount > 2)
                {
                    c.iTick = (int)Math.Ceiling(Convert.ToDouble(MoldCount) / 2);
                }
                c.iDamage = 2 * c.iTick;
                MoldCount -= c.iTick;
                if (MoldCount < 0) { MoldCount = 0; }
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


        private void MakeChatterList(DataTable rawChatter)
        {
            foreach (DataRow r in rawChatter.Rows)
            {
                if (cInt(r["MonsterID"].ToString()) == monID)
                {
                    /*
                    MonsterChatter b = new MonsterChatter(r["Chatter"].ToString(), (int)r["ChatType"]);
                    MonsterChatter b = new MonsterChatter(r["Chatter"].ToString())
                    {
                        iType = (int)r["ChatType"]
                    };
                    
                    switch (b.iType)
                    {
                        case 1: //patk
                            b.ChatColor = System.Drawing.Color.Red;
                            break;
                        case 2: //matk
                            b.ChatColor = System.Drawing.Color.CornflowerBlue;
                            break;
                        case 3: //miss
                            b.ChatColor = System.Drawing.Color.White;
                            break;
                        case 4: //defend
                            b.ChatColor = System.Drawing.Color.Aquamarine;
                            break;
                        case 5: //mold
                            b.ChatColor = System.Drawing.Color.LimeGreen;
                            break;
                        case 6: //zest
                            b.ChatColor = System.Drawing.Color.DarkOrange;
                            break;
                        case 7: //tension
                            b.ChatColor = System.Drawing.Color.LightCoral;
                            break;
                        case 8: // stun
                            b.ChatColor = System.Drawing.Color.LightCoral;
                            break;
                        case 9: // charge
                            b.ChatColor = System.Drawing.Color.Gainsboro;
                            break;
                        case 10: // restore
                            b.ChatColor = System.Drawing.Color.PeachPuff;
                            break;
                    }
                    ChatterList.Add(b);
                    */
                    ChatterList.Add(new MonsterChatter(r["Chatter"].ToString(), (int)r["ChatType"]));
                }
            }
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

        private void MakeEffectList(string rawEffects)
        {
            EffTypeList = new List<string>();
            string s = rawEffects;

            while (s.IndexOf("|") > 0)
            {
                string temp = s.Substring(0, s.IndexOf("|"));
                EffTypeList.Add(temp);
                s = s.Substring(s.IndexOf("|") + 1);
            }
            EffTypeList.Add(s);
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
