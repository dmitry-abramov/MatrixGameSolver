using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver.Experiments
{
    public class EmptyExperiment : Experiment
    {
        public override string Name
        {
            get { return "Empty experiment"; }
        }

        public override string Description
        {
            get { return "Empty experiment"; }
        }

        public override IList<ExperimentPortion> GetExperimentPortion()
        {
            return new List<ExperimentPortion>();
        }
    }
}
