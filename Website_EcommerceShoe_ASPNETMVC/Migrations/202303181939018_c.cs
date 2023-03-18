namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sizes", "idProduct", c => c.Int());
            CreateIndex("dbo.Sizes", "idProduct");
            AddForeignKey("dbo.Sizes", "idProduct", "dbo.Products", "idProduct");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sizes", "idProduct", "dbo.Products");
            DropIndex("dbo.Sizes", new[] { "idProduct" });
            DropColumn("dbo.Sizes", "idProduct");
        }
    }
}
