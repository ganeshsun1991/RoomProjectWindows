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
    public partial class Individual_Transaction : Form
    {
        Medhods ms = new Medhods();
        Room_CommonDL rc = new Room_CommonDL();
        public Individual_Transaction(int UserId)
        {
            InitializeComponent();
            textBox3.Text = Convert.ToString(UserId);
            label6.Text = Convert.ToString(UserId);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Individual_Transaction_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                AcceptButton = button1;
                dateTimePicker1.Format = DateTimePickerFormat.Short;
                dt = ms.GetCommanTransactionList("idt");
                rc.common_loadDropDown(dt, comboBox1);
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
                if (Validate())
                {
                    int res=0;
                    Transaction ts =new Transaction();
                    ts.UserID = Convert.ToInt32(textBox3.Text);
                    ts.TransactionDate = dateTimePicker1.Value;
                    ts.TransactionName = comboBox1.Text;
                    ts.Amount = Convert.ToDecimal(textBox1.Text);
                    ts.Descrption = textBox2.Text;
                    res = ms.InsertIndividualTransaction(ts);
                    if (res != 0)
                    {
                        ms.CallMessageBox("Transaction Details Saved Successfully.", "Information", "information");
                        Clear();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private Boolean Validate()
        {
            if (textBox3.Text == "")
            {
                ms.CallMessageBox("User Id Column is cannot be Blank.\nPlease Reopen the Form.", "Alert", "error");
                return false;
            }
            else if (comboBox1.Text == "")
            {
                ms.CallMessageBox("Please select any one Transaction.", "Missing", "ex");
                comboBox1.Focus();
                return false;
            }
            else if (textBox1.Text == "")
            {
                ms.CallMessageBox("Please enter the Transaction Amount.", "Missing", "ex");
                textBox1.Focus();
                return false;
            }
            else
            {
                return true;
            }
            
        }
        private void Clear()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void FillDataGrid()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = ms.GetCommanTransaction();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
