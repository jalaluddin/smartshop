namespace SmartShop.Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        SpecialPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        IsNew = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        ProductCategory_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategory_ID)
                .Index(t => t.ProductCategory_ID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        ParentCatgory_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategory", t => t.ParentCatgory_ID)
                .Index(t => t.ParentCatgory_ID);
            
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Caption = c.String(),
                        ImageUrl = c.String(),
                        OriginalName = c.String(),
                        CurrentName = c.String(),
                        Product_ID = c.Guid(nullable: false),
                        IsFeaturedImage = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.Product_ID, cascadeDelete: true)
                .Index(t => t.Product_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImage", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductCategory_ID", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductCategory", "ParentCatgory_ID", "dbo.ProductCategory");
            DropIndex("dbo.ProductImage", new[] { "Product_ID" });
            DropIndex("dbo.ProductCategory", new[] { "ParentCatgory_ID" });
            DropIndex("dbo.Product", new[] { "ProductCategory_ID" });
            DropTable("dbo.ProductImage");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
        }
    }
}
