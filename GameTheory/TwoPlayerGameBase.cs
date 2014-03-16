using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public abstract class TwoPlayerGameBase<TStrategy> 
        where TStrategy : new() 
    {
        public IStrategySet<TStrategy> FirstPlayerStrategies
        {
            get;
            private set;
        }

        public IStrategySet<TStrategy> SecondPlayerStrategies
        {
            get;
            private set;
        }

        public abstract double FirstPalyerPayoff(TwoPlayerGamePosition<TStrategy> position);

        public abstract double SecondPalyerPayoff(TwoPlayerGamePosition<TStrategy> position);
    }
}
