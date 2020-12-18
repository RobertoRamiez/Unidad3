namespace Unidad3.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Photo");
        }
    }
}
