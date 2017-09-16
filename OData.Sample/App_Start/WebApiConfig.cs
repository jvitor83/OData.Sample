using OData.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace OData.Sample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            ODataModelBuilder builder = new ODataConventionModelBuilder(config);

            builder.DataServiceVersion = new Version(4, 0);
            builder.EntitySet<Person>("People");

            
            var edmModel = builder.GetEdmModel();

            config.MapODataServiceRoute(
                routeName: "api",
                routePrefix: null,
                model: edmModel
            );

            //config.AddODataQueryFilter();
        }
    }
}
