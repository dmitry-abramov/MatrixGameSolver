using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GameTheory;

namespace UnitTests
{
    [TestClass]
    public class StrategyBaseTests
    {
        [TestMethod]
        public void TestIntStrategy()
        {
            var strategy = new StrategyBase<int>(10);
            
            Assert.AreEqual(10, strategy.Strategy);
        }

        [TestMethod]
        public void TestIntStrategyWithDefaultValueAndDescription()
        {
            var strategy = new StrategyBase<int>();

            Assert.AreEqual(0, strategy.Strategy);
            Assert.AreEqual("This is default strategy for type 'Int32'", strategy.Description);
        }

        [TestMethod]
        public void TestDefaultDescriptionForIntStrategy()
        {
            var strategy = new StrategyBase<int>(5);

            Assert.AreEqual("This is strategy with type 'Int32'", strategy.Description);
        }

        [TestMethod]
        public void TestDefaultValueForIntStrategy()
        {
            var strategy = new StrategyBase<int>("It is test description");

            Assert.AreEqual("It is test description" + Environment.NewLine + "This is default strategy for type 'Int32'", strategy.Description);
            Assert.AreEqual(0, strategy.Strategy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullConstructorParameter()
        {
            var strategy = new StrategyBase<int>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullBothConstructorParameter()
        {
            var strategy = new StrategyBase<object>(null, null);
        }

        [TestMethod]
        public void CastIStrategyToIStrategyListInt()
        {
            IStrategy strategy = new StrategyBase<List<int>>(new List<int> { 10, 20 });

            var strategyListInt = strategy.Cast<List<int>>();
            var expected = new List<int> { 10, 20 };

            Assert.IsInstanceOfType(strategyListInt, typeof(IStrategy<List<int>>));
            Assert.IsInstanceOfType(strategyListInt.Strategy, typeof(List<int>));
            Assert.IsTrue(expected.SequenceEqual(strategyListInt.Strategy));                      
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CastIStrategyToIStrategyInt()
        {
            IStrategy strategy = new StrategyBase<List<int>>(new List<int> { 10, 20 });

            var strategyInt = strategy.Cast<int>();
        }
    }
}
