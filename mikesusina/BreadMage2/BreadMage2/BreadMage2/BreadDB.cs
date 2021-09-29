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

        public List<clsSpell> LoadSpellList()
        {
            List<clsSpell> myList = new List<clsSpell>();
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM Spells;";
            FillDS(msql, ds);

            int i = 0;
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                myList.Add(new clsSpell(ds.Tables[0].Rows[i]));
                i++;
            }

            return myList;
        }

        public List<clsLocation> LoadLocationList()
        {
            List<clsLocation> myList = new List<clsLocation>();
            DataSet ds = new DataSet();
            string msql = "SELECT * FROM Locations;";
            FillDS(msql, ds);

            int i = 0;
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                myList.Add(new clsLocation(ds.Tables[0].Rows[i]));
                i++;
            }

            return myList;
        }

        public List<EffectChatter> LoadEffectChatter()
        {
            List<EffectChatter> myList = new List<EffectChatter>();
            try
            {
                DataTable dt = new DataTable();
                string msql = "SELECT * FROM BattleEffectChatter;";
                FillDT(msql, dt);

                foreach (DataRow r in dt.Rows)
                {
                    EffectChatter e = new EffectChatter(r["ChatterText"].ToString(),
                        null,
                        true,
                        r["EffType"].ToString(),
                        (int)r["SpeakerType"]);
                    myList.Add(e);
                }
            }
            catch (ApplicationException ex)
            {
                string s = "Dang couldn't load that EffectChatterList for some reason" + Environment.NewLine + ex.InnerException.ToString();
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
                    myCmd.Parameters.AddWithValue("@EffType", e.itemType);
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

                foreach (clsMageEffect e in anEffList)
                {
                    if(e.iTimer > 0 || e.iValue > 0)
                    {
                        myCmd.CommandText = "INSERT INTO [MAGEEFFECTS] Values(@MageID, @EffType, @EffValue, @Tick)";
                        myCmd.Parameters.Clear();
                        myCmd.Parameters.AddWithValue("@MageID", aSaveID);
                        myCmd.Parameters.AddWithValue("@EffType", e.sType);
                        myCmd.Parameters.AddWithValue("@EffValue", e.iValue);
                        myCmd.Parameters.AddWithValue("@Tick", e.iTimer);
                        myCmd.ExecuteNonQuery();
                    }
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

        public clsGameFlags LoadGameFlags()
        {
            clsGameFlags myGameFlags = new clsGameFlags();
            try
            {
                /*reading */
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(clsGameFlags));
                System.IO.StreamReader file = new System.IO.StreamReader(@"E:\Repositories\mikesusina\BreadMage2\BreadMage2\BreadMage2\XMLMageFlags.xml");
                myGameFlags = (clsGameFlags)reader.Deserialize(file);
                file.Close();
                return myGameFlags;
            }
            catch(ApplicationException ex)
            {
                string s = "Hey we had some issues loading GameFlags" + Environment.NewLine + ex.InnerException.ToString();
                MessageBox.Show(s);
            }
            return myGameFlags;
        }

        public void SaveGameFlags(clsGameFlags toSaveFlags)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer cerealizer= new System.Xml.Serialization.XmlSerializer(toSaveFlags.GetType());
                System.IO.FileStream file = System.IO.File.Open("E:\\Repositories\\mikesusina\\BreadMage2\\BreadMage2\\BreadMage2\\XMLMageFlags.xml", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                cerealizer.Serialize(file, toSaveFlags);
                file.Close();
            }
            catch (ApplicationException ex)
            {
                string s = "Hey we had some issues saving game flags" + Environment.NewLine + ex.InnerException.ToString();
                MessageBox.Show(s);
            }
        }

    }
}
