namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyNameImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageName");
        }
    }
}
