using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORM_SACADA
{
    public class class_KEPServerEX
    {
        // Class Khai báo tag
        public static string[] tagread(int tagnumber)
        {
            string tagID_1 = "DOAN.Device1.act_sl_type1";
            string tagID_2 = "DOAN.Device1.act_sl_type2";
            string tagID_3 = "DOAN.Device1.act_sl_type3";
            string tagID_4 = "DOAN.Device1.act_sl_total";
            string tagID_5 = "DOAN.Device1.cylinder_t1";
            string tagID_6 = "DOAN.Device1.cylinder_t2";
            string tagID_7 = "DOAN.Device1.bt_reset";
            string tagID_8 = "DOAN.Device1.bt_start";
            string tagID_9 = "DOAN.Device1.bt_stop";
            string tagID_10 = "DOAN.Device1.run_lamp";
            string tagID_11 = "DOAN.Device1.stop_lamp";
            string tagID_12 = "DOAN.Device1.lamp_auto";
            string tagID_13 = "DOAN.Device1.lamp_manual";
            string tagID_14 = "DOAN.Device1.conveyor";
            string tagID_15 = "DOAN.Device1.bt_mode";
            string tagID_16 = "DOAN.Device1.bt_manu_conveyor";
            string tagID_17 = "DOAN.Device1.bt_manu_cylinder1";
            string tagID_18 = "DOAN.Device1.bt_manu_cylinder2";
            string tagID_19 = "DOAN.Device1.bit_save";
            string tagID_20 = "DOAN.Device1.watchdog";
            string tagID_21 = "DOAN.Device1.sign_type_1";
            string tagID_22 = "DOAN.Device1.sign_type_2";
            string tagID_23 = "DOAN.Device1.sign_type_3";
            string tagID_24 = "DOAN.Device1.sign_error";
            string tagID_25 = "DOAN.Device1.ON_CAM";
            string tagID_26 = "DOAN.Device1.OFF_CAM";
            string tagID_27 = "DOAN.Device1.ss_scan";
            string tagID_28 = "DOAN.Device1.ss_type1";
            string tagID_29 = "DOAN.Device1.ss_type2";
            string tagID_30 = "DOAN.Device1.ss_type3";
            string tagID_31 = "DOAN.Device1.bt_RM";
            string tagID_32 = "DOAN.Device1.bt_RH";
            string tagID_33 = "DOAN.Device1.bt_manu_cylinder3";
            string tagID_34 = "DOAN.Device1.cylinder_t3";
            string tagID_35 = "DOAN.Device1.mid_speed";
            string tagID_36 = "DOAN.Device1.high_speed";
            string tagID_37 = "DOAN.Device1.act_sl_items_error";
            string tagID_38 = "DOAN.Device1.value_speed";
            string tagID_39 = "DOAN.Device1.time_save_data";
            string tagID_40 = "DOAN.Device1.I_START";
            string tagID_41 = "DOAN.Device1.I_STOP";
            string tagID_42 = "DOAN.Device1.I_RESET";
            string tagID_43 = "DOAN.Device1.I_SW_MODE";
            string tagID_44 = "DOAN.Device1.I_EMERGENCE";
            string tagID_45 = "DOAN.Device1.Q_run_lamp";
            string tagID_46 = "DOAN.Device1.Q_stop_lamp";
            string tagID_47 = "DOAN.Device1.Q_mid_speed";
            string tagID_48 = "DOAN.Device1.Q_high_speed";


            string[] tags;
            tags = new string[tagnumber];
            tags.SetValue(tagID_1, 1);
            tags.SetValue(tagID_2, 2);
            tags.SetValue(tagID_3, 3);
            tags.SetValue(tagID_4, 4);
            tags.SetValue(tagID_5, 5);
            tags.SetValue(tagID_6, 6);
            tags.SetValue(tagID_7, 7);
            tags.SetValue(tagID_8, 8);
            tags.SetValue(tagID_9, 9);
            tags.SetValue(tagID_10, 10);
            tags.SetValue(tagID_11, 11);
            tags.SetValue(tagID_12, 12);
            tags.SetValue(tagID_13, 13);
            tags.SetValue(tagID_14, 14);
            tags.SetValue(tagID_15, 15);
            tags.SetValue(tagID_16, 16);
            tags.SetValue(tagID_17, 17);
            tags.SetValue(tagID_18, 18);
            tags.SetValue(tagID_19, 19);
            tags.SetValue(tagID_20, 20);
            tags.SetValue(tagID_21, 21);
            tags.SetValue(tagID_22, 22);
            tags.SetValue(tagID_23, 23);
            tags.SetValue(tagID_24, 24);
            tags.SetValue(tagID_25, 25);
            tags.SetValue(tagID_26, 26);
            tags.SetValue(tagID_27, 27);
            tags.SetValue(tagID_28, 28);
            tags.SetValue(tagID_29, 29);
            tags.SetValue(tagID_30, 30);
            tags.SetValue(tagID_31, 31);
            tags.SetValue(tagID_32, 32);
            tags.SetValue(tagID_33, 33);
            tags.SetValue(tagID_34, 34);
            tags.SetValue(tagID_35, 35);
            tags.SetValue(tagID_36, 36);
            tags.SetValue(tagID_37, 37);
            tags.SetValue(tagID_38, 38);
            tags.SetValue(tagID_39, 39);
            tags.SetValue(tagID_40, 40);
            tags.SetValue(tagID_41, 41);
            tags.SetValue(tagID_42, 42);
            tags.SetValue(tagID_43, 43);
            tags.SetValue(tagID_44, 44);
            tags.SetValue(tagID_45, 45);
            tags.SetValue(tagID_46, 46);
            tags.SetValue(tagID_47, 47);
            tags.SetValue(tagID_48, 48);


            return tags;
        }
        // Class tạo array đọc ID tags - mặc định không đổi
        public static Int32[] tagID(int tagnumber)
        {
            Int32[] cltarr;
            cltarr = new Int32[tagnumber];
            for (int i = 1; i < tagnumber; i++)
            {
                cltarr.SetValue(i, i);
            }
            return cltarr;
        }
    }
}
