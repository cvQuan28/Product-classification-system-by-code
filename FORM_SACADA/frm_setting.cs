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
    public partial class frm_setting : Form
    {
        public frm_setting()
        {
            InitializeComponent();
        }

        private void btt_SQLEdit_Click(object sender, EventArgs e)
        {
            tbx_DBName.Enabled = true;
            btt_SQLSave.Enabled = true;
        }

        private void btt_SQLSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SQL_DBName = tbx_DBName.Text; // Tên Database 
            Properties.Settings.Default.Save(); // Lưu vào Setting
            tbx_DBName.Enabled = false; // Disable text field
            // Hiện thông báo
            MessageBox.Show("Sửa thành công, Khởi động lại phần mềm để cập nhật!");
        }

        private void btt_Shift_Edit_Click(object sender, EventArgs e)
        {
            dtpk_A.Enabled = true;
            dtpk_B.Enabled = true;
            dtpk_C.Enabled = true;
            btt_Shift_Save.Enabled = true;
        }

        private void btt_Shift_Save_Click(object sender, EventArgs e)
        {
           Properties.Settings.Default.Shift_A = dtpk_A.Value.ToString("HH:mm:ss");
           Properties.Settings.Default.Shift_B = dtpk_B.Value.ToString("HH:mm:ss");
           Properties.Settings.Default.Shift_C = dtpk_C.Value.ToString("HH:mm:ss");
            Properties.Settings.Default.Save();
            dtpk_A.Enabled = false;
            dtpk_B.Enabled = false;
            dtpk_C.Enabled = false;
            btt_Shift_Save.Enabled = false;
            MessageBox.Show("Đã thay đổi thời gian lên ca!");
        }

        private void frm_setting_Load(object sender, EventArgs e)
        {
            tbx_DBName.Text = Properties.Settings.Default.SQL_DBName;
            // Khởi tạo Thời gian lên ca các Shift - đưa vào date time piker
           DateTime[] returnvalue = class_Shift.innit_Shift();
           dtpk_A.Value = returnvalue[0];
           dtpk_B.Value = returnvalue[1];
           dtpk_C.Value = returnvalue[2];
        }
    }
}
