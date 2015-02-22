using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class ExperimentSummary
    {
        public Experiment Experiment { get; private set; }

        public Situation Result { get; private set; }

        public ExperimentSummary(Experiment experiment, Situation result)
        {
            Experiment = experiment;
            Result = result;
        }
    }
}
