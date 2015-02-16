using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class BrownMethodClassic : BrownMethodBase
    {
        public override List<List<List<ulong>>> Solve(BimatrixGame game, Situation startSituation, int iterationsCount)
        {
            // set start position
            var result = new List<List<List<ulong>>>();

            result.Add(new List<List<ulong>> { startSituation.FirstPlayerStrategy.ToList(), startSituation.SecondPlayerStrategy.ToList() });
                
            // first iteration
            int fpc = Choice1(game.FirstPlayerMatrix, result.Last()[1], 0);
            int spc = Choice2(game.SecondPlayerMatrix, result.Last()[0], 0);

            List<ulong> fpNewStrategy = new List<ulong>(result.Last()[0]);
            fpNewStrategy[fpc]++;

            List<ulong> spNewStrategy = new List<ulong>(result.Last()[1]);
            spNewStrategy[spc]++;

            result.Add(new List<List<ulong>> { fpNewStrategy, spNewStrategy });

            // iterations from second
            for (int i = 1; i < iterationsCount; i++)
            {
                fpc = Choice1(game.FirstPlayerMatrix, result.Last()[1], fpc);
                spc = Choice2(game.SecondPlayerMatrix, result.Last()[0], spc);

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
