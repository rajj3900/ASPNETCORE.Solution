using ASPNET.Solution.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace ASPNET.Solution.WebAPI.App_Start
{
    public class FilterConfig
    {
        public static void RegisterFilters(HttpFilterCollection filter)
        {
            //filter.Add(new BasicAuthenticationAttribute());
            //filter.Add(new DitsSecurityAuthorize());
        }
    }
}