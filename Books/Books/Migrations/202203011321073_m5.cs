namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Biography = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Authors");
        }
    }
}
