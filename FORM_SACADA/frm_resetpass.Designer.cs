namespace FORM_SACADA
{
    partial class frm_resetpass
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
            this.btn_layMK = new System.Windows.Forms.Button();
            this.textBox_emailDK = new System.Windows.Forms.TextBox();
            this.lb_KQ = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_layMK
            // 
            this.btn_layMK.Location = new System.Drawing.Point(159, 296);
            this.btn_layMK.Name = "btn_layMK";
            this.btn_layMK.Size = new System.Drawing.Size(144, 31);
            this.btn_layMK.TabIndex = 7;
            this.btn_layMK.Text = "Lấy lại mật khẩu";
            this.btn_layMK.UseVisualStyleBackColor = true;
            this.btn_layMK.Click += new System.EventHandler(this.btn_layMK_Click);
            // 
            // textBox_emailDK
            // 
            this.textBox_emailDK.Location = new System.Drawing.Point(159, 203);
            this.textBox_emailDK.Name = "textBox_emailDK";
            this.textBox_emailDK.Size = new System.Drawing.Size(245, 22);
            this.textBox_emailDK.TabIndex = 6;
            // 
            // lb_KQ
            // 
            this.lb_KQ.AutoSize = true;
            this.lb_KQ.Location = new System.Drawing.Point(156, 253);
            this.lb_KQ.Name = "lb_KQ";
            this.lb_KQ.Size = new System.Drawing.Size(68, 17);
            this.lb_KQ.TabIndex = 4;
            this.lb_KQ.Text = "Kết Quả :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Email đăng ký :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FORM_SACADA.Properties.Resources.ressetpass;
            this.pictureBox1.Location = new System.Drawing.Point(74, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu của bạn là :";
            // 
            // frm_resetpass
            // 
            this.AcceptButton = this.btn_layMK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.BackgroundImage = global::FORM_SACADA.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(461, 358);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_layMK);
            this.Controls.Add(this.textBox_emailDK);
            this.Controls.Add(this.lb_KQ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_resetpass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_resetpass";
            this.Load += new System.EventHandler(this.frm_resetpass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_layMK;
        private System.Windows.Forms.TextBox textBox_emailDK;
        private System.Windows.Forms.Label lb_KQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}