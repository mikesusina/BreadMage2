using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreadMage2.Controls
{
    public partial class EquipBoard : UserControl
    {
        private engGame myGame;
        private int acc1;
        private int acc2;
        List<clsEquipment> HelmItems = new List<clsEquipment>();
        List<clsEquipment> BackItems = new List<clsEquipment>();
        List<clsEquipment> MHItems = new List<clsEquipment>();
        List<clsEquipment> OHItems = new List<clsEquipment>();
        List<clsEquipment> AccItems = new List<clsEquipment>();
        List<clsEquipment> PinItems = new List<clsEquipment>();

        clsEquipment eqHelm = new clsEquipment();
        clsEquipment eqBack = new clsEquipment();
        clsEquipment eq1H = new clsEquipment();
        clsEquipment eq2H = new clsEquipment();
        clsEquipment eqAcc = new clsEquipment();
        clsEquipment eqPin = new clsEquipment();

        public EquipBoard(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }

        public void LoadBoard()
        {
            acc1 = 0;
            acc2 = 0;

            HelmItems = new List<clsEquipment>();
            BackItems = new List<clsEquipment>();
            MHItems = new List<clsEquipment>();
            OHItems = new List<clsEquipment>();
            AccItems = new List<clsEquipment>();
            PinItems = new List<clsEquipment>();

            //Have an option for unequipped slot
            clsEquipment e = new clsEquipment { ItemName = "Unequipped", Stats = "", equipID = 0, ImgURL = "itsnothing" };

            HelmItems.Add(e);
            BackItems.Add(e);
            MHItems.Add(e);
            OHItems.Add(e);
            AccItems.Add(e);
            PinItems.Add(e);

            //get all equipment objects mage has:
            List<int> gottenEquips = myGame.getObtainedEquipmentIDs();
            foreach (int i in gottenEquips)
            {
                clsEquipment cItem = myGame.GetEquipmentItem(i);
                switch (cItem.Slot)
                {
                    case 1:
                        HelmItems.Add(cItem);
                        break;
                    case 2:
                        BackItems.Add(cItem);
                        break;
                    case 3:
                        MHItems.Add(cItem);
                        break;
                    case 4: //2H weapons and off hand stuff need some work
                        OHItems.Add(cItem);
                        break;
                    case 5: //accessories
                        AccItems.Add(cItem);
                        break;
                    case 6: //Lapel pin
                        PinItems.Add(cItem);
                        break;
                }
            }

            //set the boxes to the equipped items
            /*
            try
            {
            */
            cbHelm.DataSource = HelmItems;
            cbHelm.DisplayMember = "ItemName";
            cbBack.DataSource = BackItems;
            cbBack.DisplayMember = "ItemName";
            cb1H.DataSource = MHItems;
            cb1H.DisplayMember = "ItemName";
            cb2H.DataSource = OHItems;
            cb2H.DisplayMember = "ItemName";
            cbAcc1.DataSource = AccItems;
            cbAcc1.DisplayMember = "ItemName";
            cbAcc2.DataSource = PinItems;
            cbAcc2.DisplayMember = "ItemName";

            if (myGame.gMage.myEquipBySlot(1) != null)
            {
                cbHelm.SelectedItem = myGame.gMage.myEquipBySlot(1);
                eqHelm = cbHelm.SelectedItem as clsEquipment;
            }
            else { cbHelm.SelectedIndex = 0; }
            if (myGame.gMage.myEquipBySlot(2) != null)
            {
                cbBack.SelectedItem = myGame.gMage.myEquipBySlot(2);
                eqBack = cbBack.SelectedItem as clsEquipment;
            }
            else { cbBack.SelectedIndex = 0; }
            if (myGame.gMage.myEquipBySlot(3) != null)
            {
                cb1H.SelectedItem = myGame.gMage.myEquipBySlot(3);
                eq1H = cb1H.SelectedItem as clsEquipment;
            }
            else { cb1H.SelectedIndex = 0; }
            if (myGame.gMage.myEquipBySlot(4) != null)
            {
                cbHelm.SelectedItem = myGame.gMage.myEquipBySlot(4);
                eq2H = cb2H.SelectedItem as clsEquipment;
            }
            else { cb2H.SelectedIndex = 0; }
            if (myGame.gMage.myEquipBySlot(5) != null)
            {
                cbAcc1.SelectedItem = myGame.gMage.myEquipBySlot(5);
                eqAcc = cbAcc1.SelectedItem as clsEquipment;
            }
            else { cbAcc1.SelectedIndex = 0; }
            if (myGame.gMage.myEquipBySlot(6) != null)
            {
                cbAcc2.SelectedItem = myGame.gMage.myEquipBySlot(6);
                eqPin = cbAcc2.SelectedItem as clsEquipment;
            }
            else { cbAcc2.SelectedIndex = 0; }

            /*
            cbAcc2.SelectedItem = myGame.gMage.Stats.CurrentEquipment().Find(x => x.Slot == 5);
            if (cbAcc2.SelectedItem != null) { eqAcc2 = cbAcc2.SelectedItem as clsEquipment;
            */

            //set the images
            if (cbHelm.SelectedItem != null)
            {
                pbHelm.Image = GetEquipImage(cbHelm.SelectedItem as clsEquipment);
                pbHelm.Show();
                lblHelm.Text = "Hat: " + (cbHelm.SelectedItem as clsEquipment).ItemName;
            }
            if (cbBack.SelectedItem != null)
            {
                pbBack.Image = GetEquipImage(cbBack.SelectedItem as clsEquipment);
                pbBack.Show();
                lbBack.Text = "Cloak: " + (cbBack.SelectedItem as clsEquipment).ItemName;
            }
            if (cb1H.SelectedItem != null)
            {
                pb1H.Image = GetEquipImage(cb1H.SelectedItem as clsEquipment);
                pb1H.Show();
                lb1H.Text = "Main Hand: " + (cb1H.SelectedItem as clsEquipment).ItemName;
            }
            if (cb2H.SelectedItem != null)
            {
                pb2H.Image = GetEquipImage(cb2H.SelectedItem as clsEquipment);
                pb2H.Show();
                lb2H.Text = "Off Hand: " + (cb2H.SelectedItem as clsEquipment).ItemName;
            }
            if (cbAcc1.SelectedItem != null)
            {
                pbAcc1.Image = GetEquipImage(cbAcc1.SelectedItem as clsEquipment);
                pbAcc1.Show();
                lbAcc1.Text = "Accessory: " + (cbAcc1.SelectedItem as clsEquipment).ItemName;
            }
            if (cbAcc2.SelectedItem != null)
            {
                pbAcc2.Image = GetEquipImage(cbAcc2.SelectedItem as clsEquipment);
                pbAcc2.Show();
                lbAcc2.Text = "Lapel Pin: " + (cbAcc2.SelectedItem as clsEquipment).ItemName;
            }
            /*
        }
        catch { throw new ArgumentOutOfRangeException("Setting the equipment boxes"); };
            */
            clearBoxes();
        }

        private void addToEquipList(clsEquipment anItem)
        {
            if (anItem.ItemName != "Unequipped")
            {

            }
        }


        private void clearBoxes()
        {
            rtbDescription.Clear();
            rtbSelectedStats.Clear();
            rtbEquippedStats.Clear();
            pbEquipped.Image = null;
            pbSelected.Image = null;
        }

        private Image GetEquipImage(clsEquipment anItem)
        {
            if (anItem.ImgURL != null && anItem.ImgURL != "")
            {
            object o = Properties.Resources.ResourceManager.GetObject(anItem.ImgURL);
            if (o is Image) { return o as Image; }
            else return Properties.Resources.bomb;
            }
            else return Properties.Resources.bomb;
        }

        private void cbHelm_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBoxes();
            if (cbHelm.SelectedIndex != -1)
            {
                clsEquipment anItem = cbHelm.SelectedItem as clsEquipment;
                buildDescBoxes(anItem, eqHelm);
                /*
                if (anItem != eqHelm)
                {
                    rtbDescription.Text = anItem.Description;
                    rtbSelectedStats.Text = anItem.Stats;
                    pbSelected.Image = GetEquipImage(anItem);
                    rtbEquippedStats.Text = eqHelm.getStatInfo();
                    pbEquipped.Image = GetEquipImage(eqHelm);
                    pbSelected.Show();
                    pbEquipped.Show();

                    lbSelected.Text = "Selected: " + anItem.ItemName;
                    lbEquipped.Text = "Equipped: " + eqHelm.ItemName;
                }
                else
                {
                    rtbEquippedStats.Text = eqHelm.getStatInfo();
                    pbEquipped.Image = GetEquipImage(eqHelm);
                    pbEquipped.Show();
                }
               */
            }
        }

        private void cbBack_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBoxes();
            if (cbBack.SelectedIndex != -1)
            {
                clsEquipment anItem = cbBack.SelectedItem as clsEquipment;
                if (anItem != eqBack)
                {
                    rtbDescription.Text = getEquipDescription(anItem);
                    rtbSelectedStats.Text = anItem.Stats;
                    pbSelected.Image = GetEquipImage(anItem);
                    rtbEquippedStats.Text = eqBack.getStatInfoForTextBox();
                    pbEquipped.Image = GetEquipImage(eqBack);
                    pbSelected.Show();
                    pbEquipped.Show();

                    lbSelected.Text = "Selected: " + anItem.ItemName;
                    lbEquipped.Text = "Equipped: " + eqBack.ItemName;
                }
                else
                {
                    rtbEquippedStats.Text = eqBack.getStatInfoForTextBox();
                    pbEquipped.Image = GetEquipImage(eqBack);
                    pbEquipped.Show();
                }
            }
        }

        private void cb1H_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBoxes();
            if (cb1H.SelectedIndex != -1)
            {
                clsEquipment anItem = cb1H.SelectedItem as clsEquipment;
                buildDescBoxes(anItem, eq1H);
                /*
                if (anItem != eq1H)
                {
                    rtbDescription.Text = anItem.Description;
                    rtbSelectedStats.Text = anItem.Stats;
                    pbSelected.Image = GetEquipImage(anItem);
                    rtbEquippedStats.Text = eq1H.getStatInfo();
                    pbEquipped.Image = GetEquipImage(eq1H);
                    pbSelected.Show();
                    pbEquipped.Show();

                    lbSelected.Text = "Selected: " + anItem.ItemName;
                    lbEquipped.Text = "Equipped: " + eq1H.ItemName;
                }
                else
                {
                    rtbEquippedStats.Text = eq1H.getStatInfo();
                    pbEquipped.Image = GetEquipImage(eq1H);
                    pbEquipped.Show();
                }
                */
            }
        }

        private void cb2H_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBoxes();
            if (cb2H.SelectedIndex != -1)
            {
                clsEquipment anItem = cb2H.SelectedItem as clsEquipment;
                if (anItem != eq2H)
                {
                    rtbDescription.Text = getEquipDescription(anItem);
                    rtbSelectedStats.Text = anItem.Stats;
                    pbSelected.Image = GetEquipImage(anItem);
                    rtbEquippedStats.Text = eq2H.getStatInfoForTextBox();
                    pbEquipped.Image = GetEquipImage(eq2H);
                    pbSelected.Show();
                    pbEquipped.Show();

                    lbSelected.Text = "Selected: " + anItem.ItemName;
                    lbEquipped.Text = "Equipped: " + eq2H.ItemName;
                }
                else
                {
                    rtbEquippedStats.Text = eq2H.getStatInfoForTextBox();
                    pbEquipped.Image = GetEquipImage(eq2H);
                    pbEquipped.Show();
                }
            }
        }

        private void cbAcc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBoxes();
            if (cbAcc1.SelectedIndex != -1)
            {
                clsEquipment anItem = cbAcc1.SelectedItem as clsEquipment;
                if (anItem != eqAcc)
                {
                    rtbDescription.Text = getEquipDescription(anItem);
                    rtbSelectedStats.Text = anItem.Stats;
                    pbSelected.Image = GetEquipImage(anItem);
                    rtbEquippedStats.Text = eqAcc.getStatInfoForTextBox();
                    pbEquipped.Image = GetEquipImage(eqAcc);
                    pbSelected.Show();
                    pbEquipped.Show();

                    lbSelected.Text = "Selected: " + anItem.ItemName;
                    lbEquipped.Text = "Equipped: " + eqAcc.ItemName;
                }
                else
                {
                    rtbEquippedStats.Text = eqAcc.getStatInfoForTextBox();
                    pbEquipped.Image = GetEquipImage(eqAcc);
                    pbEquipped.Show();
                }
            }
        }

        private void cbAcc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearBoxes();
            if (cbAcc2.SelectedIndex != -1)
            {
                clsEquipment anItem = cbAcc2.SelectedItem as clsEquipment;
                if (anItem != eqPin)
                {
                    rtbDescription.Text = getEquipDescription(anItem);
                    rtbSelectedStats.Text = anItem.Stats;
                    pbSelected.Image = GetEquipImage(anItem);
                    rtbEquippedStats.Text = eqPin.getStatInfoForTextBox();
                    pbEquipped.Image = GetEquipImage(eqPin);
                    pbSelected.Show();
                    pbEquipped.Show();

                    lbSelected.Text = "Selected: " + anItem.ItemName;
                    lbEquipped.Text = "Equipped: " + eqPin.ItemName;
                }
                else
                {
                    rtbEquippedStats.Text = eqPin.getStatInfoForTextBox();
                    pbEquipped.Image = GetEquipImage(eqPin);
                    pbEquipped.Show();
                }
            }
        }


        private void buildDescBoxes(clsEquipment selected, clsEquipment current)
        {
            lbSelected.Text = "Selected: " + selected.ItemName;
            lbEquipped.Text = "Equipped: " + current.ItemName;
            pbSelected.Image = GetEquipImage(selected);
            pbSelected.Show();
            pbEquipped.Image = GetEquipImage(current);
            pbEquipped.Show();


            //  HP
            //  SP
            //  P.ATK:
            //  M.ATK:
            //  DEF: 
            //  RES:
            //  Effect:

            // stat: (i)

            buildStatLine(rtbSelectedStats, "HP", selected.HP());
            buildStatLine(rtbSelectedStats, "SP", selected.SP());
            buildStatLine(rtbSelectedStats, "PAK", selected.PAtk());
            buildStatLine(rtbSelectedStats, "MAK", selected.MAtk());
            buildStatLine(rtbSelectedStats, "DEF", selected.Def());
            buildStatLine(rtbSelectedStats, "RES", selected.Res());
            buildEffectLine(rtbSelectedStats, selected);

            if (current == selected) { rtbEquippedStats.Text = rtbSelectedStats.Text; }
            else
            {
                buildStatLine(rtbEquippedStats, "HP", current.HP(), selected.HP());
                buildStatLine(rtbEquippedStats, "SP", current.SP(), selected.SP());
                buildStatLine(rtbEquippedStats, "PAK", current.PAtk(), selected.PAtk());
                buildStatLine(rtbEquippedStats, "MAK", current.MAtk(), selected.MAtk());
                buildStatLine(rtbEquippedStats, "DEF", current.Def(), selected.Def());
                buildStatLine(rtbEquippedStats, "RES", current.Res(), selected.Res());
                buildEffectLine(rtbEquippedStats, current);
            }

            rtbDescription.Text = getEquipDescription(selected);
        }

        private string getEquipDescription(clsEquipment anItem)
        { 
            if (anItem.equipID != 0 && myGame.flopEquipforUnique(anItem).Description != "")
            {
                return myGame.flopEquipforUnique(anItem).Description;
            }
            else return "";
        }

        private void buildStatLine(RichTextBox entryBox, string sStat, int iVal, int compareVal = 0)
        {
            int difVal = 0;
            Color valColor = Color.Red;
            string sDif = "";
            if (iVal == 0 && compareVal == 0) { return; }
            else
            {
                if (entryBox.TextLength > 0) { entryBox.AppendText(Environment.NewLine); }
                if (entryBox.Name == "rtbEquippedStats")
                {
                    difVal = compareVal - iVal;
                    sDif = " (";
                    if (difVal > 0)
                    {
                        valColor = Color.LimeGreen;
                        sDif += "+";
                    }
                    sDif += difVal.ToString() + ")";
                }
                switch (sStat)
                {
                    case "HP":
                        entryBox.AppendText("Max HP: " + iVal.ToString());
                        break;
                    case "SP":
                        entryBox.AppendText("Max SP: " + iVal.ToString());
                        break;
                    case "PAK":
                        entryBox.AppendText("P.Atk: " + iVal.ToString());
                        break;
                    case "MAK":
                        entryBox.AppendText("M.Atk: " + iVal.ToString());
                        break;
                    case "DEF":
                        entryBox.AppendText("Def: " + iVal.ToString());
                        break;
                    case "RES":
                        entryBox.AppendText("Res: " + iVal.ToString());
                        break;
                }
                if (sDif != "")
                {
                    entryBox.SelectionColor = valColor;
                    entryBox.AppendText(sDif);
                    entryBox.SelectionColor = Color.White;
                }
            }
        }

        private string buildEffectLine(RichTextBox entryBox, clsEquipment anEquip)
        {
            if (anEquip.ExtraInfo != null && anEquip.ExtraInfo.Find(x => x.Substring(0, 4) == "FLV=") != null)
            { return (anEquip.ExtraInfo.Find(x => x.Substring(0, 4) == "FLV=").Substring(4)); }
            else return "";
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Equip this stuff?", "Equip", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<clsEquipment> newEquip = new List<clsEquipment>();
                List<ComboBox> comboBoxes = new List<ComboBox>() { cbHelm, cbBack, cb1H, cb2H, cbAcc1, cbAcc2 };
                foreach (ComboBox b in comboBoxes)
                {
                    if ((b.SelectedItem as clsEquipment).equipID != 0) { newEquip.Add(b.SelectedItem as clsEquipment); }
                }
                myGame.EquipItemSet(newEquip);
                myGame.RefreshMage();
                this.Hide();

                if (myGame.gActiveStore != null)
                {
                    this.Hide();
                    myGame.BackToStore();
                }
                else
                {
                    myGame.gLock = false;
                    this.Hide();
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Get out of here?", "Cancel", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (myGame.gActiveStore != null)
                {
                    this.Hide();
                    myGame.BackToStore();
                }
                else
                {
                    myGame.gLock = false;
                    this.Hide();
                }
            }
        }

    }
}
