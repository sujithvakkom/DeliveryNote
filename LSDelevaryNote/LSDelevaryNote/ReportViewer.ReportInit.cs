using System;

namespace LSDelevaryNote
{
    partial class ReportViewer
    {//= typeof(LSDelevaryNote.Provider.Entities.DelivaryTransactionView)
        public void InitReport(Type ReportDataSourcesType,
            string ReportEmbeddedResource= "LSDelevaryNote.SummaryReport.rdlc",
            string DataSourceName = "SummaryDataSet",
            string ReportViewerName = "reportViewer1")
        {
            //this.DelivaryTransactionViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DelivaryTransactionViewBindingSource)).BeginInit();

            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = DataSourceName;
            reportDataSource1.Value = this.DelivaryTransactionViewBindingSource;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = ReportEmbeddedResource;
            //this.reportViewer1.Location = new System.Drawing.Point(3, 53);
            //this.reportViewer1.Name = ReportViewerName;
            //this.reportViewer1.Size = new System.Drawing.Size(1198, 579);
            //this.reportViewer1.TabIndex = 1;

            this.DelivaryTransactionViewBindingSource.DataSource = ReportDataSourcesType;
            ((System.ComponentModel.ISupportInitialize)(this.DelivaryTransactionViewBindingSource)).EndInit();
        }
    }
}