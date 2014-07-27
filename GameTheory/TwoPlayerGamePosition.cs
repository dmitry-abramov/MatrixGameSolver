using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory.Strategies;

namespace GameTheory
{
    public class TwoPlayerGamePosition<TStrategy>
    {
        public IStrategy<TStrategy> FirstPlayerStrategy{ get; private set; }
        public IStrategy<TStrategy> SecondPlayerStrategy{ get; private set; }

        public TwoPlayerGamePosition(IStrategy<TStrategy> fps, IStrategy<TStrategy> sps)
        {
            FirstPlayerStrategy = fps;
            SecondPlayerStrategy = sps;
        }
    }
}
