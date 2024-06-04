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
    public partial class frm_alarm : Form
    {
        public frm_alarm()
        {
            InitializeComponent();
        }
        public void Data_Alarm()
        {
            string sqlSelect = "SELECT * FROM Alarm";
            class_database.sqlDisplay(sqlSelect, dtg_data_history);
            // Đặt tên cho các cột datagridview
            dtg_data_history.Columns[0].HeaderText = "Thời gian";
            dtg_data_history.Columns[1].HeaderText = "Ca sản xuất";
            dtg_data_history.Columns[2].HeaderText = "Tình trạng";
            dtg_data_history.Columns[3].HeaderText = "Nội dung";
        }

        private void frm_alarm_Load(object sender, EventArgs e)
        {
            Data_Alarm();
        }
    }
}
