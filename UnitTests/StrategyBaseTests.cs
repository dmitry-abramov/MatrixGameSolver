using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using GameTheory.Strategies;

namespace UnitTests
{
    [TestFixture]
    public class StrategyBaseTests
    {
        [Test]
        public void TestIntStrategy()
        {
            var strategy = new StrategyBase<int>(10);
            
            Assert.AreEqual(10, strategy.Strategy);
        }

        [Test]
        public void TestIntStrategyWithDefaultValueAndDescription()
        {
            var strategy = new StrategyBase<int>();

            Assert.AreEqual(0, strategy.Strategy);
            Assert.AreEqual("This is default strategy for type 'Int32'", strategy.Description);
        }

        [Test]
        public void TestDefaultDescriptionForIntStrategy()
        {
            var strategy = new StrategyBase<int>(5);

            Assert.AreEqual("This is strategy with type 'Int32'", strategy.Description);
        }

        [Test]
        public void TestDefaultValueForIntStrategy()
        {
            var strategy = new StrategyBase<int>("It is test description");

            Assert.AreEqual("It is test description" + Environment.NewLine + "This is default strategy for type 'Int32'", strategy.Description);
            Assert.AreEqual(0, strategy.Strategy);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullConstructorParameter()
        {
            var strategy = new StrategyBase<int>(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullBothConstructorParameter()
        {
            var strategy = new StrategyBase<object>(null, null);
        }

        [Test]
        public void CastIStrategyToIStrategyListInt()
        {
            IStrategy strategy = new StrategyBase<List<int>>(new List<int> { 10, 20 });

            var strategyListInt = strategy.Cast<List<int>>();
            var expected = new List<int> { 10, 20 };

            Assert.IsInstanceOf(typeof(IStrategy<List<int>>), strategyListInt);
            Assert.IsInstanceOf(typeof(List<int>), strategyListInt.Strategy);
            Assert.IsTrue(expected.SequenceEqual(strategyListInt.Strategy));                      
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CastIStrategyToIStrategyInt()
        {
            IStrategy strategy = new StrategyBase<List<int>>(new List<int> { 10, 20 });

            var strategyInt = strategy.Cast<int>();
        }

        [Test]
        public void EqualStrategiesWithValluedType()
        {
            StrategyBase<int> strategy1 = new StrategyBase<int>(1);
            StrategyBase<int> strategy2 = new StrategyBase<int>(1);

            Assert.AreEqual(strategy1, strategy2);
            Assert.AreEqual(strategy1.GetHashCode(), strategy2.GetHashCode());
        }

        [Test]
        public void EqualStrategiesWithReferencedType()
        {
            StrategyBase<List<int>> strategy1 = new StrategyBase<List<int>>(new List<int> { 1, 2 });
            StrategyBase<List<int>> strategy2 = new StrategyBase<List<int>>(new List<int> { 1, 2 });

            Assert.AreNotEqual(strategy1, strategy2);
            Assert.AreEqual(strategy1, strategy1);
        }
    }
}
