using System;
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
            connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\Repos\mikesusina\homebase\BreadMage2\BreadMage2\Resources\BreadTable.accdb; Persist Security Info = False;";
            OleDbConnection cnn;
            cnn = new OleDbConnection(connString);

            if the db is pw protected:
            Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\Repos\mikesusina\homebase\BreadMage2\BreadMage2\Resources\BreadTable.accdb; Jet OLEDB:Database Password = MyDbPassword;
            */
        }

        public OleDbConnection BreadConnect()
        {
            connString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\Repos\mikesusina\homebase\BreadMage2\BreadMage2\Resources\BreadTable.accdb; Persist Security Info = False;";
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

        public DataSet LoadMonster(int aMonID)
        {
            DataSet ds = new DataSet();
            string msql = "SELECT Monsters.[MonName], Monsters.[HP], Monsters.[PATK], Monsters.[MATK], Monsters.[PDEF], Monsters.[MDEF], Monsters.[EXP], Monsters.[IMG]" +
            "FROM Monsters" +
            " WHERE Monsters.[MonsterID] = " + aMonID + ";";
            myConn = BreadConnect();

            //MessageBox.Show(msql);

            FillDS(msql, ds);
            return ds;
        }

        public DataSet LoadMonsterTable()
        {
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM Monsters;";
            FillDS(msql, ds);
            return ds;
        }

        public DataSet LoadItemTable()
        {
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM Items;";
            FillDS(msql, ds);
            return ds;
        }




        public DataSet LoadPlayerInv(int iType, int iSaveID = 1)
        {
            DataSet ds = new DataSet();
            string msql = "";

            ////
            //****update this to pick mage ID based on save slot
            ////
            ///
            switch (iType)
            {
                //consumables
                case 1:
                    msql = "SELECT Items.ID, Consumables.ItemName, Inventory.Count, Consumables.ImgURL, Consumables.HP, Consumables.MP, Consumables.SP, Consumables.Restore" +
                                " FROM(Items LEFT JOIN Inventory ON Items.ID = Inventory.ItemID) LEFT JOIN Consumables ON Items.ID = Consumables.ItemID" +
                                " WHERE Items.ItemType = 1 AND Inventory.MageID = 1;";
                    break;
                //combat inv
                case 2:
                    msql = "SELECT Items.ID, CombatItems.ItemName, Inventory.Count, CombatItems.ImgURL, CombatItems.Damage, CombatItems.DamageType, CombatItems.Debuff, CombatItems.DebuffType, CombatItems.StatEffect" +
                      " FROM(Items LEFT JOIN Inventory ON Items.ID = Inventory.ItemID) LEFT JOIN CombatItems ON Items.ID = CombatItems.ItemID" +
                      " WHERE Items.ItemType = 2 AND Inventory.MageID = 1;";
                    break;

                //equipment
                case 3:
                    break;
                //quest items
                case 4:
                    break;
            }
                          

            if (msql != "")
            {
                FillDS(msql, ds);
                /*
                myConn = BreadConnect();
                OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
                myAdap.Fill(ds);
                myAdap.Dispose();
                myConn.Close();
                */
            }

            return ds;
        }


    }
}
