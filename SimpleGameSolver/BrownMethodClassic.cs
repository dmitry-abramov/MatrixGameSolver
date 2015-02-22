using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class BrownMethodClassic : BrownMethodBase
    {
        public override MethodResult Solve(BimatrixGame game, Situation startSituation, int iterationsCount)
        {
            // set start position
            var result = new MethodResult();

            result.MethodTrace.Add(startSituation);
                
            // first iteration
            int fpc = Choice1(game.FirstPlayerMatrix, result.Result.SecondPlayerStrategy, 0);
            int spc = Choice2(game.SecondPlayerMatrix, result.Result.FirstPlayerStrategy, 0);

            List<ulong> fpNewStrategy = new List<ulong>(result.Result.FirstPlayerStrategy);
            fpNewStrategy[fpc]++;

            List<ulong> spNewStrategy = new List<ulong>(result.Result.SecondPlayerStrategy);
            spNewStrategy[spc]++;

            result.MethodTrace.Add(new Situation(fpNewStrategy, spNewStrategy));

            // iterations from second
            for (int i = 1; i < iterationsCount; i++)
            {
                fpc = Choice1(game.FirstPlayerMatrix, result.Result.SecondPlayerStrategy, fpc);
                spc = Choice2(game.SecondPlayerMatrix, result.Result.FirstPlayerStrategy, spc);

                fpNewStrategy = new List<ulong>(result.Result.FirstPlayerStrategy);
                fpNewStrategy[fpc]++;

                spNewStrategy = new List<ulong>(result.Result.SecondPlayerStrategy);
                spNewStrategy[spc]++;

                result.MethodTrace.Add(new Situation(fpNewStrategy, spNewStrategy));
            }

            return result;
        }
    }
}
