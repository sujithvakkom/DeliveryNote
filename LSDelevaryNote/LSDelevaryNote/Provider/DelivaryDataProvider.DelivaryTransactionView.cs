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
        /*        

EXECUTE  [dbo].[DelivaryTransactionView] 
   @receipt
  ,@description
  ,@customer
  ,@status
GO
             */
        readonly string getDelivaryTransactionViewCMD = @"[dbo].[DelivaryTransactionView] @receipt, @description, @customer, @start_date, @end_date";
        public List<DelivaryTransactionView> getDelivaryTransactionView(string Receipt = null,
            string Description = null,
            string Customer = null,
            DateTime? StartDate = null,
            DateTime? EndDate = null,
            string Status = null
            )
        {
            var receipt = !String.IsNullOrEmpty(Receipt) ?
                new SqlParameter("@receipt", Receipt) :
                new SqlParameter("@receipt", System.Data.SqlDbType.NVarChar) { Value = DBNull.Value };
            var description = !String.IsNullOrEmpty(Description) ?
                new SqlParameter("@description", Description) :
                new SqlParameter("@description", System.Data.SqlDbType.NVarChar) { Value = DBNull.Value };
            var customer = !String.IsNullOrEmpty(Customer) ?
                new SqlParameter("@customer", Customer) :
                new SqlParameter("@customer", System.Data.SqlDbType.NVarChar) { Value = DBNull.Value };
            var start_date = StartDate != null ?
                new SqlParameter("@start_date", StartDate) :
                new SqlParameter("@start_date", System.Data.SqlDbType.DateTime) { Value = DBNull.Value };
            var end_date = EndDate != null ?
                new SqlParameter("@end_date", EndDate) :
                new SqlParameter("@end_date", System.Data.SqlDbType.DateTime) { Value = DBNull.Value };
            var status = !String.IsNullOrEmpty(Status) ?
                new SqlParameter("@status", Status) :
                new SqlParameter("@status", System.Data.SqlDbType.NVarChar) { Value = "" };
            var delivery = !String.IsNullOrEmpty(null) ?
                new SqlParameter("@delivery", Status) :
                new SqlParameter("@delivery", System.Data.SqlDbType.NVarChar) { Value = "2" };

            List<DelivaryTransactionView> items = null;
            try
            {
                items = this.Database.SqlQuery<DelivaryTransactionView>(
                                                getDelivaryTransactionViewCMD,
                                                receipt,
                                                description,
                                                customer,
                                                start_date,
                                                end_date)
                                                .ToList();

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return items;
        }
        public List<DelivaryTransactionView> DelivaryTransactionViews{ get { return getDelivaryTransactionView(); } }
    }

}
