namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class das : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Note", c => c.String());
            AddColumn("dbo.Orders", "DateOrder", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DateOrder");
            DropColumn("dbo.Orders", "Note");
        }
    }
}
