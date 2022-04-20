using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BreadMage2.Screens
{
    public partial class SettingsScreen : Form
    {
        public SettingsScreen()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;


            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /* I want to make sure I don't need to reference this for updating tables, but this should go
            BreadDB BreadNet = new BreadDB();
            OleDbConnection myConn = BreadNet.BreadConnect();
            try
            {
                string msql = "SELECT * FROM MASTER";

                

                OleDbCommand myCmd = new OleDbCommand(msql, myConn);
                OleDbDataAdapter myAdap;
                DataSet ds = new DataSet();
                int i = 0;

                myConn.Open();
                myAdap = new OleDbDataAdapter(msql, myConn);
                myAdap.Fill(ds);
                myAdap.Dispose();
                //myConn.Close();

                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    

                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString() == "Settings") { MessageBox.Show("oh man");  }

                    if (ds.Tables[0].Rows[i].ItemArray[1].ToString() == "More")
                        
                    {
                        myCmd.CommandText = "UPDATE MASTER " +
                            "set Field2 = Field2 + 300 where ID = @ID";
                        //myCmd.Parameters.AddWithValue("@f1", "Way cool, man");
                        myCmd.Parameters.AddWithValue("@ID", 4);
                        myCmd.ExecuteNonQuery();
                    }


                    MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1] + " -- " + ds.Tables[0].Rows[i].ItemArray[3]);
                }


                MessageBox.Show("Connection Open ! ");
                myCmd.Dispose();
                myConn.Close();
            }
            catch (Exception ex)
            {
                string s = "Can not open connection ! "+ Environment.NewLine + Environment.NewLine + "exception: " + ex.InnerException.ToString();
                MessageBox.Show(s);
            }
        
            EVEN OLDER:::

            connection = new OleDbConnection(connetionString);
            try
            {
                connection.Open();
                oledbAdapter = new OleDbDataAdapter(sql, connection);
                oledbAdapter.Fill(ds);
                oledbAdapter.Dispose();
                connection.Close();

                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    MessageBox.Show (ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
                }
            

            */
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form myform = new CreateScreen();
            myform.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /* keep this at bottom - close window logic */
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f in ((MainScreen)MdiParent).MdiChildren)
            {
                if (f.Name == "GameScreen" && f.Visible == false) 
                {
                    Point p = new Point(65, 10);
                    f.Show();
                    f.Location = p;
                }  
            }

        }

    }
}
