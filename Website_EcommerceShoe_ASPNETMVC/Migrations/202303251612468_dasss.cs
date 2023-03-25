namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dasss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Size", c => c.String());
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
        }
    }
}
