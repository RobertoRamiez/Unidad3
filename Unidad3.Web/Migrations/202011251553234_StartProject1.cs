namespace Unidad3.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartProject1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        GenreId = c.Int(nullable: false),
                        Desarrollador_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Desarrollador_Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.Desarrollador_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.News", "Desarrollador_Id", "dbo.AspNetUsers");
            DropIndex("dbo.News", new[] { "Desarrollador_Id" });
            DropIndex("dbo.News", new[] { "GenreId" });
            DropTable("dbo.News");
            DropTable("dbo.Genres");
        }
    }
}
