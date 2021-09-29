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


    public class clsItem : IEquatable<clsItem>
    {
        /// <summary>
        /// This is the generic "item" class to populate the mage inventory. [probably] not the same as the item use engine
        /// item ID type (int) is the "type" of item
        /// 1 = healing
        /// 2 = cure
        /// 3 = combat
        /// 4 = MP heal??
        /// (n) = junk/achievement/flavor
        /// </summary>
        public int itemType { get; set; }
        public int iCount { get; set; }

        public clsItem(int aType, int aCount)
        {
            itemType = aType;
            iCount = aCount;
        }


        public void AddItem(int aCount = 1)
        {
            iCount += aCount;
        }






        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsItem objAsChoice = obj as clsItem;
            if (objAsChoice == null) return false;
            else return Equals(objAsChoice);
        }

        public override int GetHashCode()
        {
            return itemType;
        }

        public bool Equals(clsItem other)
        {
            if (other == null) return false;
            return (this.itemType.Equals(other.itemType));
        }

        static Predicate<clsItem> ByType(int aType)
        {
            return delegate (clsItem item)
            {
                return item.itemType == aType;
            };
        }
    }
}
