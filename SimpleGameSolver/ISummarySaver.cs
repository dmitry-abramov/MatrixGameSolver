using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleGameSolver
{
    interface ISummarySaver
    {
        void SaveToFile(FileInfo file, ExperimentPortion experimentPortion, BrownMethodBase method, MethodResult result);

        void SaveToFile(FileInfo file, Experiment experiment, BrownMethodBase method, IList<ExperimentPortionSummary> summaries);
    }
}
