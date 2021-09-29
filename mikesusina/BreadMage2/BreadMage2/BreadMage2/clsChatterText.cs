using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BreadMage2
{
    public class clsChatterText
    {
        public string ChatText { get; set; } = "";
        public Color ChatColor { get; set; } = Color.White;
        public bool NewLineFlag { get; set; } = true;

        public clsChatterText()
        {

        }

        public clsChatterText(string sText, Color? cColor = null, bool bFlag = true)
        {
            if (cColor != null) { ChatColor = (Color)cColor; }
            else { ChatColor = Color.White; }
            ChatText = sText;
            NewLineFlag = bFlag;
        }

    }

    public class BattleChatter : clsChatterText
    {
        public string sPreDmgText = "";
        public string sPostDmgText = "";
        public int iType { get; set; } = 1;

        public BattleChatter(string sText, Color? cColor = null, bool bFlag = true) 
        {
            if (cColor != null) { ChatColor = (Color)cColor; }
            else { ChatColor = Color.White; }
            ChatText = sText;

            //if (iType != 3 && iType != 4) { sDamage = someDamage.ToString() + " damage"; }
        }

        public bool IsDamageless()
        {
            bool b = false;
            if (iType == 8|| iType == 3|| iType == 4) { b = true; }
            return b;

        }

    }

    public class EffectChatter : clsChatterText
    {

        //speaker type: 1 = mage only, 2 = monster only 3 = shared
        public int SpeakerType { get; set; } = 3;
        public string EffType { get; set; } = "NN";
        public string sPreText = "";
        public string sPostText = "";

        public EffectChatter(string sText, Color? cColor = null, bool bFlag = true, string anEffType = "NN", int aSpeakerFlag = 3 )
        {
            if (cColor != null) { ChatColor = (Color)cColor; }
            else { ChatColor = Color.White; }
            ChatText = sText;
            EffType = anEffType;
            SpeakerType = aSpeakerFlag;

            string s = ChatText;
            if (s.IndexOf("|") > 0)
            {
                sPreText = s.Substring(0, s.IndexOf("|"));
                sPostText = s.Substring(s.IndexOf("|") + 1);
            }
            switch (EffType)
            {
                case "MP": //mold
                    ChatColor = System.Drawing.Color.LimeGreen;
                    break;
                case "ZC": //zest
                    ChatColor = System.Drawing.Color.DarkGoldenrod;
                    break;
                case "TS": //tension/pinata
                    ChatColor = System.Drawing.Color.Orange;
                    break;
                /*
                case "": 
                    ChatColor = System.Drawing.Color.White;
                    break;
                case "": 
                    ChatColor = System.Drawing.Color.Green;
                    break;
                case "": 
                    ChatColor = System.Drawing.Color.DarkOrange;
                    break;
                case "": 
                    ChatColor = System.Drawing.Color.LightCoral;
                    break;
                 */
                case "NN": // none
                    ChatColor = System.Drawing.Color.White;
                    break;
            }
        }
    }

    public class SpellChatter : clsChatterText
    {

    }
}
