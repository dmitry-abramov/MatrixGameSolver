using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
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
        public MixedStrategy(List<double> strategy) :
            base(strategy)            
        { 
        }

        public MixedStrategy() :
            base()
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
