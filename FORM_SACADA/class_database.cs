using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace FORM_SACADA
{
    public static class class_database
    {
        // Thêm mới dữ liệu (9 cột) : du lieu san xuat
        public static void cmd_SQLWrite(string sqltable_name,
                                        string collum1, string data1,
                                        string collum2, string data2,
                                        string collum3, string data3,
                                        string collum4, string data4,
                                        string collum5, string data5,
                                        string collum6, string data6,
                                        string collum7, string data7,
                                        string collum8, string data8,
                                        string collum9, string data9)
        {
            SqlConnection sql_conn;
         // string DB_Name = Properties.Settings.Default.SQL_DBName;
         // string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
         //                  + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
            sql_conn.Open();
            string sql = " INSERT INTO " + sqltable_name + " ("
                + collum1 + ","
                + collum2 + ","
                + collum3 + ","
                + collum4 + ","
                + collum5 + ","
                + collum6 + ","
                + collum7 + ","
                + collum8 + ","
                + collum9 + ")"
                + " VALUES "
                + "("
                + "@" + collum1 + ","
                + "@" + collum2 + ","
                + "@" + collum3 + ","
                + "@" + collum4 + ","
                + "@" + collum5 + ","
                + "@" + collum6 + ","
                + "@" + collum7 + ","
                + "@" + collum8 + ","
                + "@" + collum9 + ")";
            using (SqlCommand cmd = new SqlCommand(sql, sql_conn))
            {
                cmd.Parameters.AddWithValue(collum1, data1);
                cmd.Parameters.AddWithValue(collum2, data2);
                cmd.Parameters.AddWithValue(collum3, data3);
                cmd.Parameters.AddWithValue(collum4, data4);
                cmd.Parameters.AddWithValue(collum5, data5);
                cmd.Parameters.AddWithValue(collum6, data6);
                cmd.Parameters.AddWithValue(collum7, data7);
                cmd.Parameters.AddWithValue(collum8, data8);
                cmd.Parameters.AddWithValue(collum9, data9);
                cmd.ExecuteNonQuery();
            }
            sql_conn.Close();
        }
        //them du lieu scan 
        public static void cmd_SQLWrite_dataHistory(string sqltable_name,
                                        string collum1, string data1,
                                        string collum2, string data2,
                                        string collum3, string data3,
                                        string collum4, string data4,
                                        string collum5, string data5,
                                        string collum6, bool   data6,
                                        string collum7, string data7)
        {
            SqlConnection sql_conn;
            // string DB_Name = Properties.Settings.Default.SQL_DBName;
            // string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
            //                  + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
            sql_conn.Open();
            string sql = " INSERT INTO " + sqltable_name + " ("
                + collum1 + ","
                + collum2 + ","
                + collum3 + ","
                + collum4 + ","
                + collum5 + ","
                + collum6 + ","
                + collum7 + ")"
                + " VALUES "
                + "("
                + "@" + collum1 + ","
                + "@" + collum2 + ","
                + "@" + collum3 + ","
                + "@" + collum4 + ","
                + "@" + collum5 + ","
                + "@" + collum6 + ","
                + "@" + collum7 + ")";
            using (SqlCommand cmd = new SqlCommand(sql, sql_conn))
            {
                cmd.Parameters.AddWithValue(collum1, data1);
                cmd.Parameters.AddWithValue(collum2, data2);
                cmd.Parameters.AddWithValue(collum3, data3);
                cmd.Parameters.AddWithValue(collum4, data4);
                cmd.Parameters.AddWithValue(collum5, data5);
                cmd.Parameters.AddWithValue(collum6, data6);
                cmd.Parameters.AddWithValue(collum7, data7);
                cmd.ExecuteNonQuery();
            }
            sql_conn.Close();
        }
        // ghi alarm
        public static void cmd_SQLWrite_Alarm(string sqltable_name,
                                        string collum1, string data1,
                                        string collum2, string data2,
                                        string collum3, string data3,
                                        string collum4, string data4)
                                       
        {
            SqlConnection sql_conn;
            // string DB_Name = Properties.Settings.Default.SQL_DBName;
            // string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
            //                  + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
            sql_conn.Open();
            string sql = " INSERT INTO " + sqltable_name + " ("
                + collum1 + ","
                + collum2 + ","
                + collum3 + ","
                + collum4 + ")"
                + " VALUES "
                + "("
                + "@" + collum1 + ","
                + "@" + collum2 + ","
                + "@" + collum3 + ","
                + "@" + collum4 + ")";
            using (SqlCommand cmd = new SqlCommand(sql, sql_conn))
            {
                cmd.Parameters.AddWithValue(collum1, data1);
                cmd.Parameters.AddWithValue(collum2, data2);
                cmd.Parameters.AddWithValue(collum3, data3);
                cmd.Parameters.AddWithValue(collum4, data4);
                cmd.ExecuteNonQuery();
            }
            sql_conn.Close();
        }
        // Hiển thị lên data grid view
        public static void sqlDisplay(string sqlSelect, DataGridView dtgr)
        {
            SqlConnection sql_conn;
         // string DB_Name = Properties.Settings.Default.SQL_DBName;
         // string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
         //                  + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
            sql_conn.Open();
            SqlCommand cmd = new SqlCommand(sqlSelect, sql_conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtgr.DataSource = dt;
            dtgr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sql_conn.Close();
        }
    }
}
