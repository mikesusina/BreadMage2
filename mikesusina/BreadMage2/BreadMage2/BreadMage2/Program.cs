using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BreadMage2.Screens;
using System.Data.OleDb;

namespace BreadMage2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }


        public static System.Drawing.Image GetImage(string ImgURL)
        {
            if (ImgURL != "")
            {
                object o = Properties.Resources.ResourceManager.GetObject(ImgURL);
                if (o is System.Drawing.Image) { return o as System.Drawing.Image; }
                else return Properties.Resources.bomb;
            }
            else return Properties.Resources.bomb;
        }
        public static List<int> ParseDelimitedStringToInt(string rawData, string delimiter = "|")
        {
            List<int> returnList = new List<int>();

            string s = rawData;
            while (s.IndexOf("|") > 0)
            {
                int temp = Convert.ToInt32(s.Substring(0, s.IndexOf("|")));
                returnList.Add(temp);
                s = s.Substring(s.IndexOf("|") + 1);
            }
            if (s != "") { returnList.Add(Convert.ToInt32(s)); }

            return returnList;
        }
        public static List<string> ParseDelimitedStringToString(string rawData, string delimiter = "|")
        {
            List<string> returnList = new List<string>();

            string s = rawData;
            while (s.IndexOf("|") > 0)
            {
                string temp = s.Substring(0, s.IndexOf("|"));
                returnList.Add(temp);
                s = s.Substring(s.IndexOf("|") + 1);
            }
            if (s != "") { returnList.Add(s); }

            return returnList;
        }

        public static List<clsSpell> FilterSpellsByType(List<clsSpell> fullList, string sType)
        {
            List<clsSpell> returnList = new List<clsSpell>();

            switch (sType)
            {
                case "all":
                    returnList = fullList;
                    break;
                case "combat": //in-[C]ombat ONLY spells
                    returnList = fullList.FindAll(x => x.spellType == "C");
                    break;
                case "passive": //[P]assive
                    returnList = fullList.FindAll(x => x.spellType == "P");
                    break;
                case "global": //[G]eneral/global / "out of/in combat castable"
                    returnList = fullList.FindAll(x => x.spellType == "G");
                    break;
                case "castonly": //[O]nly castable from the "cast" screen (set up spells and buffs that you can't enable in combat)
                    returnList = fullList.FindAll(x => x.spellType == "O");
                    break;
                case "battle": //castable spells for the combat screen
                    returnList.AddRange(fullList.FindAll(x => x.spellType == "C"));
                    returnList.AddRange(fullList.FindAll(x => x.spellType == "G"));
                    break;
                case "spellequip": //all non item and passive spells
                    returnList.AddRange(fullList.FindAll(x => x.spellType == "C"));
                    returnList.AddRange(fullList.FindAll(x => x.spellType == "G"));
                    returnList.AddRange(fullList.FindAll(x => x.spellType == "O"));
                    break;
                case "item": //[I]tem spells
                    returnList.AddRange(fullList.FindAll(x => x.spellType == "I"));
                    break;
                case "noitems": //[I]tem spells
                    returnList.AddRange(fullList.FindAll(x => x.spellType != "I"));
                    break;
                case "mold": //mold-tuned spells, for filtering
                             // ********
                             //todo: change this to searching for spellblock info!
                    returnList.AddRange(fullList.FindAll(x => x.chatType == "M"));
                    break;
                case "zest": //ditto, but zest
                    returnList.AddRange(fullList.FindAll(x => x.spellType == "Z"));
                    break;
                case "tension": //ditto but tension
                    returnList.AddRange(fullList.FindAll(x => x.spellType == "T"));
                    break;
            }

            return returnList;
        }
    }

    
}


/* this this might be useful later
namespace Meows
{
    static class Meowgram
    {
        public static string aMeow()
        {
            return "S";
        }
    }
}
*/