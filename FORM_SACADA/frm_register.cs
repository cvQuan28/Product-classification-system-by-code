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
using System.Text.RegularExpressions;

namespace FORM_SACADA
{
    public partial class frm_register : Form
    {
        public frm_register()
        {
            InitializeComponent();
        }
        public bool checkacc(string ac)
        {
            return Regex.IsMatch(ac, "^[a-z A-Z 0-9]{2,24}$");
        }
        public bool checkmail(string em)
        {
            return Regex.IsMatch(em, @"^[\w]{3,25}@gmail.com(.vn|)$");
        }
        modify modify = new modify();
        private void txb_xacnhanmk_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btn_dangky.PerformClick();
            }
        }
        private void frm_register_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txb_hoten.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên");
                txb_hoten.Focus(); // đưa con trỏ về lại textbox họ tên
            }
            else if (txb_mail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email");
                txb_mail.Focus();
            }
            else if (txb_phone.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại");
                txb_phone.Focus();
            }
            else if (txb_tk.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
                txb_tk.Focus();
            }
            else if (txb_mk.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                txb_mk.Focus();
            }
            else if (txb_xacnhanmk.Text == "")
            {
                MessageBox.Show("Bạn chưa xác nhận mật khẩu");
                txb_xacnhanmk.Focus();
            }
            else if (txb_mk.Text != txb_xacnhanmk.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng, Vui lòng thử lại");
                txb_xacnhanmk.Focus();
                txb_xacnhanmk.SelectAll();
            }
            //Kiểm tra số 
            int value_number;
            bool kiemtra_so = int.TryParse(txb_phone.Text, out value_number);
            if (kiemtra_so == false)
            {
                MessageBox.Show("Só điện thoại phải nhập bằng số");
                return;
            }
            //nếu thỏa mãn tất cả thì kiểm tra sql
            if (txb_hoten.Text != "" && txb_mail.Text != "" && txb_phone.Text != "" && txb_tk.Text != "" && txb_mk.Text != "" && txb_xacnhanmk.Text != "" && kiemtra_so == true)
            {
                //so sánh SQL
                string tentk = @txb_tk.Text;
                string matkhau = txb_mk.Text;
                string xacnhanmk = txb_xacnhanmk.Text;
                string email = txb_mail.Text;
                string hoten = txb_hoten.Text;
                string sdt = txb_phone.Text;
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string MaNV = tbx_manhanvien.Text;
                string sex = @cbx_sex.Text;
                if (!checkacc(tentk)) { MessageBox.Show("Vui lòng nhập lại tên tài khoản khác"); return; }
                if (!checkacc(matkhau)) { MessageBox.Show("Vui lòng nhập mật khẩu"); return; }
                if (xacnhanmk != matkhau) { MessageBox.Show("Vui lòng xác nhận mật khẩu"); return; }
                // if (!checkacc(hoten)) { MessageBox.Show("Họ và tên người dùng đã tồn tại"); return; }
                if (!checkmail(email)) { MessageBox.Show("Vui lòng nhập đúng dạng Email"); return; }
                // if (!checkmail(MaNV)) { MessageBox.Show("Mã nhân viên đã tồn tại"); return; }
                if (modify.Taikhoans("Select * from Users where Email='" + email + "'").Count != 0) { MessageBox.Show("Email này đã được đăng ký,vui lòng nhập Email khác!"); return; }
                if (modify.Taikhoans("Select * from Users where MaNV='" + MaNV + "'").Count != 0) { MessageBox.Show("Mã nhân viên đã tồn tại!"); return; }
                if (modify.Taikhoans("Select * from Users where Taikhoan='" + tentk + "'").Count != 0) { MessageBox.Show("Tên tài khoản đã tồn tại!"); return; }
                try
                {

                    String query = "Insert into Users values('" + tentk + "','" + matkhau + "','" + email + "','" + MaNV + "','" + date + "','" + hoten + "','" + sex + "','" + sdt + "')";
                    modify.Command(query);
                    MessageBox.Show("Bạn đã đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult tb = MessageBox.Show("Bạn có muốn đăng nhập ngay bây giờ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (tb == DialogResult.Yes)
                    {
                        this.Close();
                        frm_login frm_login = new frm_login();
                        frm_login.ShowDialog();

                    }
                    else if (tb == DialogResult.No)
                    {
                        this.Close();
                    }


                }
                catch
                {
                    MessageBox.Show("Tài khoản đã tồn tại, Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*
                else
                {
                    class_register nd = new class_register(txb_hoten.Text, txb_mail.Text, txb_mk.Text, txb_phone.Text, txb_tk.Text);


                       if (nd.KiemtraDangMatkhau() == true ) 
                        {
                        MessageBox.Show("Mật khẩu hợp lệ");
                        }


                       else
                    {
                        MessageBox.Show("Mật khẩu không hợp lệ, Vui lòng thử lại");
                    }
                }
                */
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult hdk = MessageBox.Show("Bạn có chắc muốn hủy đăng ký không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hdk == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}
