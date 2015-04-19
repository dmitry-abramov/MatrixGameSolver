﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleGameSolver
{
    interface ISummarySaver
    {
        void SaveToFile(FileInfo file, ExperimentPortion experimentPortion, MethodResult result);

        void SaveToFile(FileInfo file, ExperimentSummary summary);
    }
}
