using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OData.Sample.Models
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTimeOffset DateOfBirth { get; set; }
        //public virtual Gender Gender { get; set; }
        //public virtual ICollection<Address> Adresses { get; set; }
    }
}