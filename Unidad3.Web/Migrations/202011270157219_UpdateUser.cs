namespace Unidad3.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.News", name: "Desarrollador_Id", newName: "ApplicationUser");
            RenameIndex(table: "dbo.News", name: "IX_Desarrollador_Id", newName: "IX_ApplicationUser");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.News", name: "IX_ApplicationUser", newName: "IX_Desarrollador_Id");
            RenameColumn(table: "dbo.News", name: "ApplicationUser", newName: "Desarrollador_Id");
        }
    }
}
