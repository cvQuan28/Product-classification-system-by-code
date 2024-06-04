namespace FORM_SACADA
{
    partial class frm_Popup_Motor
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
            this.bttMotorStop = new System.Windows.Forms.Button();
            this.bttMotorRun = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bttMotorStop
            // 
            this.bttMotorStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttMotorStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bttMotorStop.Location = new System.Drawing.Point(94, 123);
            this.bttMotorStop.Margin = new System.Windows.Forms.Padding(4);
            this.bttMotorStop.Name = "bttMotorStop";
            this.bttMotorStop.Size = new System.Drawing.Size(155, 43);
            this.bttMotorStop.TabIndex = 12;
            this.bttMotorStop.Text = "DỪNG";
            this.bttMotorStop.UseVisualStyleBackColor = true;
            this.bttMotorStop.Click += new System.EventHandler(this.bttMotorStop_Click);
            // 
            // bttMotorRun
            // 
            this.bttMotorRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bttMotorRun.Location = new System.Drawing.Point(94, 63);
            this.bttMotorRun.Margin = new System.Windows.Forms.Padding(4);
            this.bttMotorRun.Name = "bttMotorRun";
            this.bttMotorRun.Size = new System.Drawing.Size(155, 43);
            this.bttMotorRun.TabIndex = 11;
            this.bttMotorRun.Text = "CHẠY";
            this.bttMotorRun.UseVisualStyleBackColor = true;
            this.bttMotorRun.Click += new System.EventHandler(this.bttMotorRun_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Blue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(342, 48);
            this.label3.TabIndex = 13;
            this.label3.Text = "ĐIỀU KHIỂN ĐỘNG CƠ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_Popup_Motor
            // 
            this.AcceptButton = this.bttMotorRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::FORM_SACADA.Properties.Resources._3;
            this.CancelButton = this.bttMotorStop;
            this.ClientSize = new System.Drawing.Size(342, 198);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bttMotorStop);
            this.Controls.Add(this.bttMotorRun);
            this.Name = "frm_Popup_Motor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Motor_Conveyor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttMotorStop;
        private System.Windows.Forms.Button bttMotorRun;
        private System.Windows.Forms.Label label3;
    }
}