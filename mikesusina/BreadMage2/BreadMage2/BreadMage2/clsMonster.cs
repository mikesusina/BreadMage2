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

        public int monID { get; set; }
        public string MonName { get; set; }
        public int HP { get; set; }
        public int HPmax { get; set; }
        public int PAtk { get; set; }
        public int MAtk { get; set; }
        public int PDef { get; set; }
        public int MDef { get; set; }
        public int EXP { get; set; }
        public string sDropData { get; set; }
        public string sRawChatter { get; set; }
        public string ImageURL { get; set; }
        public int Location { get; set; }

        public List<String> ChatterList { get; set; }


        public DataTable MonData { get; set; }
        public DataRow MonRow { get; set; }
        //abilities?
        //drop table?
        public  DataTable DropList { get; set; }
        //picture url
        //unique chatter? roll to use unique or common?


        public clsMonster(DataTable aMonData)
        {
            MonData = aMonData;
            ParseMonsterData(MonData);
            InitializeMonster();
            
        }

        public clsMonster(DataRow aMonRow)
        {
            MonRow = aMonRow;
            ParseMonsterDataRow(MonRow);
            InitializeMonster();
        }
        /*
        private void GetMonster()
        {

            //generate/open connection
            //load query result into dataset
            //use method to populate stats
            DataSet ds = new DataSet();
            BreadNet = new BreadDB();
            MonData = BreadNet.LoadMonster(monID);
            ParseMonsterData(MonData);

        }
        */
        private void ParseMonsterData(DataTable ds)
        {
            // Monsters.[MonName], Monsters.[HP], Monsters.[PATK], Monsters.[MATK], Monsters.[PDEF], Monsters.[MDEF], Monsters.[EXP], Monsters.[IMG]"

            // ds.Rows[0].ItemArray[i]
            // MonName = 0
            // HP = 1
            // PATK = 2
            // MATK = 3
            // PDEF = 4
            // MDEF = 5
            // EXP = 6
            // IMG = 7
            // Loc = 8

            MonName = ds.Rows[0].ItemArray[0].ToString();
            HPmax = Convert.ToInt32(ds.Rows[0]["HP"].ToString());
            HP = HPmax;
            PAtk = Convert.ToInt32(ds.Rows[0]["PATK"].ToString());
            MAtk = Convert.ToInt32(ds.Rows[0]["MATK"].ToString());
            PDef = Convert.ToInt32(ds.Rows[0]["PDEF"].ToString());
            MDef = Convert.ToInt32(ds.Rows[0]["MDEF"].ToString());
            EXP = Convert.ToInt32(ds.Rows[0]["EXP"].ToString());
            ImageURL = ds.Rows[0]["IMG"].ToString();
            Location = Convert.ToInt32(ds.Rows[0]["Location"].ToString());
            monID = Convert.ToInt32(ds.Rows[0]["MonsterID"].ToString());
            sRawChatter = ds.Rows[0]["Chatter"].ToString();
            sDropData = ds.Rows[0]["Drops"].ToString();
        }

        private void ParseMonsterDataRow(DataRow dr)
        {
            // Monsters.[MonName], Monsters.[HP], Monsters.[PATK], Monsters.[MATK], Monsters.[PDEF], Monsters.[MDEF], Monsters.[EXP], Monsters.[IMG]"

            // ds.Rows[0].ItemArray[i]
            // MonName = 0
            // HP = 1
            // PATK = 2
            // MATK = 3
            // PDEF = 4
            // MDEF = 5
            // EXP = 6
            // IMG = 7

            MonName = dr["MonName"].ToString();
            HPmax = Convert.ToInt32(dr["HP"].ToString());
            HP = HPmax;
            PAtk = Convert.ToInt32(dr["PATK"].ToString());
            MAtk = Convert.ToInt32(dr["MATK"].ToString());
            PDef = Convert.ToInt32(dr["PDEF"].ToString());
            MDef = Convert.ToInt32(dr["MDEF"].ToString());
            EXP = Convert.ToInt32(dr["EXP"].ToString());
            ImageURL = dr["IMG"].ToString();
            Location = Convert.ToInt32(dr["Location"].ToString());
            monID = Convert.ToInt32(dr["MonsterID"].ToString());
            sRawChatter = dr["Chatter"].ToString();
            sDropData = dr["Drops"].ToString();
        }


        private void InitializeMonster()
        {

            //set chatter list
            ChatterList = new List<string>();
            string s = sRawChatter;

            while (s.IndexOf("|") > 0)
            {
                string temp = s.Substring(0, s.IndexOf("|"));
                ChatterList.Add(temp);
                s = s.Substring(s.IndexOf("|") + 1);
            }
            ChatterList.Add(s);

            // set the drop table
            DropList = new DataTable();
            DropList.Columns.Add("ID");
            DropList.Columns.Add("Rate");

            if (sDropData != null && sDropData != "")
            {
                string t = sDropData;
                while (t.IndexOf("|") > 0)
                {
                    //every item drop will have an ID and a [drop] Rate (out of 100%), monsters can drop multiple items
                    //take all info for one item:
                    string temp = t.Substring(0, t.IndexOf("|"));
                    AddItemToDropTable(temp);
                    t = t.Substring(t.IndexOf("|") + 1);
                }
                AddItemToDropTable(t);
            }

        }


        private void AddItemToDropTable(string s)
        {
            int tID = 0;
            int tRate = 0;
            tID = Convert.ToInt32(s.Substring(s.IndexOf("ID=") + 3, s.IndexOf("RT") - 3));
            tRate = Convert.ToInt32(s.Substring(s.IndexOf("RT=") + 3));
            DropList.Rows.Add(new Object[]{
                                    tID,
                                    tRate});
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
