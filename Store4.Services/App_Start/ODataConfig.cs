using Store4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;

namespace Store4.Services.App_Start
{
    public class ODataConfig
    {
        public static void RegisterOData(HttpConfiguration config)
        {
            //config.EnableCaseInsensitive(true);
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<StoreEntity>("storeodata");
            config.Routes.MapODataServiceRoute("store1", "odata", builder.GetEdmModel());
        }
    }
}