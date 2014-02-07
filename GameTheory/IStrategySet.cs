using System.Collections.Generic;

namespace GameTheory
{
    public interface IStrategySet<TStrategy> : ICollection<StrategyBase<TStrategy>>
        where TStrategy : new()
    {
        StrategyBase<TStrategy> GetRandomStrategy();
    }    
}
