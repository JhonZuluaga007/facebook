namespace Facebook2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tres1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.comments",
                c => new
                    {
                        Comments_id = c.Int(nullable: false, identity: true),
                        Publication_id = c.Int(nullable: false),
                        Usuario_id = c.String(),
                        Publication = c.String(),
                        Hour = c.String(),
                    })
                .PrimaryKey(t => t.Comments_id);
            
            CreateTable(
                "dbo.Publicacions",
                c => new
                    {
                        publicationId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Publication = c.String(),
                        Video = c.String(),
                        Picture = c.String(),
                        comments = c.Int(nullable: false),
                        Like = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.publicationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publicacions");
            DropTable("dbo.comments");
        }
    }
}
