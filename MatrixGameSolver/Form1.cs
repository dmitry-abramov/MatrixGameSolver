using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MatrixGameSolver
{
    public partial class MatrixGameSolverMainForm : Form
    {
        BiMatrixGame game;

        public MatrixGameSolverMainForm()
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

            SolveInformation.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left)));
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

        private void SolveCurrentGame_Click(object sender, EventArgs e)
        {
            try
            {
                int m = Convert.ToInt32(FirstPlayerStrategesCount.Value);
                int n = Convert.ToInt32(SecondPlayerStrategesCount.Value);
                doubleMatrix A = new doubleMatrix(m, n);
                doubleMatrix B = new doubleMatrix(m, n);

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        A.SetValue(Convert.ToDouble(FirstPlayerMatrix.Rows[i].Cells[j].Value), i, j);
                        B.SetValue(Convert.ToDouble(SecondPlayerMatrix.Rows[i].Cells[j].Value), i, j);
                    }
                }

                List<double> f = new List<double>();
                for (int j = 0; j < m; j++)
                {
                    f.Add( Convert.ToDouble(FirstPlayerStartPosition.Rows[0].Cells[j].Value) );
                }

                List<double> s = new List<double>();
                for (int j = 0; j < n; j++)
                {
                    s.Add( Convert.ToDouble(SecondPlayerStartPosition.Rows[0].Cells[j].Value) );
                }

                StartPosition start = 
                    new MatrixGameSolver.StartPosition( new MixedStrategy(f), new MixedStrategy(s), 
                                                        (int)StartPositionWeight.Value);

                game = new BiMatrixGame(A, B);
                BrownMethod method = new BrownMethod(progress);
                game.solve = method.solve(game, start,Convert.ToInt32(IterationCount.Value));

                ShowSolve();
                ShowTriangle(FirstPlayerGraphics, SecondPlayerGraphics);
                ShowGraphics(game.solve, "", FirstPlayerGraphics, SecondPlayerGraphics);
                ShowFeqencity(game.solve, "", FirstPlayerFeqencity, SecondPlayerFeqencity);
            }
            catch(FormatException err)
            {
                // Initializes the variables to pass to the MessageBox::Show method.
				String message = "Во время ввода данных были введены неправильные значения.";
				String caption = "Ввод неправильных данных";
				MessageBoxButtons buttons = MessageBoxButtons.OK;				

				// Displays the MessageBox.
				MessageBox.Show( this, message, caption, buttons );				
            }
        }

        private void ShowSolve()
        {
            FirstPlayerSolve.RowCount = 1;
            FirstPlayerSolve.ColumnCount = game.solve.firstPlayerSolve.Count;
            SecondPlayerSolve.RowCount = 1;
            SecondPlayerSolve.ColumnCount = game.solve.secondPlayerSolve.Count;

            for (int i = 0; i < FirstPlayerSolve.ColumnCount; i++)
            {
                FirstPlayerSolve.Rows[0].Cells[i].Value = game.solve.firstPlayerSolve[i].ToString();
            }
            for (int i = 0; i < FirstPlayerSolve.ColumnCount; i++)
            {
                SecondPlayerSolve.Rows[0].Cells[i].Value = game.solve.secondPlayerSolve[i].ToString();
            }

            firstPlayerSolveTable.RowCount = game.solve.table.Count;
            firstPlayerSolveTable.ColumnCount = game.GetFirstPlayerStrategyCount() + 1;
            secondPlayerSolveTable.RowCount = game.solve.table.Count;
            secondPlayerSolveTable.ColumnCount = game.GetSecondPlayerStrategyCount() + 1;

            List<int> tmp = new List<int>();
            for (int i = 0; i < firstPlayerSolveTable.ColumnCount + secondPlayerSolveTable.ColumnCount - 2; i++)
                tmp.Add(0);
            for (int i = 0; i < firstPlayerSolveTable.RowCount && i < secondPlayerSolveTable.RowCount; i++)
            {
                tmp[game.solve.table[i].firstPlayerChoiceField]++;
                tmp[game.GetFirstPlayerStrategyCount() + game.solve.table[i].secondPlayerChoiceField]++;

                double firstPlayerPrize = 0;
                double secondPlayerPrize = 0;
                for (int k = 0; k < game.GetFirstPlayerStrategyCount(); k++)
                {
                    for (int j = 0; j < game.GetSecondPlayerStrategyCount(); j++)
                    {
                        firstPlayerPrize += game.firstPlayerMatrix.GetValue(k, j) * tmp[k] * tmp[game.GetFirstPlayerStrategyCount() + j] / ((i+1) * (i+1));
                        secondPlayerPrize += game.secondPlayerMatrix.GetValue(k, j) * tmp[k] * tmp[game.GetFirstPlayerStrategyCount() + j] / ((i + 1) * (i + 1));
                    }                    
                }

                firstPlayerSolveTable.Rows[i].HeaderCell.Value = i.ToString();
                for (int j = 0; j < firstPlayerSolveTable.ColumnCount - 1; j++)
                {                    
                    firstPlayerSolveTable.Rows[i].Cells[j].Value = tmp[j].ToString();
                }
                firstPlayerSolveTable.Rows[i].Cells[game.GetFirstPlayerStrategyCount()].Value = firstPlayerPrize.ToString();

                secondPlayerSolveTable.Rows[i].HeaderCell.Value = i.ToString();
                for (int j = 0; j < secondPlayerSolveTable.ColumnCount - 1; j++)
                {                    
                    secondPlayerSolveTable.Rows[i].Cells[j].Value = tmp[j + 3].ToString();
                }
                secondPlayerSolveTable.Rows[i].Cells[game.GetSecondPlayerStrategyCount()].Value = secondPlayerPrize.ToString();
            }
        }

        private void ShowGraphics()
        {
            int h = 100;
            double sqrt3 = 1.7;

            FirstPlayerGraphics.ChartAreas[0].AxisX.Minimum = -1;
            FirstPlayerGraphics.ChartAreas[0].AxisY.Minimum = -1;
            FirstPlayerGraphics.ChartAreas[0].AxisY.Maximum = h+1;
            FirstPlayerGraphics.ChartAreas[0].AxisX.Maximum = h * 2 / sqrt3 + 1;
            FirstPlayerGraphics.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            FirstPlayerGraphics.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            SecondPlayerGraphics.ChartAreas[0].AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            SecondPlayerGraphics.ChartAreas[0].AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;

            FirstPlayerGraphics.Series.Clear();
            FirstPlayerGraphics.Series.Add("First player graphic");
            FirstPlayerGraphics.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            FirstPlayerGraphics.Series[0].BorderWidth = 2;
            FirstPlayerGraphics.Series[0].MarkerSize = 10;

            FirstPlayerGraphics.Series.Add("Triangle");
            FirstPlayerGraphics.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            FirstPlayerGraphics.Series[1].BorderWidth = 1;
            FirstPlayerGraphics.Series[1].Points.AddXY(0, 0);
            FirstPlayerGraphics.Series[1].Points.AddXY(h*2/sqrt3, 0);
            FirstPlayerGraphics.Series[1].Points.AddXY(h/sqrt3, h);
            FirstPlayerGraphics.Series[1].Points.AddXY(0, 0);

            SecondPlayerGraphics.ChartAreas[0].AxisX.Minimum = -1;
            SecondPlayerGraphics.ChartAreas[0].AxisY.Minimum = -1;
            SecondPlayerGraphics.ChartAreas[0].AxisY.Maximum = h + 1;
            SecondPlayerGraphics.ChartAreas[0].AxisX.Maximum = h * 2 / sqrt3 + 1;
            
            SecondPlayerGraphics.Series.Clear();
            SecondPlayerGraphics.Series.Add("Second player graphic");
            SecondPlayerGraphics.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            SecondPlayerGraphics.Series[0].BorderWidth = 2;
            SecondPlayerGraphics.Series[0].MarkerSize = 1000;
            
            SecondPlayerGraphics.Series.Add("Triangle");
            SecondPlayerGraphics.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            SecondPlayerGraphics.Series[1].BorderWidth = 1;
            SecondPlayerGraphics.Series[1].Points.AddXY(0, 0);
            SecondPlayerGraphics.Series[1].Points.AddXY(h * 2 / sqrt3, 0);
            SecondPlayerGraphics.Series[1].Points.AddXY(h / sqrt3, h);
            SecondPlayerGraphics.Series[1].Points.AddXY(0, 0);

            double x = 0;
            double y = 0;

            progress.Value = 0;
            
            for (int i = 0; i < game.solve.table.Count; i++)
            {
                List<double> s1 = new List<double>();
                List<double> s2 = new List<double>();
                for (int k = 0; k < 3; k++)
			    {
                    s1.Add(0); s2.Add(0);			 
			    }
                //take solve on i step
                for (int j = 0; j < i+1; j++)
                {
                    s1[ game.solve.table[j].firstPlayerChoiceField ]++;
                    s2[ game.solve.table[j].secondPlayerChoiceField ]++;
                }
                for (int j = 0; j < 3; j++)
                {
                    s1[j] /= (i+1); 
                    s2[j] /= (i+1);
                }
                //take coord of i step
                x = s1[0] * 0 + s1[1] * h / sqrt3 + s1[2] * h * 2 / sqrt3;
                y = s1[0] * 0 + s1[1] * h + s1[2] * 0;
                FirstPlayerGraphics.Series[0].Points.AddXY(x, y);

                x = s2[0] * 0 + s2[1] * h / sqrt3 + s2[2] * h * 2 / sqrt3;
                y = s2[0] * 0 + s2[1] * h + s2[2] * 0;
                SecondPlayerGraphics.Series[0].Points.AddXY(x, y);
                progress.Value++;
            }           
 
            makeScreenShot("test");
        }

        public void makeScreenShot(string name)
        {            
            Bitmap bmpScr = new Bitmap(FirstPlayerGraphics.Size.Width, FirstPlayerGraphics.Size.Height, System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            Graphics gr = Graphics.FromImage(bmpScr);

            gr.CopyFromScreen(Location.X + SolveInformation.Location.X + FirstPlayerGraphics.Location.X + 10, Location.Y + SolveInformation.Location.Y + FirstPlayerGraphics.Location.Y + 55, 0, 0, FirstPlayerGraphics.Size, CopyPixelOperation.SourceCopy);
            bmpScr.Save(name + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void ParametrSolve_Click(object sender, EventArgs e)
        {
            try
            {
                double param = Convert.ToDouble(Parametr.Text);

                doubleMatrix A = new doubleMatrix(3, 3);
                doubleMatrix B = new doubleMatrix(3, 3);

                A.SetValue(param * 0 + (1 - param) * 0, 0, 0);
                A.SetValue(param * 1 + (1 - param) * 1, 0, 1);
                A.SetValue(param * (-1) + (1 - param) * 1, 0, 2);

                A.SetValue(param * (-1) + (1 - param) * 1, 1, 0);
                A.SetValue(param * 0 + (1 - param) * 0, 1, 1);
                A.SetValue(param * 1 + (1 - param) * 1, 1, 2);

                A.SetValue(param * 1 + (1 - param) * 1, 2, 0);
                A.SetValue(param * (-1) + (1 - param) * 1, 2, 1);
                A.SetValue(param * 0 + (1 - param) * 0, 2, 2);

                B.SetValue(param * 0 + (1 - param) * 0, 0, 0);
                B.SetValue(param * (-1) + (1 - param) * 1, 0, 1);
                B.SetValue(param * 1 + (1 - param) * 1, 0, 2);

                B.SetValue(param * 1 + (1 - param) * 1, 1, 0);
                B.SetValue(param * 0 + (1 - param) * 0, 1, 1);
                B.SetValue(param * (-1) + (1 - param) * 1, 1, 2);

                B.SetValue(param * (-1) + (1 - param) * 1, 2, 0);
                B.SetValue(param * 1 + (1 - param) * 1, 2, 1);
                B.SetValue(param * 0 + (1 - param) * 0, 2, 2);

                FirstPlayerMatrix.Rows.Clear();
                FirstPlayerMatrix.RowCount = 3;
                FirstPlayerMatrix.ColumnCount = 3;
                SecondPlayerMatrix.Rows.Clear();
                SecondPlayerMatrix.RowCount = 3;
                SecondPlayerMatrix.ColumnCount = 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        FirstPlayerMatrix.Rows[i].Cells[j].Value = A.GetValue(i, j).ToString();
                        SecondPlayerMatrix.Rows[i].Cells[j].Value = B.GetValue(i, j).ToString();
                    }
                }

                game = new BiMatrixGame(A, B);
                BrownMethod method = new BrownMethod(progress);
                
                //задание начального приближения
                List<double> f = new List<double>();
                for (int j = 0; j < game.GetFirstPlayerStrategyCount(); j++)
                {
                    f.Add(Convert.ToDouble(FirstPlayerStartPosition.Rows[0].Cells[j].Value));
                }

                List<double> s = new List<double>();
                for (int j = 0; j < game.GetSecondPlayerStrategyCount(); j++)
                {
                    s.Add(Convert.ToDouble(SecondPlayerStartPosition.Rows[0].Cells[j].Value));
                }

                StartPosition start =
                    new MatrixGameSolver.StartPosition(new MixedStrategy(f), new MixedStrategy(s),
                                                        (int)StartPositionWeight.Value);

                game.solve = method.solve(game, start, Convert.ToInt32(IterationCount.Value));

                ShowSolve();
                ShowTriangle(FirstPlayerGraphics, SecondPlayerGraphics);
                ShowGraphics(game.solve, "", FirstPlayerGraphics, SecondPlayerGraphics);
                ShowFeqencity(game.solve, "", FirstPlayerFeqencity, SecondPlayerFeqencity);

                BiMatrixGameSolve Solve = method.solveCenter(game, Convert.ToInt32(IterationCount.Value));
                ShowGraphics(Solve, "Center", FirstPlayerGraphics, SecondPlayerGraphics);
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

        private void ShowTriangle(System.Windows.Forms.DataVisualization.Charting.Chart firstPlayer,
            System.Windows.Forms.DataVisualization.Charting.Chart secondPlayer)
        {
            int h = 100;
            double sqrt3 = 1.7;

            firstPlayer.ChartAreas[0].AxisX.Enabled = 
                System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            secondPlayer.ChartAreas[0].AxisX.Enabled = 
                System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            firstPlayer.ChartAreas[0].AxisY.Enabled =
                System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            secondPlayer.ChartAreas[0].AxisY.Enabled =
                System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;

            firstPlayer.ChartAreas[0].AxisX.Minimum = -1;
            secondPlayer.ChartAreas[0].AxisX.Minimum = -1;
            firstPlayer.ChartAreas[0].AxisY.Minimum = -1;
            secondPlayer.ChartAreas[0].AxisY.Minimum = -1;

            firstPlayer.ChartAreas[0].AxisX.Maximum = h * 2 / sqrt3 + 1;
            secondPlayer.ChartAreas[0].AxisX.Maximum = h * 2 / sqrt3 + 1;
            firstPlayer.ChartAreas[0].AxisY.Maximum = h + 1;
            secondPlayer.ChartAreas[0].AxisY.Maximum = h + 1;

            firstPlayer.Series.Clear();
            firstPlayer.Series.Add("Triangle");
            firstPlayer.Series[0].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            firstPlayer.Series[0].BorderWidth = 1;
            firstPlayer.Series[0].Points.AddXY(0, 0);
            firstPlayer.Series[0].Points.AddXY(h * 2 / sqrt3, 0);
            firstPlayer.Series[0].Points.AddXY(h / sqrt3, h);
            firstPlayer.Series[0].Points.AddXY(0, 0);

            secondPlayer.Series.Clear();
            secondPlayer.Series.Add("Triangle");
            secondPlayer.Series[0].ChartType = 
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            secondPlayer.Series[0].BorderWidth = 1;
            secondPlayer.Series[0].Points.AddXY(0, 0);
            secondPlayer.Series[0].Points.AddXY(h * 2 / sqrt3, 0);
            secondPlayer.Series[0].Points.AddXY(h / sqrt3, h);
            secondPlayer.Series[0].Points.AddXY(0, 0);
        }

        private void ShowFeqencity(BiMatrixGameSolve solve,
            string solveName,
            System.Windows.Forms.DataVisualization.Charting.Chart firstPlayer,
            System.Windows.Forms.DataVisualization.Charting.Chart secondPlayer)
        {
            firstPlayer.Series.Clear();
            secondPlayer.Series.Clear();

            //firstPlayer.Series.Add("Частоты стратегий первого игрока");
            //secondPlayer.Series.Add("Частоты стратегий второго игрока");

            firstPlayer.ChartAreas[0].AxisY.Maximum = 1;
            secondPlayer.ChartAreas[0].AxisY.Maximum = 1;
            firstPlayer.ChartAreas[0].AxisY.Minimum = 0;
            secondPlayer.ChartAreas[0].AxisY.Minimum = 0;

            firstPlayer.ChartAreas[0].AxisX.Minimum = 1;
            secondPlayer.ChartAreas[0].AxisX.Minimum = 1;
            firstPlayer.ChartAreas[0].AxisX.Maximum = solve.table.Count;
            secondPlayer.ChartAreas[0].AxisX.Maximum = solve.table.Count;

            for (int j = 0; j < solve.firstPlayerSolve.Count; j++)
            {
                firstPlayer.Series.Add("Стратегия " + j.ToString());
                firstPlayer.Series[j].ChartType = 
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                firstPlayer.Series[j].BorderWidth = 2;
            }

            for (int j = 0; j < solve.secondPlayerSolve.Count; j++)
            {
                secondPlayer.Series.Add("Стратегия " + j.ToString());
                secondPlayer.Series[j].ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                secondPlayer.Series[j].BorderWidth = 2;
            }

            for (int i = 0; i < solve.table.Count; i++)
            {
                for (int j = 0; j < solve.firstPlayerSolve.Count; j++)
                    firstPlayer.Series[j].Points.AddXY(i+1, solve.firstPlayerSolveOnStep(i)[j]);

                for (int j = 0; j < solve.secondPlayerSolve.Count; j++)
                    secondPlayer.Series[j].Points.AddXY(i+1, solve.secondPlayerSolveOnStep(i)[j]);
            }
        }

        private void ShowGraphics(BiMatrixGameSolve solve, 
            string solveName, 
            System.Windows.Forms.DataVisualization.Charting.Chart firstPlayer,
            System.Windows.Forms.DataVisualization.Charting.Chart secondPlayer)
        {
            firstPlayer.Series.Add("First player graphic of solve" + solveName);
            firstPlayer.Series[firstPlayer.Series.Count-1].ChartType = 
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            firstPlayer.Series[firstPlayer.Series.Count - 1].BorderWidth = 2;
            firstPlayer.Series[firstPlayer.Series.Count - 1].MarkerSize = 10;

            secondPlayer.Series.Add("Second player graphic of solve" + solveName);
            secondPlayer.Series[secondPlayer.Series.Count - 1].ChartType = 
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            secondPlayer.Series[secondPlayer.Series.Count - 1].BorderWidth = 2;
            secondPlayer.Series[secondPlayer.Series.Count - 1].MarkerSize = 10;

            double x = 0;
            double y = 0;
            int h = 100;
            double sqrt3 = 1.7;
            progress.Value = 0;
                        
            for (int i = 0; i < solve.table.Count; i++)
            {
                MixedStrategy s1;
                MixedStrategy s2; 
                
                //take solve on i step
                s1 = solve.firstPlayerSolveOnStep(i);
                s2 = solve.secondPlayerSolveOnStep(i);
                                
                //take coord of i step
                x = s1[0] * 0 + s1[1] * h / sqrt3 + s1[2] * h * 2 / sqrt3;
                y = s1[0] * 0 + s1[1] * h + s1[2] * 0;
                FirstPlayerGraphics.Series[firstPlayer.Series.Count - 1].Points.AddXY(x, y);

                x = s2[0] * 0 + s2[1] * h / sqrt3 + s2[2] * h * 2 / sqrt3;
                y = s2[0] * 0 + s2[1] * h + s2[2] * 0;
                SecondPlayerGraphics.Series[secondPlayer.Series.Count - 1].Points.AddXY(x, y);
                //progress.Value++;
            }
        }

        private void Parametr_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ScreenShot_Click(object sender, EventArgs e)
        {
            makeScreenShot("test");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }             
    }
}
