namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ups : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "dateUpProduct");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "dateUpProduct", c => c.DateTime(nullable: false));
        }
    }
}
