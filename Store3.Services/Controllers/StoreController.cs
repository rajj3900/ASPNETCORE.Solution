using Store3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store3.Services.Controllers
{
    public class StoreController : ApiController
    {
        public IEnumerable<Store> Get()
        {
            StoreEntities db = new StoreEntities();

            var _stores =  db.Stores.ToList();

            return _stores;
        }
    }
}
