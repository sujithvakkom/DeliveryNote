using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace LSDelevaryNote.Provider
{
    public partial class DelivaryDataProvider : DbContext
    {

        public DelivaryDataProvider(string ConnectionString)
            : base(ConnectionString)
        {
            Database.SetInitializer<DelivaryDataProvider>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //throw new UnintentionalCodeFirstException();
        }
    }
}
