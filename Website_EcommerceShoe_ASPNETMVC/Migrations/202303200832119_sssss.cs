namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sssss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Cart_idCart", "dbo.Carts");
            DropIndex("dbo.Carts", new[] { "Cart_idCart" });
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        idCart = c.Int(nullable: false, identity: true),
                        Cart_idCart = c.Int(),
                    })
                .PrimaryKey(t => t.idCart);
            
            CreateIndex("dbo.Carts", "Cart_idCart");
            AddForeignKey("dbo.Carts", "Cart_idCart", "dbo.Carts", "idCart");
        }
    }
}
