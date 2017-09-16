using OData.Sample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace OData.Sample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (var dbContext = new DatabaseModel())
            {
                //Just to initialize
            }

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
