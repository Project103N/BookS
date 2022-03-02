namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Carts", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Carts", "ApplicationUserID");
            RenameColumn(table: "dbo.Carts", name: "ApplicationUser_Id", newName: "ApplicationUserID");
            AlterColumn("dbo.Carts", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Carts", "ApplicationUserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Carts", new[] { "ApplicationUserID" });
            AlterColumn("dbo.Carts", "ApplicationUserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Carts", name: "ApplicationUserID", newName: "ApplicationUser_Id");
            AddColumn("dbo.Carts", "ApplicationUserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "ApplicationUser_Id");
        }
    }
}
