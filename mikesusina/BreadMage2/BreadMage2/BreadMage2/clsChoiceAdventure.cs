using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using BreadMage2.Screens;

namespace BreadMage2
{
    public class clsChoiceAdventure : IEquatable<clsChoiceAdventure>
    {
        public int  AdvID { get; set; }
        public string AdvName { get; set; }
        public string AdvText { get; set; }
        public string Btn1 { get; set; }
        public string Btn1Result { get; set; }
        public string Btn2 { get; set; }
        public string Btn2Result { get; set; }
        public string Btn3 { get; set; }
        public string Condition3 { get; set; }
        public string Btn3Result { get; set; }
        public string Btn4 { get; set; }
        public string Condition4 { get; set; }
        public string Btn4Result { get; set; }
        public int Location { get; set; }
        public string ImageURL { get; set; }

        public DataTable ChoiceTable { get; set; }
        public DataRow ChoiceRow { get; set; }

        public clsChoiceAdventure(DataTable aChoiceData)
        {
            ChoiceTable = aChoiceData;
            ParseChoiceData(ChoiceTable);
               
        }

        public clsChoiceAdventure(DataRow aChoiceRow)
        {
            ChoiceRow = aChoiceRow;
            ParseChoiceRowData(ChoiceRow);
        }

        private void ParseChoiceData(DataTable ds)
        {
            AdvID = Convert.ToInt32(ds.Rows[0]["ID"].ToString());
            AdvName = ds.Rows[0]["AdvName"].ToString();
            AdvText = ds.Rows[0]["AdvText"].ToString();
            Btn1 = ds.Rows[0]["Btn1"].ToString();
            Btn1Result = ds.Rows[0]["Btn1Result"].ToString();
            Btn2 = ds.Rows[0]["Btn2"].ToString();
            Btn2Result = ds.Rows[0]["Btn2Result"].ToString();
            Btn3 = ds.Rows[0]["Btn3"].ToString();
            Condition3 = ds.Rows[0]["Condition4"].ToString();
            Btn3Result = ds.Rows[0]["Btn3Result"].ToString();
            Btn4 = ds.Rows[0]["Btn4"].ToString();
            Condition4 = ds.Rows[0]["Condition4"].ToString();
            Btn4Result = ds.Rows[0]["Btn4Result"].ToString();
            Location = Convert.ToInt32(ds.Rows[0]["Location"].ToString());
            ImageURL = ds.Rows[0]["ImageURL"].ToString();
        }

        private void ParseChoiceRowData(DataRow dr)
        {
            AdvID = Convert.ToInt32(dr["ID"].ToString());
            AdvName = dr["AdvName"].ToString();
            AdvText = dr["AdvText"].ToString();
            Btn1 = dr["Btn1"].ToString();
            Btn1Result = dr["Btn1Result"].ToString();
            Btn2 = dr["Btn2"].ToString();
            Btn2Result = dr["Btn2Result"].ToString();
            Btn3 = dr["Btn3"].ToString();
            Condition3 = dr["Condition4"].ToString();
            Btn3Result = dr["Btn3Result"].ToString();
            Btn4 = dr["Btn4"].ToString();
            Condition4 = dr["Condition4"].ToString();
            Btn4Result = dr["Btn4Result"].ToString();
            Location = Convert.ToInt32(dr["Location"].ToString());
            ImageURL = dr["ImageURL"].ToString();
        }

        public List<string> GetResults(int i)
        {
            List<string> ResultList = new List<string>();

            switch (i)
            {
                case 1:
                    ResultList = ParseResult(Btn1Result);
                    break;
                case 2:
                    ResultList = ParseResult(Btn2Result);
                    break;
                case 3:
                    ResultList = ParseResult(Btn3Result);
                    break;
                case 4:
                    ResultList = ParseResult(Btn4Result);
                    break;
                default:
                    throw new Exception("Result info not found");
            }
            return ResultList;
        }

        private List<string> ParseResult(string s)
        {
            List<string> ResultData = new List<string>();

            while (s.IndexOf("|") > 0)
            {
                //tags are all four characters
                string temp = s.Substring(0, s.IndexOf("|"));
                ResultData.Add(temp);
                s = s.Substring(s.IndexOf("|") + 1);
            }

            ResultData.Add(s);

            return ResultData;
        }




        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsChoiceAdventure objAsChoice = obj as clsChoiceAdventure;
            if (objAsChoice == null) return false;
            else return Equals(objAsChoice);
        }

        public override int GetHashCode()
        {
            return AdvID;
        }

        public bool Equals(clsChoiceAdventure other)
        {
            if (other == null) return false;
            return (this.AdvID.Equals(other.AdvID));
        }

    }
}
