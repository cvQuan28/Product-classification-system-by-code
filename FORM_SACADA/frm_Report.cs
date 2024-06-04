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
    public partial class frm_Report : Form
    {
        public frm_Report()
        {
            InitializeComponent();
        }
        // Gọi hàm lấy dữ liệu từ form data (frm_Production_Data.cs)
        public string rpDatetime_Start;
        public string rpDatetime_End;
        public string rpShift_Search_Start;
        public string rpShift_Search_End;
        public string rptomorrow;
        public string rpShiftID;
        public string rpSearchBy; // = True: Tìm theo thời gian, = False: Theo ca)

        private void frm_Report_Load(object sender, EventArgs e)
        {
            // ++++++Cho full màn hình khi nhấn nút báo cáo (form_Report)++++++
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            // ++++++TÌM KIẾM THEO NGÀY THÁNG++++++
            if (rpSearchBy.ToString() == "True")
            {
                // Quy đổi giá trị thời gian sang dạng "datetime"
                DateTime DateStart = Convert.ToDateTime(rpDatetime_Start);
                DateTime DateEnd = Convert.ToDateTime(rpDatetime_End);
                // Đưa câu lệnh query sang Dataset
                this.production_dataTableAdapter.Fill
                    (this.DssqlReport.production_data, DateStart, DateEnd);
                // Làm mới báo cáo
                this.reportViewer1.RefreshReport();
            }
            // ++++++TÌM KIẾM THEO CA SẢN XUẤT++++++
            else
            {
                // Quy đổi string sang định dạng thời gian (DateTime)
                DateTime Search_Start = Convert.ToDateTime(rpShift_Search_Start);
                DateTime Search_End = Convert.ToDateTime(rpShift_Search_End);
                DateTime Search_Tomorrow = Convert.ToDateTime(rptomorrow);
                if (rpShiftID == "C") // Nếu là ca C
                {
                    // Đưa câu lệnh query sang Dataset
                    this.production_dataTableAdapter.FillBy
                        (this.DssqlReport.production_data, Search_Start,
                        Search_Tomorrow, rpShiftID.ToString());
                    // Làm mới báo cáo
                    this.reportViewer1.RefreshReport();
                }
                else // Ca A và ca B
                {
                    // Đưa câu lệnh query sang Dataset
                    this.production_dataTableAdapter.FillBy
                        (this.DssqlReport.production_data,
                        Search_Start, Search_End, rpShiftID.ToString());
                    // Làm mới báo cáo
                    this.reportViewer1.RefreshReport();
                }
            }
            // Làm full màn hình in
            reportViewer1.SetDisplayMode(Microsoft.
                Reporting.WinForms.DisplayMode.PrintLayout);
        }
    }
}
