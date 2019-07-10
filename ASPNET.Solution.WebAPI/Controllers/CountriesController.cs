using ASPNET.Solution.WebAPI.App_Start;
using DOTNET.Solution.BusinessUnit.BusinessUnit;
using DOTNET.Solution.BusinessUnit.Interface;
using DOTNET.Solution.BusinessUnit.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace ASPNET.Solution.WebAPI.Controllers
{
    //[RoutePrefix("DOTNET/v1/country")]
    public class CountriesController : BaseApiController
    {
        private readonly ICountry objCountry;

        public CountriesController(ICountry objCountry)
        {
            this.objCountry = objCountry;
        }

        //[Route("countries")]
        [HttpGet]
        //[BasicAuthenticationAttribute]
        //[Authorize]
        public IHttpActionResult GetCountries()
        {
            //var identity = Thread.CurrentPrincipal.Identity as System.Security.Claims.ClaimsIdentity;
            //var data = identity.FindFirst(ClaimTypes.Upn);

            var countriesList = objCountry.GetStates();// objCountry.GetCountries();
            return Ok(countriesList);            
        }

        [HttpGet]
        [Route("search/{name}")]
        public IHttpActionResult SearchCountries(string name)
        {
            var searchResults = objCountry.SearchCountry(name);

            if (searchResults == null)
            {
                return NotFound();
            }
            return Ok(searchResults);
        }

        [HttpPost]
        //[Route("save")]
        public IHttpActionResult AddCountry([FromBody]CountryModel country)
        {
            try
            {
                //country.Id = Guid.NewGuid();

                //if (!ModelState.IsValid)
                //{
                //    return BadRequest();
                //}

                int newCountry = objCountry.Save(country);

                if (newCountry.Equals(1))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error occurred while creating country");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
