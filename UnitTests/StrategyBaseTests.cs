using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GameTheory;
using GameTheory.Strategies;

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

        [TestMethod]
        public void EqualStrategiesWithValluedType()
        {
            StrategyBase<int> strategy1 = new StrategyBase<int>(1);
            StrategyBase<int> strategy2 = new StrategyBase<int>(1);

            Assert.AreEqual(strategy1, strategy2);
            Assert.AreEqual(strategy1.GetHashCode(), strategy2.GetHashCode());
        }

        [TestMethod]
        public void EqualStrategiesWithReferencedType()
        {
            StrategyBase<List<int>> strategy1 = new StrategyBase<List<int>>(new List<int> { 1, 2 });
            StrategyBase<List<int>> strategy2 = new StrategyBase<List<int>>(new List<int> { 1, 2 });

            Assert.AreNotEqual(strategy1, strategy2);
            Assert.AreEqual(strategy1, strategy1);
        }
    }
}
