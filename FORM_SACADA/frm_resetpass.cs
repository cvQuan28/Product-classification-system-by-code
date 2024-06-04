using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM_SACADA
{
    public partial class frm_resetpass : Form
    {
        public frm_resetpass()
        {
            InitializeComponent();
            lb_KQ.Text = "";
        }
        modify modify = new modify();
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frm_resetpass_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btn_layMK_Click(object sender, EventArgs e)
        {
            string emailDK = textBox_emailDK.Text;
            if (emailDK.Trim() == "") { MessageBox.Show("vui long nhap email"); }
            else
            {
                string query = "select * from Users where Email='" + emailDK + "'";
                if (modify.Taikhoans(query).Count != 0)
                {
                    lb_KQ.ForeColor = Color.Green;
                    lb_KQ.Text = modify.Taikhoans(query)[0].Matkhau;                   
                }
                else
                {
                    lb_KQ.ForeColor = Color.Red;
                    lb_KQ.Text = "Email này chưa được đăng ký !";

                }
            }
        }
    }
}
