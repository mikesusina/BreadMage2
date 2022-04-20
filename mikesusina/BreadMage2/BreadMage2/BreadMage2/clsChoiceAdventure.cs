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
        public int Location { get; set; }
        public string ImgURL { get; set; }
        public List<string> AppearCondition { get; set; }
        public List<string> ReplaceCondition { get; set; }
        public int ReplaceID { get; set; }
        public List<ResultItem> AdventureResults { get; set; } = new List<ResultItem>();

        public clsChoiceAdventure() { }
        public clsChoiceAdventure(DataRow dr)
        {
            AdvID = Convert.ToInt32(dr["ID"].ToString());
            AdvName = dr["AdvName"].ToString();
            AdvText = dr["AdvText"].ToString();
            Location = Convert.ToInt32(dr["Location"].ToString());
            AppearCondition = Program.ParseDelimitedStringToString(dr["AppearCondition"].ToString());
            ReplaceCondition = Program.ParseDelimitedStringToString(dr["ReplaceCondition"].ToString());
            ReplaceID = Convert.ToInt32(dr["ReplaceID"].ToString());
            ImgURL = dr["ImgURL"].ToString();

            //create the result info objects
            int i = 1;
            while (i < 5)
            {
                if (dr["Btn" + i.ToString()].ToString() != null)
                {
                    ResultItem item = new ResultItem();
                    item.SlotID = i;
                    item.ButtonText = dr["Btn" + i.ToString()].ToString();
                    item.ResultData = dr["Btn" + i.ToString() + "Result"].ToString();
                    item.RareResultData = dr["Btn" + i.ToString() + "Rare"].ToString();
                
                    // visibility condition will get set once the copy has been made
                    // buttons one and two will always be available, so no conditions - DB doesn't even have columns. 
                    if (i < 3) 
                    { item.ResultCondition = "";
                        item.ConditionMet = true;
                    }
                    else { item.ResultCondition = dr["Condition" + i.ToString()].ToString(); }
                
                    AdventureResults.Add(item);
                }
                i++;
            }
        }
        public clsChoiceAdventure ShallowCopy()
        {
            return (clsChoiceAdventure)this.MemberwiseClone();
        }

        public List<string> GetResults(ResultItem aResult, bool bRareRoll = false)
        {
            List<string> returnList = new List<string>();
            if (aResult.ResultData != "")
                { returnList.AddRange(Program.ParseDelimitedStringToString(aResult.ResultData)); }
            if (bRareRoll && aResult.RareResultData != "") 
                { returnList.AddRange(Program.ParseDelimitedStringToString(aResult.RareResultData)); }
            return returnList;
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

    public class ResultItem : IEquatable<ResultItem>
    {
        public int SlotID { get; set; }
        public string ButtonText { get; set; }
        public string ResultData { get; set; }
        public string RareResultData { get; set; }
        public string ResultCondition { get; set; }
        public bool ConditionMet = false;

        public System.Windows.Forms.Button ResultButton { get; set; }


        public ResultItem()
        {

        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ResultItem objAsResult = obj as ResultItem;
            if (objAsResult == null) return false;
            else return Equals(objAsResult);
        }

        public override int GetHashCode()
        {
            return SlotID;
        }

        public bool Equals(ResultItem other)
        {
            if (other == null) return false;
            return (this.SlotID.Equals(other.SlotID));
        }
    }
}
