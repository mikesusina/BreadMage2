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
        public int MoldCount { get; set; } = 0;
        public int ZestCount { get; set; } = 0;
        public int TensionCount { get; set; } = 0;
        public string ImgURL { get; set; } = "BreadMage2";
        public int Location { get; set; } = 1;

        private DataTable rawChatter;

        public List<BattleChatter> ChatterList { get; set; } = new List<BattleChatter>();

        public List<String> PAKChatterList { get; set; } = new List<string>(); //p atk
        public List<String> MAKChatterList { get; set; } = new List<string>(); //m atk
        public List<String> EAKChatterList { get; set; } = new List<string>(); //effect attack
        public List<String> MISChatterList { get; set; } = new List<string>(); //miss
        public List<String> DEFChatterList { get; set; } = new List<string>(); //defend

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
        }

        public int TickMonPoison()
        {
            int damage = 0;
            int iTick = 1;

            if (MoldCount <= 0) { return 0; }
            else if (MoldCount > 2)
            {
                iTick = (int)(Math.Ceiling(Convert.ToDouble(MoldCount))) / 2;
            }
            damage = 2 * iTick;
            MoldCount -= iTick;
            if (MoldCount < 0) { MoldCount = 0; }

            return damage;
        }


        private void MakeChatterList(DataTable rawChatter)
        {
            foreach (DataRow r in rawChatter.Rows)
            {
                if (cInt(r["MonsterID"].ToString()) == monID)
                {

                    BattleChatter b = new BattleChatter(r["Chatter"].ToString())
                    {
                        iType = (int)r["ChatType"]
                    };
                    

                    string s = b.ChatText;
                    if (s.IndexOf("|") > 0)
                    {
                        b.sPreDmgText = s.Substring(0, s.IndexOf("|"));
                        b.sPostDmgText = s.Substring(s.IndexOf("|") + 1);
                    }
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
                            b.ChatColor = System.Drawing.Color.White;
                            break;
                        case 5: //mold
                            b.ChatColor = System.Drawing.Color.Green;
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
                    }
                    ChatterList.Add(b);
                    /*
                    ChatterList.Add(new BattleChatter())
                    if (cInt(r["ChatType"].ToString()) == 1) { PAKChatterList.Add(r["Chatter"].ToString()); }
                    else if (cInt(r["ChatType"].ToString()) == 2) { MAKChatterList.Add(r["Chatter"].ToString()); }
                    else if (cInt(r["ChatType"].ToString()) == 3) { MISChatterList.Add(r["Chatter"].ToString()); }
                    else if (cInt(r["ChatType"].ToString()) == 4) { DEFChatterList.Add(r["Chatter"].ToString()); }
                    else if (cInt(r["ChatType"].ToString()) == 5) { EAKChatterList.Add(r["Chatter"].ToString()); }
                    //else if (cInt(r["ChatType"].ToString()) == 6) { }
                    */
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
