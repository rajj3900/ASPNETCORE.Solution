using Store2.Data;
using Store2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store2.Services.Controllers
{
    public class CountryController : ApiController
    {
        public IEnumerable<Country> Get()
        {
            //IRepository<Country> objCountry = new Repository<Country>();

            StoreEntities dbContext = new StoreEntities();

            return dbContext.Countries.ToList();

            //return objCountry.GetAll();

        }
    }
}
