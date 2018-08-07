using LSDelevaryNote.Provider;
using LSDelevaryNote.Provider.Entities;
using MyExtentions.DIalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSDelevaryNote
{
    public partial class ReportViewer : Form
    {
        SqlConnectionStringBuilder builder;
        public ReportViewer()
        {
            InitializeComponent();

            builder = new SqlConnectionStringBuilder();
            builder.DataSource = SettingsProvider.GetDataSource();
            builder.InitialCatalog = SettingsProvider.GetDatabase();
            builder.UserID = SettingsProvider.GetUserName();
            builder.Password = SettingsProvider.GetPassword();

            this.radioButtonSummary.Tag = ReportType.SUMMARY;
            this.radioButtonReplinish.Tag = ReportType.REPLENISHMENT;
            
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

            //using (DelivaryDataProvider db = new DelivaryDataProvider(builder.ConnectionString))
            //{
            //    List<DelivaryTransactionView> result = db.getDelivaryTransactionView(
            //        null,
            //        this.textBoxItem.Text.Trim(),
            //        null,
            //        this.dateTimePickerFrom.Value,
            //        this.dateTimePickerTo.Value,
            //        null
            //        );

            //    this.DelivaryTransactionViewBindingSource.DataSource = result;

            //    this.reportViewer1.RefreshReport();
            //}
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if (this.radioButtonSummary.Checked)
                radioButtonReportType_CheckedChanged(this.radioButtonSummary, e);
            else if (this.radioButtonReplinish.Checked)
                radioButtonReportType_CheckedChanged(this.radioButtonReplinish, e);
        }

        private void radioButtonReportType_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if(radioButton.Checked)
            switch ((ReportType)radioButton.Tag) {
                case ReportType.SUMMARY:
                    this.dateTimePickerFrom.Enabled = true;
                    this.dateTimePickerTo.Enabled = true;
                    InitReport(typeof(LSDelevaryNote.Provider.Entities.DelivaryTransactionView));
                    using (DelivaryDataProvider db = new DelivaryDataProvider(builder.ConnectionString))
                    {
                        List<DelivaryTransactionView> result = db.getDelivaryTransactionView(
                            null,
                            this.textBoxItem.Text.Trim(),
                            null,
                            this.dateTimePickerFrom.Value,
                            this.dateTimePickerTo.Value,
                            null
                            );
                            this.DelivaryTransactionViewBindingSource.DataSource = result;
                            this.reportViewer1.RefreshReport();
                    }
                    break;
                case ReportType.REPLENISHMENT:
                    this.dateTimePickerFrom.Enabled = false;
                    this.dateTimePickerTo.Enabled = false;
                    InitReport(
                        typeof(LSDelevaryNote.Provider.Entities.DelivaryTransactionView),
                        ReportEmbeddedResource: "LSDelevaryNote.ReplenishmentReport.rdlc",
                        DataSourceName: "ReplanishDataSet"
                        );
                    using (DelivaryDataProvider db = new DelivaryDataProvider(builder.ConnectionString))
                    {
                        List<DelevaryRelanishment> result = db.getDelivaryReplamishmentView(
                            null,
                            this.textBoxItem.Text.Trim(),
                            null,
                            //null,//
                            DateTime.Now.AddDays(-1).Date,
                            //null,//
                            DateTime.Now.Date,
                            null
                            );
                        this.DelivaryTransactionViewBindingSource.DataSource = result;

                        this.reportViewer1.RefreshReport();
                    }
                    break;
            }
        }
        enum ReportType {
            SUMMARY,REPLENISHMENT
        }
    }
}
