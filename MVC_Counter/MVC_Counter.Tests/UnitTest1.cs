using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Counter.DAL;
using Moq;
using MVC_Counter.Models;
using System.Collections.Generic;
using MVC_Counter.DBContext;
using MVC_Counter.Services;

namespace MVC_Counter.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public List<Counter> counterList = new List<Counter>()
        {
            new Counter() {Id = 0 ,CounterNumber = 0},
            new Counter() {Id = 11 ,CounterNumber = 11}
        };
        


        [TestMethod]
        public void TestMethod1()
        {
            int inputValue = 0;
            bool resultCompare = false;
            Mock<ICounterDAL> mock = new Mock<ICounterDAL>();
            mock.Setup(x => x.GetValue()).Returns(new Counter() { CounterNumber = inputValue });
            CounterService counterDAL = new CounterService(mock.Object);
            Counter result = counterDAL.GetCurrentValue();

            Assert.AreEqual(result.CounterNumber <= 10, resultCompare);
        }
    }
}
