﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadMage2.Screens;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace BreadMage2
{
    class BreadDB
    {
        private static string connString;
        private OleDbConnection myConn;

        public BreadDB()
        {
            /* 
            connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\Repositories\mikesusina\BreadMage2\BreadMage2\BreadMage2\Resources\BreadTable.accdb; Persist Security Info = False;";
            OleDbConnection cnn;
            cnn = new OleDbConnection(connString);

            if the db is pw protected:
            Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\Repositories\mikesusina\BreadMage2\BreadMage2\BreadMage2\Resources\BreadTable.accdb; Jet OLEDB:Database Password = MyDbPassword;
            */
        }

        public OleDbConnection BreadConnect()
        {
            connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\Repositories\mikesusina\BreadMage2\BreadMage2\BreadMage2\Resources\BreadTable.accdb; Persist Security Info = False;";
            //connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\BreadTable.accdb; Persist Security Info = False;";

            OleDbConnection cnn;
            cnn = new OleDbConnection(connString);
            return cnn;
        }

        private void FillDS(string msql, DataSet ds)
        {
            myConn = BreadConnect();
            OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
            myAdap.Fill(ds);
            myAdap.Dispose();
            myConn.Close();
        }

        private void FillDT(string msql, DataTable dt)
        {
            myConn = BreadConnect();
            OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
            myAdap.Fill(dt);
            myAdap.Dispose();
            myConn.Close();
        }

        public List<clsMonster> LoadMonsterList()
        {
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM Monsters;";
            FillDS(msql, ds);

            int i = 0;
            List<clsMonster> MonList = new List<clsMonster>();
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                MonList.Add(new clsMonster(ds.Tables[0].Rows[i]));
                i++;
            }

            return MonList;
        }

        public List<clsChoiceAdventure> LoadChoiceList()
        {
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM ChoiceLib;";
            FillDS(msql, ds);

            int i = 0;
            List<clsChoiceAdventure> ChoiceList = new List<clsChoiceAdventure>();
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                ChoiceList.Add(new clsChoiceAdventure(ds.Tables[0].Rows[i]));
                i++;
            }

            return ChoiceList;
        }
        /*
        public DataSet LoadMonsterTable()
        {
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM Monsters;";
            FillDS(msql, ds);

            int i = 0;
            List<clsMonster> MonList = new List<clsMonster>();
            foreach (DataRow d in ds.Tables[0].Rows) 
            {
                MonList.Add(new clsMonster(ds.Tables[0].Rows[i]));
            }

                return ds;
        }
        */
        public DataSet LoadItemTable()
        {
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM Items;";
            FillDS(msql, ds);
            return ds;
        }


        public List<clsConsumable> LoadConsumablesLib()
        {
            List<clsConsumable> myList = new List<clsConsumable>();
            DataSet ds = new DataSet();
            string msql = "SELECT Items.ID, Consumables.ItemName, Consumables.ImgURL, Consumables.HP, Consumables.MP, Consumables.SP, Consumables.Restore" +
                           " FROM Items INNER JOIN Consumables ON Items.ID = Consumables.ItemID;";
            FillDS(msql, ds);

            int i = 0;
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                myList.Add(new clsConsumable(ds.Tables[0].Rows[i]));
                i++;
            }

            return myList;
        }


        public List<clsCombatItem> LoadCombatLib()
        {
            List<clsCombatItem> myList = new List<clsCombatItem>();
            DataSet ds = new DataSet();
            string msql = "SELECT Items.ID, CombatItems.ItemName, CombatItems.ImgURL, CombatItems.Damage, CombatItems.DamageType, CombatItems.Debuff, CombatItems.DebuffType, CombatItems.StatEffect" +
                           " FROM Items INNER JOIN CombatItems ON Items.ID = CombatItems.ItemID;";
            FillDS(msql, ds);

            int i = 0;
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                myList.Add(new clsCombatItem(ds.Tables[0].Rows[i]));
                i++;
            }

            return myList;
        }

        public DataSet LoadItemLibrary(int iType)
        {
            DataSet ds = new DataSet();
            string msql = "";

            switch (iType)
            {
                //consumables
                case 1:
                    msql = "SELECT Items.ID, Consumables.ItemName, Consumables.ImgURL, Consumables.HP, Consumables.MP, Consumables.SP, Consumables.Restore" +
                           " FROM Items INNER JOIN Consumables ON Items.ID = Consumables.ItemID;";
                    break;
                //combat inv
                case 2:
                    msql = "SELECT Items.ID, CombatItems.ItemName, CombatItems.ImgURL, CombatItems.Damage, CombatItems.DamageType, CombatItems.Debuff, CombatItems.DebuffType, CombatItems.StatEffect" +
                           " FROM Items INNER JOIN CombatItems ON Items.ID = CombatItems.ItemID;";
                    break;
                //equipment
                case 3:
                    break;
                //quest items
                case 4:
                    break;
            }

            return ds;

        }


        public DataTable LoadPlayerInv(int iSaveID = 1)
        {
            DataTable dt = new DataTable();
            string msql = "SELECT Inventory.MageID, Items.ID, IIf(IsNull(Inventory.Count), 0, Inventory.Count) as ItemCount, 0 as StatusFlag" + 
                          " FROM Items LEFT JOIN Inventory ON Items.ID = Inventory.ItemID" + 
                          " WHERE IIf(IsNull(Inventory.MageID), 0, Inventory.MageID) in (" + iSaveID + ", 0);";
            FillDT(msql, dt);
            return dt;
        }

        public void SavePlayerInv(int iSaveID, DataTable dtPInv)
        {

            /*
            myConn = BreadConnect();
            string msql = "SELECT ISNULL(MageID, 0) , ItemID, Count as ItemCount from Inventory " +
                            "WHERE IIf(IsNull(Inventory.MageID), 0, Inventory.MageID) in (" + iSaveID + ", 0);";
            OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(myAdap);
            cb.GetUpdateCommand();
            myAdap.Update(dtPInv);
            */

            myConn = BreadConnect();
            try
            {
                string msql = "SELECT ISNULL(MageID, 0) as MageID, ItemID, Count from Inventory " +
                            "WHERE IIf(IsNull(Inventory.MageID), 0, Inventory.MageID) in (" + iSaveID + ", 0);";

                OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
                OleDbCommand myCmd = new OleDbCommand(msql, myConn);
                int i = 0;
                myConn.Open();


                foreach (DataRow d in dtPInv.Rows)
                {
                    if (Convert.ToInt32(dtPInv.Rows[i]["StatusFlag"]) == 2)
                    {
                        myCmd.CommandText = "UPDATE [INVENTORY] set [Count] = @Count " +
                                                "WHERE [MageID] = " + iSaveID + " AND [ItemID] = @ItemID";
                        myCmd.Parameters.AddWithValue("@Count", Convert.ToInt32(dtPInv.Rows[i]["ItemCount"].ToString()));
                        myCmd.Parameters.AddWithValue("@ItemID", Convert.ToInt32(dtPInv.Rows[i]["ID"].ToString()));
                        myCmd.ExecuteNonQuery();
                    }
                    else if (Convert.ToInt32(dtPInv.Rows[i]["StatusFlag"]) == 1)
                    {
                        myCmd.CommandText = "INSERT INTO [INVENTORY] Values (" + iSaveID + ", @ItemID, @Count)";
                        myCmd.Parameters.AddWithValue("@Count", Convert.ToInt32(dtPInv.Rows[i]["ItemCount"].ToString()));
                        myCmd.Parameters.AddWithValue("@ItemID", Convert.ToInt32(dtPInv.Rows[i]["ID"].ToString()));
                        myCmd.ExecuteNonQuery();
                    }
                    i++;
                }
                myCmd.Dispose();
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inventory save failed! ");
            }



        }


    }
}
