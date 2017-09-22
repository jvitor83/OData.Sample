using OData.Sample.Data;
using OData.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;

namespace OData.Sample.Controllers
{
    public class PeopleController : ApiController
    {
        public DatabaseModel DbContext { get; set; }

        public PeopleController()
        {
            this.DbContext = new DatabaseModel();
        }

        //[EnableQuery]
        public IQueryable Get(ODataQueryOptions<Data.Person> options)
        {
            var settings = new ODataValidationSettings()
            {
                // Initialize settings as needed.
                AllowedFunctions = AllowedFunctions.AllMathFunctions
            };

            options.Validate(settings);

            IQueryable<Data.Person> people = this.DbContext.People;

            var iqueryableToReturn = options.ApplyTo(people);

            var objectsQueryable = iqueryableToReturn as IQueryable<object>;

            var objectsExecuted = objectsQueryable.ToList();

            return objectsExecuted.AsQueryable();
        }

        protected override void Dispose(bool disposing)
        {
            this.DbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
