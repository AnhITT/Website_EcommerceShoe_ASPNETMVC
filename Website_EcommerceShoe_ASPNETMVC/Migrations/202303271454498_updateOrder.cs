namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "idCustomer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "idCustomer");
        }
    }
}
