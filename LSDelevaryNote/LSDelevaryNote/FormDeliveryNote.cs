using Microsoft.Reporting.WinForms;
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
    public partial class FormDeliveryNote : Form
    {
        public FormDeliveryNote()
        {
            try
            {
                InitializeComponent();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = SettingsProvider.GetDataSource();
                builder.InitialCatalog = SettingsProvider.GetDatabase();
                builder.UserID = SettingsProvider.GetUserName();
                builder.Password = SettingsProvider.GetPassword();


                var receipt = this.textBoxReceipt.Text.Trim();
                int type = 2;
                int entryStatus = 0;
                int transactionStatus = 0;
                int defaultAddressType = 0;
                Transaction TransactionHeader = new Transaction();
                TransactionCustomer TransactionCustomer = new TransactionCustomer();
                TransactionLines TransactionLines = new TransactionLines(null);

                using (var db = new DeliveryDbContext(builder.ConnectionString))
                {
                    if (string.IsNullOrEmpty(receipt))
                    {
                        var x = from l in db.RBOTRANSACTIONTABLE
                                where
                                l.TYPE == type &&
                                l.ENTRYSTATUS == entryStatus
                                orderby l.TRANSACTIONID descending
                                select l.RECEIPTID;
                        receipt = x.ToArray()[0].ToString();
                        textBoxReceipt.Text = receipt;
                    }
                    var transaction = from tra_h in db.RBOTRANSACTIONTABLE
                                      join sto in db.RBOSTORETABLE on tra_h.STORE equals sto.STOREID
                                      where tra_h.RECEIPTID == receipt &&
                                        tra_h.TYPE == type &&
                                        tra_h.ENTRYSTATUS == entryStatus
                                      select new Transaction()
                                      {
                                          ReceiptID = tra_h.RECEIPTID,
                                          StoreID = sto.STOREID,
                                          Name = sto.NAME,
                                          TransDate = tra_h.TRANSDATE ?? DateTime.MinValue,
                                          NetAmount = tra_h.NETAMOUNT ?? 0
                                      };

                    var transactionLine = from tra_h in db.RBOTRANSACTIONTABLE
                                          join tra_l in db.RBOTRANSACTIONSALESTRANS
                                          on tra_h.TRANSACTIONID equals tra_l.TRANSACTIONID
                                          join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                                          on
                                          new { tra_l.TRANSACTIONID, tra_l.LINENUM, INFOCODEID = Program.isDelevary } equals new { tra_i.TRANSACTIONID, tra_i.LINENUM, tra_i.INFOCODEID } into info_d
                                          from info in info_d.DefaultIfEmpty()
                                          join info_sub in db.RBOINFORMATIONSUBCODETABLE on
                                          info.INFORMATION equals info_sub.SUBCODEID into info_sub_d
                                          from info_s in info_sub_d.DefaultIfEmpty()
                                          where tra_h.RECEIPTID == receipt &&
                                            tra_h.TYPE == type &&
                                            tra_h.ENTRYSTATUS == entryStatus &&
                                            tra_l.TRANSACTIONSTATUS == transactionStatus
                                          select new TransactionLine()
                                          {
                                              ItemId = tra_l.ITEMID,
                                              Description = tra_l.DESCRIPTION,
                                              Qty = (tra_l.QTY ?? 0) * -1,
                                              TaxInckInPrice = tra_l.TAXINCLINPRICE ?? 0,
                                              Comment = tra_l.COMMENT,
                                              ExtraInfo = string.IsNullOrEmpty(info_s.DESCRIPTION) ? "NON DELIVERABLE" : info_s.DESCRIPTION
                                          };

                    var transactionCustomer = from tra_h in db.RBOTRANSACTIONTABLE
                                              join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                                              on
                                              new { tra_h.TRANSACTIONID, INFOCODEID = Program.customerInfoCode } equals new { tra_i.TRANSACTIONID, tra_i.INFOCODEID } into info_d
                                              from info in info_d.DefaultIfEmpty()
                                              join cust in db.CUSTTABLE on new { CUSTACCOUNT = string.IsNullOrEmpty(info.INFORMATION) ? tra_h.CUSTACCOUNT : info.INFORMATION } equals
                                              new { CUSTACCOUNT = cust.ACCOUNTNUM }
                                              join address in db.CUSTOMERADDRESS on
                                              new { cust.ACCOUNTNUM, ADDRESSTYPE = defaultAddressType } equals new { address.ACCOUNTNUM, address.ADDRESSTYPE }
                                              where tra_h.RECEIPTID == receipt &&
                                                tra_h.TYPE == type &&
                                                tra_h.ENTRYSTATUS == entryStatus
                                              select new TransactionCustomer()
                                              {
                                                  ReceiptID = tra_h.RECEIPTID,
                                                  CustAccount = string.IsNullOrEmpty(info.INFORMATION) ? tra_h.CUSTACCOUNT : info.INFORMATION,
                                                  Name = cust.NAME,
                                                  Address = cust.ADDRESS,
                                                  Phone = cust.PHONE,
                                                  Address1 = address.ADDRESS,
                                                  Street = address.STREET
                                              };

                    TransactionHeader = transaction.Count() > 0 ? transaction.ToList()[0] : null;

                    TransactionLines = transactionLine.Count() > 0 ? new TransactionLines(transactionLine.ToList()) : null;

                    TransactionCustomer = transactionCustomer.Count() > 0 ? transactionCustomer.ToList()[0] : null;

                    this.dataGridViewReceipt.DataSource = transaction.ToList();

                    this.dataGridViewTransaction.DataSource = transactionLine.ToList();


                    this.dataGridViewCustomer.DataSource = transactionCustomer.ToList();

                    this.TransactionBindingSource.DataSource = TransactionHeader;

                    this.TransactionCustomerBindingSource.DataSource = TransactionCustomer;

                    this.TransactionLinesBindingSource.DataSource = TransactionLines;

                    //ReportDataSource dataSourceTran = new ReportDataSource("Transaction", transaction.Count() > 0 ? transaction.ToList()[0] : null);
                    //ReportDataSource dataSourceCust = new ReportDataSource("TrransactionCustomer", transactionCustomer.Count() > 0 ? transactionCustomer.ToList()[0] : null);
                    //ReportDataSource dataSourceLine = new ReportDataSource("TransactionLines", transactionLine.Count() > 0 ? new TransactionLines(transactionLine.ToList()) : null);

                    //this.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceTran);
                    //Sthis.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceCust);
                    //this.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceLine);
                    this.reportViewerDelivary.RefreshReport();
                }
                this.dataGridViewReceipt.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
                this.DialogResult = DialogResult.Cancel;

                string receipt = textBoxReceipt.Text.Trim();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = SettingsProvider.GetDataSource();
                builder.InitialCatalog = SettingsProvider.GetDatabase();
                builder.UserID = SettingsProvider.GetUserName();
                builder.Password = SettingsProvider.GetPassword();
                int type = 2;
                int entryStatus = 0;
                int transactionStatus = 0;
                int defaultAddressType = 0;
                Transaction TransactionHeader = new Transaction();
                TransactionCustomer TransactionCustomer = new TransactionCustomer();
                TransactionLines TransactionLines = new TransactionLines(null);

            using (var db = new DeliveryDbContext(builder.ConnectionString))
            {
                var transaction = from tra_h in db.RBOTRANSACTIONTABLE
                                  join sto in db.RBOSTORETABLE on tra_h.STORE equals sto.STOREID
                                  where tra_h.RECEIPTID == receipt &&
                                    tra_h.TYPE == type &&
                                    tra_h.ENTRYSTATUS == entryStatus
                                  select new Transaction()
                                  {
                                      ReceiptID = tra_h.RECEIPTID,
                                      StoreID = sto.STOREID,
                                      Name = sto.NAME,
                                      TransDate = tra_h.TRANSDATE ?? DateTime.MinValue,
                                      NetAmount = tra_h.NETAMOUNT ?? 0
                                  };

                var transactionLine = from tra_h in db.RBOTRANSACTIONTABLE
                                      join tra_l in db.RBOTRANSACTIONSALESTRANS
                                      on tra_h.TRANSACTIONID equals tra_l.TRANSACTIONID
                                      join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                                      on
                                      new { tra_l.TRANSACTIONID, tra_l.LINENUM, INFOCODEID = Program.isDelevary } equals new { tra_i.TRANSACTIONID, tra_i.LINENUM, tra_i.INFOCODEID } into info_d
                                      from info in info_d.DefaultIfEmpty()
                                      join info_sub in db.RBOINFORMATIONSUBCODETABLE on
                                      info.INFORMATION equals info_sub.SUBCODEID into info_sub_d
                                      from info_s in info_sub_d.DefaultIfEmpty()
                                      where tra_h.RECEIPTID == receipt &&
                                        tra_h.TYPE == type &&
                                        tra_h.ENTRYSTATUS == entryStatus &&
                                        tra_l.TRANSACTIONSTATUS == transactionStatus
                                      select new TransactionLine()
                                      {
                                          ItemId = tra_l.ITEMID,
                                          Description = tra_l.DESCRIPTION,
                                          Qty = (tra_l.QTY ?? 0) * -1,
                                          TaxInckInPrice = tra_l.TAXINCLINPRICE ?? 0,
                                          Comment = tra_l.COMMENT,
                                          ExtraInfo = string.IsNullOrEmpty(info_s.DESCRIPTION) ? "NON DELIVERABLE" : info_s.DESCRIPTION
                                      };

                var transactionCustomer = from tra_h in db.RBOTRANSACTIONTABLE
                                          join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                                          on
                                          new { tra_h.TRANSACTIONID, INFOCODEID = Program.customerInfoCode } equals new { tra_i.TRANSACTIONID, tra_i.INFOCODEID } into info_d
                                          from info in info_d.DefaultIfEmpty()
                                          join cust in db.CUSTTABLE on new { CUSTACCOUNT = string.IsNullOrEmpty(info.INFORMATION) ? tra_h.CUSTACCOUNT : info.INFORMATION } equals
                                          new { CUSTACCOUNT = cust.ACCOUNTNUM }
                                          join address in db.CUSTOMERADDRESS on
                                          new { cust.ACCOUNTNUM, ADDRESSTYPE = defaultAddressType } equals new { address.ACCOUNTNUM, address.ADDRESSTYPE }
                                          where tra_h.RECEIPTID == receipt &&
                                            tra_h.TYPE == type &&
                                            tra_h.ENTRYSTATUS == entryStatus
                                          select new TransactionCustomer()
                                          {
                                              ReceiptID = tra_h.RECEIPTID,
                                              CustAccount = string.IsNullOrEmpty(info.INFORMATION) ? tra_h.CUSTACCOUNT : info.INFORMATION,
                                              Name = cust.NAME,
                                              Address = cust.ADDRESS,
                                              Phone = cust.PHONE,
                                              Address1 = address.ADDRESS,
                                              Street = address.STREET
                                          };

                TransactionHeader = transaction.Count() > 0 ? transaction.ToList()[0] : null;

                TransactionLines = transactionLine.Count() > 0 ? new TransactionLines(transactionLine.ToList()) : null;

                TransactionCustomer = transactionCustomer.Count() > 0 ? transactionCustomer.ToList()[0] : null;

                this.dataGridViewReceipt.DataSource = transaction.ToList();

                this.dataGridViewTransaction.DataSource = transactionLine.ToList();


                this.dataGridViewCustomer.DataSource = transactionCustomer.ToList();

                this.TransactionBindingSource.DataSource = TransactionHeader;

                this.TransactionCustomerBindingSource.DataSource = TransactionCustomer;

                this.TransactionLinesBindingSource.DataSource = TransactionLines;

                //ReportDataSource dataSourceTran = new ReportDataSource("Transaction", transaction.Count() > 0 ? transaction.ToList()[0] : null);
                //ReportDataSource dataSourceCust = new ReportDataSource("TrransactionCustomer", transactionCustomer.Count() > 0 ? transactionCustomer.ToList()[0] : null);
                //ReportDataSource dataSourceLine = new ReportDataSource("TransactionLines", transactionLine.Count() > 0 ? new TransactionLines(transactionLine.ToList()) : null);

                //this.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceTran);
                //Sthis.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceCust);
                //this.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceLine);
                if (transaction.Count() > 0)
                {
                    String PrinterName = SettingsProvider.GetDefaultPrinter();

                    string ReportPath = reportViewerDelivary.LocalReport.ReportEmbeddedResource;

                    using (ReportPriner Printer = new ReportPriner(ReportPath, reportViewerDelivary.LocalReport.DataSources, null))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Printer.Run(PrinterName);
                        }
                    }
                }
            }
            if (!Program.KeepOpen)
                this.Close();
        }

        private void linkLabelSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormMaintance maintance = new FormMaintance();

            maintance.ShowDialog(this);
        }

        private void FormDeliveryNote_Load(object sender, EventArgs e)
        {
            this.reportViewerDelivary.RefreshReport();
            this.reportViewerDelivary.RefreshReport();
        }

        private void RefreshReport(string receiptIN)
        {
            var receipt = receiptIN;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = SettingsProvider.GetDataSource();
            builder.InitialCatalog = SettingsProvider.GetDatabase();
            builder.UserID = SettingsProvider.GetUserName();
            builder.Password = SettingsProvider.GetPassword();
            int type = 2;
            int entryStatus = 0;
            int transactionStatus = 0;
            int defaultAddressType = 0;
            string customerInfoCode = "INF00007";
            string isDelevary = "INF00004";
            Transaction TransactionHeader = new Transaction();
            TransactionCustomer TransactionCustomer = new TransactionCustomer();
            TransactionLines TransactionLines = new TransactionLines(null);

            using (var db = new DeliveryDbContext(builder.ConnectionString))
            {
                var transaction = from tra_h in db.RBOTRANSACTIONTABLE
                                  join sto in db.RBOSTORETABLE on tra_h.STORE equals sto.STOREID
                                  where tra_h.RECEIPTID == receipt &&
                                    tra_h.TYPE == type &&
                                    tra_h.ENTRYSTATUS == entryStatus
                                  select new Transaction()
                                  {
                                      ReceiptID = tra_h.RECEIPTID,
                                      StoreID = sto.STOREID,
                                      Name = sto.NAME,
                                      TransDate = tra_h.TRANSDATE ?? DateTime.MinValue,
                                      NetAmount = tra_h.NETAMOUNT ?? 0
                                  };

                var transactionLine = from tra_h in db.RBOTRANSACTIONTABLE
                                      join tra_l in db.RBOTRANSACTIONSALESTRANS
                                      on tra_h.TRANSACTIONID equals tra_l.TRANSACTIONID
                                      join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                                      on
                                      new { tra_l.TRANSACTIONID, tra_l.LINENUM, INFOCODEID = isDelevary } equals new { tra_i.TRANSACTIONID, tra_i.LINENUM, tra_i.INFOCODEID } into info_d
                                      from info in info_d.DefaultIfEmpty()
                                      join info_sub in db.RBOINFORMATIONSUBCODETABLE on
                                      info.INFORMATION equals info_sub.SUBCODEID into info_sub_d
                                      from info_s in info_sub_d.DefaultIfEmpty()
                                      where tra_h.RECEIPTID == receipt &&
                                        tra_h.TYPE == type &&
                                        tra_h.ENTRYSTATUS == entryStatus &&
                                        tra_l.TRANSACTIONSTATUS == transactionStatus
                                      select new TransactionLine()
                                      {
                                          ItemId = tra_l.ITEMID,
                                          Description = tra_l.DESCRIPTION,
                                          Qty = (tra_l.QTY ?? 0) * -1,
                                          TaxInckInPrice = tra_l.TAXINCLINPRICE ?? 0,
                                          Comment = tra_l.COMMENT,
                                          ExtraInfo = string.IsNullOrEmpty(info_s.DESCRIPTION) ? "NON DELIVERABLE" : info_s.DESCRIPTION
                                      };

                var transactionCustomer = from tra_h in db.RBOTRANSACTIONTABLE
                                          join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                                          on
                                          new { tra_h.TRANSACTIONID, INFOCODEID = customerInfoCode } equals new { tra_i.TRANSACTIONID, tra_i.INFOCODEID } into info_d
                                          from info in info_d.DefaultIfEmpty()
                                          join cust in db.CUSTTABLE on new { CUSTACCOUNT = string.IsNullOrEmpty(info.INFORMATION) ? tra_h.CUSTACCOUNT : info.INFORMATION } equals
                                          new { CUSTACCOUNT = cust.ACCOUNTNUM }
                                          join address in db.CUSTOMERADDRESS on
                                          new { cust.ACCOUNTNUM, ADDRESSTYPE = defaultAddressType } equals new { address.ACCOUNTNUM, address.ADDRESSTYPE }
                                          where tra_h.RECEIPTID == receipt &&
                                            tra_h.TYPE == type &&
                                            tra_h.ENTRYSTATUS == entryStatus
                                          select new TransactionCustomer()
                                          {
                                              ReceiptID = tra_h.RECEIPTID,
                                              CustAccount = string.IsNullOrEmpty(info.INFORMATION) ? tra_h.CUSTACCOUNT : info.INFORMATION,
                                              Name = cust.NAME,
                                              Address = cust.ADDRESS,
                                              Phone = cust.PHONE,
                                              Address1 = address.ADDRESS,
                                              Street = address.STREET
                                          };

                TransactionHeader = transaction.Count() > 0 ? transaction.ToList()[0] : null;

                TransactionLines = transactionLine.Count() > 0 ? new TransactionLines(transactionLine.ToList()) : null;

                TransactionCustomer = transactionCustomer.Count() > 0 ? transactionCustomer.ToList()[0] : null;

                this.dataGridViewReceipt.DataSource = transaction.ToList();

                this.dataGridViewTransaction.DataSource = transactionLine.ToList();


                this.dataGridViewCustomer.DataSource = transactionCustomer.ToList();

                this.TransactionBindingSource.DataSource = TransactionHeader;

                this.TransactionCustomerBindingSource.DataSource = TransactionCustomer;

                this.TransactionLinesBindingSource.DataSource = TransactionLines;

                //ReportDataSource dataSourceTran = new ReportDataSource("Transaction", transaction.Count() > 0 ? transaction.ToList()[0] : null);
                //ReportDataSource dataSourceCust = new ReportDataSource("TrransactionCustomer", transactionCustomer.Count() > 0 ? transactionCustomer.ToList()[0] : null);
                //ReportDataSource dataSourceLine = new ReportDataSource("TransactionLines", transactionLine.Count() > 0 ? new TransactionLines(transactionLine.ToList()) : null);

                //this.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceTran);
                //Sthis.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceCust);
                //this.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceLine);
                this.reportViewerDelivary.RefreshReport();


            }
            this.dataGridViewReceipt.Refresh();
        }

        private void textBoxReceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                RefreshReport(textBoxReceipt.Text.Trim());
            }
        }

        private void linkLabelReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                var form = new Report();
                form.ShowDialog(this); 
        }
    }
}