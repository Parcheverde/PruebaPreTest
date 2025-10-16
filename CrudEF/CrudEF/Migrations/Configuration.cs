namespace CrudEF.Migrations
{
    using CrudEF.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrudEF.Models.BancoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CrudEF.Models.BancoContext";
        }

        protected override void Seed(CrudEF.Models.BancoContext context)
        {
            // 1️⃣ Primero crear las sucursales
            var sucursales = new List<Sucursal>
            {
                new Sucursal
                {
                    Nombre = "La Vida",
                    Direccion = "Calle 23, Pasaje 321, Casa 12",
                    Telefono = "22345678",
                    FechaApertura = DateTime.Parse("2025-10-03")
                }
            };

            sucursales.ForEach(s => context.Sucursal.Add(s));
            context.SaveChanges(); // guarda para que tengan IDs

            // 2️⃣ Luego crear empleados asignados a la primera sucursal
            var empleados = new List<Empleado>
            {
                new Empleado
                {
                    NombreCompleto = "Jose Oscar de la Pepa",
                    Cargo = "Admin",
                    Correo = "example@mail.com",
                    FechaContratacion = DateTime.Parse("2025-10-16"),
                    SucursalId = sucursales[0].SucursalId
                },
                new Empleado
                {
                    NombreCompleto = "Davil Oscar de la Pepa",
                    Cargo = "Cajero",
                    Correo = "example2@mail.com",
                    FechaContratacion = DateTime.Parse("2025-10-20"),
                    SucursalId = sucursales[0].SucursalId
                }
            };

            empleados.ForEach(e => context.Empleado.Add(e));
            context.SaveChanges();

            // 3️⃣ Crear cuentas vinculadas a la misma sucursal
            var cuentas = new List<Cuenta>
            {
                new Cuenta
                {
                    NumeroCuenta = "00123456",
                    Saldo = 23.5m,
                    TipoCuenta = "Ahorro",
                    FechaCreacion = DateTime.Parse("2025-10-16"),
                    SucursalId = sucursales[0].SucursalId
                },
                new Cuenta
                {
                    NumeroCuenta = "01123457",
                    Saldo = 223.5m,
                    TipoCuenta = "Corriente",
                    FechaCreacion = DateTime.Parse("2025-10-17"),
                    SucursalId = sucursales[0].SucursalId
                },
                new Cuenta
                {
                    NumeroCuenta = "01144459",
                    Saldo = 314.5m,
                    TipoCuenta = "Ahorro",
                    FechaCreacion = DateTime.Parse("2025-10-18"),
                    SucursalId = sucursales[0].SucursalId
                }
            };

            cuentas.ForEach(c => context.Cuenta.Add(c));
            context.SaveChanges();
        }
    }
}
