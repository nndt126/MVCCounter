using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_Counter.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC_Counter.DBContext
{
    public class CounterContext : DbContext, ICounterContext
    {
        public CounterContext()
            : base("name=DefaultConnection")
        {
            try
            {
                Database.SetInitializer<CounterContext>(null);
                Database.SetInitializer(new CreateDatabaseIfNotExists<CounterContext>());
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

       

        public virtual DbSet<Counter> Counters { get; set; }

        public Counter GetValue()
        {
            var result = Counters.FirstOrDefault();
            return result;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}