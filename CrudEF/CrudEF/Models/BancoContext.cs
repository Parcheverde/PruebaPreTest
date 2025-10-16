using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudEF.Models
{
    public class BancoContext : DbContext
    {
        public BancoContext():base("name=Banco")
        {
            //vacio
        }

        public DbSet<Sucursal> Sucursal  { get; set; }
        public DbSet<Empleado> Empleado  { get; set; }
        public DbSet<Cuenta> Cuenta  { get; set; }

    }
}