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
using BreadMage2.Screens;

namespace BreadMage2.Controls
{
    public partial class QuickBoard : UserControl
    {

        public BreadMage bMage { get; set; }
        public FightBoard bFight { get; set; }
        public GameScreen myGameScr { get; set; }
        private List<int> QuickItemIDs;
        private List<int> QuickSpellIDs;

        private int iSlot1;
        private int iSlot2;
        private int iSlot3;
        private int iSlot4;

        public QuickBoard(GameScreen aGameScreen)
        {
            InitializeComponent();
            myGameScr = aGameScreen;
            LoadBoard();
        }


        private void LoadBoard()
        {
            //need to load in saved spells/items - row/rows on save file for spell/item ID?
            //procedurally generate the buttons rather than hard coded? 
            // ***this seems problematic for attaching action to buttons, I don't feel comfortable with this idea, though I know it's possible
            //for each item in player inv
            //loop - if item count > 1 AND item matches a quick use slot, create OR fill the next available slot in the board
            //restrict number of items to save




            //for testing/building:
            //myGameScr.gMage.myQuickIDs.Add(1);
            myGameScr.gMage.myQuickIDs.Add(2);
            //myGameScr.gMage.myQuickIDs.Add(7);

            foreach (int QuickID in myGameScr.gMage.myQuickIDs)
            {
                if (myGameScr.gConsumableLib.Exists(x => x.itemID == QuickID))
                {
                    clsConsumable anewItem = myGameScr.gConsumableLib.Find(x => x.itemID == QuickID);

                    //image
                    object o = Properties.Resources.ResourceManager.GetObject(anewItem.ImageURL);
                    if (o is Image) { pbQS1.Image = Properties.Resources.ResourceManager.GetObject(anewItem.ImageURL) as Image; }
                    pbQS1.Show();
                    //button text = item name
                    btnQS1.Text = anewItem.ItemName;
                    //label = # available?
                    lblQS1.Text = myGameScr.gMage.GetItemCount(anewItem.itemID).ToString();

                    // fill local ID slots
                    FillIDSlots(anewItem.itemID);
                }
                else if (myGameScr.gCombatLib.Exists(x => x.itemID == QuickID))
                {
                    clsCombatItem anewItem = myGameScr.gCombatLib.Find(x => x.itemID == QuickID);

                    //image
                    object o = Properties.Resources.ResourceManager.GetObject(anewItem.ImageURL);
                    if (o is Image) { pbQS1.Image = Properties.Resources.ResourceManager.GetObject(anewItem.ImageURL) as Image; }
                    pbQS1.Show();
                    //button text = item name
                    btnQS1.Text = anewItem.ItemName;
                    //label = # available?
                    lblQS1.Text = myGameScr.gMage.GetItemCount(anewItem.itemID).ToString();

                    // fill local ID slots
                    FillIDSlots(anewItem.itemID);
                    Console.WriteLine("found quick ID: " + QuickID + " a " + anewItem.ItemName);
                }
            }
                   
        }

        private void AddSlot(object anItem)
        {
            //this is going to take some work
         /*
            if (anItem is clsConsumable)
            {
                object o = Properties.Resources.ResourceManager.GetObject(anItem)
            }
            else if (anItem is clsConsumable)
            {

            }
            //else if object is spell {}

                    object o = Properties.Resources.ResourceManager.GetObject);

            if (o is Image) { pbMonster.Image = o as Image; }
            else { pbMonster.Image = Properties.Resources.BreadMage2; }
            pbMonster.Show();



            if (Slot1Obj != null)
            {
                pbQS1.Image = 
            }
            else if (Slot2Obj != null) { }
            else if (Slot3Obj != null) { }
            else if (Slot4Obj != null) { }
            else
            { 
                //slots full - do nothing 
            }
        */

        }

        public void RefreshBoard()
        {
            //get slot Object Item/SpellID
            //if item, get count
            //if spell get MP cost
           
        }

        public void RefreshSlotIDs()
        {
            //whenever selected slots are saved, use this method to update the list of saved IDs
        }

        public void UpdateItemCount()
        {

            lblQS1.Text = myGameScr.gMage.GetItemCount(iSlot1).ToString();
            //lblQS2.Text = myGameScr.gMage.GetItemCount(iSlot2).ToString();
            //lblQS3.Text = myGameScr.gMage.GetItemCount(iSlot3).ToString();
            //lblQS4.Text = myGameScr.gMage.GetItemCount(iSlot4).ToString();
            Console.WriteLine("The lbQStext is: " + lblQS1.Text);


            // issues: can't use loop (as seen below) due to it basically updating for each slot, with no check for which item is in which slot
            // currently will always just update all info to last item in QuickID list
            /*
            foreach (int QuickID in myGameScr.gMage.myQuickIDs)
            {
                lblQS1.Text = myGameScr.gMage.GetItemCount(QuickID).ToString();
                //lblQS2.Text = myGameScr.gMage.GetItemCount(QuickID).ToString();
                //lblQS3.Text = myGameScr.gMage.GetItemCount(QuickID).ToString();
                //lblQS4.Text = myGameScr.gMage.GetItemCount(QuickID).ToString();
            }

            */

        }

        private void FillIDSlots(int anID)
        {
            if (iSlot1 == 0) { iSlot1 = anID; }
            else if (iSlot2 == 0) { iSlot2 = anID; }
            else if (iSlot3 == 0) { iSlot3 = anID; }
            else if (iSlot4 == 0) { iSlot4 = anID; }
        }
    }
}
