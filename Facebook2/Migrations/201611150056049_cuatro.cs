namespace Facebook2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuatro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.comments", "user", c => c.String());
            AddColumn("dbo.comments", "userimg", c => c.String());
            AddColumn("dbo.Publicacions", "User", c => c.String());
            AddColumn("dbo.Publicacions", "userimg", c => c.String());
            DropColumn("dbo.comments", "Usuario_id");
            DropColumn("dbo.Publicacions", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publicacions", "UserId", c => c.String());
            AddColumn("dbo.comments", "Usuario_id", c => c.String());
            DropColumn("dbo.Publicacions", "userimg");
            DropColumn("dbo.Publicacions", "User");
            DropColumn("dbo.comments", "userimg");
            DropColumn("dbo.comments", "user");
        }
    }
}
