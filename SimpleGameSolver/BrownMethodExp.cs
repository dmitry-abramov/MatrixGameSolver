using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    // укорачиваем шаг если соперник меняет стратегию
    public class BrownMethodExp : BrownMethodBase
    {
        public override List<List<List<ulong>>> Solve(double[,] fpp, double[,] spp, List<ulong> fpsp, List<ulong> spsp, int iterationsCount)
        {
            ulong fpStep = 1;
            ulong spStep = 1;

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

            result.Add(new List<List<ulong>> { fpNewStrategy, spNewStrategy});

            // iterations from second
            for (int i = 1; i < iterationsCount; i++)
            {
                int fpcNew = Choice1(fpp, result.Last()[1], fpc);
                int spcNew = Choice2(spp, result.Last()[0], spc);

                fpStep *= 2;
                if (spc != spcNew) fpStep = 1;
                
                spStep *= 2;
                if (fpc != fpcNew) spStep = 1;

                fpNewStrategy = new List<ulong>(result.Last()[0]);
                fpNewStrategy[fpcNew] += fpStep;

                spNewStrategy = new List<ulong>(result.Last()[1]);
                spNewStrategy[spcNew] += spStep;

                fpc = fpcNew;
                spc = spcNew;

                result.Add(new List<List<ulong>> { fpNewStrategy, spNewStrategy } );
            }

            return result;
        }
    }
}
