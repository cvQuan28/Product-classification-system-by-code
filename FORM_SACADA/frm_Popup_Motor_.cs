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
    public partial class frm_Popup_Motor : Form
    {
        internal static frm_Popup_Motor frm_Motor;
        public frm_Popup_Motor()
        {
            InitializeComponent();
            frm_Motor = this;
        }
        // Chương trình con hiển thị tittle
        public void setTitle(string title)
        {
            this.Text = title;
        }
        // Tạo biến tag ID cho 2 nút nhấn on/off
        public int tag_ID;
        //Nút nhấn ON Motor
        private void bttMotorRun_Click(object sender, EventArgs e)
        {
            frm_scada.frmScada.popup_button_ON_Clicked(tag_ID);
        }
        // Nút nhấn OFF Motor
        private void bttMotorStop_Click(object sender, EventArgs e)
        {
            frm_scada.frmScada.popup_button_OFF_Clicked(tag_ID);
        }
    }
}
