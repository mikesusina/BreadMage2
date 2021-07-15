using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BreadMage2
{
    public class clsCombatItem : IEquatable<clsCombatItem>
    {
        public int itemID { get; set; }
        public string ItemName { get; set; }
        public int Damage { get; set; }
        public int DamageType { get; set; }
        public int Debuff { get; set; }
        public int DebuffType { get; set; }
        public int StatEffect { get; set; }
        public string ImageURL { get; set; }

        public DataTable ItemTable { get; set; }
        public DataRow ItemRow { get; set; }

        public clsCombatItem(DataTable aItemTable)
        {
            ItemTable = aItemTable;
            ParseCombatItemData(ItemTable);
        }

        public clsCombatItem(DataRow aItemRow)
        {
            ItemRow = aItemRow;
            ParseCombatItemDataRow(ItemRow);
        }


        private void ParseCombatItemData(DataTable ds)
        {
            //Items.ID, CombatItems.ItemName, CombatItems.ImgURL, CombatItems.Damage, CombatItems.DamageType, CombatItems.Debuff, CombatItems.DebuffType, CombatItems.StatEffect


            itemID = Convert.ToInt32(ds.Rows[0]["ID"].ToString());
            ItemName = ds.Rows[0]["ItemName"].ToString();
            Damage = Convert.ToInt32(ds.Rows[0]["Damage"].ToString());
            DamageType = Convert.ToInt32(ds.Rows[0]["DamageType"].ToString());
            Debuff = Convert.ToInt32(ds.Rows[0]["Debuff"].ToString());
            DebuffType = Convert.ToInt32(ds.Rows[0]["DebuffType"].ToString());
            StatEffect = Convert.ToInt32(ds.Rows[0]["StatEffect"].ToString());
            ImageURL = ds.Rows[0]["ImgURL"].ToString();
        }

        private void ParseCombatItemDataRow(DataRow dr)
        {
            //Items.ID, CombatItems.ItemName, CombatItems.ImgURL, CombatItems.Damage, CombatItems.DamageType, CombatItems.Debuff, CombatItems.DebuffType, CombatItems.StatEffect

            itemID = Convert.ToInt32(dr["ID"].ToString());
            ItemName = dr["ItemName"].ToString();
            Damage = Convert.ToInt32(dr["Damage"].ToString());
            DamageType = Convert.ToInt32(dr["DamageType"].ToString());
            Debuff = Convert.ToInt32(dr["Debuff"].ToString());
            DebuffType = Convert.ToInt32(dr["DebuffType"].ToString());
            StatEffect = Convert.ToInt32(dr["StatEffect"].ToString());
            ImageURL = dr["ImgURL"].ToString();

        }



        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsCombatItem objAsCombat = obj as clsCombatItem;
            if (objAsCombat == null) return false;
            else return Equals(objAsCombat);
        }

        public override int GetHashCode()
        {
            return itemID;
        }

        public bool Equals(clsCombatItem other)
        {
            if (other == null) return false;
            return (this.itemID.Equals(other.itemID));
        }
    }
}
