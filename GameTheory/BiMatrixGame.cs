using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public class BiMatrixGame : TwoPlayerGameBase<int>
    {
        public BiMatrixGame(double[,] payoffFunction1, double[,] payoffFunction2, int firstPlayerStrategiesCount, int secondPlayerStrategiesCount)
        { }

        public override double FirstPalyerPayoff(TwoPlayerGamePosition<int> position)
        {
            throw new NotImplementedException();
        }

        public override double SecondPalyerPayoff(TwoPlayerGamePosition<int> position)
        {
            throw new NotImplementedException();
        }
    }
}

