using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Sample.Data
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseModel>
    {
        protected override void Seed(DatabaseModel context)
        {
            
            var john = new Person() { Name = "Jonh", Gender = Gender.Male, DateOfBirth = new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0)), Adresses = new List<Address>() { new Address() { Street = "A" }, new Address() { Street = "B" } } };
            var lucy = new Person() { Name = "Lucy", Gender = Gender.Female, DateOfBirth = new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0)), Adresses = new List<Address>() { new Address() { Street = "C" }, new Address() { Street = "D" } } };

            context.People.AddRange(new List<Person>() {
                john,
                lucy,
            });

            context.SaveChanges();

            //base.Seed(context);
        }
    }
}
