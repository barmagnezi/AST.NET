namespace MvcApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentsToStirng : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        title = c.String(),
                        author = c.String(),
                        urlAuthor = c.String(),
                        date = c.String(),
                        body = c.String(),
                        image = c.String(),
                        video = c.String(),
                        comments = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
