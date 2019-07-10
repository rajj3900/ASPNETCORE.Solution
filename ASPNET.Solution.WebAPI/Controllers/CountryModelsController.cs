using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ASPNET.Solution.WebAPI.Models;
using DOTNET.Solution.BusinessUnit.Model;

namespace ASPNET.Solution.WebAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. 
    Merge these statements into the Register method of the WebApiConfig class as applicable. 
    Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using DOTNET.Solution.BusinessUnit.Model;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<CountryModel>("CountryModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CountryModelsController : ODataController
    {
        private ASPNETSolutionWebAPIContext db = new ASPNETSolutionWebAPIContext();

        // GET: odata/CountryModels
        [EnableQuery]
        public IQueryable<CountryModel> GetCountryModels()
        {
            return db.CountryModels;
        }

        // GET: odata/CountryModels(5)
        [EnableQuery]
        public SingleResult<CountryModel> GetCountryModel([FromODataUri] Guid key)
        {
            return SingleResult.Create(db.CountryModels.Where(countryModel => countryModel.Id == key));
        }

        // PUT: odata/CountryModels(5)
        public IHttpActionResult Put([FromODataUri] Guid key, Delta<CountryModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CountryModel countryModel = db.CountryModels.Find(key);
            if (countryModel == null)
            {
                return NotFound();
            }

            patch.Put(countryModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(countryModel);
        }

        // POST: odata/CountryModels
        public IHttpActionResult Post(CountryModel countryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CountryModels.Add(countryModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CountryModelExists(countryModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(countryModel);
        }

        // PATCH: odata/CountryModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] Guid key, Delta<CountryModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CountryModel countryModel = db.CountryModels.Find(key);
            if (countryModel == null)
            {
                return NotFound();
            }

            patch.Patch(countryModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(countryModel);
        }

        // DELETE: odata/CountryModels(5)
        public IHttpActionResult Delete([FromODataUri] Guid key)
        {
            CountryModel countryModel = db.CountryModels.Find(key);
            if (countryModel == null)
            {
                return NotFound();
            }

            db.CountryModels.Remove(countryModel);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryModelExists(Guid key)
        {
            return db.CountryModels.Count(e => e.Id == key) > 0;
        }
    }
}
