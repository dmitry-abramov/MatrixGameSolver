using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace SimpleGameSolver.Experiments
{
    public class ExperimentPortionSummary
    {
        public ExperimentPortion ExperimentPortion { get; private set; }

        public Situation Result { get; private set; }

        public double FirstPlayerPayoff 
        {
            get
            {
                return GetPayoff(ExperimentPortion.Game.FirstPlayerMatrix, Result);
            }
        }

        public double SecondPlayerPayoff
        {
            get
            {
                return GetPayoff(ExperimentPortion.Game.SecondPlayerMatrix, Result);
            }
        }

        // todo: replace it 
        public double V1k
        {
            get
            {
                var v1k = double.MinValue;

                var firstPlayerMatrix = ExperimentPortion.Game.FirstPlayerMatrix;
                var secondPlayerNormalizedStrategy = Result.SecondPlayerStrategy.Normalize().ToList();

                for (var i = 0; i < firstPlayerMatrix.RowCount; i++)
                {
                    var tmp = 0.0;
                    for (var j = 0; j < firstPlayerMatrix.ColumnCount; j++)
                    {
                        tmp += firstPlayerMatrix[i, j] * secondPlayerNormalizedStrategy[j];
                    }

                    if (tmp > v1k)
                    {
                        v1k = tmp;
                    }
                }

                return v1k;
            }
        }

        // todo: replace it
        public double V2k
        {
            get
            {
                var v2k = double.MinValue;

                var secondPlayerMatrix = ExperimentPortion.Game.SecondPlayerMatrix;
                var firstPlayerNormalizedStrategy = Result.FirstPlayerStrategy.Normalize().ToList();

                for (var j = 0; j < secondPlayerMatrix.ColumnCount; j++)
                {
                    var tmp = 0.0;
                    for (var i = 0; i < secondPlayerMatrix.RowCount; i++)
                    {
                        tmp += secondPlayerMatrix[i, j] * firstPlayerNormalizedStrategy[i];
                    }

                    if (tmp > v2k)
                    {
                        v2k = tmp;
                    }
                }

                return v2k;
            }
        }

        public ExperimentPortionSummary(ExperimentPortion experimentPortion, Situation result)
        {
            ExperimentPortion = experimentPortion;
            Result = result;
        }

        // todo: remove to helper
        private double GetPayoff(Matrix<double> payoffs, Situation situation)
        {
            int n = payoffs.RowCount;
            int m = payoffs.ColumnCount;

            var firstPlayerNormalizedStrategy = situation.FirstPlayerStrategy.Normalize().ToList();
            var secondPlayerNormalizedStrategy = situation.SecondPlayerStrategy.Normalize().ToList();

            var payoff = 0.0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    payoff += payoffs[i, j] * firstPlayerNormalizedStrategy[i] * secondPlayerNormalizedStrategy[j];
                }
            }

            return payoff;
        }
    }
}
