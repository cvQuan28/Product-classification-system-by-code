using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using S7.Net;
using AForge.Video;
using AForge.Video.DirectShow;
//using S7.Net.Types;
using OnBarcode.Barcode.BarcodeScanner;
using System.Threading;
using System.Media;

namespace FORM_SACADA
{
    
    public partial class frm_import_Items : Form
    {
        
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        public frm_import_Items()
        {
            InitializeComponent();
        }
        // Chương trình con hiển thị dữ liệu
        public void Order_Display()
        {
            string sqlSelect = "SELECT * FROM DonHang";
            class_database.sqlDisplay(sqlSelect, dtg_Order);
            // Đặt tên cho các cột datagridview
            dtg_Order.Columns[0].HeaderText = "Mã đơn hàng";
            dtg_Order.Columns[1].HeaderText = "Mã sản phẩm loại 1";
            dtg_Order.Columns[2].HeaderText = "Mã sản phẩm loại 2";
            dtg_Order.Columns[3].HeaderText = "Mã sản phẩm loại 3";
        }
        private void frm_import_Items_Load(object sender, EventArgs e)
        {
            //hien thi du lieu
            Order_Display();

            // kết nối camera
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
                cbx_camera.Items.Add(Device.Name);
            if (cbx_camera.Items.Count > 0)
            {
                cbx_camera.SelectedIndex = 0;
                videoCaptureDevice = new VideoCaptureDevice();
            }

        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            if (txb_filename.Text == "")
            {
                if (bt_start.Text == "Bắt đầu")
                {
                    videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbx_camera.SelectedIndex].MonikerString);
                    videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
                    videoCaptureDevice.Start();
                    timer_scan.Start();                 
                    bt_start.Text = "Dừng lại!";
                }
                else
                {
                    bt_start.Text = "Bắt đầu";
                    lb_type_code.Visible = false;                   
                    if (videoCaptureDevice != null)
                        if (videoCaptureDevice.IsRunning == true)
                            videoCaptureDevice.Stop();
                    pictureBox1.Image = null;
                    timer_scan.Stop();
                }
            }
            
            else
            {
                //------------------đọc QR từ file------------------------------------//
                if (bt_start.Text == "Bắt đầu")
                {
                    try
                    {
                        if (txb_filename.Text != "")
                        {
                            string text = "";
                            string[] Data = ReadBarcodeFromBitmap((Bitmap)pictureBox1.Image);
                            foreach (var item in Data)
                            {
                                text += item.ToString();
                            }
                            txb_QR.Text = text;
                            bt_start.Text = "Dừng lại!";
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Mã không hợp lệ!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    bt_start.Text = "Bắt đầu";
                    if (txb_filename.Text != "")
                    {
                        txb_filename.Text = "";
                        // captureDevice.Stop();
                        pictureBox1.Image = null;
                    }
                    lb_type_code.Visible = false;
                    
    
                }
               
                
        }
        
    
    }     
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
       
        //-------------------- 2 trương trình con đọc file QR------------------//
        private String[] ReadBarcodeFromFile(string _Filepath)
        {
            String[] barcodes = BarcodeScanner.Scan(_Filepath, BarcodeType.Code39);
            return barcodes;
        }
        private String[] ReadBarcodeFromBitmap(Bitmap _bimapimage)
        {
            System.Drawing.Bitmap objImage = _bimapimage;
            String[] barcodes = BarcodeScanner.Scan(objImage, BarcodeType.Code39);
            return barcodes;
        }
        

        private void bt_set_Click(object sender, EventArgs e)
        {
            

        }


        private void btn_sp1_Click(object sender, EventArgs e)
        {
            txb_type1.Text = txb_QR.Text;
            //  pictureBox1.Image = null;
            if (txb_filename.Text == "")
            {
                videoCaptureDevice.Start();
                timer_scan.Start();
            }
            else
            {
                bt_start.Text = "Bắt đầu";
            }
        }

        private void btn_sp2_Click(object sender, EventArgs e)
        {
            txb_type2.Text = txb_QR.Text;
            //  pictureBox1.Image = null;
            if (txb_filename.Text == "")
            {
                videoCaptureDevice.Start();
                timer_scan.Start();
            }
            else
            {
                bt_start.Text = "Bắt đầu";
            }
        }

        private void btn_sp3_Click(object sender, EventArgs e)
        {
            txb_type3.Text = txb_QR.Text;
            //  pictureBox1.Image = null;
            if (txb_filename.Text == "")
            {
                videoCaptureDevice.Start();
                timer_scan.Start();
            }
            else
            {
                bt_start.Text = "Bắt đầu";
            }
        }
        private void btn_filename_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            txb_filename.Text = ofd.FileName.ToString();
           
           if(txb_filename.Text != "")
            pictureBox1.Image = Image.FromFile(txb_filename.Text);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            txb_QR.Text = "";

            // Kiểm tra mã đơn hàng đã tồn tại không
            Boolean Order_Exist = false;
            foreach (DataGridViewRow row in dtg_Order.Rows)
            {
                if (txb_madonhang.Text == row.Cells["MaDonHang"].Value.ToString())
                {
                    Order_Exist = true;
                    // Cảnh báo đơn hàng đẫ tồn tại
                    MessageBox.Show("Đơn hàng đã tồn tại!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            // Nếu đơn hàng không bị trùng thì thêm mới đơn hàng
            if (!Order_Exist)
            {
                // Khai báo giá trị
                string sqltable_name = "DonHang";
                string collum1 = "MaDonHang";
                string collum2 = "MaSanPham1";
                string collum3 = "MaSanPham2";
                string collum4 = "MaSanPham3";
                string data1 = txb_madonhang.Text.ToString();
                string data2 = txb_type1.Text.ToString();
                string data3 = txb_type2.Text.ToString();
                string data4 = txb_type3.Text.ToString();
                // Hàm Ghi dữ liệu
                class_import_sql.cmd_SQLWrite(sqltable_name,
                        collum1, data1,
                        collum2, data2,
                        collum3, data3,
                        collum4, data4);
                MessageBox.Show("Đơn hàng đã được thêm!");
                Order_Display();
                //  frm_scada.frmScada.combobox_dataload();
            }
        }

        private void btn_upd_Click(object sender, EventArgs e)
        {
            // Khai báo giá trị
            string sqltable_name = "DonHang";
            string collum1 = "MaDonHang";
            string collum2 = "MaSanPham1";
            string collum3 = "MaSanPham2";
            string collum4 = "MaSanPham3";
            string data1 = txb_madonhang.Text.ToString();
            string data2 = txb_type1.Text.ToString();
            string data3 = txb_type2.Text.ToString();
            string data4 = txb_type3.Text.ToString();
            // Hàm Ghi dữ liệu
            class_import_sql.cmd_SQLUpdate(sqltable_name,
                    collum1, data1,
                    collum2, data2,
                    collum3, data3,
                    collum4, data4);
            MessageBox.Show("Đơn hàng đã được cập nhật!");
            Order_Display();
            // frm_scada.frmScada.combobox_dataload();
        }

        private void btn_dete_Click(object sender, EventArgs e)
        {
            // Khai báo giá trị
            string sqltable_name = "DonHang";
            string collum1 = "MaDonHang";
            string data1 = txb_madonhang.Text.ToString();
            // Hàm Ghi dữ liệu
            class_import_sql.cmd_SQLDelete(sqltable_name,
                    collum1, data1);
            MessageBox.Show("Đã xóa dữ liệu!");
            Order_Display();

            //   frm_scada.frmScada.combobox_dataload();
        }
        // Hiển thị dữ liệu hàng lên textbox khi click vào một hàng nào đó
        

        private void dtg_Order_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtg_Order.Rows[e.RowIndex];
                txb_madonhang.Text = row.Cells[0].Value.ToString();
                txb_type1.Text = row.Cells[1].Value.ToString();
                txb_type2.Text = row.Cells[2].Value.ToString();
                txb_type3.Text = row.Cells[3].Value.ToString();
            }
        }

        private void frm_import_Items_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
            }
        }

        private void timer_scan_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    if (result.ResultPoints.Length > 0)
                    {
                        var offsetX = pictureBox1.SizeMode == PictureBoxSizeMode.Zoom
                           ? (pictureBox1.Width - pictureBox1.Image.Width) / 2 : 0;
                        var offsetY = pictureBox1.SizeMode == PictureBoxSizeMode.Zoom
                           ? (pictureBox1.Height - pictureBox1.Image.Height) / 2 :
                           0;
                        var rect = new Rectangle((int)result.ResultPoints[0].X + offsetX, (int)result.ResultPoints[0].Y + offsetY, 1, 1);

                        foreach (var point in result.ResultPoints)
                        {
                            if (point.X + offsetX < rect.Left)
                                rect = new Rectangle((int)point.X + offsetX, rect.Y, rect.Width + rect.X - (int)point.X - offsetX, rect.Height);
                            if (point.X + offsetX > rect.Right)
                                rect = new Rectangle(rect.X, rect.Y, rect.Width + (int)point.X - (rect.X - offsetX), rect.Height);
                            if (point.Y + offsetY < rect.Top)
                                rect = new Rectangle(rect.X, (int)point.Y + offsetY, rect.Width, rect.Height + rect.Y - (int)point.Y - offsetY);
                            if (point.Y + offsetY > rect.Bottom)
                                rect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + (int)point.Y - (rect.Y - offsetY));
                        }
                        using (var g = pictureBox1.CreateGraphics())
                        {
                            using (Pen pen = new Pen(Color.Green, 3))
                            {
                                g.DrawRectangle(pen, rect);
                                pen.Color = Color.Yellow;
                                pen.DashPattern = new float[] { 3, 3 };
                                g.DrawRectangle(pen, rect);
                            }
                            g.DrawString(result.ToString(), new Font("Tahoma", 8f), Brushes.Red, new Point(rect.X - 0, rect.Y - 30));
                        }


                    }
                    txb_QR.Text = result.ToString();
                    //lb_type_code.Text = $"- Type: { result.BarcodeFormat.ToString()}";
                    // lb_type_code.Visible = true;
                    timer_scan.Stop();
                    if (videoCaptureDevice.IsRunning)
                        videoCaptureDevice.Stop();
                }
            }
        }
    }
}
