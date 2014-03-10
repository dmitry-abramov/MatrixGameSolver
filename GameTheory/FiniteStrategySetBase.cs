using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GameTheory
{
    public class FiniteStrategySetBase<TStrategy> : HashSet<IStrategy<TStrategy>>, IStrategySet<TStrategy>
        where TStrategy : new()
    {
        public FiniteStrategySetBase()
            : base()
        {
        }

        public FiniteStrategySetBase(IList<IStrategy<TStrategy>> strategies)
            : base(strategies)
        {
        }

        public IStrategy<TStrategy> GetRandomStrategy()
        {
            int maxIndex = Count;

            if (maxIndex == 0)
            {
                throw new InvalidOperationException("Cann't get random strategy from empty set");
            }

            Random randomGenerator = new Random();
            int randomIndex = randomGenerator.Next(maxIndex);
            return this.ElementAt<IStrategy<TStrategy>>(randomIndex);
        }
    }
}
