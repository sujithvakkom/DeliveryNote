using MyExtentions.DIalogs;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace LSDelevaryNote
{
    public partial class FormSMS : Form
    {
        public FormSMS()
        {
            InitializeComponent();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = SettingsProvider.GetDataSource();
            builder.InitialCatalog = SettingsProvider.GetDatabase();
            builder.UserID = SettingsProvider.GetUserName();
            builder.Password = SettingsProvider.GetPassword();

            int type = 2;
            int entryStatus = 0;
            int transactionStatus = 0;
            int defaultAddressType = 0;
            using (var db = new DeliveryDbContext(builder.ConnectionString)) {
                var data = from tra_h in db.RBOTRANSACTIONTABLE
                           join tra_i in db.RBOTRANSACTIONINFOCODETRANS
                           on
                           new { tra_h.TRANSACTIONID, INFOCODEID = Program.customerInfoCode } equals new { tra_i.TRANSACTIONID, tra_i.INFOCODEID } into info_d
                           from info in info_d.DefaultIfEmpty()
                           join info_sub in db.RBOINFORMATIONSUBCODETABLE on
                           info.INFORMATION equals info_sub.SUBCODEID into info_sub_d
                           from info_s in info_sub_d.DefaultIfEmpty()
                           where
                             tra_h.TYPE == type &&
                             tra_h.ENTRYSTATUS == entryStatus &&
                             info_s.DESCRIPTION == Program.isDelevaryValue// &&
                             //tra_h.TRANSDATE < ToDate &&
                             //tra_h.TRANSDATE > FromDate &&
                           select new TransactionLine()
                           {
                               ReceiptID = tra_h.RECEIPTID,
                               ExtraInfo = string.IsNullOrEmpty(info_s.DESCRIPTION) ? "NON DELIVERABLE" : info_s.DESCRIPTION
                           };
            }
        }
    }
}
