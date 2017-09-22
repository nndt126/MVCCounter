using MVC_Counter.DBContext;
using MVC_Counter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Counter.DAL
{
    public class CounterDAL : ICounter
    {
        private readonly CounterContext counterDbContext;

        public CounterDAL()
        {
            counterDbContext = new CounterContext();
        }
        public Counter GetFirstValue()
        {
            var result = counterDbContext.Counters.FirstOrDefault();
            return result;
        }

        public void Add(Counter entity)
        {
            counterDbContext.Counters.Add(entity);
        }

        public void Save()
        {
            counterDbContext.SaveChanges();
        }

        public Counter GetCurrentValue()
        { 
            return GetFirstValue() ?? new Counter() { CounterNumber = 0 };
        }

        public int IncreaseValue()
        {
            try
            {
                Counter counter = GetCurrentValue();
                if (counter.CounterNumber == 0)
                {
                    Add(counter);
                }

                if (counter.CounterNumber < 10)
                {
                    counter.CounterNumber++;
                    Save();
                }
                return counter.CounterNumber;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}