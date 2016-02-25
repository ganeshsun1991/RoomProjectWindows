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
    public partial class Calculation : Form
    {
        public Calculation(string month)
        {
            InitializeComponent();
            label7.Text = "";
            label7.Text = month;
        }
        Medhods ms = new Medhods();
        CalculationDomain cd = new CalculationDomain();
        private void Calculation_Load(object sender, EventArgs e)
        {
            try
            {
                int month = 0,year = 0;
                if (label7.Text == "")
                {
                    groupBox2.Text = "Amount Calculation For the Month - " + DateTime.Now.ToString("MMMM");
                    label1.Text = "Current Month Calculation";
                    month = DateTime.Now.Month;
                    year = DateTime.Now.Year;
                }
                else
                {
                    groupBox2.Text = "Amount Calculation For the Month - " + DateTime.Now.AddMonths(-1).ToString("MMMM");
                    label1.Text = "Last Month Calculation";
                    month = (DateTime.Now.Month - 1) == 0 ? 12 : DateTime.Now.Month - 1;

                    year = DateTime.Now.Year;
                }
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                FilDataGrid("grid", month,year);
                //FilDataGrid("user", label7.Text);
                txtusercount.Text = Convert.ToString(ms.GetUserCount());
                cd = ms.GetCalculationAmount(label7.Text);
                if (cd != null)
                {
                    if (cd.TotRentAmount == 0)
                    {
                        ms.CallMessageBox("There is an No Rent amount found for this Month.\nSo the Calculation Detailes is not Completed.", "Message", "ex");
                    }
                    txtrentamount.Text = Convert.ToString(decimal.Round(cd.TotRentAmount, 2));
                    txtfoodamount.Text = Convert.ToString(decimal.Round(cd.TotFoodAmount, 2));
                    txtshareamount.Text = Convert.ToString(decimal.Round(cd.ShareAmount, 2));
                    txtsamountnfc.Text = Convert.ToString(decimal.Round(cd.NFoodShare, 2));
                }
                else
                {
                    ms.CallMessageBox("No transaction data found.", "Message", "ex");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FilDataGrid(string mode, int month,int year)
        {
            try
            {
                if (mode == "grid") 
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = ms.GetIndividualShareAmount(mode, month,year);
                    da.Fill(dt);
                    if (dt.Rows.Count > 1)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].Visible = false;
                    }
                }
                else if (mode == "user")
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = ms.GetUserList(mode);
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
