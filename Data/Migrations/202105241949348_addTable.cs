namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "MyCategories");
            DropForeignKey("dbo.Products", "category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_CategoryId" });
            RenameColumn(table: "dbo.Products", name: "category_CategoryId", newName: "CategoryId");
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        DateAchat = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Prix = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.DateAchat, t.ClientId, t.ProductId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Cin = c.Int(nullable: false, identity: true),
                        DateNaissance = c.DateTime(nullable: false),
                        Email = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.Cin);
            
            CreateTable(
                "dbo.ProductProviders",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Provider_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Provider_Id })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.Provider_Id, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Provider_Id);
            
            AddColumn("dbo.Products", "IsBiological", c => c.Int());
            AlterColumn("dbo.MyCategories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Providers", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.MyCategories", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Products", "address_StreetAddress");
            DropColumn("dbo.Products", "address_City");
            DropColumn("dbo.Products", "Discriminator");
            DropColumn("dbo.Providers", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Providers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Products", "address_City", c => c.String());
            AddColumn("dbo.Products", "address_StreetAddress", c => c.String());
            DropForeignKey("dbo.Products", "CategoryId", "dbo.MyCategories");
            DropForeignKey("dbo.ProductProviders", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.ProductProviders", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Factures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Factures", "ClientId", "dbo.Clients");
            DropIndex("dbo.ProductProviders", new[] { "Provider_Id" });
            DropIndex("dbo.ProductProviders", new[] { "Product_ProductId" });
            DropIndex("dbo.Factures", new[] { "ProductId" });
            DropIndex("dbo.Factures", new[] { "ClientId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Providers", "Password", c => c.String());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.MyCategories", "Name", c => c.String());
            DropColumn("dbo.Products", "IsBiological");
            DropTable("dbo.ProductProviders");
            DropTable("dbo.Clients");
            DropTable("dbo.Factures");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "category_CategoryId");
            CreateIndex("dbo.Products", "category_CategoryId");
            AddForeignKey("dbo.Products", "category_CategoryId", "dbo.Categories", "CategoryId");
            RenameTable(name: "dbo.MyCategories", newName: "Categories");
        }
    }
}
