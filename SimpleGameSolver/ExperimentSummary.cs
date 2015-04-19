using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class ExperimentSummary : List<ExperimentPortionSummary>
    {
        public string MethodName
        {
            get;
            private set;
        }

        public string ExperimentName
        {
            get;
            private set;
        }

        public string ExperimentDescription
        {
            get;
            private set;
        }

        public ExperimentSummary(string experimentName, string experimentDescription, string methodName)
        {
            MethodName = methodName;
            ExperimentName = experimentName;
            ExperimentDescription = experimentDescription;
        }
    }
}
