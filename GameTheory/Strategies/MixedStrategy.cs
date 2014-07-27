using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.Strategies
{
    public class UnnormalizedMixedStrategy : StrategyBase<List<int>>
    {
        public UnnormalizedMixedStrategy(List<int> strategy) :
            base(strategy)    
        { 
        }

        public UnnormalizedMixedStrategy() :
            base()
        {
        }
    }

    public class MixedStrategy : StrategyBase<List<double>>
    {
        public MixedStrategy() :
            base(new List<double> { 1 })
        {
        }

        public MixedStrategy(UnnormalizedMixedStrategy mixedStrategy)
        {
            double sum = mixedStrategy.Strategy.Sum();
            var strategy = new List<double>();
            foreach (var item in mixedStrategy.Strategy)
            {
                strategy.Add((double)item / sum);
            }

            Strategy = strategy;
        }
    }
}
