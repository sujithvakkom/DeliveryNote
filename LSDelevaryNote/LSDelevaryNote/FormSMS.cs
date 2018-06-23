using MyExtentions.DIalogs;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System;

namespace LSDelevaryNote
{
    public partial class FormSMS : Form
    {
        public FormSMS()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {

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
            {

                var data = from tra_h in db.RBOTRANSACTIONTABLE
                           join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                           on tra_h.TRANSACTIONID equals tra_i.TRANSACTIONID into tra_h_is
                           from tra_h_i in tra_h_is.DefaultIfEmpty()
                           join cust in db.CUSTTABLE on
                           string.IsNullOrEmpty(tra_h_i.INFORMATION) ? tra_h.CUSTACCOUNT : tra_h_i.INFORMATION
                           equals cust.ACCOUNTNUM
                           join cust_ad in db.CUSTOMERADDRESS on
                           cust.ACCOUNTNUM equals cust_ad.ACCOUNTNUM
                           where tra_h_i.INFOCODEID == Program.customerInfoCode &&
                           tra_h.TYPE == type &&
                           tra_h.ENTRYSTATUS == entryStatus &&
                           (from ss in db.RBOTRANSACTIONINFOCODETRANS
                            join ww in db.RBOINFORMATIONSUBCODETABLE
                            on new { p1 = (string)ss.INFOCODEID, p2 = (string)ss.SUBINFOCODEID }
                            equals new { p1 = (string)ww.INFOCODEID, p2 = (string)ww.SUBCODEID }
                            where ss.TRANSACTIONID == tra_h.TRANSACTIONID
                            && ww.INFOCODEID == Program.isDelevary
                            && ww.DESCRIPTION == Program.isDelevaryValue
                            select ss.TRANSACTIONID
                           ).Any()
                           select new TransCust()
                           {
                               ReceiptID = tra_h.RECEIPTID,
                               Customer = string.IsNullOrEmpty(tra_h_i.INFORMATION) ? tra_h.CUSTACCOUNT : tra_h_i.INFORMATION,
                               CustomerName = cust.NAME,
                               CustomerAddredd = cust.ADDRESS,
                               CustomerPhone = cust_ad.STREET
                           };
                ((ListBox)this.checkedListBox1).DataSource = data.ToList();
            }
        }

    }
}
