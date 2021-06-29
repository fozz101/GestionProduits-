using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.Configurations
{
    class ProductConfiguration:EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.HasMany(p => p.providers).WithMany(pr => pr.products);
            this.Map<Biological>(c =>
            {
                c.Requires("IsBiological").HasValue(1); //isBiological is the discriminator
            });

            this.Map<Chemical>(c =>
            {
                c.Requires("IsBiological").HasValue(0); 
            });
            this.Property(p => p.Description).HasMaxLength(200).IsOptional();

            this.HasRequired(p => p.category).WithMany(c => c.products);
        }
    }
}
