using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.Configurations
{
    public class CategoryConfiguration:EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.ToTable("MyCategories"); //renommer la classe
            this.HasKey(c => c.CategoryId);
            this.Property(c => c.Name).HasMaxLength(50).IsRequired();
        }
    }
}
