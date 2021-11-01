using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BreadMage2
{
    class engSaveData
    {

        public engSaveData()
        {

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
