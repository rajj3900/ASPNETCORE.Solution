using DOTNET.Solution.BusinessUnit.Interface;
using DOTNET.Solution.BusinessUnit.Model;
using Microsoft.AspNet.OData.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace ASPNET.Solution.WebAPI.Controllers
{
    public class CountryODataController : ODataController
    {
        private readonly ICountry objCountry;

        public CountryODataController(ICountry objCountry)
        {
            this.objCountry = objCountry;
        }

        [EnableQuery]
        [HttpGet]
        //[ODataRoute("CountriesList")]
        public IQueryable<CountryModel> Get()
        {
            var countriesList = objCountry.GetCountries().AsQueryable();

            return countriesList;
        }
    }
}
