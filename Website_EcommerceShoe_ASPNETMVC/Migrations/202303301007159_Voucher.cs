namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Voucher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vouchers", "conditionVoucher", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Vouchers", "condition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vouchers", "condition", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Vouchers", "conditionVoucher");
        }
    }
}
