namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "priceProduct", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProductSales", "priceSalePS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSales", "priceSalePS", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "priceProduct", c => c.Double(nullable: false));
        }
    }
}
