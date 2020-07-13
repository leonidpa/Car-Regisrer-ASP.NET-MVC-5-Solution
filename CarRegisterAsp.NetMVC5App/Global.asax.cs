using CarRegisterRepositoryLibrary.Services;
using CarRegisterRepositoryLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Hosting;
using System.Configuration;

namespace CarRegisterAsp.NetMVC5App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var _contentRootPath = HostingEnvironment.ApplicationPhysicalPath;
            var personsDbConnectionString = ConfigurationManager.ConnectionStrings["personsDbConnectionString"].ConnectionString;
            var carsDbConnectionString = ConfigurationManager.ConnectionStrings["carsDbConnectionString"].ConnectionString;
            RepositoryService.Register<PersonsRepository>(personsDbConnectionString.Replace("%CONTENTROOTPATH%", _contentRootPath));
            RepositoryService.Register<CarsRepository>(carsDbConnectionString.Replace("%CONTENTROOTPATH%", _contentRootPath));
        }
    }
}
