using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BreadMage2
{
    public class clsUniqueItem : IEquatable<clsUniqueItem>
    {
        public int itemID { get; set; }
        public string ItemName { get; set; }

        /// item ID type (int) is the "type" of item
        /// 1 = generic monster drops/item shop. These exist to be bought and drop to refill "item components"
        /// //** a note - most of these are unique, can drop multiple but break down to components
        /// BUT - there will be SPECIFIC items ONLY for purchasing at the store to refill components too, these are also type = 1
        /// 2 = equipment
        /// 3 = quest items
        /// (n) = ??
        public int itemType { get; set; }
        public int Yeast { get; set; } = 0;
        public string ImgURL { get; set; }
        public string Description { get; set; }
        public List <string> ResourceComponents { get; set; } = new List<string>();

        public clsUniqueItem() { }
        public clsUniqueItem(DataRow dr)
        {
            itemID = Convert.ToInt32(dr["ItemID"].ToString());
            ItemName = dr["ItemName"].ToString();
            ResourceComponents = Program.ParseDelimitedStringToString(dr["ResourceComponents"].ToString());
            itemType = Convert.ToInt32(dr["ItemType"].ToString());
            if (dr["Yeast"].ToString() != "") { Yeast = Convert.ToInt32(dr["Yeast"].ToString()); }
            ImgURL = dr["ImgURL"].ToString();
            Description = dr["Description"].ToString();
        }

        public int GetComponentValue(int iType)
        {
            int iReturn = 0;
            string itemCode = "";
            if (itemType == 1 && ResourceComponents.Count > 0) 
            {
                switch (iType)
                {

                    case 1:
                        itemCode = "ING";
                        break;
                    case 2:
                        itemCode = "CSM";
                        break;
                    case 3:
                        itemCode = "EMO";
                        break;
                }

                if (ResourceComponents.Find(x => x.Substring(0, 3) == itemCode) != "") 
                {
                    iReturn = Convert.ToInt32(ResourceComponents.Find(x => x.Substring(0, 3) == itemCode).Substring(4));
                }
            }
            return iReturn;
        }

        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsUniqueItem objAsUnique = obj as clsUniqueItem;
            if (objAsUnique == null) return false;
            else return Equals(objAsUnique);
        }

        public override int GetHashCode()
        {
            return itemID;
        }

        public bool Equals(clsUniqueItem other)
        {
            if (other == null) return false;
            return (this.itemID.Equals(other.itemID));
        }
    }
}
