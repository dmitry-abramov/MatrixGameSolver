using System.Collections.Generic;

namespace GameTheory
{
    public interface IStrategySet<TStrategy> : ICollection<IStrategy<TStrategy>>, IStrategySet
        where TStrategy : new()
    {
        IStrategy<TStrategy> GetRandomStrategy();
    }

    public interface IStrategySet : ICollection<IStrategy>
    {
        IStrategy GetRandomStrategy();
    }
}
