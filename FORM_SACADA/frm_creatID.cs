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
using OnBarcode.Barcode;
using System.Drawing.Imaging;

namespace FORM_SACADA
{
    public partial class frm_creatID : Form
    {
        public frm_creatID()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            txb_loca.Text = sfd.FileName.ToString() + ".gif";
        }
        private void GenerateQrcode(string _data, string _filename)
        {

            QRCode qrcode = new QRCode();
            qrcode.Data = _data;
            qrcode.DataMode = QRCodeDataMode.Byte;
            qrcode.UOM = UnitOfMeasure.PIXEL;
            qrcode.X = 3;
            qrcode.LeftMargin = 0;
            qrcode.RightMargin = 0;
            qrcode.TopMargin = 0;
            qrcode.BottomMargin = 0;
            qrcode.Resolution = 72;
            qrcode.Rotate = Rotate.Rotate0;
            qrcode.ImageFormat = ImageFormat.Gif;
            qrcode.drawBarcode(_filename);

        }
        private void GenerateBacode(string _data, string _filename)
        {
            Linear barcode = new Linear();
            barcode.Type = BarcodeType.CODABAR;
            barcode.Data = _data;
            barcode.drawBarcode(_filename);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateBacode(txb_maQR.Text, txb_loca.Text);
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox2.Image = barcode.Draw(txb_maQR.Text, 50);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txb_maQR.Text != null)
            {
                
                GenerateQrcode(txb_maQR.Text, txb_loca.Text);
                Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                pictureBox2.Image = qrcode.Draw(txb_maQR.Text, 100);
            }
            if (txb_maQR.Text == null)
            {
                MessageBox.Show("Vui lòng điền mã sản phẩm", "Thông báo");

            }
        }

        private void frm_creatID_Load(object sender, EventArgs e)
        {

        }
    }
}
