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
        public int itemType { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }

        public clsUniqueItem(DataTable dt)
        {
            itemID = Convert.ToInt32(dt.Rows[0]["ItemID"].ToString());
            ItemName = dt.Rows[0]["ItemName"].ToString();
            itemType = Convert.ToInt32(dt.Rows[0]["ItemType"].ToString());
            ImageURL = dt.Rows[0]["ImgURL"].ToString();
            Description = dt.Rows[0]["Description"].ToString();
        }

        public clsUniqueItem(DataRow dr)
        {
            itemID = Convert.ToInt32(dr["ItemID"].ToString());
            ItemName = dr["ItemName"].ToString();
            itemType = Convert.ToInt32(dr["ItemType"].ToString());
            ImageURL = dr["ImgURL"].ToString();
            Description = dr["Description"].ToString();
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
