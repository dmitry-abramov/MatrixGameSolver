﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Windows.Forms;

namespace SimpleGameSolver
{
    public class Experimentator
    {
        private ProgressBar ProgressBar { get; set; }

        public ExperimentSourceBase ExperimentSource { get; private set; }

        public BrownMethodBase SolveMethod { get; private set; }

        public double Progress { get; private set; }

        public Experimentator(ExperimentSourceBase experimentSource, BrownMethodBase solveMethod)
        {
            Progress = 0;
            ExperimentSource = experimentSource;
            SolveMethod = solveMethod;
            ProgressBar = new ProgressBar();
        }

        public Experimentator(ExperimentSourceBase experimentSource, BrownMethodBase solveMethod, ProgressBar progressBar)
        {
            Progress = 0;
            ExperimentSource = experimentSource;
            SolveMethod = solveMethod;
            ProgressBar = progressBar;
        }

        public void MakeExperiment()
        {
            var summaries = new List<ExperimentSummary>();
            var experiments = ExperimentSource.GetExperiments();

            var folderName = string.Format("experiment_{0}_{1}", experiments[0].Name, DateTime.UtcNow.ToString("yyyy_MM_dd_hh_mm_ss_fff"));
            var folder = new DirectoryInfo(folderName);
            folder.Create();

            ProgressBar.Maximum = experiments.Count();
            ProgressBar.Minimum = 0;

            for (int i = 0; i < experiments.Count(); i++)
            {
                Progress = i / experiments.Count();
                ProgressBar.Value = i;

                var experiment = experiments[i];
                var experimentResult = SolveMethod.Solve(experiment.Game, experiment.StartSituation, experiment.Parameters);

                summaries.Add(new ExperimentSummary(experiment, experimentResult.Result));

                var fileName = string.Format("{0}\\{1}_{2}.xlsx", folderName, experiment.Name, DateTime.UtcNow.ToString("yyyy_MM_dd_hh_mm_ss_fff"));
                var file = new FileInfo(fileName);
                ExcelHelper.SaveToFile(file, experiment, SolveMethod, experimentResult);
            }

            var summaryFileName = string.Format("{0}\\summary_{1}_{2}.xlsx", folderName, experiments[0].Name, DateTime.UtcNow.ToString("yyyy_MM_dd_hh_mm_ss_fff"));
            var summaryFile = new FileInfo(summaryFileName);
            ExcelHelper.SaveToFile(summaryFile, ExperimentSource, SolveMethod, summaries);
        }
    }
}
