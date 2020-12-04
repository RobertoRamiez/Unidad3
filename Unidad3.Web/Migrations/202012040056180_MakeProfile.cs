namespace Unidad3.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "Hobbies", c => c.String());
            AddColumn("dbo.AspNetUsers", "Favorites", c => c.String());
            AddColumn("dbo.AspNetUsers", "Videos", c => c.String());
            AddColumn("dbo.AspNetUsers", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Picture");
            DropColumn("dbo.AspNetUsers", "Videos");
            DropColumn("dbo.AspNetUsers", "Favorites");
            DropColumn("dbo.AspNetUsers", "Hobbies");
            DropColumn("dbo.AspNetUsers", "Description");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
