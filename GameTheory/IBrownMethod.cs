using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public interface IBrownMethod
    {
        MixedStrategy Solve(IGame game, int iterationCount);
        MixedStrategy Solve(IGame game, UnnormalizedMixedStrategy startPosition, int iterationCount);
    }
}
