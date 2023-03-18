namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cx : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "UrlImgCover");
            DropColumn("dbo.Products", "UrlImgCover_After");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UrlImgCover_After", c => c.String());
            AddColumn("dbo.Products", "UrlImgCover", c => c.String());
        }
    }
}
