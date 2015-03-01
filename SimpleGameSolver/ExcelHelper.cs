using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OfficeOpenXml;
using System.IO;

namespace SimpleGameSolver
{
    public static class ExcelHelper
    {
        public static void SaveToFile(Experiment experiment, MethodResult result)
        {
            var fileName = string.Format("{0}_{1}.xlsx", experiment.Name, DateTime.UtcNow.ToString("yyyy_MM_dd_hh_mm_ss_fff"));
            using (var package = new ExcelPackage(new FileInfo(fileName)))
            {
                var ws = package.Workbook.Worksheets.Add("ExperimentResult");

                ws.Cells[1, 1].Value = experiment.Name;

                ws.Cells[4, 1].Value = "parameters";
                for (int i = 0; i < experiment.Parameters.Count; i++)
                {
                    var key = experiment.Parameters.ElementAt(i).Key;
                    ws.Cells[5, i + 1].Value = key;
                    ws.Cells[6, i + 1].Value = experiment.Parameters[key];
                }

                ws.Cells[8, 1].Value = "first player";
                for (int i = 0; i < experiment.Game.FirstPlayerMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < experiment.Game.FirstPlayerMatrix.GetLength(1); j++)
                    {
                        ws.Cells[i + 9, j + 1].Value = experiment.Game.FirstPlayerMatrix[i, j];
                    }                    
                }

                ws.Cells[experiment.Game.FirstPlayerMatrix.GetLength(1) + 2, 1].Value = "second player";
                for (int i = 0; i < experiment.Game.SecondPlayerMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < experiment.Game.SecondPlayerMatrix.GetLength(1); j++)
                    {
                        ws.Cells[i + 9, j + experiment.Game.FirstPlayerMatrix.GetLength(1) + 2].Value = experiment.Game.SecondPlayerMatrix[i, j];
                    }                    
                }

                var traceStartCellNumber = 9 + experiment.Game.FirstPlayerMatrix.GetLength(0) + 4;
                ws.Cells[traceStartCellNumber - 2, 1].Value = "absolute";
                ws.Cells[traceStartCellNumber - 1, 1].Value = "#";
                var game = experiment.Game;
                for (int i = 0; i < game.FirstPlayerMatrix.GetLength(0); i++)
                {
                    ws.Cells[traceStartCellNumber - 1, i + 2].Value = "First player, strategy " + i.ToString();
                }
                for (int i = 0; i < game.FirstPlayerMatrix.GetLength(1); i++)
                {
                    ws.Cells[traceStartCellNumber - 1, game.FirstPlayerMatrix.GetLength(0) + i + 3].Value = "Second player, strategy " + i.ToString();
                }

                for (int i = 0; i < result.MethodTrace.Count; i++)
                {
                    var situation = result.MethodTrace[i];

                    for (int j = 0; j < situation.FirstPlayerStrategy.Count(); j++)
                    {
                        ws.Cells[traceStartCellNumber + i, j + 2].Value = situation.FirstPlayerStrategy[j];                                                
                    }
                    for (int j = 0; j < situation.SecondPlayerStrategy.Count(); j++)
                    {
                        ws.Cells[traceStartCellNumber + i, situation.FirstPlayerStrategy.Count() + j + 3].Value = situation.SecondPlayerStrategy[j];
                    }
                }

                var normalizeStartCell = game.FirstPlayerMatrix.GetLength(0) + game.FirstPlayerMatrix.GetLength(1) + 4;
                ws.Cells[traceStartCellNumber - 2, normalizeStartCell + 1].Value = "normalize";
                ws.Cells[traceStartCellNumber - 1, normalizeStartCell + 1].Value = "#";
                for (int i = 0; i < game.FirstPlayerMatrix.GetLength(0); i++)
                {
                    ws.Cells[traceStartCellNumber - 1, normalizeStartCell + i + 2].Value = "First player, strategy " + i.ToString();
                }
                for (int i = 0; i < game.FirstPlayerMatrix.GetLength(1); i++)
                {
                    ws.Cells[traceStartCellNumber - 1, normalizeStartCell + game.FirstPlayerMatrix.GetLength(0) + i + 3].Value = "Second player, strategy " + i.ToString();
                }

                for (int i = 0; i < result.MethodTrace.Count; i++)
                {
                    var situation = result.MethodTrace[i];

                    for (int j = 0; j < situation.FirstPlayerStrategy.Count(); j++)
                    {
                        ws.Cells[traceStartCellNumber + i, normalizeStartCell + j + 2].Value = situation.FirstPlayerStrategy[j];
                    }
                    for (int j = 0; j < situation.SecondPlayerStrategy.Count(); j++)
                    {
                        ws.Cells[traceStartCellNumber + i, normalizeStartCell + situation.FirstPlayerStrategy.Count() + j + 3].Value = situation.SecondPlayerStrategy[j];
                    }
                }
            }
        }

        public static void SaveToFile(ExperimentSourceBase experimentSource, IList<ExperimentSummary> summaries)
        {
            var fileName = string.Format("summary_{0}_{1}.xlsx", experimentSource.Name, DateTime.UtcNow.ToString("yyyy_MM_dd_hh_mm_ss_fff"));

            using (var package = new ExcelPackage(new FileInfo(fileName)))
            {
                var ws = package.Workbook.Worksheets.Add("ExperimentResult");

                ws.Cells[1, 1].Value = experimentSource.Name;

                ws.Cells[2, 1].Value = experimentSource.Description;
                                
                var parametersName = summaries[0].Experiment.Parameters.Keys.ToList();
                var cellX = 1;
                for (cellX = 1; cellX <= parametersName.Count; cellX++)
                {
                    ws.Cells[4, cellX].Value = parametersName[cellX];
                }

                var firstPlayerStratediesCount = summaries[0].Result.FirstPlayerStrategy.Count();                
                for (int i = 0; i < firstPlayerStratediesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("First player strategy {0}", i + 1);
                }

                cellX += firstPlayerStratediesCount;
                var secondPlayerStratediesCount = summaries[0].Result.SecondPlayerStrategy.Count();
                for (int i = 0; i < secondPlayerStratediesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("Second player strategy {0}", i + 1);
                }
                cellX += secondPlayerStratediesCount;

                for (int i = 0; i < firstPlayerStratediesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("First normalized player strategy {0}", i + 1);
                }

                cellX += firstPlayerStratediesCount;
                for (int i = 0; i < secondPlayerStratediesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("Second player normalized strategy {0}", i + 1);
                }
                                
                var cellY = 5;
                for (int experimentNumber = 0; experimentNumber < summaries.Count(); experimentNumber++)
                {
                    cellX = 1;       
                    var experiment = summaries[experimentNumber].Experiment;
                    var firstPlayerStrategy = summaries[experimentNumber].Result.FirstPlayerStrategy;
                    var secondPlayerStrategy = summaries[experimentNumber].Result.SecondPlayerStrategy;
                    var firstPlayerNormalizedStrategy = summaries[experimentNumber].Result.FirstPlayerStrategy.Normalize().ToList();
                    var secondPlayerNormalizedStrategy = summaries[experimentNumber].Result.SecondPlayerStrategy.Normalize().ToList();

                    for (cellX = 1; cellX <= parametersName.Count; cellX++)
                    {
                        ws.Cells[4, cellX].Value = experiment.Parameters[parametersName[cellX]];
                    }

                    for (int i = 0; i < firstPlayerStratediesCount; i++)
                    {
                        ws.Cells[4, cellX + i].Value = firstPlayerStrategy[i];
                    }

                    cellX += firstPlayerStratediesCount;
                    for (int i = 0; i < secondPlayerStratediesCount; i++)
                    {
                        ws.Cells[4, cellX + i].Value = secondPlayerStrategy[i];
                    }
                    cellX += secondPlayerStratediesCount;

                    for (int i = 0; i < firstPlayerStratediesCount; i++)
                    {
                        ws.Cells[4, cellX + i].Value = firstPlayerNormalizedStrategy[i];
                    }

                    cellX += firstPlayerStratediesCount;
                    for (int i = 0; i < secondPlayerStratediesCount; i++)
                    {
                        ws.Cells[4, cellX + i].Value = secondPlayerNormalizedStrategy[i];
                    }
                }
            }
        }
    }
}
