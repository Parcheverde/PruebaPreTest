using CrudEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CrudEF
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new BancoInitializer());

            //funciona o no ps - pruebas
            using (var db = new BancoContext())
            {
                //Error
                var sucursal = db.Sucursal.AsNoTracking().ToList();
                System.Diagnostics.Debug.WriteLine($"Total sucursales: {sucursal.Count}");
            }

        }
    }
}
