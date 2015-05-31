using System.Collections.Generic;

namespace SimpleGameSolver.Experiments
{    
    public abstract class Experiment
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract IList<ExperimentPortion> GetExperimentPortion();

        public virtual UiConfigurator GetUiConfigurator()
        {
            return new EmptyUiConfigurator(this);
        }
    }
}
