using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Thư viện SQL
using System.Text.RegularExpressions;

namespace FORM_SACADA
{
    public partial class frm_control_users : Form
    {
        public frm_control_users()
        {
            InitializeComponent();
        }
        public void Control_Users_Display()
        {
            string sqlSelect = "SELECT * FROM Users";
            class_database.sqlDisplay(sqlSelect, dtg_control_users);
            // Đặt tên cho các cột datagridview
            dtg_control_users.Columns[0].HeaderText = "Tài khoản";
            dtg_control_users.Columns[1].HeaderText = "Mật khẩu";
            dtg_control_users.Columns[2].HeaderText = "Email";
            dtg_control_users.Columns[3].HeaderText = "Mã nhân viên";
            dtg_control_users.Columns[4].HeaderText = "Ngày sinh";
            dtg_control_users.Columns[5].HeaderText = "Họ và tên";
            dtg_control_users.Columns[6].HeaderText = "Giới tính";
            dtg_control_users.Columns[7].HeaderText = "Số điện thoại";

        }

        private void frm_control_users_Load(object sender, EventArgs e)
        {
            Control_Users_Display();
        }

        // Cập nhật thông tin
        public static void cmd_SQLUpdate(string sqltable_name,
                                string collum1, string data1,
                                string collum2, string data2,
                                string collum3, string data3,
                                string collum4, string data4,
                                string collum5, string data5,
                             //   string collum6, string data6,
                                string collum7, string data7,
                                string collum8, string data8)
        {
            SqlConnection sql_conn;
         //  string DB_Name = Properties.Settings.Default.SQL_DBName;
         //  string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
         //                   + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
            sql_conn.Open();
            string sql = " UPDATE " + sqltable_name + " SET "
                + collum1 + "= '" + data1 + "', "
                + collum2 + "= '" + data2 + "', "
                + collum3 + "= '" + data3 + "', "
                + collum4 + "= '" + data4 + "', "
                + collum5 + "= '" + data5 + "', "
            //    + collum6 + "= '" + data6 + "', "
                + collum7 + "= '" + data7 + "', "
                + collum8 + "= '" + data8 + "'"
                + "WHERE "
                + collum1 + " = '" + data1 + "';";
            using (SqlCommand cmd = new SqlCommand(sql, sql_conn))
            {
                cmd.ExecuteNonQuery();
            }
            sql_conn.Close();
        }
        modify modify = new modify();
        public bool checkacc(string ac)
        {
            return Regex.IsMatch(ac, "^[a-z A-Z 0-9]{2,24}$");
        }
        public bool checkmail(string em)
        {
            return Regex.IsMatch(em, @"^[\w]{3,25}@gmail.com(.vn|)$");
        }
        private void btn_edit_Click_1(object sender, EventArgs e)
        {
            txb_tk.ReadOnly = false;
            txb_mk.ReadOnly = false;
            txb_mail.ReadOnly = false;
            txb_name.ReadOnly = false;
            txb_phone.ReadOnly = false;
            txb_date.ReadOnly = false;
            txb_sex.ReadOnly = false;
            txb_mnv.ReadOnly = false;
            btn_delete.Enabled = true;
            btn_update.Enabled = true;
            bt_them.Enabled = true;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            txb_tk.ReadOnly = true;
            txb_mk.ReadOnly = true;
            txb_mail.ReadOnly = true;
            txb_name.ReadOnly = true;
            txb_phone.ReadOnly = true;
            txb_date.ReadOnly = true;
            txb_sex.ReadOnly = true;
            txb_mnv.ReadOnly = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;
            bt_them.Enabled = false;
        }

        private void bt_them_Click_1(object sender, EventArgs e)
        {
            frm_register frmRegister = new frm_register();
            frmRegister.ShowDialog();
        }

        private void btn_update_Click_1(object sender, EventArgs e)
        {
            string sqltable_name = "Users";
            string collum1 = "Taikhoan";
            string collum2 = "Matkhau";
            string collum3 = "Email";
            string collum4 = "Hoten";
            string collum5 = "Phone";
            //  string collum6 = "Ngaysinh";
            string collum7 = "Gioitinh";
            string collum8 = "MaNV";
            //=========so sánh SQL
            string data1 = txb_tk.Text;
            string data2 = txb_mk.Text;
            string data3 = txb_mail.Text;
            string data4 = txb_name.Text;
            string data5 = txb_phone.Text;
            //  string data6 = txb_date.Text;
            string data8 = txb_mnv.Text;
            string data7 = txb_sex.Text;
            //   if (!checkacc(data1)) { MessageBox.Show("Vui lòng nhập lại tên tài khoản khác"); return; }
            //   if (!checkacc(data2)) { MessageBox.Show("Vui lòng nhập mật khẩu"); return; }
            // if (!checkacc(hoten)) { MessageBox.Show("Họ và tên người dùng đã tồn tại"); return; }
            //    if (!checkmail(data3)) { MessageBox.Show("Vui lòng nhập đúng dạng Email"); return; }
            // if (!checkmail(MaNV)) { MessageBox.Show("Mã nhân viên đã tồn tại"); return; }
            //   if (modify.Taikhoans("Select * from Users where Email='" + data3 + "'").Count != 0) { MessageBox.Show("Email này đã được đăng ký,vui lòng nhập Email khác!"); return; }
            //   if (modify.Taikhoans("Select * from Users where MaNV='" + data8 + "'").Count != 0) { MessageBox.Show("Mã nhân viên đã tồn tại!"); return; }
            //   if (modify.Taikhoans("Select * from Users where Taikhoan='" + data1 + "'").Count != 0) { MessageBox.Show("Tên tài khoản đã tồn tại!"); return; }
            try
            {
                cmd_SQLUpdate(sqltable_name,
                    collum1, data1,
                    collum2, data2,
                    collum3, data3,
                    collum4, data4,
                    collum5, data5,
                    //   collum6, data6,
                    collum7, data7,
                    collum8, data8);
                MessageBox.Show("Thông tin nhân viên đã được cập nhật!");
            }
            catch
            {
                MessageBox.Show("Tài khoản đã tồn tại, Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            // Khai báo giá trị
            string sqltable_name = "Users";
            string collum1 = "Taikhoan";
            string data1 = txb_tk.Text.ToString();
            // Hàm Ghi dữ liệu
            class_import_sql.cmd_SQLDelete(sqltable_name,
                    collum1, data1);
            MessageBox.Show("Đã xóa dữ liệu!");
            Control_Users_Display();
        }

        private void dtg_control_users_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dtg_control_users.Rows[e.RowIndex];
                txb_tk.Text = row.Cells[0].Value.ToString();
                txb_mk.Text = row.Cells[1].Value.ToString();
                txb_mail.Text = row.Cells[2].Value.ToString();
                txb_name.Text = row.Cells[3].Value.ToString();
                txb_phone.Text = row.Cells[4].Value.ToString();
                txb_date.Text = row.Cells[5].Value.ToString();
                txb_sex.Text = row.Cells[6].Value.ToString();
                txb_mnv.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}
