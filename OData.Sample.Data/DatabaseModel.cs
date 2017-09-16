using System;
using System.Collections;
using System.Collections.Generic;

namespace OData.Sample.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DatabaseModel : DbContext
    {

        static DatabaseModel()
        {
            var databaseInitializer = new OData.Sample.Data.DatabaseInitializer();
            Database.SetInitializer<DatabaseModel>(databaseInitializer);
        }

        // Your context has been configured to use a 'DatabaseModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'OData.Sample.Data.DatabaseModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DatabaseModel' 
        // connection string in the application configuration file.
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Adresses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(r => r.Adresses);
            //base.OnModelCreating(modelBuilder);
        }
    }


}

namespace OData.Sample.Data
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTimeOffset DateOfBirth { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Address> Adresses { get; set; }
    }

    public enum Gender
    {
        Undefined = 0,
        Male = 1,
        Female = 2
    }
}

namespace OData.Sample.Data
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string Street { get; set; }
    }
}