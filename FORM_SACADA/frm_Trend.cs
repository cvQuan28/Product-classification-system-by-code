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
    public partial class frm_Trend : Form
    {
        string getdataSP1 = frm_scada.trend_data_SP1();
        string getdataSP2 = frm_scada.trend_data_SP2();
        string getdataSP3 = frm_scada.trend_data_SP3();
        public frm_Trend()
        {
            InitializeComponent();
        }
        private void fillChart()
        {
            chart1.Series["Sản lượng"].Points.AddXY("Sản phẩm loại 1", getdataSP1);
            chart1.Series["Sản lượng"].Points[0].Label = getdataSP1;
            chart1.Series["Sản lượng"].Points[0].Color = Color.Blue;

            chart1.Series["Sản lượng"].Points.AddXY("Sản phẩm loại 2", getdataSP2);
            chart1.Series["Sản lượng"].Points[1].Label = getdataSP2;
            chart1.Series["Sản lượng"].Points[1].Color = Color.Blue;

            chart1.Series["Sản lượng"].Points.AddXY("Sản phẩm loại 3", getdataSP3);
            chart1.Series["Sản lượng"].Points[2].Label = getdataSP3;
            chart1.Series["Sản lượng"].Points[2].Color = Color.Blue;

            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        }
        private void pieChart()
        {
            chart2.Series["Sản lượng"].Points.AddXY("Sản phẩm loại 1", getdataSP1);
            chart2.Series["Sản lượng"].Points.AddXY("Sản phẩm loại 2", getdataSP2);
            chart2.Series["Sản lượng"].Points.AddXY("Sản phẩm loại 3", getdataSP3);
        }
        private void frm_Trend_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dATA_SYSTEMDataSet1.production_data' table. You can move, or remove it, as needed.
          //  this.production_dataTableAdapter.Fill(this.dATA_SYSTEMDataSet1.production_data);
            fillChart();
            pieChart();
        }
    }
}
