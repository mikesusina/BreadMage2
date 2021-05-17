using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace BreadMage2
{
    public class clsConsumable
    {
        public int itemID { get; set; }
        public string ItemName { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int SP { get; set; }
        public int Restore { get; set; }
        public string ImageURL { get; set; }

        public DataTable ItemTable { get; set; }
        public DataRow ItemRow { get; set; }
        //abilities?

        public clsConsumable(DataTable aItemTable)
        {
            ItemTable = aItemTable;
            ParseConsumableData(ItemTable);
        }

        public clsConsumable(DataRow aItemRow)
        {
            ItemRow = aItemRow;
            ParseConsumableDataRow(ItemRow);
        }

        public clsConsumable(int i)
        {

        }

        private void ParseConsumableData(DataTable ds)
        {
            //  Items.ID, Consumables.ItemName, Consumables.ImgURL, Consumables.HP, Consumables.MP, Consumables.SP, Consumables.Restore

            itemID = Convert.ToInt32(ds.Rows[0].ItemArray[0].ToString());
            ItemName = ds.Rows[0]["ItemName"].ToString();
            HP = Convert.ToInt32(ds.Rows[0]["HP"].ToString());
            MP = Convert.ToInt32(ds.Rows[0]["HP"].ToString());
            SP = Convert.ToInt32(ds.Rows[0]["HP"].ToString());
            Restore = Convert.ToInt32(ds.Rows[0]["HP"].ToString());
            ImageURL = ds.Rows[0]["ImgURL"].ToString();
        }

        private void ParseConsumableDataRow(DataRow dr)
        {
            //  Items.ID, Consumables.ItemName, Consumables.ImgURL, Consumables.HP, Consumables.MP, Consumables.SP, Consumables.Restore

            itemID = Convert.ToInt32(dr["ID"].ToString());
            ItemName = dr["ItemName"].ToString();
            HP = Convert.ToInt32(dr["HP"].ToString());
            MP = Convert.ToInt32(dr["MP"].ToString());
            SP = Convert.ToInt32(dr["SP"].ToString());
            Restore = Convert.ToInt32(dr["Restore"].ToString());
            ImageURL = dr["ImgURL"].ToString();
        }



    }
}
