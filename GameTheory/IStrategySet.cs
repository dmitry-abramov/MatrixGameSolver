using System.Collections.Generic;

namespace GameTheory
{
    public interface IStrategySet<TStrategy> : ISet<IStrategy<TStrategy>>
        where TStrategy : new()
    {
        IStrategy<TStrategy> GetRandomStrategy();
    }
}
