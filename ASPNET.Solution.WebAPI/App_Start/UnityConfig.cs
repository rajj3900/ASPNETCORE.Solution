using DOTNET.Solution.BusinessUnit.BusinessUnit;
using DOTNET.Solution.BusinessUnit.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ASPNET.Solution.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICountry, CountryManager>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}