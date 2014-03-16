using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public class MixedExtension : TwoPlayerGameBase<List<double>>
    {
        public override double FirstPalyerPayoff(TwoPlayerGamePosition<List<double>> position)
        {
            throw new NotImplementedException();
        }

        public override double SecondPalyerPayoff(TwoPlayerGamePosition<List<double>> position)
        {
            throw new NotImplementedException();
        }
    }
}
