using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadMage2
{
    public class clsTownLot
    {
        public int ID { get; set; }
        public string TownName { get; set; } = "DefaultName";
        public int TownType { get; set; } //item shop, equip shop, skill equip, etc... - determines button img
        // 1 = equipment/equip screen
        // 2 = spells&skills/components
        // 3 = flavor/quest(/utility?)
        // 4 = save?
        // 5 = casino?
        //** a note about the skill equip! Make all towns have a skill shop that has a button to enter the skill equip screen, which loads the bespoke board
        // alternatively, make this same button but in the save hut
        // even perhaps! both?
        public int LocationID { get; set; } //this is the clsLocation - the map tile. To group by. Able to add shops to non-town zones via this?
        public int TownLotNo { get; set; } //column location in town
        public string Condition { get; set; } = "";
        public bool Visible = true;
        public string ImgURL { get; set; } = "";
        
        public string ChatterGroup { get; set; } = "";
        public System.Windows.Forms.Button TownButton { get; set; } = new System.Windows.Forms.Button();
        public List<int> TownInvIDs { get; set; }

        public clsTownLot() {  }
        public clsTownLot(DataRow dr)
        {
            ID = Convert.ToInt32(dr["ID"].ToString());
            TownName = dr["TownName"].ToString();
            TownType = Convert.ToInt32(dr["TownType"].ToString());
            LocationID = Convert.ToInt32(dr["TownLocation"].ToString());
            TownLotNo = Convert.ToInt32(dr["TownLotNo"].ToString());
            Condition = dr["TownCondition"].ToString();
            ImgURL = dr["ImgURL"].ToString();
            TownInvIDs = Program.ParseDelimitedStringToInt(dr["TownInventory"].ToString(), "|");
            ChatterGroup = dr["ChatterGroup"].ToString();
        }
        public clsTownLot ShallowCopy()
        {
            return (clsTownLot)this.MemberwiseClone();
        }
        public void SetButton()
        {

        }
    }
}
