using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using WebApplication3.Models;

namespace WebApplication3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Movie>("Movies"); // We are exposing only Movies via oData
            config.Select().Expand().Filter().OrderBy().MaxTop(600).Count();
            config.MapODataServiceRoute("Movies", "odata", modelBuilder.GetEdmModel());
            // Web API 配置和服务

            // Web API 路由
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
