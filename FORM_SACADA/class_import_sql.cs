using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient; // Thư viện SQL

namespace FORM_SACADA
{
    public static class class_import_sql
    {
        // Thêm mới đơn hàng (ghi dữ liệu 3 cột)
        public static void cmd_SQLWrite(string sqltable_name,
                                        string collum1, string data1,
                                        string collum2, string data2,
                                        string collum3, string data3,
                                        string collum4, string data4)

        {
           // Data Source = DESKTOP - TDIFOA1\SQLEXPRESS; Initial Catalog = DATA_Login; Integrated Security = True
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
        // Cập nhật đơn hàng
        public static void cmd_SQLUpdate(string sqltable_name,
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
            string sql = " UPDATE " + sqltable_name + " SET "
                + collum1 + "= '" + data1 + "', "
                + collum2 + "= '" + data2 + "', "
                + collum3 + "= '" + data3 + "', "
                + collum4 + "= '" + data4 + "'"
                + "WHERE "
                + collum1 + " = '" + data1 + "';";
            using (SqlCommand cmd = new SqlCommand(sql, sql_conn))
            {
                cmd.ExecuteNonQuery();
            }
            sql_conn.Close();
        }
        // Xóa đơn hàng
        public static void cmd_SQLDelete(string sqltable_name,
                                string collum, string condision)
        {
            SqlConnection sql_conn;
         //   string DB_Name = Properties.Settings.Default.SQL_DBName;
         //   string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
         //                    + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
            sql_conn.Open();
            string sql = " DELETE FROM " + sqltable_name
                + " WHERE "
                + collum + " = '" + condision + "'";
            using (SqlCommand cmd = new SqlCommand(sql, sql_conn))
            {
                cmd.ExecuteNonQuery();
            }
            sql_conn.Close();
        }
        // Hiển thị lên data grid view
        public static void sqlDisplay(string sqlSelect, DataGridView dtgr)
        {
            SqlConnection sql_conn;
          //  string DB_Name = Properties.Settings.Default.SQL_DBName;
          //  string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
          //                   + DB_Name + ";Integrated Security=True";
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
        // Hiển thị đơn hàng trong combobox ở form chính
        public static void FillComboBox(ComboBox cbx,
                                        string sqlSelect, string collum)
        {
            SqlConnection sql_conn;
          // string DB_Name = Properties.Settings.Default.SQL_DBName;
          // string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
          //                  + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
            sql_conn.Open();
            var table = new DataTable();
            using (var adapter = new SqlDataAdapter(sqlSelect, sql_conn))
                adapter.Fill(table);
                cbx.ValueMember = collum;
            cbx.DataSource = table;
            sql_conn.Close();

        }
        // Hiển thị dữ liệu lên textbox khi giá trị combobox thay đổi
        public static void getcomboboxindex(ComboBox cbx, TextBox tbx1,
                                            TextBox tbx2, TextBox tbx3, string sqlSelect,
                                            string column1, string column2 , string colum3)
        {
            SqlConnection sql_conn;
          //  string DB_Name = Properties.Settings.Default.SQL_DBName;
          //  string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
          //                   + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
            sql_conn.Open();
            var table = new DataTable();
            using (var adapter = new SqlDataAdapter(sqlSelect, sql_conn))
                adapter.Fill(table);
            // Đưa dữ liệu vào textbox type 1
            tbx1.DataBindings.Clear();
            tbx1.DataBindings.Add("Text", cbx.DataSource, column1);
            // Đưa dữ liệu vào textbox type 2
            tbx2.DataBindings.Clear();
            tbx2.DataBindings.Add("Text", cbx.DataSource, column2);
            // Đưa dữ liệu vào textbox type 3
            tbx3.DataBindings.Clear();
            tbx3.DataBindings.Add("Text", cbx.DataSource, colum3);
            sql_conn.Close();
        }

        internal static void cmd_SQLWrite(string sqltable_name, string collum1, string data1, string collum2, string data2, string collum3, string data3)
        {
            throw new NotImplementedException();
        }

        internal static void cmd_SQLUpdate(string sqltable_name, string collum1, string data1, string collum2, string data2, string collum3, string data3)
        {
            throw new NotImplementedException();
        }
    }
}

