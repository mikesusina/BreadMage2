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
        public int LocationID { get; set; } = 0;
        public string LocationName { get; set; } = "DefaultLoc";
        public string LocationType { get; set; } = "wander";
        public int Zone { get; set; } = 1;
        public int ZoneLocation { get; set; } = 0; //1-12 the location on the map
        public Image MapTile { get; set; } = Properties.Resources.mapvoid;
        public string Description { get; set; } = "Default Descripton";


        public clsLocation() { }
        public clsLocation(DataRow dr)
        {
            LocationID = Convert.ToInt32(dr["ID"].ToString());
            LocationName = dr["LocationName"].ToString();
            LocationType = dr["LocationType"].ToString();
            Zone = Convert.ToInt32(dr["Zone"].ToString());
            ZoneLocation = Convert.ToInt32(dr["ZoneLocation"].ToString());
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
            return LocationID;
        }

        public bool Equals(clsLocation other)
        {
            if (other == null) return false;
            return (this.LocationID.Equals(other.LocationID));
        }
    }
}
