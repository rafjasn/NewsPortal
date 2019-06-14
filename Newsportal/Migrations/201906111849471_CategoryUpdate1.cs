namespace Newsportal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Post_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Post_Id");
            AddForeignKey("dbo.Categories", "Post_Id", "dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Categories", new[] { "Post_Id" });
            DropColumn("dbo.Categories", "Post_Id");
        }
    }
}
