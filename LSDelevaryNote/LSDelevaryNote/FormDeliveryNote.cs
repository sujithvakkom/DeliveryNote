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
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = SettingsProvider.GetDataSource();
            builder.InitialCatalog = SettingsProvider.GetDatabase();
            builder.UserID = SettingsProvider.GetUserName();
            builder.Password = SettingsProvider.GetPassword();
            var receipt = this.textBoxReceipt.Text.Trim();
            int type = 2;
            int entryStatus = 0;
            int transactionStatus = 0;

            using (var db = new DeliveryDbContext(builder.ConnectionString))
            {
                var transaction = from tra_h in db.RBOTRANSACTIONTABLE
                                  join sto in db.RBOSTORETABLE on tra_h.STORE equals sto.STOREID
                                  where tra_h.RECEIPTID == receipt &&
                                    tra_h.TYPE == type &&
                                    tra_h.ENTRYSTATUS == entryStatus
                                  select new { tra_h.RECEIPTID,sto.STOREID,sto.NAME,tra_h.TRANSDATE,tra_h.NETAMOUNT };

                var transactionLine = from tra_h in db.RBOTRANSACTIONTABLE
                                  join tra_l in db.RBOTRANSACTIONSALESTRANS
                                  on tra_h.TRANSACTIONID equals tra_l.TRANSACTIONID
                                  where tra_h.RECEIPTID == receipt &&
                                    tra_h.TYPE == type &&
                                    tra_h.ENTRYSTATUS == entryStatus &&
                                    tra_l.TRANSACTIONSTATUS == transactionStatus
                                  select new { tra_l.ITEMID, tra_l.DESCRIPTION, tra_l.QTY, tra_l.TAXINCLINPRICE };



                this.dataGridViewReceipt.DataSource = transaction.ToList();
            }
            this.dataGridViewReceipt.Refresh();
        }

        private void linkLabelSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormMaintance maintance = new FormMaintance();
            maintance.ShowDialog(this);
        }
    }
}
