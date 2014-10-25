using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GameTheoryUI
{
    public partial class BaricentricChart : UserControl
    {
        private const string separatePointsSerieName = "Separate points";
        private const string borderSerieName = "Border of area";

        private DataPoint firstBasisVertex;
        private DataPoint secondBasisVertex;
        private DataPoint thirdBasisVertex;

        #region constructors
        public BaricentricChart()
        {
            InitializeComponent();

            SetBasisVertex(new PointF(0, 0), new PointF(0, 1), new PointF(1, 0));
            InnerClearChart();
        }

        public BaricentricChart(PointF first, PointF second, PointF third)
        {
            InitializeComponent();

            SetBasisVertex(first, second, third);
            InnerClearChart();
        }
        #endregion

        #region public methods
        public void AddBaricentricPoint(double x, double y, double z)
        {
            InnerAddPointToSerie(separatePointsSerieName, x, y, z);
        }

        public void AddPointToLine(string lineName, double x, double y, double z)
        {
            var serie = InnerChart.Series[lineName];

            if (serie == null)
            {
                CreateLine(lineName);
            }
            else
            {
                if (IsLine(serie))
                {
                    InnerAddPointToSerie(lineName, x, y, z);
                }
            }

            throw new ArgumentException(
                string.Format("Serie with name '{0}' is not line", lineName),
                "lineName");
        }

        public void AddPointToSerie(string serieName, double x, double y, double z)
        {
            InnerAddPointToSerie(serieName, x, y, z);
        }

        public void ClearChart()
        {
            ResetChart();
        }
        #endregion

        #region private methods
        private void DrawBorder()
        {
            var borderSerie = InnerChart.Series[borderSerieName];

            if (borderSerie == null)
            {
                borderSerie = new Series(borderSerieName);

                borderSerie.ChartType = SeriesChartType.Line;
                
                borderSerie.Points.Add(firstBasisVertex);
                borderSerie.Points.Add(secondBasisVertex);
                borderSerie.Points.Add(thirdBasisVertex);

                InnerChart.Series.Add(borderSerieName);
            }
        }

        private void CreateLine(string lineName)
        {
            var serie = InnerChart.Series[lineName];

            if (serie == null)
            {
                serie = new Series(lineName);
                serie.ChartType = SeriesChartType.Line;

                InnerChart.Series.Add(serie);
            }

            throw new ArgumentException(
                string.Format("Group of points with name '{0}' has already exist", lineName),
                "lineName");
        }

        private bool IsLine(Series serie)
        {
            return serie.ChartType == SeriesChartType.Line && serie.Name != borderSerieName;
        }

        private void InnerAddPointToSerie(string serieName, double x, double y, double z)
        {
            var point = ConvertToChartPoint(x, y, z);
            InnerChart.Series[serieName].Points.Add(point);
        }

        private DataPoint ConvertToChartPoint(double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        private void ResetChart()
        {
            InnerClearChart();

            DrawBorder();
            InnerChart.Series.Add(separatePointsSerieName);
        }

        private void InnerClearChart()
        {
            InnerChart.Series.Clear();
        }

        private void SetBasisVertex(PointF first, PointF second, PointF third)
        {
            firstBasisVertex = new DataPoint(first.X, first.Y);
            firstBasisVertex.Name = "1";

            secondBasisVertex = new DataPoint(second.X, second.Y);
            secondBasisVertex.Name = "2";

            thirdBasisVertex = new DataPoint(third.X, third.Y);
            thirdBasisVertex.Name = "3";
        }
        #endregion
    }
}
