using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Global
    {
        public static int _UserID = 0;
        public static string _UserName = "";
        public static int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public static string  UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
    }
}
