using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace LSDelevaryNote
{
    public partial class DeliveryDbContext : DbContext
    {

        public DeliveryDbContext(string ConnectionString)
            : base(ConnectionString)
        {
            Database.SetInitializer<DeliveryDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //throw new UnintentionalCodeFirstException();
        }
    }
}
