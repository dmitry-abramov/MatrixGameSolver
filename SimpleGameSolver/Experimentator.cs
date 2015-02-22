using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class Experimentator
    {
        public ExperimentSourceBase ExperimentSource { get; private set; }

        public Experimentator(ExperimentSourceBase experimentSource)
        {
            ExperimentSource = experimentSource;
        }

        public void MakeExperiment()
        {
        }
    }
}
