using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidotti.Domain.Entities;

namespace Vidotti.Infra.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(x => x.Id);
            Property(x => x.Image).IsRequired().HasMaxLength(1024);
            Property(x => x.Price);
            Property(x => x.QuantityOnHand);
            Property(x => x.Title).IsRequired().HasMaxLength(80);
        }
    }
}
