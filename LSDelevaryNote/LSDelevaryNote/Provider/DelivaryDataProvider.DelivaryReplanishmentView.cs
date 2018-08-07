using LSDelevaryNote.Provider.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LSDelevaryNote.Provider
{
    public partial class DelivaryDataProvider : DbContext
    {

        readonly string getDelivaryReplamishmentViewCMD = @"[dbo].[ReplishmentView]  @description, @start_date, @end_date";

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
            var itemOnhand = client.GetQuantity().ToList() ; 
            
            List<DelevaryRelanishment> res = null;
            try
            {
                res = (from i in items
                       join o in itemOnhand
                       on i.ITEMID equals o.item_code into x
                       from y in x.DefaultIfEmpty()
                       select new DelevaryRelanishment()
                       {
                           ItemCode = i.ITEMID,
                           Description = i.DESCRIPTION,
                           OnHandQuantity = y == null ? 0: y.quantity,
                           SoldDelivarableQuantity = i.HOMEDELIVERYQUANTITY,
                           SoldPickedQuantity = i.STOREPICKUPQUANTITY
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
