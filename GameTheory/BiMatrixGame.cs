using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public class BiMatrixGame : IGame
    {
        public IStrategySet<int> FirstPlayerStrategySet {get; private set; }
        public IStrategySet<int> SecondPlayerStrategySet { get; private set; }

        private double[,] payoffFunction;

        public BiMatrixGame(double[,] payoffFunction, int fpsc, int spsc)
        {
            this.payoffFunction = payoffFunction;

            FirstPlayerStrategySet = new FiniteStrategySetBase<int>();
            SecondPlayerStrategySet = new FiniteStrategySetBase<int>();

            for (int i = 0; i < fpsc; i++)
            {
                FirstPlayerStrategySet.Add(new StrategyBase<int>(i));
            }

            for (int i = 0; i < spsc; i++)
            {
                SecondPlayerStrategySet.Add(new StrategyBase<int>(i));
            }
        }

        public double GetPayoff(int playerNumber, params IStrategy[] position)
        {
            return GetPayoffForPalyer(playerNumber, position);
        }

        public double GetPayoff(int playerNumber, IEnumerable<IStrategy> position)
        {
            return GetPayoffForPalyer(playerNumber, position);
        }

        public IEnumerable<double> GetPayoffs(params IStrategy[] playersStrategies)
        {
            return GetPayoffsForAllPlayers(playersStrategies);
        }

        public IEnumerable<double> GetPayoffs(IEnumerable<IStrategy> playersStrategies)
        {
            return GetPayoffsForAllPlayers(playersStrategies);
        }

        public IStrategySet<TStrategy> GetStrategySet<TStrategy>(int playerNumber) where TStrategy : new()
        {
            if (playerNumber < 1 || playerNumber > 2) 
            { 
                throw new ArgumentException(string.Format("Game has not player witn number '{0}'", playerNumber), "playerNumber");
            }

            if (typeof(TStrategy) != typeof(int))
            {
                throw new ArgumentException(string.Format("Wrong strategy type. It should be '{0}'", typeof(int)), "TStrategy");
            }

            if (playerNumber == 1) return (IStrategySet<TStrategy>)FirstPlayerStrategySet;
            return (IStrategySet<TStrategy>)SecondPlayerStrategySet;
        }

        private double GetPayoffForPalyer(int playerNumber, IEnumerable<IStrategy> position)
        {
            if (!Util.IsArgumentInRange(playerNumber, 1, 2))
            {
                throw new ArgumentException(string.Format("Game has not player witn number '{0}'", playerNumber), "playerNumber");
            }

            if (!Util.IsArgumentInRange(position.Count(), 1, 2))
            {
                throw new ArgumentException(string.Format("Game has {0} players", 2), "position");
            }

            if (FirstPlayerStrategySet.Contains(position.ElementAt(0)) &&
                 SecondPlayerStrategySet.Contains(position.ElementAt(1)))
            {
                return payoffFunction[(int)position.ElementAt(0).Strategy, (int)position.ElementAt(1).Strategy];
            }

            throw new ArgumentException("Not valid position for this game", "position");
        }

        private IEnumerable<double> GetPayoffsForAllPlayers(IEnumerable<IStrategy> playersStrategies)
        {
            throw new NotImplementedException();
        }
    }
}

