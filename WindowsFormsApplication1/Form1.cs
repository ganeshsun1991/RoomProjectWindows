using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using Dapper;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        User us = new User();
        Medhods ms = new Medhods();
        Room_CommonDL rc = new Room_CommonDL();
        static string constring = Convert.ToString(ConfigurationSettings.AppSettings["connection"]);
        SqlConnection cn = new SqlConnection(constring);
        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            Form1 f1 = new Form1();
            DataTable dt = new DataTable();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            f1.Text = "Login";
            try
            {
                dt = ms.GetUserListCombo();
                rc.common_loadDropDown(dt, comboBox1);
                comboBox1.SelectedValue = 100;
                //IList<User> userlist = ms.GetUserList();
                //foreach (var user in userlist)
                //{
                //    comboBox1.Items.Add(user.UserName);
                //}
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Boolean res = validateItem();
                if (res == true)
                {
                    User user = null;
                    user = ms.GetUserDetaile(comboBox1.Text, textBox1.Text);
                    if (user == null)
                    {
                        ms.CallMessageBox("You entered User Name or Password is not tallyed.", "Information", "error");
                    }
                    else
                    {
                        if (user.Allow_Access == true)
                        {
                            ms.CallInsertScript(user.UserID);
                            Admin ad = new Admin(user.UserID, user.UserName);
                            Form1 f1 = new Form1();
                            this.Visible = false;
                            ad.Visible = true;
                        }
                        else
                        {
                            ms.CallMessageBox("Your Account is Blocked.Please call System Administrtor.", "Alert", "ex");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateItem()
        {
            if (comboBox1.Text == "")
            {
                ms.CallMessageBox("Please select the UserName.", "Missing", "ex");
                comboBox1.Focus();
                return false;
            }
            else if (textBox1.Text == "")
            {
                ms.CallMessageBox("Please enter the Password.", "Missing", "ex");
                textBox1.Focus();
                return false;
            }
            else
            {
                return true;
            }


        }
    }
}
