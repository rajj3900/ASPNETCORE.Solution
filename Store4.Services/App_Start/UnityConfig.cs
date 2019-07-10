using Store4.BusinessUnit.CountryManagement;
using Store4.BusinessUnit.StoreManagement;
using Store4.Repository.CountryRepo;
using Store4.Repository.StoreRepo;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Store4.Services
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IStoreManager, StoreManager>();
            container.RegisterType<IStoreRepository, StoreRepository>();
            container.RegisterType<ICountryManager, CountryManager>();
            container.RegisterType<ICountryRepository, CountryRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}