namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SubTotalPrice = c.Double(nullable: false),
                        CartID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.CartID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.CartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "CartID", "dbo.Carts");
            DropForeignKey("dbo.CartItems", "BookID", "dbo.Books");
            DropIndex("dbo.CartItems", new[] { "CartID" });
            DropIndex("dbo.CartItems", new[] { "BookID" });
            DropTable("dbo.CartItems");
        }
    }
}
