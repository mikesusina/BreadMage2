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

        private void FillDT(string msql, DataTable dt)
        {
            myConn = BreadConnect();
            OleDbDataAdapter myAdap = new OleDbDataAdapter(msql, myConn);
            myAdap.Fill(dt);
            myAdap.Dispose();
            myConn.Close();
        }

        public clsGameLibs LoadLibraries()
        {
            clsGameLibs o = new clsGameLibs();
            o.SetMonsterLib(LoadMonsterList());
            o.SetChoiceLib(LoadChoiceList());
            o.SetEffectChatterLib(LoadEffectChatter());
            o.SetItemLib(LoadUniqueItemsList());
            o.SetEquipLib(LoadEquipment());
            o.SetSpellLib(LoadSpellList());
            o.SetEquipSpells(); //this requires both the equip and spell library to be populated
            o.SetLocationLib(LoadLocationList());
            o.SetEffectLib(LoadEffectLibrary());
            o.SetSpellChatterLib(LoadSpellChatter());
            o.SetWeaponChatterLib(LoadWeaponChatter());
            o.SetTownLocationsLib(LoadTownLocationLibrary());
            return o;
        }

        public List<clsMonster> LoadMonsterList()
        {
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM Monsters;";
            FillDT(msql, dt);

            DataTable rawChatter = new DataTable();
            msql = "SELECT * FROM MonsterChatter;";
            FillDT(msql, rawChatter);

            //Create the master list of chatter results first
            int i = 0;
            List<MonsterChatter> MasterChatterList = new List<MonsterChatter>();
            foreach (DataRow r in rawChatter.Rows)
            {
                MasterChatterList.Add(new MonsterChatter(r["Chatter"].ToString(), r["ChatType"].ToString(), Convert.ToInt32(r["MonsterID"].ToString())));
                i++;
            }

            //then load the monsters by row
            List<clsMonster> MonList = new List<clsMonster>();
            foreach (DataRow r in dt.Rows)
            {
                MonList.Add(new clsMonster(r, MasterChatterList.FindAll(x => x.iMonID == Convert.ToInt32(r["MonsterID"].ToString()))));
            }

            return MonList;
        }

        public List<clsChoiceAdventure> LoadChoiceList()
        {
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM ChoiceLib;";
            FillDT(msql, dt);

            List<clsChoiceAdventure> ChoiceList = new List<clsChoiceAdventure>();
            foreach (DataRow r in dt.Rows)
            {
                clsChoiceAdventure a = new clsChoiceAdventure(r);
                Console.WriteLine(a.GetType().Name);
                Console.WriteLine(a.GetType().FullName);
                ChoiceList.Add(new clsChoiceAdventure(r));
            }

            return ChoiceList;
        }

        public List<clsUniqueItem> LoadUniqueItemsList()
        {
            List<clsUniqueItem> myList = new List<clsUniqueItem>();
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM ItemBook;";
            FillDT(msql, dt);

            foreach (DataRow r in dt.Rows)
            {
                myList.Add(new clsUniqueItem(r));
            }

            return myList;
        }

        public List<clsEquipment> LoadEquipment()
        {
            List<clsEquipment> myList = new List<clsEquipment>();
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM Equipment;";
            FillDT(msql, dt);

            foreach (DataRow r in dt.Rows)
            {
                myList.Add(new clsEquipment(r));
            }

            return myList;
        }

        public List<clsSpell> LoadSpellList()
        {
            List<clsSpell> myList = new List<clsSpell>();
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM Spells;";
            FillDT(msql, dt);

            foreach (DataRow r in dt.Rows)
            {
                myList.Add(new clsSpell(r));
            }

            return myList;
        }

        public List<clsLocation> LoadLocationList()
        {
            List<clsLocation> myList = new List<clsLocation>();
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM Locations;";
            FillDT(msql, dt);

            foreach (DataRow r in dt.Rows)
            {
                myList.Add(new clsLocation(r));
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
                        r["EffType"].ToString(),
                        true,
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
        
        public List<SpellChatter> LoadSpellChatter()
        {
            List<SpellChatter> myList = new List<SpellChatter>();
            try
            {
                DataTable dt = new DataTable();
                string msql = "SELECT * FROM SpellChatter;";
                FillDT(msql, dt);

                foreach (DataRow r in dt.Rows)
                {
                    //(string sText, string aSpellType, string aTarget, string anElement, bool bFlag = true)
                    SpellChatter e = new SpellChatter(r["Chatter"].ToString(),
                        r["SpellType"].ToString(),
                        r["Target"].ToString(),
                        r["Element"].ToString());
                    myList.Add(e);
                }
            }
            catch (ApplicationException ex)
            {
                string s = "Dang couldn't load that EffectChatterList for some reason" + Environment.NewLine + ex.InnerException.ToString();
            }
            return myList;
        }

        public List<WeaponChatter> LoadWeaponChatter()
        {
            List<WeaponChatter> myList = new List<WeaponChatter>();
            try
            {
                DataTable dt = new DataTable();
                string msql = "SELECT * FROM WeaponChatter;";
                FillDT(msql, dt);

                foreach (DataRow r in dt.Rows)
                {
                    //public WeaponChatter(string sText, string aSubType, bool bFlag = true)
                    myList.Add(new WeaponChatter(r["Chatter"].ToString(), r["SubType"].ToString()));
                }
            }
            catch (ApplicationException ex)
            {
                string s = "Dang couldn't load that WeaponChatter Library for some reason" + Environment.NewLine + ex.InnerException.ToString();
            }
            return myList;
        }

        public List<clsEffect> LoadEffectLibrary()
        {
            List<clsEffect> myList = new List<clsEffect>();
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM EffectLib;";
            FillDT(msql, dt);

            foreach (DataRow r in dt.Rows)
            {
                myList.Add(new clsEffect(r));
            }

            return myList;
        }
        public List<clsTownLot> LoadTownLocationLibrary()
        {
            List<clsTownLot> myList = new List<clsTownLot>();
            DataTable dt = new DataTable();
            string msql = "SELECT * FROM TownLocations;";
            FillDT(msql, dt);

            foreach (DataRow r in dt.Rows)
            {
                myList.Add(new clsTownLot(r));
            }

            return myList;
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


        public void SaveData(clsSaveData toSaveFlags)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer cerealizer = new System.Xml.Serialization.XmlSerializer(toSaveFlags.GetType());
                System.IO.FileStream file = System.IO.File.Open("E:\\Repositories\\mikesusina\\BreadMage2\\BreadMage2\\BreadMage2\\XMLSaveFlags.xml", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                cerealizer.Serialize(file, toSaveFlags);
                file.Close();
            }
            catch (ApplicationException ex)
            {
                string s = "Hey we had some issues saving game flags" + Environment.NewLine + ex.InnerException.ToString();
                MessageBox.Show(s);
            }
        }


        public clsSaveData LoadSaveData()
        {
            clsSaveData loadedData = new clsSaveData();
            try
            {
                /*reading */
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(clsGameFlags));
                System.IO.StreamReader file = new System.IO.StreamReader(@"E:\Repositories\mikesusina\BreadMage2\BreadMage2\BreadMage2\XMLSaveFlags.xml");
                loadedData = (clsSaveData)reader.Deserialize(file);
                file.Close();
                return loadedData;
            }
            catch (ApplicationException ex)
            {
                string s = "Hey we had some issues loading GameFlags" + Environment.NewLine + ex.InnerException.ToString();
                MessageBox.Show(s);
            }
            return loadedData;
        }
    }
}
