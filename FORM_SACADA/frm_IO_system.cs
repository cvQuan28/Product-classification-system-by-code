using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCAutomation; // Thư viện OPC


namespace FORM_SACADA
{
    public partial class frm_IO_system : Form
    {
        public frm_IO_system()
        {
            InitializeComponent();
        }
        string Watchdog_value = "0";
        private void frm_IO_system_Load(object sender, EventArgs e)
        {
            KEPServerEX_Connect();
        }
        private void cbx_IO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_IO.SelectedIndex == 0)
            {
                grp_DI.Visible = true;
            }
            else if (cbx_IO.SelectedIndex == 1)
            {
                grp_DO.Visible = true;
            }
            else if (cbx_IO.SelectedIndex == 5)
            {
                grp_COM.Visible = true;
            }
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
        Class_Status_Display Display = new Class_Status_Display();
        //==========================ĐỌC DỮ LIỆU TAG=====================
        bool dieukien_run = false, posItems1 = false, posItems2 = false, posItems3 = false, posError = false;
        private void dataScan(int ID, int NumItems, ref Array tagID,
            ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {

            for (int i = 1; i <= NumItems; i++)
            {
                // Khai báo biến chung
                int getTagID = Convert.ToInt32(tagID.GetValue(i));
                string tagValue = ItemValues.GetValue(i)?.ToString();

                if (getTagID == 40) //          I_START
                {
                    tbx_value_start.Text = tagValue;
                    if(tagValue=="True")
                    {
                        Display.STT_Textbox(tbx_value_start, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 41) //          I_STOP
                {
                    tbx_value_stop.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_stop, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 42) //          I_RESET
                {
                    tbx_value_reset.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_reset, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 43) //          I_Sw_mode
                {
                    tbx_value_sw_mode.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_sw_mode, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 44) //          I_EMERGENCE
                {
                    tbx_value_emergence.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_emergence, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 27) //          I_ss_scan
                {
                    tbx_value_ss_scan.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_ss_scan, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 28) //          I_ss_type1
                {
                    tbx_value_ss_type1.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_ss_type1, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 29) //          I_ss_type2
                {
                    tbx_value_ss_type2.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_ss_type2, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 30) //          I_ss_type3
                {
                    tbx_value_ss_type3.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_ss_type3, tagValue, "#7CFC00", "000000");
                    }
                }

                if (getTagID == 45) //          Q_run_lamp
                {
                    tbx_value_Q_run.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_Q_run, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 46) //          Q_stop_lamp
                {
                    tbx_value_Q_stop.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_Q_stop, tagValue, "#7CFC00", "000000");
                    }

                }
                if (getTagID == 47) //          Q_mid_speed
                {
                    tbx_value_Q_midspeed.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_Q_midspeed, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 48) //          Q_high_speed
                {
                    tbx_value_Q_high_speed.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_Q_high_speed, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 14) //          Q_conveyor
                {
                    tbx_value_Q_Conveyor.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_Q_Conveyor, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 5) //          Q_Cyl_1
                {
                    tbx_value_Q_Cyl1.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_Q_Cyl1, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 6) //          Q_Cyl_2
                {
                    tbx_value_Q_Cyl2.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_Q_Cyl2, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 34) //          Q_Cyl_3
                {
                    tbx_value_Q_Cyl3.Text = tagValue;
                    if (tagValue == "True")
                    {
                        Display.STT_Textbox(tbx_value_Q_Cyl3, tagValue, "#7CFC00", "000000");
                    }
                }
                if (getTagID == 20) //         Watchdog
                {
                    tbx_value_Watchdog.Text = tagValue;
                    class_WatchDog.WatchdogStatus_txb(tbx_PLC_connect, tagValue);
                    if(tbx_PLC_connect.Text== "Sucessful")
                    {
                        tbx_PLC_connect.BackColor = ColorTranslator.FromHtml("#7CFC00");
                        tbx_PLC_connect.ForeColor = ColorTranslator.FromHtml("000000");
                    }
                    else
                    {
                        tbx_PLC_connect.BackColor = default(Color);
                        tbx_PLC_connect.ForeColor = default(Color);
                    }
                   

                }
                

            }
        }
    }   
}
