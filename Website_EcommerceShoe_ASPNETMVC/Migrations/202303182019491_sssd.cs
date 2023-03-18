namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sssd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UrlImgCover", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UrlImgCover");
        }
    }
}
