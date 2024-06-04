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
    public partial class frm_data_history : Form
    {
        public frm_data_history()
        {
            InitializeComponent();
        }
        public void Data_History_Display()
        {
            string sqlSelect = "SELECT * FROM production_history";
            class_database.sqlDisplay(sqlSelect, dtg_data_history);
            // Đặt tên cho các cột datagridview
            dtg_data_history.Columns[0].HeaderText = "Thời gian";
            dtg_data_history.Columns[1].HeaderText = "Ca sản xuất";
            dtg_data_history.Columns[2].HeaderText = "Mã đơn hàng";
            dtg_data_history.Columns[3].HeaderText = "Nhân viên phụ trách";
            dtg_data_history.Columns[4].HeaderText = "Mã sản phẩm";
            dtg_data_history.Columns[5].HeaderText = "Trạng thái";
            dtg_data_history.Columns[6].HeaderText = "Loại mã";
        }
        private void frm_data_history_Load(object sender, EventArgs e)
        {
            Data_History_Display();
        }

        private void dtg_data_history_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Data_History_Display();
        }
    }
}
