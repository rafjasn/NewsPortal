namespace Newsportal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageIdToPost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Image", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Image", c => c.String(nullable: false));
        }
    }
}
