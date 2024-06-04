namespace FORM_SACADA
{
    partial class frm_production_data
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btt_Search = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdb_SortbyShift = new System.Windows.Forms.RadioButton();
            this.rdb_SortbyTime = new System.Windows.Forms.RadioButton();
            this.grb_SortbyShift = new System.Windows.Forms.GroupBox();
            this.cb_ShiftSelect = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpk_ShiftDate = new System.Windows.Forms.DateTimePicker();
            this.grb_SortbyTime = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpk_TimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpk_DateEnd = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpk_TimeStart = new System.Windows.Forms.DateTimePicker();
            this.dtpk_DateStart = new System.Windows.Forms.DateTimePicker();
            this.btt_Report = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grb_SortbyShift.SuspendLayout();
            this.grb_SortbyTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btt_Search
            // 
            this.btt_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btt_Search.Location = new System.Drawing.Point(756, 23);
            this.btt_Search.Margin = new System.Windows.Forms.Padding(4);
            this.btt_Search.Name = "btt_Search";
            this.btt_Search.Size = new System.Drawing.Size(128, 35);
            this.btt_Search.TabIndex = 31;
            this.btt_Search.Text = "Tìm kiếm";
            this.btt_Search.UseVisualStyleBackColor = true;
            this.btt_Search.Click += new System.EventHandler(this.btt_Search_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.grb_SortbyShift);
            this.panel1.Controls.Add(this.grb_SortbyTime);
            this.panel1.Controls.Add(this.btt_Report);
            this.panel1.Controls.Add(this.btt_Search);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(1, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1281, 718);
            this.panel1.TabIndex = 34;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Controls.Add(this.rdb_SortbyShift);
            this.groupBox5.Controls.Add(this.rdb_SortbyTime);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox5.Location = new System.Drawing.Point(19, 15);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(221, 122);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Lựa chọn tìm kiếm";
            // 
            // rdb_SortbyShift
            // 
            this.rdb_SortbyShift.AutoSize = true;
            this.rdb_SortbyShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdb_SortbyShift.Location = new System.Drawing.Point(8, 71);
            this.rdb_SortbyShift.Margin = new System.Windows.Forms.Padding(4);
            this.rdb_SortbyShift.Name = "rdb_SortbyShift";
            this.rdb_SortbyShift.Size = new System.Drawing.Size(158, 24);
            this.rdb_SortbyShift.TabIndex = 13;
            this.rdb_SortbyShift.Text = "Theo ca sản xuất";
            this.rdb_SortbyShift.UseVisualStyleBackColor = true;
            this.rdb_SortbyShift.CheckedChanged += new System.EventHandler(this.rdb_SortbyShift_CheckedChanged);
            // 
            // rdb_SortbyTime
            // 
            this.rdb_SortbyTime.AutoSize = true;
            this.rdb_SortbyTime.Checked = true;
            this.rdb_SortbyTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdb_SortbyTime.Location = new System.Drawing.Point(8, 36);
            this.rdb_SortbyTime.Margin = new System.Windows.Forms.Padding(4);
            this.rdb_SortbyTime.Name = "rdb_SortbyTime";
            this.rdb_SortbyTime.Size = new System.Drawing.Size(135, 24);
            this.rdb_SortbyTime.TabIndex = 12;
            this.rdb_SortbyTime.TabStop = true;
            this.rdb_SortbyTime.Text = "Theo thời gian";
            this.rdb_SortbyTime.UseVisualStyleBackColor = true;
            this.rdb_SortbyTime.CheckedChanged += new System.EventHandler(this.rdb_SortbyTime_CheckedChanged);
            // 
            // grb_SortbyShift
            // 
            this.grb_SortbyShift.BackColor = System.Drawing.SystemColors.Control;
            this.grb_SortbyShift.Controls.Add(this.cb_ShiftSelect);
            this.grb_SortbyShift.Controls.Add(this.label11);
            this.grb_SortbyShift.Controls.Add(this.label12);
            this.grb_SortbyShift.Controls.Add(this.dtpk_ShiftDate);
            this.grb_SortbyShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grb_SortbyShift.Location = new System.Drawing.Point(248, 170);
            this.grb_SortbyShift.Margin = new System.Windows.Forms.Padding(4);
            this.grb_SortbyShift.Name = "grb_SortbyShift";
            this.grb_SortbyShift.Padding = new System.Windows.Forms.Padding(4);
            this.grb_SortbyShift.Size = new System.Drawing.Size(488, 116);
            this.grb_SortbyShift.TabIndex = 33;
            this.grb_SortbyShift.TabStop = false;
            this.grb_SortbyShift.Text = "Tìm kiếm theo ca";
            this.grb_SortbyShift.Visible = false;
            // 
            // cb_ShiftSelect
            // 
            this.cb_ShiftSelect.FormattingEnabled = true;
            this.cb_ShiftSelect.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cb_ShiftSelect.Location = new System.Drawing.Point(131, 69);
            this.cb_ShiftSelect.Margin = new System.Windows.Forms.Padding(4);
            this.cb_ShiftSelect.Name = "cb_ShiftSelect";
            this.cb_ShiftSelect.Size = new System.Drawing.Size(143, 28);
            this.cb_ShiftSelect.TabIndex = 14;
            this.cb_ShiftSelect.Text = "--Ca SX--";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 72);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Chọn ca:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 36);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "Chọn ngày :";
            // 
            // dtpk_ShiftDate
            // 
            this.dtpk_ShiftDate.AllowDrop = true;
            this.dtpk_ShiftDate.Checked = false;
            this.dtpk_ShiftDate.CustomFormat = "yyyy-mm-dd";
            this.dtpk_ShiftDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_ShiftDate.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dtpk_ShiftDate.Location = new System.Drawing.Point(131, 30);
            this.dtpk_ShiftDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpk_ShiftDate.Name = "dtpk_ShiftDate";
            this.dtpk_ShiftDate.Size = new System.Drawing.Size(143, 26);
            this.dtpk_ShiftDate.TabIndex = 0;
            this.dtpk_ShiftDate.Value = new System.DateTime(2021, 9, 14, 14, 29, 43, 0);
            // 
            // grb_SortbyTime
            // 
            this.grb_SortbyTime.BackColor = System.Drawing.SystemColors.Control;
            this.grb_SortbyTime.Controls.Add(this.label10);
            this.grb_SortbyTime.Controls.Add(this.dtpk_TimeEnd);
            this.grb_SortbyTime.Controls.Add(this.dtpk_DateEnd);
            this.grb_SortbyTime.Controls.Add(this.label9);
            this.grb_SortbyTime.Controls.Add(this.dtpk_TimeStart);
            this.grb_SortbyTime.Controls.Add(this.dtpk_DateStart);
            this.grb_SortbyTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grb_SortbyTime.Location = new System.Drawing.Point(248, 15);
            this.grb_SortbyTime.Margin = new System.Windows.Forms.Padding(4);
            this.grb_SortbyTime.Name = "grb_SortbyTime";
            this.grb_SortbyTime.Padding = new System.Windows.Forms.Padding(4);
            this.grb_SortbyTime.Size = new System.Drawing.Size(488, 124);
            this.grb_SortbyTime.TabIndex = 29;
            this.grb_SortbyTime.TabStop = false;
            this.grb_SortbyTime.Text = "Tìm kiếm theo thời gian";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 75);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Kết thúc:";
            // 
            // dtpk_TimeEnd
            // 
            this.dtpk_TimeEnd.CustomFormat = "HH:mm:ss";
            this.dtpk_TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_TimeEnd.Location = new System.Drawing.Point(287, 71);
            this.dtpk_TimeEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpk_TimeEnd.Name = "dtpk_TimeEnd";
            this.dtpk_TimeEnd.ShowUpDown = true;
            this.dtpk_TimeEnd.Size = new System.Drawing.Size(153, 26);
            this.dtpk_TimeEnd.TabIndex = 4;
            // 
            // dtpk_DateEnd
            // 
            this.dtpk_DateEnd.AllowDrop = true;
            this.dtpk_DateEnd.Checked = false;
            this.dtpk_DateEnd.CustomFormat = "yyyy-mm-dd";
            this.dtpk_DateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_DateEnd.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dtpk_DateEnd.Location = new System.Drawing.Point(131, 71);
            this.dtpk_DateEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpk_DateEnd.Name = "dtpk_DateEnd";
            this.dtpk_DateEnd.Size = new System.Drawing.Size(143, 26);
            this.dtpk_DateEnd.TabIndex = 3;
            this.dtpk_DateEnd.Value = new System.DateTime(2021, 9, 14, 14, 29, 43, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 38);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Bắt đầu:";
            // 
            // dtpk_TimeStart
            // 
            this.dtpk_TimeStart.CustomFormat = "HH:mm:ss";
            this.dtpk_TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_TimeStart.Location = new System.Drawing.Point(287, 36);
            this.dtpk_TimeStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtpk_TimeStart.Name = "dtpk_TimeStart";
            this.dtpk_TimeStart.ShowUpDown = true;
            this.dtpk_TimeStart.Size = new System.Drawing.Size(153, 26);
            this.dtpk_TimeStart.TabIndex = 1;
            // 
            // dtpk_DateStart
            // 
            this.dtpk_DateStart.AllowDrop = true;
            this.dtpk_DateStart.Checked = false;
            this.dtpk_DateStart.CustomFormat = "yyyy-mm-dd";
            this.dtpk_DateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpk_DateStart.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dtpk_DateStart.Location = new System.Drawing.Point(131, 36);
            this.dtpk_DateStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtpk_DateStart.Name = "dtpk_DateStart";
            this.dtpk_DateStart.Size = new System.Drawing.Size(143, 26);
            this.dtpk_DateStart.TabIndex = 0;
            this.dtpk_DateStart.Value = new System.DateTime(2021, 9, 14, 14, 29, 43, 0);
            // 
            // btt_Report
            // 
            this.btt_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btt_Report.Location = new System.Drawing.Point(756, 66);
            this.btt_Report.Margin = new System.Windows.Forms.Padding(4);
            this.btt_Report.Name = "btt_Report";
            this.btt_Report.Size = new System.Drawing.Size(128, 39);
            this.btt_Report.TabIndex = 32;
            this.btt_Report.Text = "Báo cáo";
            this.btt_Report.UseVisualStyleBackColor = true;
            this.btt_Report.Click += new System.EventHandler(this.btt_Report_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 147);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1281, 610);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label1.Image = global::FORM_SACADA.Properties.Resources.backgroud;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1173, 55);
            this.label1.TabIndex = 51;
            this.label1.Text = "TRA CỨU DỮ LIỆU SẢN XUẤT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_production_data
            // 
            this.AcceptButton = this.btt_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1173, 778);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_production_data";
            this.Text = "frm_production_data";
            this.Load += new System.EventHandler(this.frm_production_data_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grb_SortbyShift.ResumeLayout(false);
            this.grb_SortbyShift.PerformLayout();
            this.grb_SortbyTime.ResumeLayout(false);
            this.grb_SortbyTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btt_Report;
        private System.Windows.Forms.RadioButton rdb_SortbyShift;
        private System.Windows.Forms.RadioButton rdb_SortbyTime;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpk_TimeEnd;
        private System.Windows.Forms.DateTimePicker dtpk_DateEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpk_TimeStart;
        private System.Windows.Forms.DateTimePicker dtpk_DateStart;
        private System.Windows.Forms.Button btt_Search;
        private System.Windows.Forms.GroupBox grb_SortbyTime;
        private System.Windows.Forms.GroupBox grb_SortbyShift;
        private System.Windows.Forms.ComboBox cb_ShiftSelect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpk_ShiftDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}