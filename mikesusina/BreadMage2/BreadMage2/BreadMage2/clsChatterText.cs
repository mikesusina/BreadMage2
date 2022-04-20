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
        public int iSlot = 1;
        public Color ChatColor { get; set; } = Color.White;
        public bool NewLineFlag { get; set; } = true;

        public int iDamage = 0;
        public int iTick = 0;
        public string chatType = "N";
        public string speaker = "none";



        public System.Windows.Forms.Panel ActionPanel = new System.Windows.Forms.Panel() { Size = new Size(250, 75) };
        public System.Windows.Forms.PictureBox pbActionIcon = new System.Windows.Forms.PictureBox();
        public System.Windows.Forms.RichTextBox rtbActionText = new System.Windows.Forms.RichTextBox();

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

        public Color GetColor()
        {
            Color c = new Color();

            switch (chatType.ToLower())
            {
                case "mold":
                    c = Color.LimeGreen;
                    break;
                case "zest":
                    c = Color.DarkOrange;
                    break;
                case "tension":
                    c = Color.Plum;
                    break;
                case "stun":
                    c = Color.LightCoral;
                    break;
                case "charge":
                    c = Color.MediumSeaGreen;
                    break;
                case "restore":
                    c = Color.PeachPuff;
                    break;
                case "physical":
                    c = Color.Red;
                    break;
                case "magic":
                    c = Color.DeepSkyBlue;
                    break;
                default:
                    c = Color.White;
                    break;
            }
            return c;
        }

        public string GetValueChatter()
        {
            string sValue = "";
            if (iDamage != 0)
            {
                sValue += iDamage.ToString();
                if (iDamage < 0) { sValue += " restored"; }
                else { sValue += " damage"; }
            }
            return sValue;
        }


        public string GetTickChatter()
        {
            string sTick = "";
            if (iTick != 0)
            {
                if (iTick > 0) { sTick += "+"; }
                sTick += iTick.ToString() + $" {(chatType)}";
            }
            return sTick;
        }

        public void ClearDamageInfo()
        {
            iDamage = 0;
            iTick = 0;
            chatType = "none";
        }
        public void UpdateDamageInfo(int someDamage, int someTick = 0, string someType = "N")
        {
            iDamage = someDamage;
            iTick = someTick;
            chatType = someType;
        }

    }

    public class MonsterChatter : clsChatterText
    {
        public int iMonID { get; set; }
        //public string chatType { get; set; } = "N";

        public MonsterChatter(string someText, int anID = 0, Color? cColor = null) 
        {
            if (cColor != null) { ChatColor = (Color)cColor; }
            else { ChatColor = Color.White; }
            iMonID = anID;
            NewLineFlag = true;
            ChatText = someText;

            //if (iType != 3 && iType != 4) { sDamage = someDamage.ToString() + " damage"; }
        }

        public MonsterChatter(string someText, string someType, int anID = 0)
        {
            iMonID = anID;
            NewLineFlag = true;
            ChatText = someText;
            chatType = someType;

            //if (iType != 3 && iType != 4) { sDamage = someDamage.ToString() + " damage"; }
        }

        public bool IsDamageless()
        {
            bool b = false;
            if (chatType == "stun" || chatType == "miss"|| chatType == "defend") { b = true; }
            return b;

        }
    }

    public class EffectChatter : clsChatterText
    {

        //speaker type: 1 = mage only, 2 = monster only 3 = shared
        public int SpeakerType { get; set; } = 3;
        public string EffType { get; set; } = "N";

        public EffectChatter(string sText, string anEffType, bool bFlag = true, int aSpeakerFlag = 3)
        {
            ChatText = sText;
            NewLineFlag = bFlag;
            EffType = anEffType;
            SpeakerType = aSpeakerFlag;
        }
    }

    public class WeaponChatter : clsChatterText
    {
        public string SubType { get; set; }

        public WeaponChatter() { }
        public WeaponChatter(string sText, string aSubType, bool bFlag = true)
        {


            ChatText = sText;
            if (aSubType.ToLower() == "mold") { ChatColor = System.Drawing.Color.LimeGreen; }
            else if (aSubType.ToLower() == "zest") { ChatColor = System.Drawing.Color.DarkGoldenrod; }
            else if (aSubType.ToLower() == "tension") { ChatColor = System.Drawing.Color.Orange; }
            else if (aSubType.ToLower() == "magic") { ChatColor = System.Drawing.Color.DeepSkyBlue; }
            else { ChatColor = System.Drawing.Color.Red; }
            NewLineFlag = bFlag;
        }
    }

    public class SpellChatter : clsChatterText
    {
        public string SpellType { get; set; } = "D";
        public string Target { get; set; }
        public string Element { get; set; }

        public SpellChatter() { }

        public SpellChatter(string sText, string aSpellType, string aTarget, string anElement, bool bFlag = true)
        {
            DecodeType(aSpellType, anElement);
            ChatText = sText;
            SpellType = aSpellType;
            Target = aTarget;
            Element = anElement;
            NewLineFlag = bFlag;
        }
        private void DecodeType(string aSpellType, string anElement)
        {
            //spells work a little wonky compared to other types
            if (anElement == "M") { ChatColor = System.Drawing.Color.LimeGreen; }
            else if(anElement == "Z") { ChatColor = System.Drawing.Color.DarkGoldenrod; }
            else if (anElement == "T") { ChatColor = System.Drawing.Color.Orange; }

            else if (aSpellType== "C") { ChatColor = System.Drawing.Color.Red; }
            else if (anElement == "B") { ChatColor = System.Drawing.Color.OldLace; }

            else { ChatColor = System.Drawing.Color.White; }

        }
    }

    public class DamageInfoChatter : clsChatterText
    {

        public DamageInfoChatter()
        {

        }
        public DamageInfoChatter(int someDamage, int someTick)
        {
            iDamage = someDamage;
            iTick = someTick;
        }

    }
}
