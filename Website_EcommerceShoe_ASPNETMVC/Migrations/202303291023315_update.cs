namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductSales", "discountSalePS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSales", "discountSalePS", c => c.String());
        }
    }
}
