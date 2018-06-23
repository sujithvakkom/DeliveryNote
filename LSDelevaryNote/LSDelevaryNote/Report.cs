using MyExtentions.DIalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LSDelevaryNote
{
    public partial class Report : Form
    {
        private TransactionLines TransactionLines;
        private ContextMenu cm;

        public Report()
        {
            loadReport(null, null, null);
            InitializeComponent();
            init();
            this.dateTimePickerTo.Value = DateTime.Now.Date;
            this.dateTimePickerTo.MaxDate = DateTime.Now.Date;
            this.dateTimePickerFrom.MaxDate = DateTime.Now.Date;
            this.dataGridViewReport.DataSource = this.TransactionLines;

        }
        public Report(TransactionLines transactionLines)
        {
            this.TransactionLines = transactionLines;
            InitializeComponent();
            init();
            this.dataGridViewReport.DataSource = this.TransactionLines;
        }
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void init()
        {
        }

        private void Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dataGridViewReport, sfd.FileName); // Here dataGridview1 is your grid view name
            }

        }

        void loadReport(DateTime? FromDate, DateTime? ToDate,string ItemCode)
        {
            FromDate = FromDate ?? DateTime.MinValue;
            ToDate = ToDate ?? DateTime.Now;
            ItemCode = string.IsNullOrEmpty(ItemCode) ? "" : ItemCode;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = SettingsProvider.GetDataSource();
            builder.InitialCatalog = SettingsProvider.GetDatabase();
            builder.UserID = SettingsProvider.GetUserName();
            builder.Password = SettingsProvider.GetPassword();

            int type = 2;
            int entryStatus = 0;
            int transactionStatus = 0;
            int defaultAddressType = 0;
            using (var db = new DeliveryDbContext(builder.ConnectionString))
            {   //LINENUM changed to LINEID IN in line 103 col 155 by rafeeq
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
                                      where
                                        tra_h.TYPE == type &&
                                        tra_h.ENTRYSTATUS == entryStatus &&
                                        tra_l.TRANSACTIONSTATUS == transactionStatus &&
                                        info_s.DESCRIPTION == Program.isDelevaryValue &&
                                        tra_h.TRANSDATE < ToDate &&
                                        tra_h.TRANSDATE > FromDate &&
                                        tra_l.ITEMID.StartsWith(ItemCode)
                                      select new TransactionLine()
                                      {
                                          ReceiptID = tra_h.RECEIPTID,
                                          ItemId = tra_l.ITEMID,
                                          Description = tra_l.DESCRIPTION,
                                          Qty = (tra_l.QTY ?? 0) * -1,
                                          TaxInckInPrice = -1*(tra_l.NETAMOUNTINCLTAX ?? 0),
                                          Comment = tra_l.COMMENT,
                                          ExtraInfo = string.IsNullOrEmpty(info_s.DESCRIPTION) ? "NON DELIVERABLE" : info_s.DESCRIPTION
                                      };
                /*
                var transactionCustomer = from tra_h in db.RBOTRANSACTIONTABLE
                                          join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                                          on
                                          new { tra_h.TRANSACTIONID, INFOCODEID = customerInfoCode } equals new { tra_i.TRANSACTIONID, tra_i.INFOCODEID } into info_d
                                          from info in info_d.DefaultIfEmpty()
                                          join cust in db.CUSTTABLE on new { CUSTACCOUNT = string.IsNullOrEmpty(info.INFORMATION) ? tra_h.CUSTACCOUNT : info.INFORMATION } equals
                                          new { CUSTACCOUNT = cust.ACCOUNTNUM }
                                          join address in db.CUSTOMERADDRESS on
                                          new { cust.ACCOUNTNUM, ADDRESSTYPE = defaultAddressType } equals new { address.ACCOUNTNUM, address.ADDRESSTYPE }
                                          where 
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
                                          */

                this.TransactionLines = transactionLine.Count() > 0 ? new TransactionLines(transactionLine.ToList()) : null;
            }
        }


        private void buttonFilter_Click(object sender, EventArgs e)
        {
            loadReport(this.dateTimePickerFrom.Value, 
                this.dateTimePickerTo.Value, 
                this.textBoxItem.Text.Trim());
            this.dataGridViewReport.DataSource = this.TransactionLines;

        }

        private void dataGridViewReport_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.cm = new ContextMenu();
                cm.MenuItems.Add("Export", new EventHandler(Export_Click));
                this.dataGridViewReport.ContextMenu = cm;

               cm.Show(dataGridViewReport, new Point(e.X, e.Y));
            }
        }

        private void buttonSMS_Click(object sender, EventArgs e)
        {
            FormSMS formSMS = new FormSMS();
            formSMS.ShowDialog(this.Parent);
        }
    }
}
