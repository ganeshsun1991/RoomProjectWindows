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
            objUser = ms.GetUsersList("userist");
            //dt = ms.GetUserNameByID("user", 0);

            foreach (User obj in objUser)
            {
                UserFromList.Items.Add(obj.UserName);
                UserFromList.DisplayMember = "ID";
                UserFromList.ValueMember = "Name";
            }
            //rc.common_loadListBox(dt, UserFromList);
        }

        private void btnMoveToOne_Click(object sender, EventArgs e)
        {
            if (UserFromList.Items.Count > 0)
            {
                // checking whether listbix1 has items or not if yes then moving items
                UserToList.Items.Add(UserFromList.SelectedItem.ToString());
                UserFromList.Items.Remove(UserFromList.SelectedItem);
            }   
        }


        private void btnMoveToAll_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveFromOne_Click(object sender, EventArgs e)
        {

        }

        private void MoveFromAll_Click(object sender, EventArgs e)
        {

        }

        
    }
}
