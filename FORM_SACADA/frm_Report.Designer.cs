namespace FORM_SACADA
{
    partial class frm_Report
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.production_dataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DssqlReport = new FORM_SACADA.DssqlReport();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.production_dataTableAdapter = new FORM_SACADA.DssqlReportTableAdapters.production_dataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.production_dataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DssqlReport)).BeginInit();
            this.SuspendLayout();
            // 
            // production_dataBindingSource
            // 
            this.production_dataBindingSource.DataMember = "production_data";
            this.production_dataBindingSource.DataSource = this.DssqlReport;
            // 
            // DssqlReport
            // 
            this.DssqlReport.DataSetName = "DssqlReport";
            this.DssqlReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.production_dataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FORM_SACADA.rp_sqlReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // production_dataTableAdapter
            // 
            this.production_dataTableAdapter.ClearBeforeFill = true;
            // 
            // frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_Report";
            this.Text = "frm_Report";
            this.Load += new System.EventHandler(this.frm_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.production_dataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DssqlReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource production_dataBindingSource;
        private DssqlReport DssqlReport;
        private DssqlReportTableAdapters.production_dataTableAdapter production_dataTableAdapter;
    }
}