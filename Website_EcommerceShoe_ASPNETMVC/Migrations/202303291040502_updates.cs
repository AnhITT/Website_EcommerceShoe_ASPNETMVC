namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSales", "salePSPhanTram", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.ProductSales", "quantityPS", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductSales", "priceSalePS", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSales", "priceSalePS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ProductSales", "quantityPS");
            DropColumn("dbo.ProductSales", "salePSPhanTram");
        }
    }
}
