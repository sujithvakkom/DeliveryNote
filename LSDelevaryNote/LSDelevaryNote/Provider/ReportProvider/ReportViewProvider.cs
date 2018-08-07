using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LSDelevaryNote.Provider.ReportProvider
{
    public class ReportViewProvider:IDisposable
    {

        private System.Windows.Forms.BindingSource TransactionBindingSource;
        private System.Windows.Forms.BindingSource TransactionCustomerBindingSource;
        private System.Windows.Forms.BindingSource TransactionLinesBindingSource;
        private LocalReport LocalReport;
        SqlConnectionStringBuilder builder;
        public ReportViewProvider(
            String DataSource,
            String InitialCatalog,
            String UserID,
            String Password)
        {

            builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource;
            builder.InitialCatalog = InitialCatalog;
            builder.UserID = UserID;
            builder.Password = Password;

            this.TransactionBindingSource = new System.Windows.Forms.BindingSource();
            this.TransactionCustomerBindingSource = new System.Windows.Forms.BindingSource();
            this.TransactionLinesBindingSource = new System.Windows.Forms.BindingSource();

            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource1.Name = "Transaction";
            reportDataSource1.Value = this.TransactionBindingSource;
            reportDataSource2.Name = "TransactionCustomer";
            reportDataSource2.Value = this.TransactionCustomerBindingSource;
            reportDataSource3.Name = "TransactionLines";
            reportDataSource3.Value = this.TransactionLinesBindingSource;
            this.LocalReport = new LocalReport();
            LocalReport.DataSources.Add(reportDataSource1);
            LocalReport.DataSources.Add(reportDataSource2);
            LocalReport.DataSources.Add(reportDataSource3);
            LocalReport.ReportEmbeddedResource = "LSDelevaryNote.DelivaryReport.rdlc";
        }

        public LocalReport GetDelivaryReport(
            String Receipt)
        {
            string receipt = Receipt;

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
                //  LINENUM   changed to LINENUM = (decimal)tra_i.LINEID  in line 195 colu 156 by rafeeq
                var transactionLine = from tra_h in db.RBOTRANSACTIONTABLE
                                      join tra_l in db.RBOTRANSACTIONSALESTRANS
                                      on tra_h.TRANSACTIONID equals tra_l.TRANSACTIONID
                                      join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                                      on
                                      new { tra_l.TRANSACTIONID, tra_l.LINENUM, INFOCODEID = Program.isDelevary } equals new { tra_i.TRANSACTIONID, LINENUM = (decimal)tra_i.LINEID, tra_i.INFOCODEID } into info_d
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

                //this.dataGridViewReceipt.DataSource = transaction.ToList();
                //this.dataGridViewTransaction.DataSource = transactionLine.ToList();
                //this.dataGridViewCustomer.DataSource = transactionCustomer.ToList();

                this.TransactionBindingSource.DataSource = TransactionHeader;

                this.TransactionCustomerBindingSource.DataSource = TransactionCustomer;

                this.TransactionLinesBindingSource.DataSource = TransactionLines;

                //ReportDataSource dataSourceTran = new ReportDataSource("Transaction", transaction.Count() > 0 ? transaction.ToList()[0] : null);
                //ReportDataSource dataSourceCust = new ReportDataSource("TrransactionCustomer", transactionCustomer.Count() > 0 ? transactionCustomer.ToList()[0] : null);
                //ReportDataSource dataSourceLine = new ReportDataSource("TransactionLines", transactionLine.Count() > 0 ? new TransactionLines(transactionLine.ToList()) : null);

                //this.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceTran);
                //Sthis.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceCust);
                //this.reportViewerDelivary.LocalReport.DataSources.Add(dataSourceLine);
                LocalReport.Refresh();
                return LocalReport;
            }
        }

        public void Dispose()
        {
            if(this.LocalReport!=null)
            this.LocalReport.Dispose();

            if (this.TransactionBindingSource != null)
                this.TransactionBindingSource.Dispose();

            if (this.TransactionCustomerBindingSource != null)
                this.TransactionCustomerBindingSource.Dispose();

            if (this.TransactionLinesBindingSource != null)
                this.TransactionLinesBindingSource.Dispose();
            
        }
    }
}
