using Store4.BusinessUnit.StoreManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace Store4.Services.Controllers
{
    public class StoreODataController : ODataController
    {
        public IStoreManager StoreManager { get; }

        public StoreODataController(IStoreManager storeManager)
        {
            this.StoreManager = storeManager;
        }
        // GET: api/StoreOData
        [EnableQuery]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(StoreManager.GetStoresList());
        }

        // GET: api/StoreOData/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StoreOData
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StoreOData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StoreOData/5
        public void Delete(int id)
        {
        }
    }
}
