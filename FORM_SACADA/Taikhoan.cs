using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORM_SACADA
{
    class Taikhoan
    {
        private string tentaikhoan;
        private string matkhau;
        private string hoten;

        public Taikhoan()
        {

        }

        public Taikhoan(string tentaikhoan, string matkhau, string hoten)
        {
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            
            this.hoten = hoten;
        }

        public string Tentaikhoan { get => tentaikhoan; set => tentaikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Hoten { get => hoten; set => hoten = value; }
    }
}

