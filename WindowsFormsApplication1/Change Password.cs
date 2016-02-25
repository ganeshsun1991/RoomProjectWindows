using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Change_Password : Form
    {
        public Change_Password(int UserId)
        {
            InitializeComponent();
            label5.Text = Convert.ToString(UserId);
        }
        Medhods ms = new Medhods();
        string pword = "";
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            txtoldpassword.Text = "";
            txtnewpassword.Text = "";
            txtrepassword.Text = "";
        }
        private Boolean Validate()
        {
            if (txtoldpassword.Text == "")
            {
                ms.CallMessageBox("Please enter the old Password.", "Missing", "ex");
                txtoldpassword.Focus();
                return false;
            }
            else if (txtnewpassword.Text == "")
            {
                ms.CallMessageBox("Please enter the new Password.", "Missing", "ex");
                txtnewpassword.Focus();
                return false;
            }
            else if (txtrepassword.Text == "")
            {
                ms.CallMessageBox("Please enter the Re-Enter password.", "Missing", "ex");
                txtrepassword.Focus();
                return false;
            }
            else if (txtnewpassword.Text != txtrepassword.Text)
            {
                ms.CallMessageBox("You entered password and Re-Enter password in not match.", "Alert", "ex");
                txtnewpassword.Focus();
                return false;
            }
            else if (txtoldpassword.Text != pword)
            {
                ms.CallMessageBox("You entered password is incorrect please enter correct password.", "Message", "error");
                txtoldpassword.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            try            
            {
                AcceptButton = button1;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                pictureBox1.Image = Properties.Resources.profile_change_password;
                User u = new User();
                u = ms.GetUserDetaile("", "", label5.Text);
                if (u != null)
                {
                    pword = u.Passwod;
                }
                else
                {
                    ms.CallMessageBox("No Data found.\nPlease try again.","Message","ex");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    int res = ms.ChangePasswordByID(label5.Text, txtnewpassword.Text);
                    if (res != 0)
                    {
                        ms.CallMessageBox("Password changed successfully.", "Information", "information");
                        clear();
                        txtoldpassword.Focus();
                    }
                    else
                    {
                        ms.CallMessageBox("Error occoured while changing password please try again.", "Message", "error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
    }
}
