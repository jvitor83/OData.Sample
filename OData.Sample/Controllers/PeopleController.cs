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

        //[EnableQueryAttribute(
        //    AllowedArithmeticOperators = AllowedArithmeticOperators.All,
        //    AllowedFunctions = AllowedFunctions.All,
        //    AllowedLogicalOperators = AllowedLogicalOperators.All,
        //    AllowedQueryOptions = AllowedQueryOptions.All
        //    )]
        //[EnableQuery]
        public IQueryable Get(ODataQueryOptions<Models.Person> options)
        {
            var settings = new ODataValidationSettings()
            {
                // Initialize settings as needed.
                AllowedFunctions = AllowedFunctions.AllMathFunctions
            };

            options.Validate(settings);

            IQueryable<Data.Person> people = this.DbContext.People;

            IQueryable<Models.Person> peopleProjected = people.Select(p => new Models.Person() {
                Id = p.Id,
                Name = p.Name,
                DateOfBirth = p.DateOfBirth
            });

            // Here the query was not yet executed, so, we have the possibility to apply the query options at the "Api Model Person" and it will be projected to the Query at Database


            IQueryable iqueryableWithOptionsApplied = options.ApplyTo(peopleProjected);

            //IQueryable<Models.Person> iqueryableToReturn = iqueryableWithOptionsApplied as IQueryable<Models.Person>;

            return iqueryableWithOptionsApplied;
        }

        protected override void Dispose(bool disposing)
        {
            this.DbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
