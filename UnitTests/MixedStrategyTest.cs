using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using GameTheory.Strategies;

namespace UnitTests
{
    [TestFixture]
    public class MixedStrategyTest
    {
        [Test]
        public void CreateMixedStrategy()
        {
            var strategy = new MixedStrategy();

            Assert.AreEqual(1, strategy.Strategy.Sum());
        }

        [Test]
        public void CreateMixedStrategyFromUnnormilized()
        {
            var unnormalizedMixedStrategy = new UnnormalizedMixedStrategy(new List<int> { 1, 2, 3 });
            var strategy = new MixedStrategy(unnormalizedMixedStrategy);

            Assert.AreEqual(1.0, strategy.Strategy.Sum());
        }
    }
}
