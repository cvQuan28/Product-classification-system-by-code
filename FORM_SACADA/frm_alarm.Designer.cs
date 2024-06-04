namespace FORM_SACADA
{
    partial class frm_alarm
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
            this.dtg_data_history = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_data_history)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_data_history
            // 
            this.dtg_data_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_data_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg_data_history.Location = new System.Drawing.Point(0, 0);
            this.dtg_data_history.Name = "dtg_data_history";
            this.dtg_data_history.RowTemplate.Height = 24;
            this.dtg_data_history.Size = new System.Drawing.Size(1246, 553);
            this.dtg_data_history.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label8.Image = global::FORM_SACADA.Properties.Resources.backgroud;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1246, 55);
            this.label8.TabIndex = 51;
            this.label8.Text = "ALARM";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 553);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtg_data_history);
            this.Name = "frm_alarm";
            this.Text = "frm_alarm";
            this.Load += new System.EventHandler(this.frm_alarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_data_history)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dtg_data_history;
    }
}