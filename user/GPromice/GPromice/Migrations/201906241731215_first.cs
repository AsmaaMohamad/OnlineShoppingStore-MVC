namespace GPromice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        MemberId = c.String(),
                        CartStatusId = c.Int(),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Members", t => t.Member_MemberId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.Member_MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 200),
                        lastName = c.String(maxLength: 200),
                        EmailId = c.String(maxLength: 200),
                        Password = c.String(maxLength: 200),
                        IsActive = c.Boolean(),
                        IsDelete = c.Boolean(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        ConfirmPassword = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.MemberRole",
                c => new
                    {
                        MemberRoleId = c.Int(nullable: false, identity: true),
                        MemId = c.Int(),
                        RoleId = c.Int(),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.MemberRoleId)
                .ForeignKey("dbo.Members", t => t.Member_MemberId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.Member_MemberId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.shippingDetails",
                c => new
                    {
                        shippingDetailsID = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        Address = c.String(maxLength: 500),
                        city = c.String(maxLength: 500),
                        state = c.String(maxLength: 500),
                        Country = c.String(maxLength: 500),
                        ZipCode = c.String(maxLength: 50),
                        AmountPaid = c.Decimal(precision: 18, scale: 2),
                        PaymentType = c.String(maxLength: 50),
                        Member_MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.shippingDetailsID)
                .ForeignKey("dbo.Members", t => t.Member_MemberId)
                .Index(t => t.Member_MemberId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 500),
                        CategoryID = c.Int(),
                        IsActive = c.Boolean(),
                        IsDelete = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ProductImage = c.String(),
                        Quantity = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CatID = c.Int(nullable: false, identity: true),
                        CatName = c.String(maxLength: 500),
                        IsActive = c.Boolean(),
                        IsDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.CatID);
            
            CreateTable(
                "dbo.CartStatus",
                c => new
                    {
                        CartStatusID = c.Int(nullable: false, identity: true),
                        CartStatus = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CartStatusID);
            
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
                "dbo.SlideImage",
                c => new
                    {
                        SlideId = c.Int(nullable: false, identity: true),
                        SlideTitle = c.String(maxLength: 500),
                        SlideImage = c.String(),
                    })
                .PrimaryKey(t => t.SlideId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.shippingDetails", "Member_MemberId", "dbo.Members");
            DropForeignKey("dbo.MemberRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.MemberRole", "Member_MemberId", "dbo.Members");
            DropForeignKey("dbo.Cart", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.shippingDetails", new[] { "Member_MemberId" });
            DropIndex("dbo.MemberRole", new[] { "Member_MemberId" });
            DropIndex("dbo.MemberRole", new[] { "RoleId" });
            DropIndex("dbo.Cart", new[] { "Member_MemberId" });
            DropIndex("dbo.Cart", new[] { "ProductId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SlideImage");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CartStatus");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.shippingDetails");
            DropTable("dbo.Roles");
            DropTable("dbo.MemberRole");
            DropTable("dbo.Members");
            DropTable("dbo.Cart");
        }
    }
}
