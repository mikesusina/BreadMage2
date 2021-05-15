using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace BreadMage2
{
    public class Monster
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
        public string ImageURL { get; set; }
        private BreadDB BreadNet;
        public DataTable MonData { get; set; }
        //abilities?
        //drop table?
        //picture url
        //unique chatter? roll to use unique or common?


        public Monster(DataTable aMonData)
        {
            MonData = aMonData;
            ParseMonsterData(MonData);
            
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

            MonName = ds.Rows[0].ItemArray[0].ToString();
            HPmax = Convert.ToInt32(ds.Rows[0]["HP"].ToString());
//                .ItemArray[1]);
            HP = HPmax;
            PAtk = Convert.ToInt32(ds.Rows[0]["PATK"].ToString());
            MAtk = Convert.ToInt32(ds.Rows[0]["MATK"].ToString());
            PDef = Convert.ToInt32(ds.Rows[0]["PDEF"].ToString());
            MDef = Convert.ToInt32(ds.Rows[0]["MDEF"].ToString());
            EXP = Convert.ToInt32(ds.Rows[0]["EXP"].ToString());
            ImageURL = ds.Rows[0]["IMG"].ToString();
        }



    }
}
