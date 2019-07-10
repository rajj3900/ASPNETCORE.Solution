using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ASPNET.Solution.WebAPI.Filters
{
    public class DitsAuthorize : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            //return base.IsAuthorized(actionContext);
            //CommonRepository commonRepo = new CommonRepository();

            try
            {
                //if (!commonRepo.IsCurrentUserAdministrator() && !commonRepo.IsCurrentUserJuriAdmin())
                if (!CommonRepo())
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                    return false;
                }
                else
                {
                    HttpContext.Current.Response.AddHeader("AuthenticationStatus", "Authorized");
                    return true;
                }
            }
            catch
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                return false;
            }
        }

        private bool CommonRepo()
        {
            return true;
        }
    }
}