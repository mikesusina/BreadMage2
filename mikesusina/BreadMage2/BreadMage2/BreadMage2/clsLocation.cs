using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace BreadMage2
{
    public class clsLocation : IEquatable<clsLocation>
    {
        public int LocID { get; set; } = 0;
        public string LocationName { get; set; } = "DefaultLoc";
        public int Zone { get; set; } = 1;
        public int LocX { get; set; } = 0;
        public string LocY { get; set; } = "e";
        public Image MapTile { get; set; } = Properties.Resources.mapvoid;
        public string Description { get; set; } = "Default Descripton";


        public clsLocation()
        {

        }


        public clsLocation(DataTable dt)
        {
            LocID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
            LocationName = dt.Rows[0]["LocationName"].ToString();
            Zone = Convert.ToInt32(dt.Rows[0]["Zone"].ToString());
            LocX = Convert.ToInt32(dt.Rows[0]["LocX"].ToString());
            LocY = dt.Rows[0]["LocY"].ToString();
            MapTile = GetImage(dt.Rows[0]["ImgURL"].ToString());
            Description = dt.Rows[0]["Description"].ToString();
        }

        public clsLocation(DataRow dr)
        {
            LocID = Convert.ToInt32(dr["ID"].ToString());
            LocationName = dr["LocationName"].ToString();
            Zone = Convert.ToInt32(dr["Zone"].ToString());
            LocX = Convert.ToInt32(dr["LocX"].ToString());
            LocY = dr["LocY"].ToString();
            MapTile = GetImage(dr["ImgURL"].ToString());
            Description = dr["Description"].ToString();
        }




        private Image GetImage(string s)
        {
            Image i = Properties.Resources.mapvoid;
            object o = Properties.Resources.ResourceManager.GetObject(s);
            if (o is Image) { i = o as Image; }

            return i;
        }

        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsLocation objAsLocation = obj as clsLocation;
            if (objAsLocation == null) return false;
            else return Equals(objAsLocation);
        }

        public override int GetHashCode()
        {
            return LocID;
        }

        public bool Equals(clsLocation other)
        {
            if (other == null) return false;
            return (this.LocID.Equals(other.LocID));
        }
    }
}
