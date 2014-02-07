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

            foreach(var strategy in new double[]{1, 2, 3, 4, 5})
            {
                strategySet.Add(new StrategyBase<double>(strategy));
            }

            var randomStrategy = strategySet.GetRandomStrategy();

            Assert.IsTrue(strategySet.Contains(randomStrategy));
        }
    }
}
