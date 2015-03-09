using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleGameSolver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            FirstPlayerMatrix.ColumnCount = 3;
            FirstPlayerMatrix.RowCount = 3;
            SecondPlayerMatrix.ColumnCount = 3;
            SecondPlayerMatrix.RowCount = 3;

            FirstPlayerStartPosition.RowCount = 1;
            SecondPlayerStartPosition.RowCount = 1;
            FirstPlayerStartPosition.ColumnCount = 3;
            SecondPlayerStartPosition.ColumnCount = 3;

            methodList.Items.Add(new BrownMethodClassic());
            methodList.Items.Add(new BrownMethodExp());
            methodList.Items.Add(new BrownMethodExp2());
            methodList.Items.Add(new BrownMethodSupExp());
            methodList.DisplayMember = "Name";
            methodList.ValueMember = "Name";
            methodList.SelectedIndex = 0;

            experimentList.Items.Add(new BordersRotationExperimentSource());
            experimentList.Items.Add(new DoctrinesGameExperimentSource());
            experimentList.Items.Add(new StepIncreaseCoefficientExperimentSource());
            experimentList.Items.Add(new FirstPlayerOneBRBorderRotationAndIncreaseStepExperimentSource());
            experimentList.DisplayMember = "Name";
            experimentList.ValueMember = "Name";
            experimentList.SelectedIndex = 0;
        }

        private void FirstPlayerStrategesCount_ValueChanged(object sender, EventArgs e)
        {
            FirstPlayerMatrix.RowCount = Convert.ToInt32(FirstPlayerStrategesCount.Value);
            SecondPlayerMatrix.RowCount = Convert.ToInt32(FirstPlayerStrategesCount.Value);
            FirstPlayerStartPosition.ColumnCount = Convert.ToInt32(FirstPlayerStrategesCount.Value);
        }

        private void SecondPlayerStrategesCount_ValueChanged(object sender, EventArgs e)
        {
            FirstPlayerMatrix.ColumnCount = Convert.ToInt32(SecondPlayerStrategesCount.Value);
            SecondPlayerMatrix.ColumnCount = Convert.ToInt32(SecondPlayerStrategesCount.Value);
            SecondPlayerStartPosition.ColumnCount = Convert.ToInt32(SecondPlayerStrategesCount.Value);
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int m = Convert.ToInt32(FirstPlayerStrategesCount.Value);
                int n = Convert.ToInt32(SecondPlayerStrategesCount.Value);
                int iterationCount = Convert.ToInt32(IterationCount.Value);
                double[,] A = new double[m, n];
                double[,] B = new double[m, n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        A.SetValue(Convert.ToDouble(FirstPlayerMatrix.Rows[i].Cells[j].Value), i, j);
                        B.SetValue(Convert.ToDouble(SecondPlayerMatrix.Rows[i].Cells[j].Value), i, j);
                    }
                }

                List<ulong> fpStartPosition = new List<ulong>();
                for (int j = 0; j < m; j++)
                {
                    fpStartPosition.Add(Convert.ToUInt64(FirstPlayerStartPosition.Rows[0].Cells[j].Value));
                }

                List<ulong> spStartPosition = new List<ulong>();
                for (int j = 0; j < n; j++)
                {
                    spStartPosition.Add(Convert.ToUInt64(SecondPlayerStartPosition.Rows[0].Cells[j].Value));
                }

                BrownMethodBase method = (BrownMethodBase)methodList.SelectedItem;

                var parameters = new Dictionary<string, string>() {{"iterationsCount", iterationCount.ToString()}};
                var result = method.Solve(new BimatrixGame(A, B), new Situation(fpStartPosition, spStartPosition), parameters);

                // show results
                FirstPlayerSolve.RowCount = 1;
                FirstPlayerSolve.ColumnCount = m;

                SecondPlayerSolve.RowCount = 1;
                SecondPlayerSolve.ColumnCount = n;

                var normalize = result.Result.FirstPlayerStrategy.Normalize().ToList();
                for (int i = 0; i < FirstPlayerSolve.ColumnCount; i++)
                {
                    FirstPlayerSolve.Rows[0].Cells[i].Value = normalize[i];
                }

                normalize = result.Result.SecondPlayerStrategy.Normalize().ToList();
                for (int i = 0; i < SecondPlayerSolve.ColumnCount; i++)
                {
                    SecondPlayerSolve.Rows[0].Cells[i].Value = normalize[i];
                }

                // fill tables
                firstPlayerSolveTable.RowCount = result.MethodTrace.Count();
                firstPlayerSolveTable.ColumnCount = m;
                secondPlayerSolveTable.RowCount = result.MethodTrace.Count();
                secondPlayerSolveTable.ColumnCount = n;

                for (int j = 0; j < m; j++)
                {
                    firstPlayerSolveTable.Columns[j].HeaderCell.Value = string.Format("Стратегия {0}", j + 1);
                }

                for (int j = 0; j < n; j++)
                {
                    secondPlayerSolveTable.Columns[j].HeaderCell.Value = string.Format("Стратегия {0}", j + 1);
                }

                for (int i = 0; i < result.MethodTrace.Count(); i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        firstPlayerSolveTable.Rows[i].Cells[j].Value = result.MethodTrace[i].FirstPlayerStrategy[j];
                        firstPlayerSolveTable.Rows[i].HeaderCell.Value = i.ToString();
                    }

                    for (int j = 0; j < n; j++)
                    {
                        secondPlayerSolveTable.Rows[i].Cells[j].Value = result.MethodTrace[i].SecondPlayerStrategy[j];
                        secondPlayerSolveTable.Rows[i].HeaderCell.Value = i.ToString();
                    }
                }

                // draw frequerency
                chart1.Series.Clear();
                chart2.Series.Clear();

                chart1.ChartAreas[0].AxisY.Maximum = 1;
                chart2.ChartAreas[0].AxisY.Maximum = 1;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart2.ChartAreas[0].AxisY.Minimum = 0;

                chart1.ChartAreas[0].AxisX.Minimum = 1;
                chart2.ChartAreas[0].AxisX.Minimum = 1;
                chart1.ChartAreas[0].AxisX.Maximum = result.MethodTrace.Count();
                chart2.ChartAreas[0].AxisX.Maximum = result.MethodTrace.Count();

                for (int j = 0; j < m; j++)
                {
                    chart1.Series.Add("Стратегия " + (j + 1).ToString());
                    chart1.Series[j].ChartType =
                        System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series[j].BorderWidth = 2;
                }

                for (int j = 0; j < n; j++)
                {
                    chart2.Series.Add("Стратегия " + (j + 1).ToString());
                    chart2.Series[j].ChartType =
                        System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart2.Series[j].BorderWidth = 2;
                }

                for (int i = 0; i < result.MethodTrace.Count(); i++)
                {
                    normalize = result.MethodTrace[i].FirstPlayerStrategy.Normalize().ToList();
                    for (int j = 0; j < m; j++)
                    {
                        chart1.Series[j].Points.AddXY(i + 1, normalize[j]);
                    }
                    normalize = result.MethodTrace[i].SecondPlayerStrategy.Normalize().ToList();
                    for (int j = 0; j < n; j++)
                    {
                        chart2.Series[j].Points.AddXY(i + 1, normalize[j]);
                    }
                }
            }
            catch (FormatException err)
            {
                // Initializes the variables to pass to the MessageBox::Show method.
                String message = "Во время ввода данных были введены неправильные значения.";
                String caption = "Ввод неправильных данных";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                // Displays the MessageBox.
                MessageBox.Show(this, message, caption, buttons);
            }
        }

        private void ExecuteExperiment_Click(object sender, EventArgs e)
        {
            var experimentSource = (ExperimentSourceBase)experimentList.SelectedItem;
            var method = (BrownMethodBase)methodList.SelectedItem;

            var experimentator = new Experimentator(experimentSource, method, experimentProgressBar);

            experimentator.MakeExperiment();
        }
    }
}
