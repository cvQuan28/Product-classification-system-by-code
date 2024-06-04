using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;

namespace FORM_SACADA
{
    public partial class frm_main : Form
    {
        
        public static string Username = string.Empty;
        public static bool Load_sacada = false;
       public frm_main()
        {
            InitializeComponent();
        }
        //==========================CHƯƠNG TRÌNH CON CLASS==================
        class_control_users control_users = new class_control_users();
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            control_users.Not_Login_form_main();
            //statusStrip1.BackColor = Color.Green;
            if(Username == " Admin")
            {
                control_users.admin_Control_Elements_frm_main();
            }
        }
        
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

           frm_login frmLogin = new frm_login();
            frmLogin.ShowDialog();
           // OpenChildForm(new frm_login());
            if (!string.IsNullOrEmpty(Username))
            {
                this.toolStripStatusLabel4.Text = Username;
                this.toolStripStatusLabel4.BackColor = ColorTranslator.FromHtml("lawnGreen");
            }
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }
        private void sCADAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Load_sacada==false)
            {
                frm_scada frmscada = new frm_scada();
                frmscada.Show();
                frm_scada.nhanvien = toolStripStatusLabel4.Text;
                //OpenChildForm(new frm_scada());
            }
            else
            {
            }
            // load tiến độ
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";

        }
        private void mànHìnhChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void đồThịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_Trend());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }
        private void dữLiệuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frm_production_data());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void càiĐặtHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_setting());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void nhậpDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_import_Items());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void tạoMãSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_creatID());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_register register = new frm_register();
            register.ShowDialog();
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thoát không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void đăngXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            control_users.Not_Login_form_main();
            frm_scada.user_admin = false;
            frm_scada.user_operator = false;
            if (Load_sacada == true)
            {
                control_users.Not_Login_form_scada();
            }
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            this.toolStripStatusLabel4.Text = string.Empty;    
        }

        private void menu_qlnv_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_control_users());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void timer_time_now_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lb_date_time.Text = now.ToString();
        }
        private void hỗTrợToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/viet.quan.282/");
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_information());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void iOCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_IO_system());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }

        private void menu_alarm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_alarm());
            toolStripProgressBar1.PerformStep();
            toolStripStatusLabel5.Text = toolStripProgressBar1.Value.ToString() + "%";
        }
    }
}
