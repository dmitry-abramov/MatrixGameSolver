using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class Experimentator
    {
        public ExperimentSourceBase ExperimentSource { get; private set; }

        public BrownMethodBase SolveMethod { get; private set; }

        public double Progress { get; private set; }

        public Experimentator(ExperimentSourceBase experimentSource, BrownMethodBase solveMethod)
        {
            Progress = 0;
            ExperimentSource = experimentSource;
            SolveMethod = solveMethod;
        }

        public void MakeExperiment()
        {
            var summarys = new List<ExperimentSummary>();
            var experiments = ExperimentSource.GetExperiments();

            for (int i = 0; i < experiments.Count(); i++)
            {
                Progress = i / experiments.Count();

                var experiment = experiments[i];
                var experimentResult = SolveMethod.Solve(experiment.Game, experiment.StartSituation, experiment.Parameters);

                summarys.Add(new ExperimentSummary(experiment, experimentResult.Result));
            }
        }
    }
}
