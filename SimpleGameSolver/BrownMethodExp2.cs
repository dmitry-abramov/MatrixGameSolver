using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    // укорачиваем шаг до единицы если кто-то меняет стратегию
    public class BrownMethodExp2 : BrownMethodBase
    {
        public override MethodResult Solve(BimatrixGame game, Situation startSituation, IDictionary<string, string> parameters)
        {
            var iterationsCount = 1;
            Int32.TryParse(parameters["iterationsCount"], out iterationsCount);

            ulong fpStep = 1;
            ulong spStep = 1;

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
                int fpcNew = Choice1(game.FirstPlayerMatrix, result.Result.SecondPlayerStrategy, fpc);
                int spcNew = Choice2(game.SecondPlayerMatrix, result.Result.FirstPlayerStrategy, spc);

                fpStep *= 2;
                if (spc != spcNew || fpc != fpcNew) fpStep = 1;

                spStep *= 2;
                if (fpc != fpcNew || spc != spcNew) spStep = 1;

                fpNewStrategy = new List<ulong>(result.Result.FirstPlayerStrategy);
                fpNewStrategy[fpcNew] += fpStep;

                fpNewStrategy = new List<ulong>(result.Result.SecondPlayerStrategy);
                spNewStrategy[spcNew] += spStep;

                fpc = fpcNew;
                spc = spcNew;

                result.MethodTrace.Add(new Situation(fpNewStrategy, spNewStrategy));
            }

            return result;
        }
    }
}
