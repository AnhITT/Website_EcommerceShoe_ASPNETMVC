namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class size : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Sizes_idSize", c => c.Int());
            AddColumn("dbo.Sizes", "Product_idProduct1", c => c.Int());
            CreateIndex("dbo.Products", "Sizes_idSize");
            CreateIndex("dbo.Sizes", "Product_idProduct1");
            AddForeignKey("dbo.Sizes", "Product_idProduct1", "dbo.Products", "idProduct");
            AddForeignKey("dbo.Products", "Sizes_idSize", "dbo.Sizes", "idSize");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Sizes_idSize", "dbo.Sizes");
            DropForeignKey("dbo.Sizes", "Product_idProduct1", "dbo.Products");
            DropIndex("dbo.Sizes", new[] { "Product_idProduct1" });
            DropIndex("dbo.Products", new[] { "Sizes_idSize" });
            DropColumn("dbo.Sizes", "Product_idProduct1");
            DropColumn("dbo.Products", "Sizes_idSize");
        }
    }
}
