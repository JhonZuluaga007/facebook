namespace Facebook2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cinco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.comments", "Like", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.comments", "Like");
        }
    }
}
