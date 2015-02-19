using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public interface IExperimentSource
    {
        string Description { get; }

        IList<Experiment> GetExperiments();
    }
}
