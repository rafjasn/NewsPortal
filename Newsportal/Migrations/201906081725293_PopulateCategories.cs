namespace Newsportal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories ( Name, Description) VALUES ( 'category1', 'description1')");
            Sql("INSERT INTO Categories ( Name, Description) VALUES ( 'category2', 'description2')");
            Sql("INSERT INTO Categories ( Name, Description) VALUES ( 'category3', 'description3')");
            Sql("INSERT INTO Categories ( Name, Description) VALUES ( 'category4', 'description4')");
            Sql("INSERT INTO Categories ( Name, Description) VALUES ( 'category5', 'description5')");
        }
        
        public override void Down()
        {
        }
    }
}
