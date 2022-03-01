namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7_book_class_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorId = c.Int(nullable: false),
                        PageCount = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Details = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        UnitsInStock = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        TotalSell = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Books");
        }
    }
}
