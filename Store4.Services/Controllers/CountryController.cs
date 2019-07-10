using Store4.BusinessUnit.CountryManagement;
using Store4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store4.Services.Controllers
{
    [RoutePrefix("api/v1/country")]
    public class CountryController : BaseAPIController
    {
        public CountryController(ICountryManager countryManager)
        {
            CountryManager = countryManager;
        }

        public ICountryManager CountryManager { get; }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(CountryManager.GetCountriesList());
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult Post([FromBody]CountryEntity country)
        {
            try
            {
                int newCountry = CountryManager.SaveCountry(country);

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


        [HttpPut]
        [Route("update")]
        public IHttpActionResult Put([FromBody]CountryEntity country)
        {
            try
            {
                int newCountry = CountryManager.SaveCountry(country);

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

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                int deleteCountry = CountryManager.DeletCountry(id);

                if (deleteCountry.Equals(1))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error occured while deleting country");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
