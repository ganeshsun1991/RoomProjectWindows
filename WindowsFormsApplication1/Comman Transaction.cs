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
    public partial class Comman_Transaction : Form
    {
        Medhods ms = new Medhods();
        Room_CommonDL rc = new Room_CommonDL();
        DataTable dt = new DataTable();
        int RowID;
        public Comman_Transaction(int UserId, string type)
        {

            InitializeComponent();
            if (type == "iall")
            {
                dt = ms.GetUserNameByID("user", 0);
                rc.common_loadDropDown(dt, comboBox2);
            }
            else if (type == "idt")
            {
                dt = ms.GetUserNameByID("userbyid", UserId);
                rc.common_loadDropDown(dt, comboBox2);
                comboBox2.SelectedValue = UserId;
            }
            else
            {
                dt = ms.GetUserNameByID("userbyid", UserId);
                rc.common_loadDropDown(dt, comboBox2);
            }

            label7.Text = type;
        }
        //http://www.smarterasp.net/support/kb/a1579/how-can-i-restore-mssql-database-to-your-server.aspx?KBSearchID=154297
        private void Comman_Transaction_Load(object sender, EventArgs e)
        {
            try
            {
                //pictureBox2.Image= Properties.Resources.
                DataTable dt = new DataTable();
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                FillDataGrid(label7.Text, Convert.ToInt32(comboBox2.SelectedValue));
                AcceptButton = btnAdd;
                if (label7.Text == "ct")
                {
                    dt = ms.GetCommanTransactionList("ct");
                    rc.common_loadDropDown(dt, ddlTransactionType);
                    label8.Visible = false;
                    txttotAmount.Visible = false;
                    comboBox2.Enabled = false;
                    //Comman_Transaction ct = new Comman_Transaction(0, "");
                    //ct.Text = "Comman Transaction";
                    label1.Text = "Comman Transaction";
                }
                else if (label7.Text == "idt")
                {
                    dt = ms.GetCommanTransactionList("idt");
                    rc.common_loadDropDown(dt, ddlTransactionType);
                    label1.Text = "Individual Transaction";

                    txttotAmount.Visible = true;
                    txttotAmount.Text = Convert.ToString(ms.GetTotalExpensessAmountByUserID(Convert.ToInt32(comboBox2.SelectedValue)));
                    //Comman_Transaction ct = new Comman_Transaction(0, "");
                    //ct.Text = "Individual Transaction";
                }
                else if (label7.Text == "iall")
                {
                    dt = ms.GetCommanTransactionList("idt");
                    rc.common_loadDropDown(dt, ddlTransactionType);
                    label1.Text = "Edit User Individual Transaction";
                    label8.Visible = false;
                    txttotAmount.Visible = false;
                    Comman_Transaction ct = new Comman_Transaction(0, "");
                    ct.Text = "Edit User Individual Transaction";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {

                    int res;
                    Transaction ts = new Transaction();
                    ts.UserID = Convert.ToInt32(comboBox2.SelectedValue);
                    ts.TransactionDate = dtTransactionDate.Value;
                    ts.TransactionName = ddlTransactionType.Text;
                    ts.Amount = Convert.ToDecimal(txtAmt.Text);
                    ts.Descrption = txtDescription.Text;
                    res = ms.InsertCommanTransaction(ts);
                    if (res != 0)
                    {
                        ms.CallMessageBox("Transaction Details Saved Successfully.", "Information", "information");
                        Clear();
                        FillDataGrid(label7.Text, Convert.ToInt32(comboBox2.SelectedValue));
                        txttotAmount.Text = Convert.ToString(ms.GetTotalExpensessAmountByUserID(Convert.ToInt32(comboBox2.SelectedValue)));
                    }
                    else
                    {
                        ms.CallMessageBox("Error occoured while saving Transation Details.\nPlease call System Administrator.", "Error", "error");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private Boolean Validate(string mode)
        {
            if (comboBox2.SelectedValue == "")
            {
                ms.CallMessageBox("Member ID is cannot be blank please reopen the form.", "Error", "error");
                return false;
            }
            else if (ddlTransactionType.Text == "Select")
            {
                ms.CallMessageBox("Please choose the Transaction Name.", "Missing", "ex");
                ddlTransactionType.Focus();
                return false;
            }
            else if (txtAmt.Text == "")
            {
                ms.CallMessageBox("Please enter the Transaction Amount.", "Missing", "ex");
                txtAmt.Focus();
                return false;
            }
            else
            {
                if (ddlTransactionType.Text == "Rent" && mode != "update")
                {
                    if (ms.CheckRentAmountAvaliablity(dtTransactionDate.Value.Month, dtTransactionDate.Value.Year))
                    {
                        ms.CallMessageBox("The Rent Amount Already entered for this Month.", "Alert", "ex");
                        RowID = 0;
                        Clear();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        private void Clear()
        {
            dtTransactionDate.Value = DateTime.Now;
            ddlTransactionType.Text = "";
            comboBox2.Text = "";
            txtAmt.Text = "";
            txtDescription.Text = "";
        }
        private void FillDataGrid(string type, int UserID)
        {

            DataTable dt = new DataTable();
            if (type == "ct")
            {
                SqlDataAdapter da = ms.GetCommanTransaction();
                da.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    ms.CallMessageBox("There is an no data found for this Month.", "Message", "ex");
                    txtAmt.Text = "";
                    txtDescription.Text = "";
                }
                dataGridView1.DataSource = dt;
            }
            else if (type == "idt")
            {
                SqlDataAdapter da = ms.GetIndividualTransaction(Convert.ToInt32(comboBox2.SelectedValue));
                da.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    ms.CallMessageBox("There is an no data found for this Month.", "Message", "ex");
                    txtAmt.Text = "";
                    txtDescription.Text = "";
                }
                dataGridView1.DataSource = dt;
            }
            else if (type == "iall")
            {
                SqlDataAdapter da = ms.GetIndividualTransactionAll();
                da.Fill(dt);
                if (dt.Rows.Count <= 0)
                {
                    ms.CallMessageBox("There is an no data found for this Month.", "Message", "ex");
                    txtAmt.Text = "";
                    txtDescription.Text = "";
                }
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int res = 0;
                if ("" == "")
                {
                    ms.CallMessageBox("Please select any one comman transaction to Delete.", "Alert", "ex");
                }
                else
                {
                    res = ms.DeleteCommanTransactionById(Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()));
                    if (res != 0)
                    {
                        ms.CallMessageBox("Transaction Deleted successfully.", "Information", "information");
                        Clear();
                        FillDataGrid(label7.Text, Convert.ToInt32(comboBox2.SelectedValue));
                    }
                }
            }
            catch (Exception ex)
            {
                ms.CallMessageBox("Error occoured while Deleting Transation Details.\nPlease call System Administrator.", "Error", "error");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int res = 0;
            try
            {

                if ("" == "")
                {
                    ms.CallMessageBox("Please select any one comman transaction to Update.", "Alert", "ex");
                }
                else
                {
                    Transaction tr = new Transaction();
                    //tr.Id = Convert.ToInt32(label14.Text);
                    //tr.UserID = Convert.ToInt32(textBox4.Text);
                    //tr.TransactionDate = dtTransactionDate.Value;
                    //tr.TransactionName = comboBox2.Text;
                    //tr.Amount = Convert.ToDecimal(textBox5.Text);
                    //tr.Descrption = textBox6.Text;
                    res = ms.UpdateCommanTransacation(tr);
                    if (res != 0)
                    {
                        ms.CallMessageBox("Transaction Detaile Updated Successfuly.", "Information", "information");
                        FillDataGrid(label7.Text, Convert.ToInt32(comboBox2.SelectedValue));
                    }
                    else
                    {
                        ms.CallMessageBox("Error occoured while updateing Transation Details.\nPlease call System Administrator.", "Error", "error");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Boolean ValidateUpdate()
        {
            if ("" == "")
            {
                ms.CallMessageBox("The id column is cannot be blank.\nPlease select any one Transaction.", "Alert", "ex");
                return false;
            }
            else if (comboBox2.Text == "")
            {
                ms.CallMessageBox("Please select the Transaction Type.", "Missing", "ex");
                comboBox2.Focus();
                return false;
            }

            return true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (RowID == 0)
                {

                    if (Validate("insert"))
                    {
                        if (label7.Text == "ct")
                        {
                            int res;
                            Transaction ts = new Transaction();
                            ts.UserID = Convert.ToInt32(comboBox2.SelectedValue);
                            ts.TransactionDate = dtTransactionDate.Value;
                            ts.TransactionName = ddlTransactionType.Text;
                            ts.Amount = Convert.ToDecimal(txtAmt.Text);
                            ts.Descrption = txtDescription.Text;
                            res = ms.InsertCommanTransaction(ts);
                            if (res != 0)
                            {
                                ms.CallMessageBox("Transaction Details Saved Successfully.", "Information", "information");
                                Clear();
                                FillDataGrid(label7.Text, Convert.ToInt32(comboBox2.SelectedValue));
                                txttotAmount.Text = Convert.ToString(ms.GetTotalExpensessAmountByUserID(Convert.ToInt32(comboBox2.SelectedValue)));
                                txtAmt.Focus();
                            }
                            else
                            {
                                ms.CallMessageBox("Error occoured while saving Transation Details.\nPlease call System Administrator.", "Error", "error");
                            }
                        }
                        else if (label7.Text == "idt")
                        {
                            int res = 0;
                            Transaction ts = new Transaction();
                            ts.UserID = Convert.ToInt32(comboBox2.SelectedValue);
                            ts.TransactionDate = dtTransactionDate.Value;
                            ts.TransactionName = ddlTransactionType.Text;
                            ts.Amount = Convert.ToDecimal(txtAmt.Text);
                            ts.Descrption = txtDescription.Text;
                            res = ms.InsertIndividualTransaction(ts);
                            if (res != 0)
                            {
                                ms.CallMessageBox("Transaction Details Saved Successfully.", "Information", "information");
                                FillDataGrid(label7.Text, Convert.ToInt32(comboBox2.SelectedValue));
                                txttotAmount.Text = Convert.ToString(ms.GetTotalExpensessAmountByUserID(Convert.ToInt32(comboBox2.SelectedValue)));
                                txtAmt.Focus();
                                Clear();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (RowID != 0 && RowID != null)
            {
                if (Validate("update"))
                {
                    int res = 0;
                    Transaction ts = new Transaction();
                    ts.Id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    ts.UserID = Convert.ToInt32(comboBox2.SelectedValue);
                    ts.Amount = Convert.ToDecimal(txtAmt.Text);
                    ts.TransactionDate = dtTransactionDate.Value;
                    ts.TransactionName = ddlTransactionType.Text;
                    ts.Descrption = txtDescription.Text;
                    if (label7.Text == "ct")
                    {
                        res = ms.UpdateCommanTransacation(ts);
                        RowID = 0;
                    }
                    else if (label7.Text == "idt" || label7.Text == "iall")
                    {
                        res = ms.UpdateIndividualTransacation(ts);
                        RowID = 0;
                    }
                    if (res != 0)
                    {
                        ms.CallMessageBox("Transaction Details Updated successfully.", "Information", "information");
                        Clear();
                        FillDataGrid(label7.Text, Convert.ToInt32(comboBox2.SelectedValue));
                        txttotAmount.Text = Convert.ToString(ms.GetTotalExpensessAmountByUserID(Convert.ToInt32(comboBox2.SelectedValue)));
                        RowID = 0;
                    }
                }
            }
            else
            {
                ms.CallMessageBox("Please select any one Transaction to Update.", "Alert", "ex");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (RowID != 0 && RowID != null)
            {
                int res = 0;
                if (label7.Text == "ct")
                {
                    res = ms.DeleteCommanTransactionById(Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()));
                    RowID = 0;
                }
                else if (label7.Text == "idt" || label7.Text == "iall")
                {
                    res = ms.DeleteIndividualTransactionById(Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()));
                    RowID = 0;
                }
                if (res != 0)
                {
                    ms.CallMessageBox("Transaction Details Deleted successfully.", "Information", "information");
                    Clear();
                    FillDataGrid(label7.Text, Convert.ToInt32(comboBox2.SelectedValue));
                    txttotAmount.Text = Convert.ToString(ms.GetTotalExpensessAmountByUserID(Convert.ToInt32(comboBox2.SelectedValue)));
                }
            }
            else
            {
                ms.CallMessageBox("Please select any one Transaction to Delete.", "Alert", "ex");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAmt.Text = "";
            txtDescription.Text = "";
            RowID = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Transaction tr = ms.GetCommanTransactionById(Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()), label7.Text);
                if (tr != null)
                {
                    RowID = tr.Id;
                    ddlTransactionType.Text = tr.TransactionName;
                    dtTransactionDate.Value = tr.TransactionDate;
                    txtAmt.Text = Convert.ToString(tr.Amount);
                    txtDescription.Text = tr.Descrption;
                }

                //RowID = ms.GetCommanTransactionById(Convert.ToInt32(dataGridView1.SelectedCells[0].Value;
                else
                {
                    ms.CallMessageBox("Please select proper way.", "Alert", "ex");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedIndex > 0)
                {
                    if (comboBox2.SelectedValue != null)
                    {
                        FillDataGrid("idt", Convert.ToInt32(comboBox2.SelectedValue));
                    }
                    else
                    {
                        FillDataGrid("idt", 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease Call system Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAmt_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}

