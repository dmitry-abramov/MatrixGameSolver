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

                BrownMethodBase method = new BrownMethodClassic();

                if (comboBox1.SelectedIndex == 0) method = new BrownMethodClassic();
                else if (comboBox1.SelectedIndex == 1) method = new BrownMethodExp();
                else if (comboBox1.SelectedIndex == 2) method = new BrownMethodExp2();
                else if (comboBox1.SelectedIndex == 3) method = new BrownMethodSupExp();

                var result = method.Solve(A, B, fpStartPosition, spStartPosition, iterationCount);

                // show results
                FirstPlayerSolve.RowCount = 1;
                FirstPlayerSolve.ColumnCount = m;

                SecondPlayerSolve.RowCount = 1;
                SecondPlayerSolve.ColumnCount = n;

                var tmp = result.Last().ElementAt(0);
                double normalize = tmp.Select(u => Convert.ToDouble(u)).Sum();
                for (int i = 0; i < FirstPlayerSolve.ColumnCount; i++)
                {
                    FirstPlayerSolve.Rows[0].Cells[i].Value = (double)result.Last()[0][i] / normalize;
                }
                tmp = result.Last().ElementAt(1);
                normalize = tmp.Select(u => Convert.ToDouble(u)).Sum();
                for (int i = 0; i < SecondPlayerSolve.ColumnCount; i++)
                {
                    SecondPlayerSolve.Rows[0].Cells[i].Value = (double)result.Last()[1][i] / normalize;
                }

                // fill tables
                firstPlayerSolveTable.RowCount = result.Count;
                firstPlayerSolveTable.ColumnCount = m;
                secondPlayerSolveTable.RowCount = result.Count;
                secondPlayerSolveTable.ColumnCount = n;

                for (int j = 0; j < result[0][0].Count; j++)
                {
                    firstPlayerSolveTable.Columns[j].HeaderCell.Value = string.Format("Стратегия {0}", j + 1);
                }

                for (int j = 0; j < result[0][1].Count; j++)
                {
                    secondPlayerSolveTable.Columns[j].HeaderCell.Value = string.Format("Стратегия {0}", j + 1);
                }

                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 0; j < result[i][0].Count; j++)
                    {
                        firstPlayerSolveTable.Rows[i].Cells[j].Value = result[i][0][j];
                        firstPlayerSolveTable.Rows[i].HeaderCell.Value = i.ToString();
                    }

                    for (int j = 0; j < result[i][1].Count; j++)
                    {
                        secondPlayerSolveTable.Rows[i].Cells[j].Value = result[i][1][j];
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
                chart1.ChartAreas[0].AxisX.Maximum = result.Count;
                chart2.ChartAreas[0].AxisX.Maximum = result.Count;

                for (int j = 0; j < result.Last()[0].Count; j++)
                {
                    chart1.Series.Add("Стратегия " + (j + 1).ToString());
                    chart1.Series[j].ChartType =
                        System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series[j].BorderWidth = 2;
                }

                for (int j = 0; j < result.Last()[1].Count; j++)
                {
                    chart2.Series.Add("Стратегия " + (j + 1).ToString());
                    chart2.Series[j].ChartType =
                        System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart2.Series[j].BorderWidth = 2;
                }

                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 0; j < result[i][0].Count; j++)
                    {
                        tmp = result[i].ElementAt(0);
                        normalize = tmp.Select(u => Convert.ToDouble(u)).Sum();
                        chart1.Series[j].Points.AddXY(i + 1, (double)result[i][0][j] / normalize);
                    }
                    for (int j = 0; j < result[i][1].Count; j++)
                    {
                        tmp = result[i].ElementAt(1);
                        normalize = tmp.Select(u => Convert.ToDouble(u)).Sum();
                        chart2.Series[j].Points.AddXY(i + 1, (double)result[i][1][j] / normalize);
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


    }
}
