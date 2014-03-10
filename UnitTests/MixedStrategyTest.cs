using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GameTheory;

namespace UnitTests
{
    [TestClass]
    public class MixedStrategyTest
    {
        [TestMethod]
        public void CreateMixedStrategy()
        {
            var strategy = new MixedStrategy();

            Assert.AreEqual(1, strategy.Strategy.Sum());
        }

        [TestMethod]
        public void CreateMixedStrategyFromUnnormilized()
        {
            var unnormalizedMixedStrategy = new UnnormalizedMixedStrategy(new List<int> { 1, 2, 3 });
            var strategy = new MixedStrategy(unnormalizedMixedStrategy);

            Assert.AreEqual(1.0, strategy.Strategy.Sum());
        }
    }
}
