using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace BreadMage2
{
    public class clsEquipment : IEquatable<clsEquipment>
    {
        public int equipID { get; set; }
        public string ItemName { get; set; }
        public int Slot { get; set; } //1 = helm 2=back 3=MH 4=OH 5=ACC, 0 is for all, for an unequip
        public string Stats { get; set; }
        public List<string> ExtraInfo { get; set; } // used for misc info: equip screen to detail effect info (FLV), holding weapon chatter type (CHT)
        public string Description { get; set; }
        public string ImgURL { get; set; }
        public clsSpell EQSpell { get; set; }


        private int PAtkStat { get; set; } = 0;
        private int MAtkStat { get; set; } = 0;
        private int DefStat { get; set; } = 0;
        private int ResStat { get; set; } = 0;
        private int HPStat { get; set; } = 0;
        private int SPStat { get; set; } = 0;
        private int PassiveInt { get; set; } = 0;
        private int CombatInt { get; set; } = 0;

        private List<string> StatData { get; set; }

        public clsEquipment() { }
        public clsEquipment(DataRow dr)
        {
            //  Items.ID, Equipment.ItemName, Equipment.ImgURL, Equipment.HP, Equipment.MP, Equipment.SP, Equipment.Restore

            equipID = Convert.ToInt32(dr["EquipID"].ToString());
            ItemName = dr["ItemName"].ToString();
            Slot = Convert.ToInt32(dr["Slot"].ToString());
            StatData = Program.ParseDelimitedStringToString(dr["Stats"].ToString());
            ExtraInfo = Program.ParseDelimitedStringToString(dr["ExtraInfo"].ToString());
            ImgURL = dr["ImgURL"].ToString();

            //setting stat values from raw StatData
            foreach (string s in StatData)
            {
                //decode action tag "XYZ="
                switch (s.Substring(0, 3))
                {
                    case "PAK": // p attack
                        PAtkStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "MAK": // m attack
                        MAtkStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "DEF": // def
                        DefStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "RES": // res
                        ResStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "HPM": //HP Max
                        HPStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "SPM": //SP Max
                        SPStat = Convert.ToInt32(s.Substring(4));
                        break;
                    case "PID": //passive ID - this is the SPELL ID
                        PassiveInt = Convert.ToInt32(s.Substring(4));
                        break;
                    case "CID": //Combat ID - this is the SPELL ID
                        CombatInt = Convert.ToInt32(s.Substring(4));
                        break;
                    default:
                        break;
                }
            }
        }

        public int PAtk() { return PAtkStat; }
        public int MAtk() { return MAtkStat; }
        public int Def() { return DefStat; }
        public int Res() { return ResStat; }
        public int HP() { return HPStat; }
        public int SP() { return SPStat; }
        public int PassiveEffect() { return PassiveInt; }
        public int CombatSkill() { return CombatInt; }

        public string getStatInfoForTextBox()
        {
            string s = "";
            if (StatData != null)
                { foreach (string t in StatData) { s += Environment.NewLine + t; } }
            return s;
        }

        

        // this is definitely stolen from
        //docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-5.0
        //stackoverflow.com/questions/9854917/how-can-i-find-a-specific-element-in-a-listt
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            clsEquipment objAsEquipment = obj as clsEquipment;
            if (objAsEquipment == null) return false;
            else return Equals(objAsEquipment);
        }

        public override int GetHashCode()
        {
            return equipID;
        }

        public bool Equals(clsEquipment other)
        {
            if (other == null) return false;
            return (this.equipID.Equals(other.equipID));
        }
    }
}
