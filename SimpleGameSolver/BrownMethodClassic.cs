using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class BrownMethodClassic : BrownMethodBase
    {
        public override List<List<List<int>>> Solve(double[,] fpp, double[,] spp, List<int> fpsp, List<int> spsp, int iterationsCount)
        {
            // set start position
            var result = new List<List<List<int>>>();

            result.Add(new List<List<int>> { fpsp, spsp });
                
            // first iteration
            int fpc = Choice1(fpp, result.Last()[1], 0);
            int spc = Choice2(spp, result.Last()[0], 0);

            List<int> fpNewStrategy = new List<int>(result.Last()[0]);
            fpNewStrategy[fpc]++;

            List<int> spNewStrategy = new List<int>(result.Last()[1]);
            spNewStrategy[spc]++;

            result.Add(new List<List<int>> { fpNewStrategy, spNewStrategy });

            // iterations from second
            for (int i = 1; i < iterationsCount; i++)
            {
                fpc = Choice1(fpp, result.Last()[1], fpc);
                spc = Choice2(spp, result.Last()[0], spc);

                fpNewStrategy = new List<int>(result.Last()[0]);
                fpNewStrategy[fpc]++;

                spNewStrategy = new List<int>(result.Last()[1]);
                spNewStrategy[spc]++;

                result.Add(new List<List<int>> { fpNewStrategy, spNewStrategy });
            }

            return result;
        }
    }
}
