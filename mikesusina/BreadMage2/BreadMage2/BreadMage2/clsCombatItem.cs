using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BreadMage2.Screens
{
    public class clsCombatItem
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
        public clsCombatItem(int i)
        {
            
        }


        private void ParseCombatItemData(DataTable ds)
        {
            //Items.ID, CombatItems.ItemName, CombatItems.ImgURL, CombatItems.Damage, CombatItems.DamageType, CombatItems.Debuff, CombatItems.DebuffType, CombatItems.StatEffect


            itemID = Convert.ToInt32(ds.Rows[0].ItemArray[0].ToString());
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

            itemID = Convert.ToInt32(dr.ItemArray[0].ToString());
            ItemName = dr["ItemName"].ToString();
            Damage = Convert.ToInt32(dr["Damage"].ToString());
            DamageType = Convert.ToInt32(dr["DamageType"].ToString());
            Debuff = Convert.ToInt32(dr["Debuff"].ToString());
            DebuffType = Convert.ToInt32(dr["DebuffType"].ToString());
            StatEffect = Convert.ToInt32(dr["StatEffect"].ToString());
            ImageURL = dr["ImgURL"].ToString();

        }
    }
}
