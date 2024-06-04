using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using System.Data.SqlClient; // Thư viện SQL
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
//using OnBarcode.Barcode.BarcodeScanner;
using System.Threading;
using ZXing;
using System.Media;
using Point = System.Drawing.Point;
//using S7.Net;
using OPCAutomation; // Thư viện OPC

namespace FORM_SACADA
{
    public partial class frm_scada : Form
    {
        
        internal static frm_scada frmScada;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        public static string nhanvien = string.Empty;
        public static bool user_admin = false;
        public static bool user_operator = false;
        public frm_scada()
        {
            InitializeComponent();
            frmScada = this;
        }
        //==========================CHƯƠNG TRÌNH CON CLASS==================
        class_control_users control_users = new class_control_users();

        //==========================WATCHDOG================================
        string Watchdog_value = "0";
        private void Timer_Watchdog_Tick(object sender, EventArgs e)
        {
            class_WatchDog.WatchdogStatus(toolStripStatusLabel1, Watchdog_value);
            if(Watchdog_value != "" )
            {
                Save_Alarm("Canh bao", "Mat ket noi voi PLC");
            }
        }
        private void cbx_Order_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT * FROM DonHang";
            string column1 = "MaSanPham1";
            string column2 = "MaSanPham2";
            string column3 = "MaSanPham3";
            class_import_sql.getcomboboxindex(cbx_Order, tbx_Order_type1, tbx_Order_type2, tbx_Order_type3,
                                             sqlSelect, column1, column2, column3);
        }

        private void frm_scada_Load(object sender, EventArgs e)
        {
            frm_main.Load_sacada = true;
            //================phân quyền người dùng===============
            if(user_admin==true)
            {
                control_users.admin_Control_Elements_frm_scada();
                
            }
            else if (user_operator==true)
            {
                control_users.Operator_Control_Elements_frm_scada();
            }
            else
            {
                control_users.Not_Login_form_scada();
            }
            
            //==================kết nối kepware================
            KEPServerEX_Connect(); 
            
            //================= kết nối camera=================
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
                cbx_camera.Items.Add(Device.Name);
            if (cbx_camera.Items.Count > 0)
            {
                cbx_camera.SelectedIndex = 0;
                videoCaptureDevice = new VideoCaptureDevice();
            }

            //load data
            combobox_dataload();
            sqlInnit();
            txb_nv.Text = nhanvien;
            txb_shift.Text = class_Shift.shift_Now();
        }
        // Load dữ liệu cho combobox đơn hàng
        public void combobox_dataload()
        {
            string sqlSelect = "SELECT * FROM DonHang;";
            string collum = "MaDonHang";
            class_import_sql.FillComboBox(cbx_Order, sqlSelect, collum);
        }
        // Khởi tạo SQL
        public void sqlInnit()
        {
            SqlConnection sql_conn;
          // string DB_Name = Properties.Settings.Default.SQL_DBName;
          // string sqlName = @"Data Source =DESKTOP-KR69N05\SQLEXPRESS;Initial Catalog="
          //                  + DB_Name + ";Integrated Security=True";
            sql_conn = new SqlConnection(ConnectSQL.strCon);
        }
        // Gửi dữ liệu đồ thị qua form "frm_Trend.cs"
        static string data_kho1;
        static string data_kho2;
        static string data_kho3;
        // sản lượng kho 1
        public static string trend_data_SP1()
        {
            return data_kho1;
        }
        // sản lượng kho 2
        public static string trend_data_SP2()
        {
            return data_kho2;
        }
        // sản lượng kho 3
        public static string trend_data_SP3()
        {
            return data_kho3;
        }
        
        /*
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        */
        //=================== khi tắt form SCADA==========================
        private void frm_scada_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_main.Load_sacada = false;
            if (videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.Stop();
            }
        }
        //===================== MỞ CAMERA======================================
        private void btn_oncam_Click(object sender, EventArgs e)
        {
            if (btn_oncam.Text == "Start Camera")
            {
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cbx_camera.SelectedIndex].MonikerString);
                videoCaptureDevice.NewFrame += CaptureDevice_NewFrame;
                videoCaptureDevice.Start();
                timer_scan.Start();
                btn_oncam.Text = "Stop Camera";
                //gửi xuống PLC
                WriteItems.SetValue(1, 25);
                PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            }
            else
            {
                btn_oncam.Text = "Start Camera";
                if (videoCaptureDevice != null)
                    if (videoCaptureDevice.IsRunning == true)
                        videoCaptureDevice.Stop();
                pictureBox1.Image = null;
                timer_scan.Stop();
                //------gửi xuống PLC
                WriteItems.SetValue(0, 25);
                PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            }

        }
        //===================== Chọn dữ liệu ảnh mã sản phẩm ==============================//
       private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
       {
           pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
       }
        //==================================Scan MÃ Sản phẩm=============================================//
        bool check_scan = false;
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
                    lb_type_code.Text = $"-{ result.BarcodeFormat.ToString()}";
                    lb_type_code.Visible = true;
                    lb_id_product.Visible = true;
                    lb_id_product.Text = result.ToString();
                    // timer_scan.Stop();
                    // if (videoCaptureDevice.IsRunning)
                    //      videoCaptureDevice.Stop();
                    timer_sorting_ID.Start();
                    timer_sorting_ID.Enabled = true;
                    check_scan = true;
                    Save_history_Data();
                }
                else
                {
                }
                
            }
        }
        //luu lich su san xuat
        private void Save_history_Data()
        {
            // Khai báo giá trị
            string sqltable_name = "production_history";
            string collum1 = "date_time";
            string collum2 = "shift";
            string collum3 = "Madonhang";
            string collum4 = "nhanVien";
            string collum5 = "product_id";
            string collum6 = "status";
            string collum7 = "type";

            string data1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string data2 = class_Shift.shift_Now();
            string data3 = cbx_Order.Text;
            string data4 = nhanvien;
            string data5 = lb_id_product.Text;
            bool   data6 = check_scan;
            string data7 = lb_type_code.Text;
            // Hàm Ghi dữ liệu
            class_database.cmd_SQLWrite_dataHistory(sqltable_name,
                collum1, data1,
                collum2, data2,
                collum3, data3,
                collum4, data4,
                collum5, data5,
                collum6, data6,
                collum7, data7);
        }
        //luu alarm
        private void Save_Alarm(string status, string noidung)
        {
            // Khai báo giá trị
            string sqltable_name = "Alarm";
            string collum1 = "date_time";
            string collum2 = "shift";
            string collum3 = "status";
            string collum4 = "noidung";

            string data1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string data2 = class_Shift.shift_Now();
            string data3 = status;
            string data4 = noidung;
            // Hàm Ghi dữ liệu
            class_database.cmd_SQLWrite_Alarm(sqltable_name,
                collum1, data1,
                collum2, data2,
                collum3, data3,
                collum4, data4);
        }

        //----------------------------- STATUS -----------------------------//
        Class_Status_Display Status_Display = new Class_Status_Display();

        // Khai báo biến tạm lưu dữ liệu sản xuất
        string sql_OrderID;
        string sql_nhanvien;
        string sql_Masanpham1_Setting;
        string sql_Masanpham2_Setting;
        string sql_Masanpham3_Setting;
        //==========================CHƯƠNG TRÌNH CON LƯU DỮ LIỆU SẢN XUẤT=====================
        private void Save_Data()
        {
            // Khai báo giá trị
            string sqltable_name = "production_data";
            string collum1 = "Date_time";
            string collum2 = "Shift";
            string collum3 = "Madonhang";
            string collum4 = "NhanVien";
            string collum5 = "SL_KHO_1";
            string collum6 = "SL_KHO_2";
            string collum7 = "SL_KHO_3";
            string collum8 = "SL_ITEMS_ER";
            string collum9 = "TOTAL";

            string data1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string data2 = class_Shift.shift_Now();
            string data3 = cbx_Order.Text;
            string data4 = nhanvien;
            string data5 = txb_sl_1.Text;
            string data6 = txb_sl_2.Text;
            string data7 = txb_sl_3.Text;
            string data8 = txb_item_error.Text;
            string data9 = txb_sl_total.Text;
            // Hàm Ghi dữ liệu
            class_database.cmd_SQLWrite(sqltable_name,
                collum1, data1,
                collum2, data2,
                collum3, data3,
                collum4, data4,
                collum5, data5,
                collum6, data6,
                collum7, data7,
                collum8, data8,
                collum9, data9);
        }
        //==========================KEPServerEX CONNECT=====================
        static int tagNumber = 48;      // Cài đặt số lượng tag của project
        static int PLCscantime = 1000;  // Cài đặt thời gian quét PLC
        // Gọi các kết nối OPC
        public OPCAutomation.OPCServer AnOPCServer;
        public OPCAutomation.OPCServer OPCServer;
        public OPCAutomation.OPCGroups OPCGroup;
        public OPCAutomation.OPCGroup PLC;
        public string Groupname;

        static int arrlength = tagNumber + 1;
        Array OPtags = class_KEPServerEX.tagread(arrlength);
        Array tagID = class_KEPServerEX.tagID(arrlength);
        Array WriteItems = Array.CreateInstance(typeof(object), arrlength);
        Array tagHandles = Array.CreateInstance(typeof(Int32), arrlength);
        Array OPCError = Array.CreateInstance(typeof(Int32), arrlength);
        Array dataType = Array.CreateInstance(typeof(Int16), arrlength);
        Array AccessPaths = Array.CreateInstance(typeof(string), arrlength);
        Array arrcheck = Array.CreateInstance(typeof(object), arrlength);
        // Chương trình con kết nối (Connect)
        private void KEPServerEX_Connect()
        {
            string IOServer = "Kepware.KEPServerEX.V6";
            string IOGroup = "OPCGroup1";
            OPCServer = new OPCAutomation.OPCServer();
            OPCServer.Connect(IOServer, "");
            PLC = OPCServer.OPCGroups.Add(IOGroup);
            PLC.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(dataScan);
            PLC.UpdateRate = PLCscantime;
            PLC.IsSubscribed = PLC.IsActive;
            PLC.OPCItems.DefaultIsActive = true;
            PLC.OPCItems.AddItems(tagNumber, ref OPtags, ref tagID,
                out tagHandles, out OPCError, dataType, AccessPaths);
        }
        //==========================ĐỌC DỮ LIỆU TAG=====================
        bool dieukien_run = false, posItems1 = false , posItems2 = false , posItems3 = false , posError = false;
        private void dataScan(int ID, int NumItems, ref Array tagID,
            ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            
            for (int i = 1; i <= NumItems; i++)
            {
                // Khai báo biến chung
                int getTagID = Convert.ToInt32(tagID.GetValue(i));
                string tagValue = ItemValues.GetValue(i)?.ToString();
                // Watchdog
                if (getTagID == 1) // số lượng sản phẩm kho 1
                {
                    txb_sl_1.Text = tagValue;
                    txb_sl_t1.Text = tagValue;
                    data_kho1 = tagValue;
                   
                }
                if (getTagID == 2) // số lượng sản phẩm kho 2
                {
                    txb_sl_2.Text = tagValue;
                    txb_sl_t2.Text = tagValue;
                    data_kho2 = tagValue;
                    
                }
                if (getTagID == 3) // số lượng sản phẩm kho 3
                {
                    txb_sl_3.Text = tagValue;
                    txb_sl_t3.Text = tagValue;
                    data_kho3 = tagValue;
                   
                }
                if (getTagID == 37) // số lượng sản phẩm lỗi
                {
                    txb_item_error.Text = tagValue;
                    txb_it_err.Text = tagValue;
                  //  txb_sl_t3.Text = tagValue;
                  //  data_kho3 = tagValue;

                }
                if (getTagID==4) // giá trị tổng sản phẩm đã phân loại
                {
                    txb_sl_total.Text = tagValue;

                }
                if(getTagID==5) // trạng thái cyliner 1
                {
                    Status_Display.stt_cylinder(cylinder_t1, tagValue);
                    Status_Display.stt_cylinder(cylinder_out_t1, tagValue);
                    Status_Display.simu_cylinder(cylinder_out_t1, tagValue);
                  //  posItems1 = true;
                }
                if (getTagID == 6)// trạng thái cyliner 2
                {
                    Status_Display.stt_cylinder(cylinder_t2, tagValue);
                    Status_Display.stt_cylinder(cylinder_out_t2, tagValue);
                    Status_Display.simu_cylinder(cylinder_out_t2, tagValue);
                  //  posItems2 = true;
                }
                if (getTagID == 34)// trạng thái cyliner 3
                {
                    Status_Display.stt_cylinder(cylinder_t3, tagValue);
                    Status_Display.stt_cylinder(cylinder_out_t3, tagValue);
                    Status_Display.simu_cylinder(cylinder_out_t3, tagValue);
                  //  posItems3 = true;
                }
                if (getTagID == 7)// trạng thái nút Reset
                {
                    //Status_Display.STT_Button(btn_reset, tagValue, "#FFFF00", "#FEFCFE");
                }
                if (getTagID == 45) // trạng thái nút Start
                {
                    Status_Display.STT_Button(btn_start, tagValue, "#7CFC00", "#FEFCFE");
                }
                if (getTagID == 46)// trạng thái nút Stop
                {
                    Status_Display.STT_Button(btn_stop, tagValue, "#FF0000", "#FEFCFE");
                }
                if (getTagID == 12)// trạng thái nút auto
                {
                    Status_Display.STT_Button(btt_Auto, tagValue, "#7CFC00", "#FEFCFE");
                    timer_simu_items.Stop();
                }
                if (getTagID == 13)// trạng thái nút manual
                {
                    Status_Display.STT_Button(btt_Manu, tagValue, "#7CFC00", "#FEFCFE");
                }
                if (getTagID == 47)// trạng thái nút tốc độ trung bình
                {
                    Status_Display.STT_Button(btn_RM, tagValue, "#7CFC00", "#FEFCFE");
                }
                if (getTagID == 48)// trạng thái nút tốc độ cao
                {
                    Status_Display.STT_Button(btn_RH, tagValue, "#7CFC00", "#FEFCFE");
                }
                if (getTagID == 14) // trạng thái băng tải
                {
                    Status_Display.stt_conveyor(sym_conveyor1, tagValue);
                    Status_Display.stt_conveyor(sym_conveyor_2, tagValue);
                    Status_Display.stt_conveyor(sym_conveyor_3, tagValue);
                    Status_Display.stt_conveyor(sym_motor_conveyor, tagValue);
                }
                if (getTagID == 24) // kiểm tra sản phẩm lỗi
                {
                    if (tagValue == "True")
                    {
                        lb_type_code.Text = "None";
                        lb_type_code.Visible = true;
                        lb_id_product.Visible = true;
                        lb_id_product.Text = "None";
                        lb_type_product.Text = "NG";
                        lb_type_product.Visible = true;
                        timer_simu_items.Enabled = true;
                        timer_simu_items.Start();
                    }
                }
                if (getTagID == 26) // resset camera
                {
                    if (tagValue == "True")
                    {
                        btn_oncam.PerformClick();
                    }
                }
                if(getTagID == 27) // trạng thái sensor scan
                {
                    Status_Display.stt_sensor(sym_ss_scan, tagValue);
                    if (tagValue == "True")
                    {
                        sym_box.Visible = true;
                    }                                    
                }
                if (getTagID == 28) // trạng thái sensor type1
                {
                        Status_Display.stt_sensor(sym_ss_t1, tagValue);  
                }
                if (getTagID == 29) // trạng thái sensor type2
                {
                        Status_Display.stt_sensor(sym_ss_t2, tagValue);
                }
                if (getTagID == 30) // trạng thái sensor type3
                {
                        Status_Display.stt_sensor(sym_ss_type_3, tagValue);
                }
                if (getTagID == 38) // trạng thái sensor type3
                {
                    txb_value_speed.Text = tagValue;
                }
                //++++Giá trị WatchDog +++
                if (getTagID == 20) // giá trị watchdog
                {
                    Watchdog_value = tagValue;
                }
                //++++DỮ LIỆU SẢN XUẤT +++
                // Bit trigger lưu dữ liệu
                if (getTagID == 19)
                {
                    if (tagValue == "True")
                    {
                        Save_Data();
                    }
                }
            }         
        }
        //==========================NÚT NHẤN ĐIỀU KHIỂN =====================
        // Nút nhấn dừng hệ thống
        private void btn_stop_Click(object sender, EventArgs e)
        {
            WriteItems.SetValue(1, 9);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            WriteItems.SetValue(0, 9);
        }
        // Nút nhấn reset dữ liệu sản xuất
        private void btn_reset_Click(object sender, EventArgs e)
        {
            WriteItems.SetValue(1, 7);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            WriteItems.SetValue(0, 7);
        }
        // Nút nhấn khởi động hệ thống
        private void btn_start_Click(object sender, EventArgs e)
        {
            WriteItems.SetValue(1, 8);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            WriteItems.SetValue(0, 8);
           // timer_sorting_ID.Start();
        }
        // Nút nhấn chọn chế độ bằng tay
        private void btt_Manu_Click(object sender, EventArgs e)
        {
            WriteItems.SetValue(0, 15);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
        }
        // Nút nhấn chọn chế độ tự động
        private void btt_Auto_Click(object sender, EventArgs e)
        {
            WriteItems.SetValue(1, 15);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
        }
        //Nút nhấn lưu dữ liệu sản xuất
        //Nút nhấn chọn tốc đô trung bình
        private void btn_RM_Click(object sender, EventArgs e)
        {
            WriteItems.SetValue(1, 31);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            WriteItems.SetValue(0, 31);
        }
        //Nút nhấn chọn tốc đô cao
        private void btn_RH_Click(object sender, EventArgs e)
        {
            WriteItems.SetValue(1, 32);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            WriteItems.SetValue(0, 32);
        }
        //==========================TRUYỀN DỮ LIỆU POPUP WINDOW====================
        //ON
        public void popup_button_ON_Clicked(int tagID)
        {
            WriteItems.SetValue(1, tagID);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            
        }//OFF
        public void popup_button_OFF_Clicked(int tagID)
        {
            WriteItems.SetValue(0, tagID);
            PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
            
        }
        //==========================NÚT NHÂN POPUP ĐIỀU KHIỂN BẰNG TAY====================
        // Cylinder_1
        private void cylinder_t1_Click(object sender, EventArgs e)
        {
            frm_Popup_Cylinder frm_Cylinder = new frm_Popup_Cylinder();
            frm_Cylinder.tag_ID = 17;   // ID tag Chạy XL1         
            frm_Cylinder.Show();
            frm_Popup_Cylinder.frm_Cylinder.setTitle("Cylinder1 Control");
        }
        // Cylinder_2
        private void cylinder_t2_Click(object sender, EventArgs e)
        {
            frm_Popup_Cylinder frm_Cylinder = new frm_Popup_Cylinder();
            frm_Cylinder.tag_ID = 18;   // ID tag Chạy XL2         
            frm_Cylinder.Show();
            frm_Popup_Cylinder.frm_Cylinder.setTitle("Cylinder2 Control");
        }
        // Cylinder_3
        private void cylinder_t3_Click(object sender, EventArgs e)
        {
            frm_Popup_Cylinder frm_Cylinder = new frm_Popup_Cylinder();
            frm_Cylinder.tag_ID = 33;   // ID tag Chạy XL2         
            frm_Cylinder.Show();
            frm_Popup_Cylinder.frm_Cylinder.setTitle("Cylinder3 Control");
        }

        private void timer_time_now_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lb_date_time.Text = now.ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Save_Data();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if ( btn_history.Text == "product history")
            {
                //dtg_history.Visible = true;
                btn_history.Text = "Hide";
                frm_data_history frmDataHis = new frm_data_history();
                frmDataHis.Show();
            }
            else
            {
                //dtg_history.Visible = false;
                btn_history.Text = "product history";
            }
        }

        private void btn_setting_time_Click(object sender, EventArgs e)
        {
        if (btn_setting_time.Text == "Edit")
        {
                txb_set.Enabled = true;
                btn_setting_time.Text = "Save";
            }
       else
       {
                WriteItems.SetValue(txb_set.Text, 39);
                PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
                btn_setting_time.Text = "Edit";
                MessageBox.Show("Dữ liệu đã được lưu");
                txb_set.Enabled = false;
       }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_IO_system frmIO = new frm_IO_system();
            frmIO.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        //Motor
        private void standardControl8_Click(object sender, EventArgs e)
        {
            frm_Popup_Motor frm_Motor = new frm_Popup_Motor();
            frm_Motor.tag_ID = 16;   // ID tag Chạy XL2         
            frm_Motor.Show();
            frm_Popup_Motor.frm_Motor.setTitle("Conveyor Control");
        }
        //===========================TIMER PHÂN LOẠI MÃ SẢN PHẨM============================
        private void timer_sorting_ID_Tick(object sender, EventArgs e)
        {
              if (txb_QR.Text == tbx_Order_type1.Text)
              {
                  WriteItems.SetValue(1, 21);
                  PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
                  WriteItems.SetValue(0, 21);
                  lb_type_product.Text = "Type1";
                  lb_type_product.Visible = true;
                  timer_sorting_ID.Stop();
                  //mô phỏng di chuyển sản phẩm
                  timer_simu_items.Enabled = true;
                  timer_simu_items.Start();
                  posItems1 = true;
              }
              else if (txb_QR.Text == tbx_Order_type2.Text)
              {
                  WriteItems.SetValue(1, 22);
                  PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
                  WriteItems.SetValue(0, 22);
                  lb_type_product.Text = "Type2";
                  lb_type_product.Visible = true;
                  timer_sorting_ID.Stop();
                  //mô phỏng di chuyển sản phẩm
                  timer_simu_items.Enabled = true;
                  timer_simu_items.Start();
                  posItems2 = true;
            
              }
              else if (txb_QR.Text == tbx_Order_type3.Text)
              {
                  WriteItems.SetValue(1, 23);
                  PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
                  WriteItems.SetValue(0, 23);
                  lb_type_product.Text = "Type3";
                  lb_type_product.Visible = true;
                  timer_sorting_ID.Stop();
                  //mô phỏng di chuyển sản phẩm
                  timer_simu_items.Enabled = true;
                  timer_simu_items.Start();
                  posItems3 = true;
              }
              else
              {
                WriteItems.SetValue(1, 24);
                PLC.SyncWrite(tagNumber, ref tagHandles, ref WriteItems, out OPCError);
                WriteItems.SetValue(0, 24);
                timer_sorting_ID.Stop();
                lb_type_product.Text = "Error";
                Save_Alarm("Canh bao", "San pham nam ngoai don hang");
              }
        }
        int x = 35, y = 300, a = 1;
        private void timer_simu_items_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                sym_box.Location = new Point(x, y);
                if (x >= 170 && posItems1 == true)
                {
                    x = 35;
                    y = 300;
                    sym_box.Location = new Point(x,y);
                    sym_box.Visible = false;
                    posItems1 = false;
                    dieukien_run = false;
                    timer_simu_items.Stop();
                }
                else if (x >= 380 && posItems2 == true)
                {
                    x = 35;
                    y = 300;
                    sym_box.Location = new Point(x, y);
                    sym_box.Visible = false;
                    posItems2 = false;
                    dieukien_run = false;
                    timer_simu_items.Stop();
                }
                else if (x >= 550 && posItems3 == true)
                {
                    x = 35;
                    y = 300;
                    sym_box.Location = new Point(x, y);
                    sym_box.Visible = false;
                    posItems3 = false;
                    dieukien_run = false;
                    timer_simu_items.Stop();
                }
                else if (x >= 700 )
                {
                    x = 35;
                    y = 300;
                    sym_box.Location = new Point(x, y);
                    sym_box.Visible = false;
                    dieukien_run = false;
                    timer_simu_items.Stop();
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
