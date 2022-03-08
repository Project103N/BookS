namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m18 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Image", c => c.String());
        }
    }
}
