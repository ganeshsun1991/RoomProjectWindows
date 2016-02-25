using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MonthWiseReport : Form
    {
        public MonthWiseReport()
        {
            InitializeComponent();
        }
        Medhods ms = new Medhods();
        private void MonthWiseReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.Text = "Month Wise Report";
                FillMonthYear();
                FillDataGrid(DateTime.Now.Year, DateTime.Now.Month - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FillMonthYear()
        {
            int indexcount = 0;
            for (int month = 1; month <= 12; month++)
            {
                string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
                ddlmonth.Items.Add(monthName.ToString());
            }
            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                ddlyear.Items.Add(i.ToString());
                indexcount++;
            }
            ddlmonth.SelectedIndex = DateTime.Now.Month - 2;
            ddlyear.SelectedIndex = indexcount - 1;
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            if (Validate())
            {

                FillDataGrid(Convert.ToInt32(ddlyear.Text), Convert.ToInt32(ddlmonth.SelectedIndex + 1));
            }
        }
        private Boolean Validate()
        {
            if (ddlyear.Text == "")
            {
                ms.CallMessageBox("Please select year.", "Missing", "ex");
                return false;
            }
            else if (ddlmonth.Text == "")
            {
                ms.CallMessageBox("Please select month.", "Missing", "ex");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void FillDataGrid(int year, int month)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = ms.GetCalculatedDataByYearMonth(year, month);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
            }
            else
            {
                ms.CallMessageBox("No data found for your selected month and year.", "Information", "ex");
                dataGridView1.DataSource = null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
