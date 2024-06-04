using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM_SACADA
{
   public class class_control_users
    {
        // Disable toàn bộ khi chưa đăng nhập/ hoặc nhấn đăng xuất
        public void Not_Login_form_main()
        {
            frm_main frm_main = (frm_main)Application.OpenForms["frm_main"];
            
            // Các object trong form main cần Disable
            frm_main.menu_donhang.Enabled = false;
            frm_main.menu_data.Enabled = false;
            frm_main.menu_alarm.Enabled = false;
            frm_main.menu_trend.Enabled = false;
            frm_main.menu_setting.Enabled = false;
            frm_main.menu_qlnv.Enabled = false;
            frm_main.IO_check.Enabled = false;
        }
        public void Not_Login_form_scada()
        {
            frm_scada frm_scada = (frm_scada)Application.OpenForms["frm_scada"];
            // Các object trong form scada cần Disable
            frm_scada.btt_Auto.Enabled = false;
            frm_scada.btt_Manu.Enabled = false;
            frm_scada.btn_start.Enabled = false;
            frm_scada.btn_stop.Enabled = false;
            frm_scada.btn_reset.Enabled = false;
            frm_scada.btn_save.Enabled = false;
            frm_scada.btn_oncam.Enabled = false;
            frm_scada.btn_RM.Enabled = false;
            frm_scada.btn_RH.Enabled = false;
            frm_scada.cbx_Order.Enabled = false;
            frm_scada.txb_set.Enabled = false;      
        }
        // Đăng nhập bằng quyền Admin
        public void admin_Control_Elements_frm_main()
        {
            frm_main frm_main = (frm_main)Application.OpenForms["frm_main"];
            // Các object trong form main cần Enable
            frm_main.menu_donhang.Enabled = true;
            frm_main.menu_data.Enabled = true;
            frm_main.menu_alarm.Enabled = true;
            frm_main.menu_trend.Enabled = true;
            frm_main.menu_setting.Enabled = true;
            frm_main.menu_qlnv.Enabled = true;
            frm_main.IO_check.Enabled = true;
        }
        public void admin_Control_Elements_frm_scada()
        {
            frm_scada frm_scada = (frm_scada)Application.OpenForms["frm_scada"];
            // Các object trong form scada cần Enable
            frm_scada.btt_Auto.Enabled = true;
            frm_scada.btt_Manu.Enabled = true;
            frm_scada.btn_start.Enabled =true;
            frm_scada.btn_stop.Enabled = true;
            frm_scada.btn_reset.Enabled =true;
            frm_scada.btn_save.Enabled = true;
            frm_scada.btn_oncam.Enabled = true;
            frm_scada.btn_RM.Enabled = true;
            frm_scada.btn_RH.Enabled = true;
            frm_scada.cbx_Order.Enabled = true;
            frm_scada.txb_set.Enabled = true;
        }

        // Đăng nhập bằng quyền người dùng Operator
        public void Operator_Control_Elements_frm_main()
        {
            frm_main frm_main = (frm_main)Application.OpenForms["frm_main"];
            
            // Các object trong form main cần enable
            frm_main.menu_donhang.Enabled = true;
            frm_main.menu_data.Enabled = true;
            frm_main.menu_alarm.Enabled = false;
            frm_main.menu_trend.Enabled = true;
            frm_main.menu_setting.Enabled = false;
            frm_main.menu_qlnv.Enabled = false;
            frm_main.IO_check.Enabled = true;
        }
        public void Operator_Control_Elements_frm_scada()
        {
            frm_scada frm_scada = (frm_scada)Application.OpenForms["frm_scada"];
            // Các object trong form scada cần Disable
            frm_scada.btt_Auto.Enabled = true;
            frm_scada.btt_Manu.Enabled = true;
            frm_scada.btn_start.Enabled = true;
            frm_scada.btn_stop.Enabled = true;
            frm_scada.btn_reset.Enabled = true;
            frm_scada.btn_save.Enabled = true;
            frm_scada.btn_oncam.Enabled = true;
            frm_scada.btn_RM.Enabled = true;
            frm_scada.btn_RH.Enabled = true;
            frm_scada.cbx_Order.Enabled = true;
            frm_scada.txb_set.Enabled = true;
        }
    }
}
