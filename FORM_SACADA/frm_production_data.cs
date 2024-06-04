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
    public partial class frm_production_data : Form
    {
        public frm_production_data()
        {
            InitializeComponent();
        }
        // Nút radio button tìm kiếm theo thời gian
        private void rdb_SortbyTime_CheckedChanged(object sender, EventArgs e)
        {
            grb_SortbyTime.Visible = true;
            grb_SortbyShift.Visible = false;
            grb_SortbyTime.Location = new Point(190, 13);
        }
        // Nút radio button tìm kiếm theo ca sản xuất
        private void rdb_SortbyShift_CheckedChanged(object sender, EventArgs e)
        {
            grb_SortbyShift.Visible = true;
            grb_SortbyTime.Visible = false;
            grb_SortbyShift.Location = new Point(190, 13);
        }
        //==========================TÌM KIẾM DỮ LIỆU SQL=====================
        // Nút nhấn tìm kiếm SQL
        private void btt_Search_Click(object sender, EventArgs e)
        {
            
            // SQL tìm kiếm theo thời gian
            string Date_Start = dtpk_DateStart.Value.ToString("yyyy-MM-dd");
            string Time_Start = dtpk_TimeStart.Value.ToString("HH:mm:ss");
            string Date_End = dtpk_DateEnd.Value.ToString("yyyy-MM-dd");
            string Time_End = dtpk_TimeEnd.Value.ToString("HH:mm:ss");
            if (rdb_SortbyTime.Checked == true) // Nếu chọn tìm kiếm theo thời gian
            {
                string tablename = "production_data"; // Bảng cần truy vấn
                string datetime_collum_name = "Date_time";
                string sqlSelect = "SELECT *FROM "
                       + tablename + " where "+ datetime_collum_name+" between '"
                       + Date_Start + " " + Time_Start
                       + "' and '" + Date_End + " " + Time_End
                       + "' ORDER BY " + datetime_collum_name + ";";
                class_database.sqlDisplay(sqlSelect, dataGridView1);
            }
            
            // SQL tìm kiếm theo ca sản xuất
            if (rdb_SortbyShift.Checked == true) // Nếu chọn tìm kiếm theo ca SX
            {
                var dt1 = dtpk_ShiftDate.Value.AddDays(1); // Ngày mai của dtpicker
                string dt = dtpk_ShiftDate.Value.ToString("yyyy-MM-dd");
                string tomorrow = dt1.ToString("yyyy-MM-dd");
                string tablename = "production_data"; // Bảng cần truy vấn
                string datetime_collum_name = "Date_time"; // Cột thời gian
                string Shift_collum_name = "Shift"; // Cột ca sản xuất
                string Shiftname = cb_ShiftSelect.Text; // Tên ca đã lựa chọn
                string search_end_time;
                // Xác định thời điểm kết thúc tìm kiếm
                if (cb_ShiftSelect.Text == "C")
                {
                    search_end_time = tomorrow + " 13:00:00'";
                }
                else // Nếu là ca A hoặc B
                {
                    search_end_time = tomorrow + " 00:00:00'";
                }
                // Câu lệnh tìm kiếm
                string sqlSelect = "SELECT *FROM "
                      + tablename
                      + " where " + Shift_collum_name + " = '" + Shiftname + "' AND "
                      + datetime_collum_name + " between '" + dt + "' and '"
                      + search_end_time
                      + " ORDER BY " + datetime_collum_name + ";";
                class_database.sqlDisplay(sqlSelect, dataGridView1);
                // Đặt tên cho các cột datagridview
                
            }
            dataGridView1.Columns[0].HeaderText = "Ngày Tháng";
            dataGridView1.Columns[1].HeaderText = "Ca sản xuất";
            dataGridView1.Columns[2].HeaderText = "Mã Đơn Hàng";
            dataGridView1.Columns[3].HeaderText = "Nhân Viên";
            dataGridView1.Columns[4].HeaderText = "Sản lượng kho 1";
            dataGridView1.Columns[5].HeaderText = "Sản lượng kho 2";
            dataGridView1.Columns[6].HeaderText = "Sản lượng kho 3";
            dataGridView1.Columns[7].HeaderText = "Sản phẩm lỗi";
            dataGridView1.Columns[8].HeaderText = "Tổng sản lượng";
        }

        private void btt_Report_Click(object sender, EventArgs e)
        {
            // Tạo các biến string từ date time piker
            string Date_Start = dtpk_DateStart.Value.ToString("yyyy-MM-dd");
            string Time_Start = dtpk_TimeStart.Value.ToString("HH:mm:ss");
            string Date_End = dtpk_DateEnd.Value.ToString("yyyy-MM-dd");
            string Time_End = dtpk_TimeEnd.Value.ToString("HH:mm:ss");
            string ShiftDate = dtpk_ShiftDate.Value.ToString("yyyy-MM-dd");
            string tomorrow = dtpk_ShiftDate.Value.AddDays(1).ToString("yyyy-MM-dd");
            string ShiftID = cb_ShiftSelect.Text;
            string SearchBy = rdb_SortbyTime.Checked.ToString();
            // Mở form xuất báo cáo (form_Report)
            frm_Report frm = new frm_Report();
            // Truyền dữ liệu qua form report
            frm.rpDatetime_Start = Date_Start + ' ' + Time_Start;
            frm.rpDatetime_End = Date_End + ' ' + Time_End;
            frm.rpShift_Search_Start = ShiftDate + " 00:00:00";
            frm.rpShift_Search_End = ShiftDate + " 23:59:59";
            frm.rptomorrow = tomorrow + " 23:59:59";
            frm.rpShiftID = ShiftID;
            frm.rpSearchBy = SearchBy;
            frm.Show();
        }

        private void frm_production_data_Load(object sender, EventArgs e)
        {
            dtpk_ShiftDate.Value = DateTime.Now;
            dtpk_DateStart.Value = DateTime.Now;
            dtpk_DateEnd.Value = DateTime.Now;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
