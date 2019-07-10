using Store4.BusinessUnit.StoreManagement;
using Store4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace Store4.Services.Controllers
{
    [RoutePrefix("api/v1/store")]
    public class StoreController : BaseAPIController
    {
        private readonly IStoreManager _storeManager;
        public StoreController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_storeManager.GetStoresList());
        }
                

        [HttpGet]
        [Route("search/{name}")]
        public IHttpActionResult SearchByName(string name)
        {
            var searchResults = _storeManager.SearchStoreByName(name);

            if (searchResults == null)
            {
                return NotFound();
            }
            return Ok(searchResults);
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult Save([FromBody]StoreEntity store)
        {
            try
            {
                int newStore = _storeManager.SaveStore(store);

                if (newStore.Equals(1))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Error occurred while creating store");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
