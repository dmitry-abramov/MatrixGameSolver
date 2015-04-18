using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleGameSolver
{
    interface ISummarySaver
    {
        void SaveToFile(FileInfo file, ExperimentPortion experiment, BrownMethodBase method, MethodResult result);

        void SaveToFile(FileInfo file, Experiment experimentSource, BrownMethodBase method, IList<ExperimentPortionSummary> summaries);
    }
}
