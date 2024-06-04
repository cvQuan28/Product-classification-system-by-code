using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORM_SACADA
{
    public static class class_Shift
    {
        // Kiểm tra ca hiện tại
        public static string shift_Now()
        {
            string Shiftnow = "";
            string st1 = Properties.Settings.Default.Shift_A;
            string st2 = Properties.Settings.Default.Shift_B;
            string st3 = Properties.Settings.Default.Shift_C;
            string stimenow = DateTime.Now.ToString("HH:mm:ss");

            DateTime t1 = DateTime.Parse(st1);
            DateTime t2 = DateTime.Parse(st2);
            DateTime t3 = DateTime.Parse(st3);
            DateTime timenow = DateTime.Parse(stimenow);
            if (timenow.TimeOfDay >= t1.TimeOfDay && timenow.TimeOfDay < t2.TimeOfDay)
            {
                Shiftnow = "A"; // Ca A
            }
            else if (timenow.TimeOfDay >= t2.TimeOfDay && timenow.TimeOfDay < t3.TimeOfDay)
            {
                Shiftnow = "B"; // Ca B
            }
            else
            {
                Shiftnow = "C"; // Ca C
            }
            return Shiftnow;
        }

        // Đưa dữ liệu cài đặt vào date time piker
        public static DateTime[] innit_Shift()
        {
            DateTime[] arr = new DateTime[3];
            var t1 = Properties.Settings.Default.Shift_A;
            var t2 = Properties.Settings.Default.Shift_B;
            var t3 = Properties.Settings.Default.Shift_C;
            string vt1 = "2021-09-14 " + t1;
            string vt2 = "2021-09-14 " + t2;
            string vt3 = "2021-09-14 " + t3;

            DateTime st1 = DateTime.ParseExact(vt1, "yyyy-MM-dd HH:mm:ss", null);
            DateTime st2 = DateTime.ParseExact(vt2, "yyyy-MM-dd HH:mm:ss", null);
            DateTime st3 = DateTime.ParseExact(vt3, "yyyy-MM-dd HH:mm:ss", null);
            arr[0] = st1;
            arr[1] = st2;
            arr[2] = st3;
            return arr;
        }
    }
}
