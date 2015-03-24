using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class ExperimentSummary
    {
        public Experiment Experiment { get; private set; }

        public Situation Result { get; private set; }

        public double FirstPlayerPayoff 
        {
            get
            {
                return GetPayoff(Experiment.Game.FirstPlayerMatrix, Result);
            }
        }

        public double SecondPlayerPayoff
        {
            get
            {
                return GetPayoff(Experiment.Game.SecondPlayerMatrix, Result);
            }
        }

        // todo: replace it 
        public double V1k
        {
            get
            {
                var v1k = double.MinValue;

                var firstPlayerMatrix = Experiment.Game.FirstPlayerMatrix;
                var secondPlayerNormalizedStrategy = Result.SecondPlayerStrategy.Normalize().ToList();

                for (var i = 0; i < firstPlayerMatrix.GetLength(0); i++)
                {
                    var tmp = 0.0;
                    for (var j = 0; j < firstPlayerMatrix.GetLength(1); j++)
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

                var secondPlayerMatrix = Experiment.Game.SecondPlayerMatrix;
                var firstPlayerNormalizedStrategy = Result.FirstPlayerStrategy.Normalize().ToList();

                for (var j = 0; j < secondPlayerMatrix.GetLength(1); j++)
                {
                    var tmp = 0.0;
                    for (var i = 0; i < secondPlayerMatrix.GetLength(0); i++)
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

        public ExperimentSummary(Experiment experiment, Situation result)
        {
            Experiment = experiment;
            Result = result;
        }

        // todo: remove to helper
        private double GetPayoff(double[,] payoffs, Situation situation)
        {
            int n = payoffs.GetLength(0);
            int m = payoffs.GetLength(1);

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
