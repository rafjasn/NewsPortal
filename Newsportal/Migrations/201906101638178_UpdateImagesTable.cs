namespace Newsportal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImagesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Title", c => c.String());
        }
    }
}
