using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace BreadMage2
{
    public class clsEquipment : IEquatable<clsEquipment>
    {
        public int equipID { get; set; }
        public string ItemName { get; set; }
        public int Slot { get; set; }
        public string Stats { get; set; }
        public string ExtraInfo { get; set; } //for adding abilities or other effects? idea: recycle effects like mold as add w/ weapon types and resist with armor types?
        public string  Description { get; set; }
        public string ImgURL { get; set; }


        private int PAtkStat { get; set; }
        private int MAtkStat { get; set; }
        private int DefStat { get; set; }
        private int ResStat { get; set; }

        private List<string> StatData { get; set; }

        //public int HP

        public clsEquipment(DataTable aItemTable)
        {
            ParseEquipmentData(aItemTable);
            InitalizeEquipment();
        }

        public clsEquipment(DataRow aItemRow)
        {
            ParseEquipmentDataRow(aItemRow);
            InitalizeEquipment();
        }

        public clsEquipment() { }


        public int PAtk() { return PAtkStat; }
        public int MAtk() { return MAtkStat; }
        public int Def() { return DefStat; }
        public int Res() { return ResStat; }




        private void ParseEquipmentData(DataTable ds)
        {
            //  Items.ID, Equipment.ItemName, Equipment.ImgURL, Equipment.Slot, Equipment.Stats, Equipment.SP, Equipment.Restore

            equipID = Convert.ToInt32(ds.Rows[0]["EquipID"].ToString());
            ItemName = ds.Rows[0]["ItemName"].ToString();
            Slot = Convert.ToInt32(ds.Rows[0]["Slot"].ToString());
            Stats = ds.Rows[0]["Stats"].ToString();
            ExtraInfo = ds.Rows[0]["ExtraInfo"].ToString();
            Description = ds.Rows[0]["Description"].ToString();
            ImgURL = ds.Rows[0]["ImgURL"].ToString();
        }

        private void ParseEquipmentDataRow(DataRow dr)
        {
            //  Items.ID, Equipment.ItemName, Equipment.ImgURL, Equipment.HP, Equipment.MP, Equipment.SP, Equipment.Restore

            equipID = Convert.ToInt32(dr["EquipID"].ToString());
            ItemName = dr["ItemName"].ToString();
            Slot = Convert.ToInt32(dr["Slot"].ToString());
            Stats = dr["Stats"].ToString();
            ExtraInfo = dr["ExtraInfo"].ToString();
            Description = dr["Description"].ToString();
            ImgURL = dr["ImgURL"].ToString();
        }

        private void InitalizeEquipment()
        {
            ParseStatInfo(Stats);
            SetStats();
        }


        private void ParseStatInfo(string sStats)
        {
            //for splitting out item stats

            StatData = new List<string>();
            string s = sStats;

            while (s.IndexOf("|") > 0)
            {
                //tags are all four characters
                string temp = s.Substring(0, s.IndexOf("|"));
                StatData.Add(temp);
                s = s.Substring(s.IndexOf("|") + 1);
            }
            StatData.Add(s);
        }

        private void SetStats()
        {
            // go through list of stat info
            // see the ChoiceBoard control ResolveChoice() method for further info
            //

            foreach (string s in StatData)
            {
                //decode action tag "XYZ="
                switch (s.Substring(0, 3))
                {
                    case "PAK": // p attack
                        PAtkStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "MAK": // m attack
                        MAtkStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "DEF": // def
                        DefStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "RES": // res
                        ResStat = Convert.ToInt32(s.Substring(4));
                        break;
                    default:
                        break;
                }
            }
        }


        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsEquipment objAsEquipment = obj as clsEquipment;
            if (objAsEquipment == null) return false;
            else return Equals(objAsEquipment);
        }

        public override int GetHashCode()
        {
            return equipID;
        }

        public bool Equals(clsEquipment other)
        {
            if (other == null) return false;
            return (this.equipID.Equals(other.equipID));
        }
    }
}
