namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m16 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Comments", "UserID");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.Comments", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "UserID" });
            AlterColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "UserID", newName: "User_Id");
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "User_Id");
        }
    }
}
