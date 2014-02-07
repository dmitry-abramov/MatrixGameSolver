using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GameTheory
{
    public class FiniteStrategySetBase<TStrategy> : Collection<StrategyBase<TStrategy>>, IStrategySet<TStrategy>
        where TStrategy : new()
    {
        public FiniteStrategySetBase() : base()
        {
        }

        public FiniteStrategySetBase(IList<StrategyBase<TStrategy>> strategies)
            : base(strategies)
        {
        }

        public StrategyBase<TStrategy> GetRandomStrategy()
        {
            int maxIndex = this.Count;

            if (maxIndex == 0)
            {
                throw new InvalidOperationException("Cann't get random strategy from empty set");
            }

            Random randomGenerator = new Random();
            int randomIndex = randomGenerator.Next(maxIndex);
            return this.ElementAt(randomIndex);
        }
    }
}
