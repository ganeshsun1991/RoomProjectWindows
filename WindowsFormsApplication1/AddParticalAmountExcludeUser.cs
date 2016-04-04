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
    public partial class AddParticalAmountExcludeUser : Form
    {
        Room_CommonDL rc = new Room_CommonDL();
        Medhods ms = new Medhods();
        DataTable dt = new DataTable();
        public AddParticalAmountExcludeUser()
        {
            InitializeComponent();
        }

        private void AddParticalAmountExcludeUser_Load(object sender, EventArgs e)
        {
            List<User> objUser = null;
            objUser = ms.GetUsersList("user");
            //dt = ms.GetUserNameByID("user", 0);

            foreach (User obj in objUser)
            {
                UserFromList.Items.Add(obj);
                UserFromList.DisplayMember = "ID";
                UserFromList.ValueMember = "Name";
            }
            //rc.common_loadListBox(dt, UserFromList);
        }

        private void btnMoveToOne_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(UserFromList, UserToList);
        }

        private void MoveListBoxItems(ListBox source, ListBox destination)
        {
            ListBox.SelectedObjectCollection sourceItems = source.SelectedItems;
            foreach (var item in sourceItems)
            {
                destination.Items.Add(item);
                destination.ValueMember = "ID";
                destination.DisplayMember = "Name";
                UserFromList.Items.Remove(item);
            }


            //while (source.SelectedItems.Count > 0)
            //{


            //source.SelectedItems[0]
            //}
        }

        private void btnMoveToAll_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(UserFromList, UserToList);
        }

        private void btnMoveFromOne_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(UserFromList, UserToList);
        }

        private void MoveFromAll_Click(object sender, EventArgs e)
        {
            MoveListBoxItems(UserFromList, UserToList);
        }
    }
}
