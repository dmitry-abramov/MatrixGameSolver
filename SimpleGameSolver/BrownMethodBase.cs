using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public abstract class BrownMethodBase
    {
        public int IterationsCount { get; private set; }

        public BrownMethodBase(int iterationCount)
        {
            IterationsCount = iterationCount;
        }

        public abstract List<List<List<int>>> Solve(double[,] fpp, double[,] spp, List<int> fpsp, List<int> spsp);
    }
}
