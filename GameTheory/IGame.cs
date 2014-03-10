using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameTheory;

namespace GameTheory
{
    public interface IGame
    {
        double GetPayoff(int playerNumber, params IStrategy[] position);

        double GetPayoff(int playerNumber, IEnumerable<IStrategy> position);

        IEnumerable<double> GetPayoffs(params IStrategy[] playersStrategies);

        IEnumerable<double> GetPayoffs(IEnumerable<IStrategy> playersStrategies);

        IStrategySet<TStrategy> GetStrategySet<TStrategy>(int playerNumber) where TStrategy : new();
    }
}
