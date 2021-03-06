namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
using Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.GetProduitsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Data.GetProduitsContext";
        }

        protected override void Seed(Data.GetProduitsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Categories.AddOrUpdate(

                    p => p.Name, //Uniqueness property
                    new Category { Name = "Medicament" },
                    new Category { Name = "Vetement" },
                    new Category { Name = "Meuble" });
            context.SaveChanges();
        }
    }
}
