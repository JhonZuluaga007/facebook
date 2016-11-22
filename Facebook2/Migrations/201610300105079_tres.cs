namespace Facebook2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Datos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        datos = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Datos");
        }
    }
}
