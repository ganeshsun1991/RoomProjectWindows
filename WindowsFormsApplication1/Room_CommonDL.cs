using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Room_CommonDL
    {

        public void common_loadDropDown(DataTable dtBind, ComboBox CommonCombox)
        {

            //datarow dr;

            //dr = dtbind.newrow();

            //dr["id"] ="0";
            //dr["name"] = "select";
            //dtbind.rows.insertat(dr, 0);
            CommonCombox.DataSource = dtBind;
            CommonCombox.ValueMember = "ID";
            CommonCombox.DisplayMember = "Name";



        }

        public void common_loadListBox(DataTable objUser, ListBox ListBox)
        {

            //datarow dr;

            //dr = dtbind.newrow();

            //dr["id"] ="0";
            //dr["name"] = "select";

            //dtbind.rows.insertat(dr, 0);
            //ListBox.Items.Add();
            ListBox.DataSource = objUser;
            ListBox.ValueMember = "ID";
            ListBox.DisplayMember = "Name";



        }

    }
}
