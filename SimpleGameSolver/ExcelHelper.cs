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
    }
}
