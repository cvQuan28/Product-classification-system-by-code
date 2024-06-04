using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace FORM_SACADA
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }
        //==========================CHƯƠNG TRÌNH CON CLASS==================
        class_control_users control_users = new class_control_users();
        modify modify = new modify();

        private void frm_login_Load(object sender, EventArgs e)
        {
            tbx_tk.Focus();
        }
     // private static string DB_Name = Properties.Settings.Default.SQL_DBName;
        private void tbx_mk_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }
        private void btn_login_Click_1(object sender, EventArgs e)
        {
            if (tbx_tk.Text == "")
            {
                MessageBox.Show("Vui lòng điền tài khoản");
                tbx_tk.Focus();
            }
            if (tbx_mk.Text == "")
            {
                MessageBox.Show("Vui lòng điền mật khẩu");
                tbx_tk.Focus();
            }

            SqlConnection sqlcn = ConnectSQL.GetSqlConnection();
            try
            {
                sqlcn.Open();
                string tk = tbx_tk.Text;
                string mk = tbx_mk.Text;
                if (tbx_tk.Text == "admin" && tbx_mk.Text == "admin")
                {
                    control_users.admin_Control_Elements_frm_main();
                    frm_scada.user_admin = true;
                }
                string data_login_sql = "select *from Users Where Taikhoan= '" + tk + "' and Matkhau= '" + mk + "'";
                SqlCommand cmd = new SqlCommand(data_login_sql, sqlcn);
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {

                    string username = tbx_tk.Text;
                    string query = "select * from Users where TaiKhoan='" + username + "'";
                    // gửi dữ liêu sang form
                    frm_main frmMain = new frm_main();
                    frm_main.Username = modify.Taikhoans(query)[0].Hoten;
                    frm_scada.nhanvien = modify.Taikhoans(query)[0].Hoten;
                    string hoten = modify.Taikhoans(query)[0].Hoten;
                    MessageBox.Show("Đăng nhập thành công!", hoten, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlcn.Close();
                    this.Close();
                    string admin_tk = "admin";
                    string admin_mk = "admin";
                    if (tbx_tk.Text == admin_tk && tbx_mk.Text == admin_mk)
                    {
                        control_users.admin_Control_Elements_frm_main();
                        frm_scada.user_admin = true;
                    }
                    else
                    {
                        control_users.Operator_Control_Elements_frm_main();
                        frm_scada.user_operator = true;
                    }

                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            tbx_mk.UseSystemPasswordChar = false;
            if (checkBox2.Checked == false)
            {
                tbx_mk.UseSystemPasswordChar = true;
            }
        }

        private void hyperlinkLabelControl2_Click(object sender, EventArgs e)
        {
            frm_resetpass frmResetpasss = new frm_resetpass();
            frmResetpasss.ShowDialog();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            frm_register register = new frm_register();
            register.ShowDialog();
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
