using MVC_Counter.DBContext;
using MVC_Counter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Counter.DAL
{
    public class CounterDAL : ICounterDAL
    {
        private readonly ICounterContext _iCounterDbContext;
        //private readonly CounterContext counterDbContext;

        public CounterDAL()
        {
            _iCounterDbContext = new CounterContext();
        }

        public CounterDAL(ICounterContext iCounterDbContext)
        {
            _iCounterDbContext = iCounterDbContext;
        }

        
        public Counter GetValue()
        {
            var result = _iCounterDbContext.Counters.FirstOrDefault();
            return result;
        }

        public void CreateData(Counter entity)
        {
            _iCounterDbContext.Counters.Add(entity);
        }

        public void SaveData()
        {
            _iCounterDbContext.SaveChanges();
            //counterDbContext.SaveChanges();
        }

        public Counter GetCurrentValue()
        {
            Counter result = GetValue();
            if (result == null)
            {
                result = new Counter() { CounterNumber = 0 };
            }
            return result;

        }

        public int Increase()
        {
            try
            {
                Counter counter = GetCurrentValue();
                if (counter.CounterNumber == 0)
                {
                    CreateData(counter);
                }

                if (counter.CounterNumber < 10)
                {
                    counter.CounterNumber++;
                    SaveData();
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