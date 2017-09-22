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
        protected override void Dispose(bool disposing)
        {
            this.DbContext.Dispose();
            base.Dispose(disposing);
        }

        public IQueryable Get(ODataQueryOptions<Data.Person> options)
        {
            IQueryable<Data.Person> people = this.DbContext.People;

            var iqueryableToReturn = options.ApplyTo(people);
            //return iqueryableToReturn; // It should return OK here (even for GroupBy)

            var objectsQueryable = iqueryableToReturn as IQueryable<object>;

            var objectsExecuted = objectsQueryable.ToList();

            Type type = objectsExecuted.First().GetType();

            return objectsExecuted.AsQueryable();
        }
    }

    //public class PeopleController : ODataController
    //{
    //    public DatabaseModel DbContext { get; set; }
    //    public PeopleController()
    //    {
    //        this.DbContext = new DatabaseModel();
    //    }
    //    protected override void Dispose(bool disposing)
    //    {
    //        this.DbContext.Dispose();
    //        base.Dispose(disposing);
    //    }
        
    //    [EnableQuery]
    //    public IQueryable<Data.Person> Get()
    //    {
    //        IQueryable<Data.Person> people = this.DbContext.People;
    //        return people;
    //    }
    //}
}
