using Store4.Common;
using Store4.Services.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Store4.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            StoreMapper.RegisterMapper();
            GlobalConfiguration.Configure(ODataConfig.RegisterOData);
        }
    }
}
