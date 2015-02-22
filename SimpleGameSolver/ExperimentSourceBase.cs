using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public abstract class ExperimentSourceBase
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract IList<Experiment> GetExperiments();
    }
}
