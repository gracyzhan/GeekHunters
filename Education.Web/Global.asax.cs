using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GracyDemoSkills.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

          
            //Database.SetInitializer(new EducationInitializer());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EducationContext>());
            // RegisterSQLite();
        }

        protected void RegisterSQLite()
        {
            Process.Start(Server.MapPath("~/gacutil.exe"), "/i " + Server.MapPath("~/bin/System.Data.SQLite.Dll"));
        }
    }
}
