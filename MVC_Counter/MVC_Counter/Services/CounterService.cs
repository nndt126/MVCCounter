using MVC_Counter.DAL;
using MVC_Counter.DBContext;
using MVC_Counter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Counter.Services
{
    public class CounterService : ICounterService
    {
        private readonly ICounterDAL _iCounter;

        public CounterService()
        {
            _iCounter = new CounterDAL();
        }

        public CounterService(ICounterDAL iCounter)
        {
            _iCounter = iCounter;
        }

        public Counter GetCurrentValue()
        {
            var result = _iCounter.GetValue();
            if (result == null)
                result = new Counter() { CounterNumber = 0 };
            return result;
            //return _iCounter.GetValue() ?? new Counter() { CounterNumber = 0 };
        }

        public int Increase()
        {
            try
            {
                Counter counter = GetCurrentValue();
                if (counter.CounterNumber == 0)
                    _iCounter.CreateData(counter);

                else if (counter.CounterNumber < 10)
                {
                    counter.CounterNumber++;
                    _iCounter.SaveData();
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