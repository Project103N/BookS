namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12_CategoryController : DbMigration
    {
        public override void Up()
        {    
           
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        CommentText = c.String(),
                        UserID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.BookID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        AddressID = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "BookID", "dbo.Books");
            DropForeignKey("dbo.Carts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "AddressID" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "BookID" });
            DropIndex("dbo.Carts", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Comments");
            DropTable("dbo.Carts");
        }
    }
}
