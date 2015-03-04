using System.Collections.Generic;

namespace SimpleGameSolver
{
    // todo : it should be interface
    public abstract class ExperimentSourceBase
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract IList<Experiment> GetExperiments();

        // todo : remove
        public override string ToString()
        {
            return Name;
        }
    }
}
