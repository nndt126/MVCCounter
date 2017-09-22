using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_Counter.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC_Counter.DBContext
{
    public class CounterContext : DbContext
    {
        public CounterContext()
            : base("name=DefaultConnection")
        {
            //Database.SetInitializer<CounterContext>(null);
            Database.SetInitializer(new CreateDatabaseIfNotExists<CounterContext>());
        }
        public DbSet<Counter> Counters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}