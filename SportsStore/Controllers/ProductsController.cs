using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SportsStore.Controllers
{
    public class ProductsController : ApiController
    {
        public ProductsController()
        {
            Repository = new ProductRepository();
        }
        public IEnumerable<Product> GetProducts()
        {
            return Repository.Products;
        }
        public IHttpActionResult GetProduct(int id)
        {
            //Product or IHttpActionResult

            //return Repository.Products.Where(p => p.Id == id).FirstOrDefault();
            //
            //Product result = Repository.Products.Where(p => p.Id == id).FirstOrDefault();
            //if (result == null)
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //else
            //    return result;
            //
            Product result = Repository.Products.Where(p => p.Id == id).FirstOrDefault();
            return result == null ? (IHttpActionResult)BadRequest("No Product Found") : Ok(result);
        }
        public async Task PostProduct(Product product)
        {
            await Repository.SaveProductAsync(product);
        }

        [Authorize(Roles = "Administrators")]
        public async Task DeleteProduct(int id)
        {
            await Repository.DeleteProductAsync(id);
        }
        private IRepository Repository { get; set; }
    }
}
