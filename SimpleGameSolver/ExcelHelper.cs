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
        public static void SaveToFile(FileInfo file, ExperimentPortion experiment, BrownMethodBase method, MethodResult result)
        {
            using (var package = new ExcelPackage(file))
            {
                var ws = package.Workbook.Worksheets.Add("ExperimentResult");

                ws.Cells[1, 1].Value = string.Format("Name: {0}", experiment.Name);
                ws.Cells[2, 1].Value = string.Format("Method: {0}", method.Name);

                ws.Cells[4, 1].Value = "parameters";
                for (int i = 0; i < experiment.Parameters.Count; i++)
                {
                    var key = experiment.Parameters.ElementAt(i).Key;
                    ws.Cells[5, i + 1].Value = key;
                    ws.Cells[6, i + 1].Value = experiment.Parameters[key];
                }

                ws.Cells[8, 1].Value = "first player";
                for (int i = 0; i < experiment.Game.FirstPlayerMatrix.RowCount; i++)
                {
                    for (int j = 0; j < experiment.Game.FirstPlayerMatrix.ColumnCount; j++)
                    {
                        ws.Cells[i + 9, j + 1].Value = experiment.Game.FirstPlayerMatrix[i, j];
                    }
                }

                ws.Cells[8, experiment.Game.FirstPlayerMatrix.ColumnCount + 2].Value = "second player";
                for (int i = 0; i < experiment.Game.SecondPlayerMatrix.RowCount; i++)
                {
                    for (int j = 0; j < experiment.Game.SecondPlayerMatrix.ColumnCount; j++)
                    {
                        ws.Cells[i + 9, j + experiment.Game.FirstPlayerMatrix.ColumnCount + 2].Value = experiment.Game.SecondPlayerMatrix[i, j];
                    }
                }

                var traceStartCellNumber = 9 + experiment.Game.FirstPlayerMatrix.RowCount + 4;
                ws.Cells[traceStartCellNumber - 2, 1].Value = "absolute";
                ws.Cells[traceStartCellNumber - 1, 1].Value = "#";
                var game = experiment.Game;
                for (int i = 0; i < game.FirstPlayerMatrix.RowCount; i++)
                {
                    ws.Cells[traceStartCellNumber - 1, i + 2].Value = "First player, strategy " + (i + 1).ToString();
                }
                for (int i = 0; i < game.FirstPlayerMatrix.ColumnCount; i++)
                {
                    ws.Cells[traceStartCellNumber - 1, game.FirstPlayerMatrix.RowCount + i + 3].Value = "Second player, strategy " + (i + 1).ToString();
                }

                for (int i = 0; i < result.MethodTrace.Count; i++)
                {
                    var situation = result.MethodTrace[i];

                    ws.Cells[traceStartCellNumber + i, 1].Value = i;

                    for (int j = 0; j < situation.FirstPlayerStrategy.Count(); j++)
                    {
                        ws.Cells[traceStartCellNumber + i, j + 2].Value = situation.FirstPlayerStrategy[j];
                    }
                    for (int j = 0; j < situation.SecondPlayerStrategy.Count(); j++)
                    {
                        ws.Cells[traceStartCellNumber + i, situation.FirstPlayerStrategy.Count() + j + 3].Value = situation.SecondPlayerStrategy[j];
                    }
                }

                var normalizeStartCell = game.FirstPlayerMatrix.RowCount + game.FirstPlayerMatrix.ColumnCount + 4;
                ws.Cells[traceStartCellNumber - 2, normalizeStartCell + 1].Value = "normalize";
                ws.Cells[traceStartCellNumber - 1, normalizeStartCell + 1].Value = "#";
                for (int i = 0; i < game.FirstPlayerMatrix.RowCount; i++)
                {
                    ws.Cells[traceStartCellNumber - 1, normalizeStartCell + i + 2].Value = "First player, strategy " + (i + 1).ToString();
                }
                for (int i = 0; i < game.FirstPlayerMatrix.ColumnCount; i++)
                {
                    ws.Cells[traceStartCellNumber - 1, normalizeStartCell + game.FirstPlayerMatrix.RowCount + i + 3].Value = "Second player, strategy " + (i + 1).ToString();
                }

                for (int i = 0; i < result.MethodTrace.Count; i++)
                {
                    var situation = result.MethodTrace[i];
                    var firstPlayerNormalizedStrategy = situation.FirstPlayerStrategy.Normalize().ToList();
                    var secondPlayerNormalizedStrategy = situation.SecondPlayerStrategy.Normalize().ToList();

                    ws.Cells[traceStartCellNumber + i, normalizeStartCell + 1].Value = i;

                    for (int j = 0; j < situation.FirstPlayerStrategy.Count(); j++)
                    {
                        ws.Cells[traceStartCellNumber + i, normalizeStartCell + j + 2].Value = firstPlayerNormalizedStrategy[j];
                    }
                    for (int j = 0; j < situation.SecondPlayerStrategy.Count(); j++)
                    {
                        ws.Cells[traceStartCellNumber + i, normalizeStartCell + situation.FirstPlayerStrategy.Count() + j + 3].Value = secondPlayerNormalizedStrategy[j];
                    }
                }

                package.Save();
            }
        }

        public static void SaveToFile(FileInfo file, Experiment experimentSource, BrownMethodBase method, IList<ExperimentPortionSummary> summaries)
        {
            using (var package = new ExcelPackage(file))
            {
                var ws = package.Workbook.Worksheets.Add("ExperimentsResult");

                ws.Cells[1, 1].Value = string.Format("Name: {0}", experimentSource.Name);

                ws.Cells[2, 1].Value = string.Format("Description: {0}", experimentSource.Description);

                ws.Cells[3, 1].Value = string.Format("Method: {0}", method.Name);

                var parametersName = summaries[0].Experiment.Parameters.Keys.ToList();
                var cellX = 1;
                for (cellX = 1; cellX <= parametersName.Count; cellX++)
                {
                    ws.Cells[4, cellX].Value = parametersName[cellX - 1];
                }

                var firstPlayerStrategiesCount = summaries[0].Result.FirstPlayerStrategy.Count();
                var secondPlayerStrategiesCount = summaries[0].Result.SecondPlayerStrategy.Count();

                for (int i = 0; i < firstPlayerStrategiesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("First player start position strategy {0}", i + 1);
                }
                cellX += firstPlayerStrategiesCount;

                for (int i = 0; i < secondPlayerStrategiesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("Second player start position strategy {0}", i + 1);
                }
                cellX += secondPlayerStrategiesCount;

                for (int i = 0; i < firstPlayerStrategiesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("First player strategy {0}", i + 1);
                }
                cellX += firstPlayerStrategiesCount;

                for (int i = 0; i < secondPlayerStrategiesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("Second player strategy {0}", i + 1);
                }
                cellX += secondPlayerStrategiesCount;

                for (int i = 0; i < firstPlayerStrategiesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("First normalized player strategy {0}", i + 1);
                }
                cellX += firstPlayerStrategiesCount;

                for (int i = 0; i < secondPlayerStrategiesCount; i++)
                {
                    ws.Cells[4, cellX + i].Value = string.Format("Second player normalized strategy {0}", i + 1);
                }
                cellX += secondPlayerStrategiesCount;

                ws.Cells[4, cellX].Value = string.Format("payoff of first player");
                cellX++;

                ws.Cells[4, cellX].Value = string.Format("payoff of second player");
                cellX++;

                ws.Cells[4, cellX].Value = string.Format("v1(k)");
                cellX++;

                ws.Cells[4, cellX].Value = string.Format("v2(k)");
                cellX++;

                var cellY = 5;
                for (int experimentNumber = 0; experimentNumber < summaries.Count(); experimentNumber++)
                {
                    cellX = 1;
                    var experiment = summaries[experimentNumber].Experiment;
                    var firstPlayerStrategy = summaries[experimentNumber].Result.FirstPlayerStrategy;
                    var secondPlayerStrategy = summaries[experimentNumber].Result.SecondPlayerStrategy;
                    var firstPlayerNormalizedStrategy = summaries[experimentNumber].Result.FirstPlayerStrategy.Normalize().ToList();
                    var secondPlayerNormalizedStrategy = summaries[experimentNumber].Result.SecondPlayerStrategy.Normalize().ToList();
                    var firstPlayerStartStrategy = summaries[experimentNumber].Experiment.StartSituation.FirstPlayerStrategy;
                    var secondPlayerStartStrategy = summaries[experimentNumber].Experiment.StartSituation.SecondPlayerStrategy;

                    for (cellX = 1; cellX <= parametersName.Count; cellX++)
                    {
                        ws.Cells[cellY, cellX].Value = experiment.Parameters[parametersName[cellX - 1]];
                    }

                    for (int i = 0; i < firstPlayerStrategiesCount; i++)
                    {
                        ws.Cells[cellY, cellX + i].Value = firstPlayerStartStrategy[i];
                    }
                    cellX += firstPlayerStrategiesCount;

                    for (int i = 0; i < secondPlayerStrategiesCount; i++)
                    {
                        ws.Cells[cellY, cellX + i].Value = secondPlayerStartStrategy[i];
                    }
                    cellX += secondPlayerStrategiesCount;

                    for (int i = 0; i < firstPlayerStrategiesCount; i++)
                    {
                        ws.Cells[cellY, cellX + i].Value = firstPlayerStrategy[i];
                    }
                    cellX += firstPlayerStrategiesCount;

                    for (int i = 0; i < secondPlayerStrategiesCount; i++)
                    {
                        ws.Cells[cellY, cellX + i].Value = secondPlayerStrategy[i];
                    }
                    cellX += secondPlayerStrategiesCount;

                    for (int i = 0; i < firstPlayerStrategiesCount; i++)
                    {
                        ws.Cells[cellY, cellX + i].Value = firstPlayerNormalizedStrategy[i];
                    }
                    cellX += firstPlayerStrategiesCount;

                    for (int i = 0; i < secondPlayerStrategiesCount; i++)
                    {
                        ws.Cells[cellY, cellX + i].Value = secondPlayerNormalizedStrategy[i];
                    }
                    cellX += secondPlayerStrategiesCount;

                    ws.Cells[cellY, cellX].Value = summaries[experimentNumber].FirstPlayerPayoff;
                    cellX++;

                    ws.Cells[cellY, cellX].Value = summaries[experimentNumber].SecondPlayerPayoff;
                    cellX++;

                    ws.Cells[cellY, cellX].Value = summaries[experimentNumber].V1k;
                    cellX++;

                    ws.Cells[cellY, cellX].Value = summaries[experimentNumber].V2k;
                    cellX++;

                    cellY++;
                }

                package.Save();
            }
        }
    }
}
