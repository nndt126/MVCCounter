using System;
using Moq;
using NUnit.Framework;
using MVC_Counter.DBContext;
using MVC_Counter.DAL;
using MVC_Counter.Models;
using MVC_Counter.Services;

namespace MVC_Counter.Tests
{
    [TestFixture]
    public class CounterDALTest
    {
        [TestCase(0, true)]    
        [TestCase(11, false)]
        public void TestFunctionGetCurrentValue(int inputValue, bool result)
        {
            Mock<ICounterDAL> mock = new Mock<ICounterDAL>();
            mock.Setup(x => x.GetValue()).Returns(new Counter() { CounterNumber = inputValue });
            //CounterDAL counterDAL = new CounterDAL(mock.Object);
            CounterService counterService = new CounterService(mock.Object);
            Counter resultNumber = counterService.GetCurrentValue();
            Assert.AreEqual(resultNumber.CounterNumber <= 10, result);
        }

        [TestCase(0, 1)]  // Testcase is applied when application start first times.
        [TestCase(5, 6)]   // Testcase is applied when application start next times.
        [TestCase(11, 11)] // Testcase is applied to test number is not greater than 10.
        public void TestFunctionIncrease(int numberBeforeIncreasing, int numberAfterIncreasing)
        {
            Mock<ICounterDAL> mockCounterRespository = new Mock<ICounterDAL>();
            mockCounterRespository.Setup(x => x.GetValue()).Returns(new Counter() { CounterNumber = numberBeforeIncreasing });
            mockCounterRespository.Setup(x => x.CreateData(It.IsAny<Counter>()));
            mockCounterRespository.Setup(x => x.SaveData());

            CounterService counterService = new CounterService(mockCounterRespository.Object);
            int resultNumber = counterService.Increase();
            Assert.AreEqual(resultNumber, numberAfterIncreasing);
        }
    }
}
