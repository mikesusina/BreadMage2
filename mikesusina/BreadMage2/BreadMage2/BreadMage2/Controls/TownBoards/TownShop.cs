using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;



namespace BreadMage2
{
    public partial class TownShop : UserControl
    {
        /// <summary>
        /// USE THIS FOR ITEMS AND EQUIPMENT (as separate shops)
        /// USE A DIFFERENT FRONT FOR SPELLS
        /// </summary>

        private engGame myGame;
        public BindingSource shopInv = new BindingSource();
        public BindingSource secondaryInv = new BindingSource();
        private clsTownLot activeStore => myGame.TownEngine.activeStore;
        private int shopType => myGame.TownEngine.activeStore.TownType;


        public TownShop(engGame aGame)
        {
            InitializeComponent();
            myGame = aGame;
        }


        public void PopulateStock()
        {
            lblYeast.Text = "Yeast:" + Environment.NewLine + myGame.gMage.Stats.Yeast.ToString();
            radioAbout.Checked = true;
            lbShopInventory.DataSource = shopInv;
            switch (shopType)
            {
                case 1:
                    lbShopInventory.DisplayMember = "ItemName";
                    gbInventory.Enabled = false;
                    gbInventory.Hide();
                    break;
                case 2:
                    lbShopInventory.DisplayMember = "spellName";
                    gbInventory.Enabled = true;
                    gbInventory.Show();
                    radioStock.Checked = true;
                    break;
            }
        }



        public void SetGenericText()
        {
            switch (shopType)
            {
                case 1:
                    gbInventory.Enabled = false;
                    break;
                case 2:
                    radioGeneric.Text = "Components";
                    break;

            }
        }

        

        private void lbShopInventory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lbShopInventory.SelectedItem != null)
            { 
                rtbSelectedInfo.Clear();
                if (lbShopInventory.SelectedItem is clsUniqueItem)
                {
                    tbAmount.Text = (lbShopInventory.SelectedItem as clsUniqueItem).Yeast.ToString();
                    rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsUniqueItem).Description);
                }
                else if (lbShopInventory.SelectedItem is clsSpell)
                {
                    tbAmount.Text = (lbShopInventory.SelectedItem as clsSpell).YeastCost.ToString();
                    rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsSpell).spellDescription);
                }
                //add to chatter box
            }
        }

        private void lbShopInventory_Enter(object sender, System.EventArgs e)
        {
            if (lbShopInventory.Focused && lbShopInventory.SelectedItem != null)
            {
                rtbSelectedInfo.Clear();
                if (lbShopInventory.SelectedItem is clsUniqueItem)
                {
                    tbAmount.Text = (lbShopInventory.SelectedItem as clsUniqueItem).Yeast.ToString();
                    rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsUniqueItem).Description);
                }
                else if (lbShopInventory.SelectedItem is clsSpell)
                {
                    tbAmount.Text = (lbShopInventory.SelectedItem as clsSpell).YeastCost.ToString();
                    rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsSpell).spellDescription);
                }
            }
        }

        private void btnContinue_Click(object sender, System.EventArgs e)
        {
            if (lbShopInventory.SelectedItem != null)
            {
                if (lbShopInventory.SelectedItem is clsUniqueItem)
                {
                    bool b = myGame.BuyItem(lbShopInventory.SelectedItem as clsUniqueItem);
                    if (!b) { MessageBox.Show("You don't have the stuff to make the dough!"); }
                    else
                    {
                        myGame.bMage.UpdateBars();
                        lblYeast.Text = myGame.gMage.Stats.Yeast.ToString();
                    }
                }
                else if (lbShopInventory.SelectedItem is clsSpell)
                {
                    bool b = myGame.BuySpell(lbShopInventory.SelectedItem as clsSpell);
                    if (!b) { MessageBox.Show("You don't have the stuff to make the dough!"); }
                    else
                    {
                        shopInv.Remove(lbShopInventory.SelectedItem);
                        shopInv.ResetBindings(false);
                        myGame.bMage.UpdateBars();
                        lblYeast.Text = myGame.gMage.Stats.Yeast.ToString();
                    }
                    /* BUYING A SPELL
                    tbAmount.Text = (lbShopInventory.SelectedItem as clsSpell).YeastCost.ToString();
                    rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsSpell).spellDescription);
                    */
                }

                

            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            myGame.gActiveStore = null;
            this.Hide();
        }


        private void radioSelectedText_CheckChanged(object sender, EventArgs e)
        {
            RadioButton b = sender as RadioButton;

            if (b.Focused && b.Checked)
            {
                rtbSelectedInfo.Clear();
                if (lbShopInventory.SelectedItem != null)
                {
                    if (b == radioInfo)
                    {
                        if (shopType == 1) //equip
                        {
                            //make text box the stats
                            //rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsUniqueItem).Description);

                        }
                        else if (shopType == 2) //spells
                        {
                            if (radioStock.Checked)
                            {
                                //make the text box the spell effects?
                                //rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsSpell).spellDescription);
                            }
                        }
                    }
                    else if (b == radioAbout)
                    {
                        if (shopType == 1) //equip
                        {
                            rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsUniqueItem).Description);

                        }
                        else if (shopType == 2) //spells
                        {
                            if (radioStock.Checked)
                            {
                                rtbSelectedInfo.AppendText((lbShopInventory.SelectedItem as clsSpell).spellDescription);
                            }
                        }
                    }
                }

                //maybe reroll shop chatter?
            }
        }

        private void radioStock_CheckChanged(object sender, EventArgs e)
        {
            RadioButton b = sender as RadioButton;

            if (b.Focused && b.Checked)
            {
                rtbSelectedInfo.Clear();
                lblSelectedName.Text = "";
                pbSelectedItem.Image = null;
                tbAmount.Text = "0";
                //switch the stock and clear the selection
                lbShopInventory.ClearSelected();
                if (b == radioStock) 
                {
                    lbShopInventory.DataSource = shopInv; 
                    switch (shopType)
                    {
                        case 1:
                        case 3:
                            lbShopInventory.DisplayMember = "ItemName";
                            break;
                        case 2:
                            lbShopInventory.DisplayMember = "spellName";
                            break;

                    }
                }
                else if (b == radioGeneric) 
                {
                    lbShopInventory.DataSource = secondaryInv;
                    switch (shopType)
                    {
                        case 1:
                            break;
                        case 2:
                        case 3:
                            lbShopInventory.DisplayMember = "ItemName";
                            break;
                    }
                }

                lbShopInventory.ClearSelected();
                pbSelectedItem.Image = null; //getpicture
                lblSelectedName.Text = "";
                //myGame.gTT.SetToolTip(pbEffectIcon, null);
            }
        }

        private void btnEquip_Click(object sender, EventArgs e)
        {
            switch (shopType)
            {
                case 1: //equip
                    myGame.OpenEquipBoard();
                    break;
                case 2: //spells
                    myGame.OpenSpellbookBoard();
                    break;
            }
        }
    }
}
