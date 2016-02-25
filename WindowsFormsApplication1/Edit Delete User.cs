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
    public partial class Edit_Delete_User : Form
    {
        Medhods ms = new Medhods();
        Room_CommonDL rc = new Room_CommonDL();
        string RowID;
        public Edit_Delete_User()
        {
            InitializeComponent();
        }

        private void Edit_Delete_User_Load(object sender, EventArgs e)
        {
            try
            {
                textBox10.Text = Convert.ToString(ms.GetUserCount());
                DataTable dt = new DataTable();
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                FillDataGrid();
                dt = ms.GetCommanTransactionList("rolelist");
                rc.common_loadDropDown(dt, comboBox1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillDataGrid()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = ms.GetAllUsers();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }

        private void CallClear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            checkBox1.Checked = false;
        }

        private Boolean Validate()
        {
            if (textBox1.Text == "")
            {
                ms.CallMessageBox("Please select the User to Update.", "Alert", "ex");
                return false;
            }
            else if (textBox2.Text == "")
            {
                ms.CallMessageBox("Please enter the UserName.", "Missing", "ex");
                textBox2.Focus();
                return false;
            }
            else if (textBox4.Text == "")
            {
                ms.CallMessageBox("Please enter the User Address.", "Missing", "ex");
                textBox4.Focus();
                return false;
            }
            else if (textBox5.Text == "")
            {
                ms.CallMessageBox("Plese enter the User M.No1.", "Missing", "ex");
                textBox5.Focus();
                return false;
            }
            else if (textBox7.Text == "")
            {
                ms.CallMessageBox("Please enter the User Desigination.", "Missing", "ex");
                textBox7.Focus();
                return false;
            }
            else if (comboBox1.Text == "")
            {
                ms.CallMessageBox("Please select the User Role", "Missing", "ex");
                comboBox1.Focus();
                return false;
            }
            else
            {
                return true;
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

        #region Button Events
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ds;
                if (textBox1.Text != "")
                {
                    ds = MessageBox.Show("Are you sure want to Delete the Member?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ds == DialogResult.Yes)
                    {
                        int res = ms.DeleteUserDetails(Convert.ToInt32(textBox1.Text));
                        if (res != 0)
                        {
                            FillDataGrid();
                            textBox10.Text = Convert.ToString(ms.GetUserCount());
                            ms.CallMessageBox("Member deleted successfully.", "Information", "information");
                        }
                        else
                        {
                            ms.CallMessageBox("Delete failed!\nPlease call System Administrator.", "Error", "error");
                        }

                    }
                }
                else
                {
                    ms.CallMessageBox("Please select the Member to Delete.", "Alert", "ex");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                if (Validate())
                {
                    user.UserID = Convert.ToInt32(textBox1.Text);
                    user.UserName = textBox2.Text;
                    user.NickName = textBox3.Text;
                    user.Address = textBox4.Text;
                    user.MobileNo1 = textBox5.Text;
                    user.MobileNo2 = textBox6.Text;
                    user.JobName = textBox7.Text;
                    user.UserRole = comboBox1.Text;
                    user.Allow_Access = checkBox1.Checked;
                    int res = ms.UpdateUserDetails(user);
                    if (res != 0)
                    {
                        FillDataGrid();
                        CallClear();
                        ms.CallMessageBox("Member Details updated successfully", "Infromation", "information");
                    }
                    else
                    {
                        ms.CallMessageBox("Update failed!\nPlease call System Administrator.", "Error", "error");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CallClear();
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                User us = null;
                us = ms.GetUserDetaile("", "", dataGridView1.SelectedCells[0].Value.ToString());
                if (us != null)
                {
                    textBox1.Text = Convert.ToString(us.UserID);
                    textBox8.Text = us.Passwod;
                    textBox9.Text = us.JoiningDate.ToString("dd-MM-yyyy"); ;
                    textBox2.Text = us.UserName;
                    textBox3.Text = us.NickName;
                    textBox4.Text = us.Address;
                    textBox5.Text = us.MobileNo1;
                    textBox6.Text = us.MobileNo2;
                    textBox7.Text = us.JobName;
                    comboBox1.Text = us.UserRole;
                    checkBox1.Checked = us.Allow_Access;
                }
                else
                {
                    ms.CallMessageBox("Please select proper way.", "Alert", "ex");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +"\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
