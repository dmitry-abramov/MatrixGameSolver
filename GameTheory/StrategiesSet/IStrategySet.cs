using System.Collections.Generic;
using GameTheory.Strategies;

namespace GameTheory.StrategiesSet
{
    public interface IStrategySet<TStrategy> : ISet<IStrategy<TStrategy>>
        where TStrategy : new()
    {
        IStrategy<TStrategy> GetRandomStrategy();
    }
}
