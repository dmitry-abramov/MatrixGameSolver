using System;
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

        private ISummarySaver SummarySaver { get { return new ExcelSummarySaver();  } }

        public Experiment Experiment { get; private set; }

        public BrownMethodBase SolveMethod { get; private set; }

        public double Progress { get; private set; }

        public Experimentator(Experiment experiment, BrownMethodBase solveMethod)
        {
            Progress = 0;
            Experiment = experiment;
            SolveMethod = solveMethod;
            ProgressBar = new ProgressBar();
        }

        public Experimentator(Experiment experiment, BrownMethodBase solveMethod, ProgressBar progressBar)
        {
            Progress = 0;
            Experiment = experiment;
            SolveMethod = solveMethod;
            ProgressBar = progressBar;
        }

        public void MakeExperiment()
        {
            var summaries = new List<ExperimentPortionSummary>();
            var experimentPortions = Experiment.GetExperimentPortion();

            var folderName = string.Format("experiment_{0}_{1}", experimentPortions[0].Name, DateTime.UtcNow.ToString("yyyy_MM_dd_hh_mm_ss_fff"));
            var folder = new DirectoryInfo(folderName);
            folder.Create();

            ProgressBar.Maximum = experimentPortions.Count();
            ProgressBar.Minimum = 0;

            for (int i = 0; i < experimentPortions.Count(); i++)
            {
                Progress = i / experimentPortions.Count();
                ProgressBar.Value = i;

                var experimentPortion = experimentPortions[i];
                var experimentPortionResult = SolveMethod.Solve(experimentPortion.Game, experimentPortion.StartSituation, experimentPortion.Parameters);

                summaries.Add(new ExperimentPortionSummary(experimentPortion, experimentPortionResult.Result));

                var fileName = string.Format("{0}\\{1}_experiment_{2}.xlsx", folderName, experimentPortion.Name, i.ToString());
                var file = new FileInfo(fileName);
                SummarySaver.SaveToFile(file, experimentPortion, SolveMethod, experimentPortionResult);
            }

            var summaryFileName = string.Format("{0}\\summary_{1}_{2}.xlsx", folderName, experimentPortions[0].Name, DateTime.UtcNow.ToString("yyyy_MM_dd_hh_mm_ss_fff"));
            var summaryFile = new FileInfo(summaryFileName);
            SummarySaver.SaveToFile(summaryFile, Experiment, SolveMethod, summaries);
        }
    }
}
