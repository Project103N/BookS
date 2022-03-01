namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_CategoryID = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryID, t.Book_BookId })
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.CategoryBooks", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.CategoryBooks", new[] { "Book_BookId" });
            DropIndex("dbo.CategoryBooks", new[] { "Category_CategoryID" });
            DropTable("dbo.CategoryBooks");
            DropTable("dbo.Categories");
        }
    }
}
