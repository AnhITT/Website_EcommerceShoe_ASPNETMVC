namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sssda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImagesProducts", "Product_idProduct", "dbo.Products");
            AddColumn("dbo.ImagesProducts", "Product_idProduct1", c => c.Int());
            AddColumn("dbo.Products", "ImagesProduct_idImg", c => c.Int());
            CreateIndex("dbo.ImagesProducts", "Product_idProduct1");
            CreateIndex("dbo.Products", "ImagesProduct_idImg");
            AddForeignKey("dbo.Products", "ImagesProduct_idImg", "dbo.ImagesProducts", "idImg");
            AddForeignKey("dbo.ImagesProducts", "Product_idProduct1", "dbo.Products", "idProduct");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImagesProducts", "Product_idProduct1", "dbo.Products");
            DropForeignKey("dbo.Products", "ImagesProduct_idImg", "dbo.ImagesProducts");
            DropIndex("dbo.Products", new[] { "ImagesProduct_idImg" });
            DropIndex("dbo.ImagesProducts", new[] { "Product_idProduct1" });
            DropColumn("dbo.Products", "ImagesProduct_idImg");
            DropColumn("dbo.ImagesProducts", "Product_idProduct1");
            AddForeignKey("dbo.ImagesProducts", "Product_idProduct", "dbo.Products", "idProduct");
        }
    }
}
