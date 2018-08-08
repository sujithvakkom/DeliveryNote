using LSDelevaryNote.Provider.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using LSDelevaryNote.ERPServiceReference;
using System.Threading.Tasks;

namespace LSDelevaryNote.Provider
{
    public partial class DelivaryDataProvider : DbContext
    {

        readonly string getDelivaryReplamishmentViewCMD = @"[dbo].[ReplishmentView]  @description, @start_date, @end_date";
        private List<Item> itemOnhand295;
        private List<Item> itemOnhand150;
        private List<Item> itemOnhand650;

        public List<DelevaryRelanishment> getDelivaryReplamishmentView(string Receipt = null,
            string Description = null,
            string Customer = null,
            DateTime? StartDate = null,
            DateTime? EndDate = null,
            string Status = null
            )
        {

            var description = !String.IsNullOrEmpty(Description) ?
                new SqlParameter("@description", Description) :
                new SqlParameter("@description", System.Data.SqlDbType.NVarChar) { Value = DBNull.Value };
            var start_date = StartDate != null ?
                new SqlParameter("@start_date", StartDate) :
                new SqlParameter("@start_date", System.Data.SqlDbType.DateTime) { Value = DBNull.Value };
            var end_date = EndDate != null ?
                new SqlParameter("@end_date", EndDate) :
                new SqlParameter("@end_date", System.Data.SqlDbType.DateTime) { Value = DBNull.Value };


            List<ReplishmentView> items = null;
            try
            {
                items = this.Database.SqlQuery<ReplishmentView>(
                                                getDelivaryReplamishmentViewCMD,
                                                description,
                                                start_date,
                                                end_date)
                                                .ToList();

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
            ERPServiceReference.GetOnhandQuantitySoapClient client = new
               ERPServiceReference.GetOnhandQuantitySoapClient();
            /*
            
            itemOnhand295 = client.GetQuantity("295").ToList();
            itemOnhand150 = client.GetQuantity("150").ToList();
            itemOnhand650 = client.GetQuantity("650").ToList();
            
            */
            Task task1 = Task.Factory.StartNew(() =>
            {
                itemOnhand295 = client.GetQuantity("295").ToList();               
                //ReportViewer.ProgressMessage.RemoveMessage(3);
            });
            Task task2 = Task.Factory.StartNew(() =>
            {
                itemOnhand150 = client.GetQuantity("150").ToList();
                //ReportViewer.ProgressMessage.RemoveMessage(1);
            });
            Task task3 = Task.Factory.StartNew(() =>
            {
                itemOnhand650 = client.GetQuantity("650").ToList();
                //ReportViewer.ProgressMessage.RemoveMessage(2);
            });

            Task.WaitAll(task1, task2, task3);

            List<DelevaryRelanishment> res = null;
            try
            {
                res = (from i in items
                       join o in itemOnhand295
                       on i.ITEMID equals o.item_code into x
                       from a in x.DefaultIfEmpty()
                       join o150 in itemOnhand150 on i.ITEMID equals o150.item_code into y
                       from b in y.DefaultIfEmpty()
                       join o150 in itemOnhand650 on i.ITEMID equals o150.item_code into z
                       from c in y.DefaultIfEmpty()
                       select new DelevaryRelanishment()
                       {
                           ItemCode = i.ITEMID,
                           Description = i.DESCRIPTION,
                           OnHandQuantity = a == null ? 0: a.quantity,
                           SoldDelivarableQuantity = i.HOMEDELIVERYQUANTITY,
                           SoldPickedQuantity = i.STOREPICKUPQUANTITY,
                           OnHandQuantity150 = b == null ? 0 : b.quantity,
                           OnHandQuantity650 = c == null ? 0 : c.quantity
                       }).ToList();
            }
            catch (Exception ex) {

                Console.Write(ex.Message);
            }
            return res;
        }

        public List<DelevaryRelanishment> DelivaryTransactionView { get { return getDelivaryReplamishmentView(); } }
    }

    public class ItemQuantity
    {
        public string ItemId { get; set; }
        public decimal Quantity { get; set; }
    }

}
