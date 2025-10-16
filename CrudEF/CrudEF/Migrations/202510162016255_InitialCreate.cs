namespace CrudEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        CuentaId = c.Int(nullable: false, identity: true),
                        NumeroCuenta = c.String(nullable: false, maxLength: 8),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoCuenta = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        SucursalId = c.Int(nullable: false),
                        EmpleadoId = c.Int(),
                    })
                .PrimaryKey(t => t.CuentaId)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId, cascadeDelete: true)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId)
                .Index(t => t.SucursalId)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false, maxLength: 100),
                        Cargo = c.String(nullable: false, maxLength: 50),
                        Correo = c.String(nullable: false),
                        FechaContratacion = c.DateTime(nullable: false),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.Sucursals",
                c => new
                    {
                        SucursalId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Direcccion = c.String(nullable: false, maxLength: 100),
                        Telefono = c.String(nullable: false),
                        fechaApertura = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SucursalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cuentas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Cuentas", "SucursalId", "dbo.Sucursals");
            DropIndex("dbo.Empleadoes", new[] { "SucursalId" });
            DropIndex("dbo.Cuentas", new[] { "EmpleadoId" });
            DropIndex("dbo.Cuentas", new[] { "SucursalId" });
            DropTable("dbo.Sucursals");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Cuentas");
        }
    }
}
