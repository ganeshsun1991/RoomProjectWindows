using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class New_User : Form
    {
        public New_User()
        {
            InitializeComponent();
        }
        Medhods ms = new Medhods();
        Room_CommonDL rc = new Room_CommonDL();
        User u = new User();
        

        private void New_User_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                textBox1.Text = Convert.ToString(ms.GetLastId());
                dt = ms.GetCommanTransactionList("rolelist");
                rc.common_loadDropDown(dt, comboBox1);                
                AcceptButton = button1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }       

        private void New_User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool res;
                int UserId;
                res = Validate();
                if (res == true)
                {
                    u.UserID = Convert.ToInt32(textBox1.Text);
                    u.UserName = textBox2.Text;
                    u.NickName = textBox3.Text;
                    u.Address = textBox4.Text;
                    u.MobileNo1 = textBox5.Text;
                    u.MobileNo2 = textBox6.Text;
                    u.JobName = textBox7.Text;
                    u.JoiningDate = dateTimePicker1.Value;
                    u.UserRole = comboBox1.Text;
                    u.IsNonFoodUser = checkBox2.Checked;
                    u.Allow_Access = checkBox1.Checked;
                    u.IsAcive = true;
                    UserId = ms.InserUserDetails(u);
                    if (UserId != 0)
                    {
                        textBox1.Text = Convert.ToString(u.UserID+1);
                        textBox2.Focus();
                        clear();
                        ms.CallMessageBox("The Member Details has been saved successfully.", "Information", "information");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            checkBox1.Checked = false;
        }


        private bool Validate()
        {
            IList<User> name = null;
            if (textBox2.Text == "")
            {
                ms.CallMessageBox("Please enter the Member Name.", "Missing", "ex");
                textBox2.Focus();
                return false;
            }
            else if (textBox4.Text == "")
            {
                ms.CallMessageBox("Please enter the Member Address.", "Missing", "ex");
                textBox4.Focus();
                return false;
            }
            else if (textBox5.Text == "")
            {
                ms.CallMessageBox("Plese enter the Member Phone 1.", "Missing", "ex");
                textBox5.Focus();
                return false;
            }
            else if (textBox7.Text == "")
            {
                ms.CallMessageBox("Please enter the Member Desigination.", "Missing", "ex");
                textBox7.Focus();
                return false;
            }
            else if (comboBox1.Text == "")
            {
                ms.CallMessageBox("Please select the Member Role", "Missing", "ex");
                comboBox1.Focus();
                return false;
            }
            else
            {
                name = ms.GetUserName(textBox2.Text);
                if (name != null && name.Count > 0)
                {
                    ms.CallMessageBox("Member Name already exsists Please enter the Different Member Name.", "Information", "ex");
                    textBox2.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        private void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;

        }

    }

}


