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
