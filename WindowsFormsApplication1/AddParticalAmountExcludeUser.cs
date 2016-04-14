using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class AddParticalAmountExcludeUser : Form
    {
        Room_CommonDL rc = new Room_CommonDL();
        Medhods ms = new Medhods();
        DataTable dt = new DataTable();
        int RowId = 0;

        public AddParticalAmountExcludeUser(int UserId)
        {
            InitializeComponent();
            dt = ms.GetUserNameByID("userbyid", UserId);
            rc.common_loadDropDown(dt, ddlUserList);
            lblUserId.Text = Convert.ToString(UserId);
        }

        private void AddParticalAmountExcludeUser_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            InitForm();
        }

        private void btnMoveToOne_Click(object sender, EventArgs e)
        {
            if (UserFromList.SelectedItems.Count > 0)
            {
                MoveListBoxItems(UserFromList, UserToList);
            }
            else
            {
                ms.CallMessageBox("Please select an one item from the Source List Box.", "Missing", "ex");
            }
        }

        private void btnMoveToAll_Click(object sender, EventArgs e)
        {
            if (UserFromList.SelectedItems.Count > 0)
            {
                MoveListBoxItems(UserFromList, UserToList);
            }
            else
            {
                ms.CallMessageBox("Please select an one item from the Source List Box.", "Missing", "ex");
            }
        }

        private void btnMoveFromOne_Click(object sender, EventArgs e)
        {
            if (UserToList.SelectedItems.Count > 0)
            {
                MoveListBoxItems(UserToList, UserFromList);
            }
            else
            {
                ms.CallMessageBox("Please select an one item from the Destination List Box.", "Missing", "ex");
            }
        }

        private void MoveFromAll_Click(object sender, EventArgs e)
        {
            if (UserToList.SelectedItems.Count > 0)
            {
                MoveListBoxItems(UserToList, UserFromList);
            }
            else
            {
                ms.CallMessageBox("Please select an one item from the Destination List Box.", "Missing", "ex");
            }

        }

        private void MoveListBoxItems(ListBox SourceListbox, ListBox DestinationListBox)
        {
            if (SourceListbox.Items.Count > 0)
            {
                for (int i = 0; i <= SourceListbox.SelectedItems.Count; i++)
                {
                    DestinationListBox.Items.Add(SourceListbox.SelectedItems[i].ToString());
                    SourceListbox.Items.Remove(SourceListbox.SelectedItems[i]);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RowId == 0)
            {
                if (ValiDate())
                {
                    ms.InsertParaticialAmountData(Convert.ToString(UserToList.SelectedItem), Convert.ToDecimal(txtAmount.Text), Convert.ToInt32(lblUserId.Text), txtDescrption.Text, dateTimePicker1.Value, 1, 0);
                    ms.CallMessageBox("Transaction Details Saved Successfully.", "Information", "information");
                    FillDataGrid();
                    InitForm();
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RowId > 0)
            {
                if (ValiDate())
                {

                    ms.InsertParaticialAmountData(Convert.ToString(UserToList.SelectedItem), Convert.ToDecimal(txtAmount.Text), Convert.ToInt32(lblUserId.Text), txtDescrption.Text, dateTimePicker1.Value, 2, Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()));
                    ms.CallMessageBox("Transaction Details Updated Successfully.", "Information", "information");
                    FillDataGrid();
                    InitForm();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RowId > 0)
            {
                if (RowId > 0)
                {
                    ms.InsertParaticialAmountData("", 0, 0, "", dateTimePicker1.Value, 5, Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()));
                    ms.CallMessageBox("Transaction Details Deleted Successfully.", "Information", "information");
                    FillDataGrid();
                    InitForm();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Transaction tr = ms.InsertParaticialAmountData("", 0, 0, "", DateTime.Now, 4, Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()));
                if (tr != null)
                {
                    RowId = tr.Id;
                    txtAmount.Text = Convert.ToString(tr.Amount);
                    dateTimePicker1.Value = tr.TransactionDate;
                    txtDescrption.Text = tr.Descrption;
                    UserToList.Items.Clear();
                    UserToList.Items.Add(tr.UserName);
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

        private void FillDataGrid()
        {
            SqlDataAdapter da = ms.GetParaticialExcludeUser();
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count <= 0)
            {
                ms.CallMessageBox("There is an no data found for the exclude usre for this month.", "Message", "ex");
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
        }
        private Boolean ValiDate()
        {
            if (UserToList.SelectedItems.Count == 0)
            {
                ms.CallMessageBox("Please add and select any one user exclude from the List Box.", "Message", "ex");
                UserFromList.Focus();
                return false;
            }
            else if (txtAmount.Text == null || txtAmount.Text == "")
            {
                ms.CallMessageBox("Please enter the Transaction Amount.", "Message", "ex");
                txtAmount.Focus();
                return false;
            }

            else if (lblUserId.Text == null || lblUserId.Text == "")
            {
                ms.CallMessageBox("UserId is blank please reopen the window.", "Error", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void InitForm()
        {
            RowId = 0;
            UserFromList.Items.Clear();
            UserToList.Items.Clear();
            txtAmount.Text = "";
            txtDescrption.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            List<User> objUser = null;
            objUser = ms.GetUsersList("userlist");
            FillDataGrid();

            foreach (User obj in objUser)
            {
                UserFromList.Items.Add(obj.UserName);
                UserFromList.DisplayMember = "ID";
                UserFromList.ValueMember = "Name";
            }
        }

    }
}
