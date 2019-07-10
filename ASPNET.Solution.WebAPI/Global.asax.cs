//using ASPNET.Solution.WebAPI.App_Start;
using ASPNET.Solution.WebAPI.App_Start;
using ASPNETCORE.Solution.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;

namespace ASPNET.Solution.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(WebApiODataConfig.RegisterOData);
            //MappingConfig.RegisterMaps();
            EntityMapper.RegisterMapper();
            FilterConfig.RegisterFilters(new HttpFilterCollection());
        }
    }
}
