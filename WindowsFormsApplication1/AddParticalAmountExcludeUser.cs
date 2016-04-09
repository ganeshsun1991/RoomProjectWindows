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
        public AddParticalAmountExcludeUser(int UserId)
        {
            InitializeComponent();
            dt = ms.GetUserNameByID("userbyid", UserId);
            rc.common_loadDropDown(dt, ddlUserList);
            lblUserId.Text = Convert.ToString(UserId);
        }

        private void AddParticalAmountExcludeUser_Load(object sender, EventArgs e)
        {
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
            if (UserToList.SelectedItems.Count <= 0)
            {
                ms.CallMessageBox("Please add and select any one user exclude from the List Box.", "Message", "ex");
                UserFromList.Focus();
                return false;
            }
            else if (txtAmount.Text != null || txtAmount.Text != "")
            {
                ms.CallMessageBox("Please enter the Transaction Amount.", "Message", "ex");
                txtAmount.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
