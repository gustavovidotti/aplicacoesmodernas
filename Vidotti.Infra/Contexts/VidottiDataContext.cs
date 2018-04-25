using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidotti.Domain.Entities;
using Vidotti.Infra.Mappings;

namespace Vidotti.Infra.Contexts
{
    public class VidottiDataContext : DbContext
    {
        public VidottiDataContext() : base(@"Server=localhost,11433;Database=vidottimodernstore;User ID=sa;Password=DockerSql2017!;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
