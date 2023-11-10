using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackProyectoSW
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //edited
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                            "text/html",
                            StringComparison.InvariantCultureIgnoreCase,
                            true,
                            "application/json")
                );

       

            // Ruta para el método GetUserData
            config.Routes.MapHttpRoute(
                name: "GetUserDataApi",
                routeTemplate: "api/Users/GetUserData",
                defaults: new { controller = "Users", action = "GetUserData" }
            );
        }
    }
}
