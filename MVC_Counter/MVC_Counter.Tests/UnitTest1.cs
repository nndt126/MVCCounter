using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Counter.DBContext;
using MVC_Counter.DAL;
using MVC_Counter.Models;
using Autofac.Extras.Moq;
using Autofac;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Counter.Tests
{
    [TestClass]
    public class UnitTest1
    {
        ICounterDAL counterDAL;
        ICounterContext db;

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            List<Counter> data = new List<Counter>
            {
                new Counter {CounterNumber = 0 },
                new Counter {CounterNumber = 11 }
            };
            DbSet<Counter> myDbSet = GetQueryableMockDbSet(data);
            var mock = AutoMock.GetLoose();
            mock.Mock<ICounterContext>().Setup(c => c.Counters).Returns(myDbSet);
            mock.Provide<ICounterDAL, CounterDAL>();
            counterDAL = mock.Create<ICounterDAL>();
        }


        [TestMethod]
        public void TestMethod1()
        {
            var counter = counterDAL.GetValue();
            Assert.AreEqual(0, counter.CounterNumber);
        }
    }
}
