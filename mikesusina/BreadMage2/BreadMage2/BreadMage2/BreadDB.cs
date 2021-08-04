using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadMage2.Screens;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Xml;

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

            DataTable rawChatter = new DataTable();
            msql = "SELECT * FROM MonsterChatter;";
            FillDT(msql, rawChatter);

            int i = 0;
            List<clsMonster> MonList = new List<clsMonster>();
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                MonList.Add(new clsMonster(ds.Tables[0].Rows[i], rawChatter));
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

        public List<clsUniqueItem> LoadUniqueItemsList()
        {
            List<clsUniqueItem> myList = new List<clsUniqueItem>();
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM ItemBook;";
            FillDS(msql, ds);

            int i = 0;
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                myList.Add(new clsUniqueItem(ds.Tables[0].Rows[i]));
                i++;
            }

            return myList;
        }

        public List<clsItem> LoadPlayerInv(int aSaveID = 1)
        {

            DataTable dt = new DataTable();
            string msql = "SELECT * FROM Inventory WHERE IIf(IsNull(MageID), 0, MageID) in (" + aSaveID + ", 0); ";
            FillDT(msql, dt);

            List<clsItem> newInv = new List<clsItem>();
            foreach (DataRow d in dt.Rows)
            {
                clsItem newItem= new clsItem(Convert.ToInt32(d["ItemID"].ToString()), Convert.ToInt32(d["Count"].ToString()));
                newInv.Add(newItem);
            }
            return newInv;
        }

        public void SavePlayerInv(int aSaveID, List<clsItem> anInv)
        {
            myConn = BreadConnect();
            try
            {
                string msql = "SELECT * FROM Inventory WHERE IIf(IsNull(MageID), 0, " + aSaveID + ") in (" + aSaveID + ", 0); ";

                OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
                OleDbCommand myCmd = new OleDbCommand(msql, myConn);
                myConn.Open();

                myCmd.CommandText = "DELETE FROM INVENTORY WHERE MAGEID = @MageID";
                myCmd.Parameters.AddWithValue("@MageID", aSaveID);
                myCmd.ExecuteNonQuery();

                foreach (clsItem e in anInv)
                {
                    myCmd.CommandText = "INSERT INTO [INVENTORY] Values(@MageID, @ItemID, @Count)";
                    myCmd.Parameters.Clear();
                    myCmd.Parameters.AddWithValue("@MageID", aSaveID);
                    myCmd.Parameters.AddWithValue("@EffType", e.iIDType);
                    myCmd.Parameters.AddWithValue("@EffValue", e.iCount);
                    myCmd.ExecuteNonQuery();
                }
                myCmd.Dispose();
                myConn.Close();
            }
            catch (Exception ex)
            {
                string s = "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "InnerException: " + ex.InnerException.ToString();
                s = "Inventory save failed" + Environment.NewLine + Environment.NewLine + s;
                MessageBox.Show(s);
            }

            /* OLD SYSTEM
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


            EVEN OLDER??
            myConn = BreadConnect();
            string msql = "SELECT ISNULL(MageID, 0) , ItemID, Count as ItemCount from Inventory " +
                            "WHERE IIf(IsNull(Inventory.MageID), 0, Inventory.MageID) in (" + iSaveID + ", 0);";
            OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(myAdap);
            cb.GetUpdateCommand();
            myAdap.Update(dtPInv);
            */
        }

        public List<clsMageEffect> LoadMageEffectsList(int aSaveID = 1)
        {
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM MageEffects WHERE IIf(IsNull(MageID), 0, MageID) in (" + aSaveID + ", 0); ";
            FillDT(msql, dt);

            List<clsMageEffect> EffList = new List<clsMageEffect>();
            foreach (DataRow d in dt.Rows)
            {
                clsMageEffect newEffect = new clsMageEffect(d["EffType"].ToString(), Convert.ToInt32(d["EffValue"].ToString()), Convert.ToInt32(d["Tick"].ToString()));
                EffList.Add(newEffect);
            }

            return EffList;
        }

        public void SaveMageEffectList(int aSaveID, List<clsMageEffect> anEffList)
        {

            myConn = BreadConnect();
            try
            {
                string msql = "SELECT * FROM MageEffects WHERE IIf(IsNull(MageID), 0, MageID) in (" + aSaveID + ", 0); ";
                OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
                OleDbCommand myCmd = new OleDbCommand(msql, myConn);
                myConn.Open();

                myCmd.CommandText = "DELETE FROM MAGEEFFECTS WHERE MAGEID = @MageID";
                myCmd.Parameters.AddWithValue("@MageID", aSaveID);
                myCmd.ExecuteNonQuery();

                foreach (clsMageEffect  e in anEffList)
                {
                    myCmd.CommandText = "INSERT INTO [MAGEEFFECTS] Values(@MageID, @EffType, @EffValue, @Tick)";
                    myCmd.Parameters.Clear();
                    myCmd.Parameters.AddWithValue("@MageID", aSaveID);
                    myCmd.Parameters.AddWithValue("@EffType", e.sType);
                    myCmd.Parameters.AddWithValue("@EffValue", e.iValue);
                    myCmd.Parameters.AddWithValue("@Tick", e.iTimer);
                    myCmd.ExecuteNonQuery();
                }
                myCmd.Dispose();
                myConn.Close();
            }
            catch (Exception ex)
            {
                string s = "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "InnerException: " + ex.InnerException.ToString();
                s = "Effect List save failed! " + Environment.NewLine + Environment.NewLine + s;
                MessageBox.Show(s);
            }
        }

        public void a(clsMage aMage)
        {
            clsTest test = new clsTest();
            /* writing
            //test.magename = "aname";
            //test.athing = 3;
            System.Xml.Serialization.XmlSerializer a = new System.Xml.Serialization.XmlSerializer(test.GetType());


            //var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\something.xml";
            System.IO.FileStream file = System.IO.File.Open("E:\\Repositories\\mikesusina\\BreadMage2\\BreadMage2\\BreadMage2\\XMLMageFlags.xml", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);

            a.Serialize(file, test);
            file.Close();
            */

            /*reading */

            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(clsTest));
            System.IO.StreamReader file = new System.IO.StreamReader(@"E:\Repositories\mikesusina\BreadMage2\BreadMage2\BreadMage2\XMLMageFlags.xml");
            clsTest loaded = (clsTest)reader.Deserialize(file);
            file.Close();
            Console.WriteLine(loaded.magename + "" + loaded.athing.ToString());
        }


    }
}
