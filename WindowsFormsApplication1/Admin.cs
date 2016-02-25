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
    public partial class Admin : Form
    {

        public Admin(int UserID, string UserName)
        {
            InitializeComponent();
            label2.Text = Convert.ToString(UserID);
            label3.Text = UserName;
        }
        Medhods ms = new Medhods();
        private void Admin_Load(object sender, EventArgs e)
        {
            try
            {
                User u = new User();
                u = ms.GetUserDetaile("", "", label2.Text);
                if (u != null)
                {
                    if (u.UserRole == "Admin")
                    {
                        this.Text = "Admin-" + label3.Text;
                        pictureBox1.Image = Properties.Resources.welcome_admin_login;
                        pictureBox2.Image = Properties.Resources.administrator;
                        //this.Icon = Properties.Resources.adminicon;
                    }
                    else
                    {
                        this.Text = "User-" + label3.Text;
                        pictureBox1.Image = Properties.Resources.Welcome;
                        pictureBox2.Image = Properties.Resources.user;
                        admissionToolStripMenuItem.Enabled = false;
                        commanTransactionToolStripMenuItem.Enabled = false;
                        editUserTransactionToolStripMenuItem.Enabled = false;
                        monthWiseToolStripMenuItem.Visible = false;
                         //this.Icon = Properties.Resources.adminicon;
                    }
                }
                else
                {
                    ms.CallMessageBox("No Data Found.\nPlease logout and try again.", "Message", "ex");

                }

                timer1.Start();

                label3.Text = "Welcome Back: " + label3.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

            New_User nu = new New_User();
            nu.ShowDialog();
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit_Delete_User edu = new Edit_Delete_User();
            edu.ShowDialog();
        }

        private void commanTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comman_Transaction ct = new Comman_Transaction(Convert.ToInt32(label2.Text), "ct");
            ct.ShowDialog();
        }

        private void individualTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comman_Transaction idt = new Comman_Transaction(Convert.ToInt32(label2.Text), "idt");
            idt.ShowDialog();
        }

        private void editUserTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comman_Transaction idt = new Comman_Transaction(Convert.ToInt32(label2.Text), "iall");
            idt.ShowDialog();
        }

        private void viewCurrentMonthCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculation ca = new Calculation("");
            ca.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_Password cp = new Change_Password(Convert.ToInt32(label2.Text));
            cp.ShowDialog();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                this.Visible = false;
                f1.Visible = true;
            }
        }

        private void lastMonthTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculation ca = new Calculation("last");
            ca.ShowDialog();
        }

        private void monthWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthWiseReport mwr = new MonthWiseReport();
            mwr.ShowDialog();
        }
    }
}
