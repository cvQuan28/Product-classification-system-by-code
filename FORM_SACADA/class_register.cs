using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORM_SACADA
{
    class class_register
    {
       private string hoten, email, phone, taikhoan, matkhau;
        public class_register()
        {
            hoten = email = phone = taikhoan = matkhau = "";
        }
        public class_register(string ten, string mail , string didong, string tk, string mk)
        {
            hoten = ten;
            email = mail;
            phone = didong;
            taikhoan = tk;
            matkhau = mk;
            
        }
        public bool KiemtraDangMatkhau() // tối thiểu 7 ký tự và có cả chữ và số
        {
            //Kiểm tra độ dài
            
            if (matkhau.Length < 7)
            {
                return false;
            }
            if (matkhau.Length >= 7)
            {
                //Kiemtra có cả chữ vào số 
                bool kiemtrachu = false; //coi như chưa có chữ
                bool kiemtraso = false; // coi như chưa có số

                for (int i = 0; i < matkhau.Length; i++)
                {
                    if (kiemtrachu == true && kiemtraso == true)
                    {
                        break; //Dừng vòng lặp 
                    }
                    //kiemtra chữ
                    if ((matkhau[i] >= 'A' && matkhau[i] <= 'Z') || (matkhau[i] >= 'a' && matkhau[i] <= 'z'))
                    {
                        kiemtrachu = true;
                    }
                    //kiemtra số
                    //if (matkhau[i] >= '0' && matkhau[i] <= '9')
                    if(char.IsDigit(matkhau[i]))
                    {
                        kiemtraso = true;
                    }
                }

                if (kiemtraso == false || kiemtrachu == false)
                {
                    return false; // không hợp lệ
                }
                if (kiemtraso=true && kiemtrachu==true)
                {
                    return true; // hoàn toàn hợp lệ
                }
            }

               

          
            return true; // hoàn toàn hợp lệ
        }
    }
}
