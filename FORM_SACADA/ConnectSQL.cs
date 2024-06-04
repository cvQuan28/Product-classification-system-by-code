using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FORM_SACADA
{
    public static class ConnectSQL
    {
        public static string DB_Name = Properties.Settings.Default.SQL_DBName;
        public static string strCon = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
                             + DB_Name + ";Integrated Security=True";
        //Data Source = DESKTOP - KR69N05\SQLEXPRESS;Initial Catalog = DATA_SYSTEM; Integrated Security = True
        // private static string strCon = @"Data Source=DESKTOP-TDIFOA1\SQLEXPRESS;Initial Catalog=DATA_ITEMS;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(strCon);
        }

    }
}