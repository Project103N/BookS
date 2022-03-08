namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo_Upload1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Image");
        }
    }
}
