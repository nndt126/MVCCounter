using MVC_Counter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Counter.DBContext
{
    public interface ICounterContext
    {
        DbSet<Counter> Counters { get; set; }
        int SaveChanges();
        //Counter GetValue();
    }
}
