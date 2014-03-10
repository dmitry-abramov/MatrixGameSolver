using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GameTheory;

namespace UnitTests
{
    [TestClass]
    public class FiniteStrategySetBaseTest
    {
        [TestMethod]
        public void CreateNewStrategySet()
        {
            var strategySet = new FiniteStrategySetBase<double>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetRandomStrategyFromEmptySet()
        {
            var strategySet = new FiniteStrategySetBase<double>();
            var randomStrategy = strategySet.GetRandomStrategy();
        }

        [TestMethod]
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

        [TestMethod]
        public void AddExitingElement()
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

        [TestMethod]
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
