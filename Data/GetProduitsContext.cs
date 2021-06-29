using Data.Configurations;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GetProduitsContext:DbContext
    {
        public GetProduitsContext():base("name=GestionProduitsCtx")
        {
            Database.SetInitializer<GetProduitsContext>(new DropCreateDatabaseIfModelChanges<GetProduitsContext>());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Facture> Factures { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new AdressConfiguration());


        }
    }
}
