using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;
namespace Data.Configurations
{
    public class AdressConfiguration : EntityTypeConfiguration<Address>
    {
        public AdressConfiguration()
        {
            //this.Property(p => p.City).IsRequired();
            //this.Property(p => p.StreetAddress).IsOptional().HasMaxLength(50);
        }
    }
}
