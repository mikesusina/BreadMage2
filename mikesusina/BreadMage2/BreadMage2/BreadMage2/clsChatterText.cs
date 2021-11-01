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

        public Color GetColor(string someType)
        {
            Color c = new Color();

            switch (someType)
            {
                case "M": //mold
                    c = Color.LimeGreen;
                    break;
                case "Z": //zest
                    c = Color.DarkOrange;
                    break;
                case "T": //tension
                    c = Color.Plum;
                    break;
                case "S": //stun
                    c = Color.LightCoral;
                    break;
                case "H": //charge
                    c = Color.MediumSeaGreen;
                    break;
                case "R": //restore
                    c = Color.PeachPuff;
                    break;
                case "D": //pdamage
                    c = Color.Red;
                    break;
                case "G": //ma[G]ic damage
                    c = Color.DeepSkyBlue;
                    break;
                default:
                    c = Color.White;
                    break;
            }
            return c;
        }
        public string GetTypeString(string someType)
        {
            switch (someType)
            {
                case "M": //mold
                    return "Mold";
                case "Z": //zest
                    return "Zest";
                case "T": //tension
                    return "Tension";
                case "S": //stun
                    return "Stun";
                case "H": //charge
                    return "Charge";
                case "R": //restore
                    return "Restore";
                case "D": //pdamage
                    return "Damage";
                case "G": //ma[G]ic damage
                    return "Damage";
                default:
                    return "none";
            }
        }

    }

    public class MonsterChatter : clsChatterText
    {
        public int iType { get; set; } = 1;
        public string EffType { get; set; } = "N";

        public MonsterChatter(string someText, Color? cColor = null) 
        {
            if (cColor != null) { ChatColor = (Color)cColor; }
            else { ChatColor = Color.White; }
            NewLineFlag = true;
            ChatText = someText;

            //if (iType != 3 && iType != 4) { sDamage = someDamage.ToString() + " damage"; }
        }

        public MonsterChatter(string someText, int someType, Color? cColor = null)
        {
            if (cColor != null) { ChatColor = (Color)cColor; }
            else { setMonsterColor(someType); }
            iType = someType;
            NewLineFlag = true;
            ChatText = someText;

            //if (iType != 3 && iType != 4) { sDamage = someDamage.ToString() + " damage"; }
        }

        public bool IsDamageless()
        {
            bool b = false;
            if (iType == 8|| iType == 3|| iType == 4) { b = true; }
            return b;

        }

        private void setMonsterColor(int someType)
        {
            string sType = "N";
            switch (someType)
            {
                case 1: //patk
                    sType = "D";
                    break;
                case 2: //matk
                    sType = "G";
                    break;
                case 3: // miss
                    sType = "N";
                    break;
                case 4: // defend
                    sType = "N";
                    break;
                case 5: // mold
                    sType = "M";
                    break;
                case 6: // zest
                    sType = "Z";
                    break;
                case 7: // tension
                    sType = "T";
                    break;
                case 8: // stun
                    sType = "S";
                    break;
                case 9: // charge
                    sType = "H";
                    break;
                case 10: // restore/heal
                    sType = "R";
                    break;
                case 11: //
                    sType = "N";
                    break;
            }
            EffType = sType;
            ChatColor = GetColor(sType);
        }

        public string getMChatTypeInfo()
        {
            string s = "Damage";
            switch (iType)
            {
                case 1: //patk, no element
                    break;
                case 2: //matk, no element
                    break;
                case 3: //miss
                    s = "Miss";
                    break;
                case 4: //defend
                    s = "Block"; //note - parry will need it's own maybe?
                    break;
                case 5: //mold
                    s = "Mold";
                    break;
                case 6: //zest
                    s = "Zest";
                    break;
                case 7: //tension
                    s = "Tension";
                    break;
                case 8: // stun
                    s = "Stun";
                    break;
                case 9: // charge
                    s = "Charge";
                    break;
                case 10: // restore or heal?
                    s = "Heal";
                    break;
                default:
                    s = "Damage";
                    break;
            }
            return s;
        }

    }

    public class EffectChatter : clsChatterText
    {

        //speaker type: 1 = mage only, 2 = monster only 3 = shared
        public int SpeakerType { get; set; } = 3;
        public string EffType { get; set; } = "N";

        public EffectChatter(string sText, string anEffType, Color? cColor = null, bool bFlag = true, int aSpeakerFlag = 3)
        {
            //color override
            if (cColor != null) { ChatColor = (Color)cColor; }
            else { ChatColor = GetColor(anEffType); }
            ChatText = sText;
            NewLineFlag = bFlag;
            EffType = anEffType;
            SpeakerType = aSpeakerFlag;
        }

        public string getEChatTypeInfo()
        {
            switch (EffType)
            {
                case "M":
                    return "Mold";
                case "Z":
                    return "Zest";
                case "T":
                    return "Tension";
                case "Q":
                    return "Quick Attack";
                case "S":
                    return "Stun";
                case "B":
                    return "Block";
                case "P":
                    return "Parry";
                case "L":
                    return "Silence";
                case "H":
                    return "Charge";
                default:
                    return "None";
            }
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

        public string getSChatTypeInfo()
        {
            switch (Element)
                {
                    case "M":
                        return "Mold";
                    case "Z":
                        return "Zest";
                    case "T":
                        return "Tension";
                    case "D":
                        return "Damage";
                    case "B":
                        return "Buff";
                    case "E":
                        return "Heal";
                    default:
                        return "Damage";
            }
        }
    }

    public class DamageInfoChatter : clsChatterText
    {
        public int iDamage = 0;
        public int iTick = 0;
        public string effType = "N";

        public DamageInfoChatter()
        {

        }
        public DamageInfoChatter(int someDamage, int someTick)
        {
            iDamage = someDamage;
            iTick = someTick;
        }

        public void UpdateInfo(int someDamage, int someTick = 0, string someType = "N")
        {
            iDamage = someDamage;
            iTick = someTick;
            effType = someType;
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
                sTick += iTick.ToString() + $" {GetTypeString(effType)}"; }
            return sTick;
        }
        public string GetDamageType()
        {
            string[] Physical = new string[] {"D", "T", "Q", "B", "P"};
            if (iDamage < 0) { return "R"; }
            else if (Physical.Contains(effType)) { return "P"; }
            else return "M";
        }

        //set chat color
        public string GetChatter()
        {
            string s = "";
            string sValue = "";

            if (iDamage != 0)
            {
                sValue += iDamage.ToString();
                if (iDamage < 0) { sValue += " restored"; }
                else { sValue += " damage"; }
            }
            if (iTick != 0)
            {
                if (sValue.Length > 0)
                sValue += iDamage.ToString();
                if (iDamage < 0) { sValue += $" restored"; }
                else { sValue += " damage"; }
            }
            int i = 2;
            i.ToString();
            return $"({s})";
        }

        public void ClearInfo()
        {
            iDamage = 0;
            iTick = 0;
            effType = "N";
        }
    }
}
