namespace CrudEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sucursals", "Direccion", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Sucursals", "Direcccion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sucursals", "Direcccion", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Sucursals", "Direccion");
        }
    }
}
