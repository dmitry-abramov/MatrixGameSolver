using System;
using System.Collections.Generic;
using NUnit.Framework;

using GameTheory.Strategies;
using GameTheory.StrategiesSet;

namespace UnitTests
{
    [TestFixture]
    public class FiniteStrategySetBaseTest
    {
        [Test]
        public void CreateNewStrategySet()
        {
            var strategySet = new FiniteStrategySetBase<double>();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetRandomStrategyFromEmptySet()
        {
            var strategySet = new FiniteStrategySetBase<double>();
            var randomStrategy = strategySet.GetRandomStrategy();
        }

        [Test]
        public void GetRandomStrategy()
        {
            var strategySet = new FiniteStrategySetBase<double>();

            foreach (var strategy in new double[] { 1, 2, 3, 4, 5 })
            {
                strategySet.Add(new StrategyBase<double>(strategy));
            }

            var randomStrategy = strategySet.GetRandomStrategy();

            Assert.IsTrue(strategySet.Contains(randomStrategy));
        }

        [Test]
        public void AddExitingValuedElement()
        {
            var strategySet = new FiniteStrategySetBase<double>();

            foreach (var strategy in new double[] { 1, 2, 3, 4, 5 })
            {
                strategySet.Add(new StrategyBase<double>(strategy));
            }

            var result = strategySet.Add(new StrategyBase<double>(3));

            Assert.AreEqual(false, result);
            Assert.AreEqual(5, strategySet.Count);
        }

        [Test]
        [Ignore]
        public void AddExitingReferencedElement()
        {
            var strategySet = new FiniteStrategySetBase<List<double>>();

            foreach (var strategy in new double[] { 1, 2, 3, 4, 5 })
            {
                strategySet.Add(new StrategyBase<List<double>>(new List<double>{strategy}));
            }

            var result = strategySet.Add(new StrategyBase<List<double>>(new List<double>{3}));


            Assert.AreEqual(false, result);
            Assert.AreEqual(5, strategySet.Count);
        }

        [Test]
        public void CreateFromList()
        {
            var list = new List<IStrategy<int>> 
                { 
                    new StrategyBase<int>(1),
                    new StrategyBase<int>(2),
                    new StrategyBase<int>(3),
                    new StrategyBase<int>(3),
                    new StrategyBase<int>(4),
                    new StrategyBase<int>(5)
                };

            var strategySet = new FiniteStrategySetBase<int>(list);

            Assert.AreEqual(5, strategySet.Count);
        }
    }
}
