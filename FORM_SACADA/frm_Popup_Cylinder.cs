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
    public partial class frm_Popup_Cylinder : Form
    {
        internal static frm_Popup_Cylinder frm_Cylinder;
        public frm_Popup_Cylinder()
        {
            InitializeComponent();
            frm_Cylinder = this;
        }
        // Chương trình con hiển thị tittle
        public void setTitle(string title)
        {
            this.Text = title;
        }
        // Tạo biến tag ID cho 2 nút nhấn on/off
        public int tag_ID;
        

        //Nút nhấn ON Cylinder
        private void bttMotorRun_Click_1(object sender, EventArgs e)
        {
            frm_scada.frmScada.popup_button_ON_Clicked(tag_ID);
        }
        // Nút nhấn OFF cylinder
        private void bttMotorStop_Click_1(object sender, EventArgs e)
        {
            frm_scada.frmScada.popup_button_OFF_Clicked(tag_ID);
        }
    }
}
