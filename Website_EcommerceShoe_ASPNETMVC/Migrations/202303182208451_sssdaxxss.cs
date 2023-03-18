namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sssdaxxss : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sizes", name: "idProduct", newName: "Product_idProduct");
            RenameIndex(table: "dbo.Sizes", name: "IX_idProduct", newName: "IX_Product_idProduct");
            AddColumn("dbo.Sizes", "productID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sizes", "productID");
            RenameIndex(table: "dbo.Sizes", name: "IX_Product_idProduct", newName: "IX_idProduct");
            RenameColumn(table: "dbo.Sizes", name: "Product_idProduct", newName: "idProduct");
        }
    }
}
