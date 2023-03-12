namespace Website_EcommerceShoe_ASPNETMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        idBlog = c.Int(nullable: false, identity: true),
                        titleBlog = c.String(),
                        descriptionBlog = c.String(),
                        dateSubmitted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idBlog);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        idBrand = c.Int(nullable: false, identity: true),
                        nameBrand = c.String(),
                        Product_idProduct = c.Int(),
                    })
                .PrimaryKey(t => t.idBrand)
                .ForeignKey("dbo.Products", t => t.Product_idProduct)
                .Index(t => t.Product_idProduct);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        idCart = c.Int(nullable: false, identity: true),
                        quantityCart = c.Int(nullable: false),
                        nameCart = c.String(),
                        PaymentMethodId = c.Int(),
                        IdPaymentMethod_idMethod = c.Int(),
                    })
                .PrimaryKey(t => t.idCart)
                .ForeignKey("dbo.PaymentMethods", t => t.IdPaymentMethod_idMethod)
                .Index(t => t.IdPaymentMethod_idMethod);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        idMethod = c.Int(nullable: false, identity: true),
                        nameMethod = c.String(),
                    })
                .PrimaryKey(t => t.idMethod);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        idCar = c.Int(nullable: false, identity: true),
                        nameCar = c.String(),
                        descriptionCar = c.String(),
                        Product_idProduct = c.Int(),
                    })
                .PrimaryKey(t => t.idCar)
                .ForeignKey("dbo.Products", t => t.Product_idProduct)
                .Index(t => t.Product_idProduct);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        idFB = c.Int(nullable: false, identity: true),
                        ratingFB = c.Double(nullable: false),
                        titleFB = c.String(),
                        descriptionFB = c.String(),
                    })
                .PrimaryKey(t => t.idFB);
            
            CreateTable(
                "dbo.ImagesProducts",
                c => new
                    {
                        idImg = c.Int(nullable: false, identity: true),
                        urlImg = c.String(),
                        Product_idProduct = c.Int(),
                    })
                .PrimaryKey(t => t.idImg)
                .ForeignKey("dbo.Products", t => t.Product_idProduct)
                .Index(t => t.Product_idProduct);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        idProduct = c.Int(nullable: false, identity: true),
                        nameProduct = c.String(),
                        titleProduct = c.String(),
                        descriptionProduct = c.String(),
                        UrlImgCover = c.String(),
                        UrlImgCover_After = c.String(),
                        priceProduct = c.Double(nullable: false),
                        statusProduct = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idProduct);
            
            CreateTable(
                "dbo.ProductSales",
                c => new
                    {
                        idPS = c.Int(nullable: false, identity: true),
                        namePS = c.String(),
                        descriptionPS = c.String(),
                        priceSalePS = c.Double(nullable: false),
                        discountSalePS = c.String(),
                        dateStartSale = c.DateTime(nullable: false),
                        dateEndSale = c.DateTime(nullable: false),
                        Product_idProduct = c.Int(),
                    })
                .PrimaryKey(t => t.idPS)
                .ForeignKey("dbo.Products", t => t.Product_idProduct)
                .Index(t => t.Product_idProduct);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        idSize = c.Int(nullable: false, identity: true),
                        nameSize = c.String(),
                        quantitySize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSize);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        idVoucher = c.Int(nullable: false, identity: true),
                        nameVoucher = c.String(),
                        descriptionVoucher = c.String(),
                        priceVoucher = c.Double(nullable: false),
                        quantityVoucher = c.Int(nullable: false),
                        dateStartVoucher = c.DateTime(nullable: false),
                        dateEndVoucher = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idVoucher);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProductSales", "Product_idProduct", "dbo.Products");
            DropForeignKey("dbo.ImagesProducts", "Product_idProduct", "dbo.Products");
            DropForeignKey("dbo.Categories", "Product_idProduct", "dbo.Products");
            DropForeignKey("dbo.Brands", "Product_idProduct", "dbo.Products");
            DropForeignKey("dbo.Carts", "IdPaymentMethod_idMethod", "dbo.PaymentMethods");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductSales", new[] { "Product_idProduct" });
            DropIndex("dbo.ImagesProducts", new[] { "Product_idProduct" });
            DropIndex("dbo.Categories", new[] { "Product_idProduct" });
            DropIndex("dbo.Carts", new[] { "IdPaymentMethod_idMethod" });
            DropIndex("dbo.Brands", new[] { "Product_idProduct" });
            DropTable("dbo.Vouchers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sizes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProductSales");
            DropTable("dbo.Products");
            DropTable("dbo.ImagesProducts");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Categories");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Carts");
            DropTable("dbo.Brands");
            DropTable("dbo.Blogs");
        }
    }
}
