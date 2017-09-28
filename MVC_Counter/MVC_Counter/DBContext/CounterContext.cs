using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_Counter.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using MVC_Counter.Migrations;

namespace MVC_Counter.DBContext
{
    public class CounterContext : DbContext, ICounterContext
    {
        static CounterContext()
        {
            Database.SetInitializer<CounterContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CounterContext, Configuration>());
            Database.SetInitializer<CounterContext>(new CreateDatabaseIfNotExists<CounterContext>());
            //CreateDatabase();
            
        }
        public CounterContext()
            : base("name=DefaultConnection")
        {
        }

        public static void CreateDatabase()
        {
            var context = new CounterContext();
            context.Database.Initialize(true);
        }

        public virtual DbSet<Counter> Counters { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}