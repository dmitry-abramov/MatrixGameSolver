using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class BrownMethodClassic : BrownMethodBase
    {
        public override List<List<List<ulong>>> Solve(double[,] fpp, double[,] spp, List<ulong> fpsp, List<ulong> spsp, int iterationsCount)
        {
            // set start position
            var result = new List<List<List<ulong>>>();

            result.Add(new List<List<ulong>> { fpsp, spsp });
                
            // first iteration
            int fpc = Choice1(fpp, result.Last()[1], 0);
            int spc = Choice2(spp, result.Last()[0], 0);

            List<ulong> fpNewStrategy = new List<ulong>(result.Last()[0]);
            fpNewStrategy[fpc]++;

            List<ulong> spNewStrategy = new List<ulong>(result.Last()[1]);
            spNewStrategy[spc]++;

            result.Add(new List<List<ulong>> { fpNewStrategy, spNewStrategy });

            // iterations from second
            for (int i = 1; i < iterationsCount; i++)
            {
                fpc = Choice1(fpp, result.Last()[1], fpc);
                spc = Choice2(spp, result.Last()[0], spc);

                fpNewStrategy = new List<ulong>(result.Last()[0]);
                fpNewStrategy[fpc]++;

                spNewStrategy = new List<ulong>(result.Last()[1]);
                spNewStrategy[spc]++;

                result.Add(new List<List<ulong>> { fpNewStrategy, spNewStrategy });
            }

            return result;
        }
    }
}
