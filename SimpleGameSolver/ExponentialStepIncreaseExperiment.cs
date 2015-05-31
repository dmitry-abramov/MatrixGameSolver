using MathNet.Numerics.LinearAlgebra;
using SimpleGameSolver.Experiments;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class ExponentialStepIncreaseExperiment : Experiment
    {
        public override string Name
        {
            get { return "Zero sum game with exponential steps increase"; }
        }

        public override string Description
        {
            get { return "Zero sum game with exponential steps increase"; }
        }

        public override IList<ExperimentPortion> GetExperimentPortion()
        {
            var experiments = new List<ExperimentPortion>();

            var kValues = new int[] { 2, 3, 5, 10 };

            foreach (var k in kValues)
            {
                var parameters = new Dictionary<string, string>
                        {                        
                            { "iterationsCount", "100" },
                            { "stepIncreaseCoefficient", "2" },
                            { "k", k.ToString() }
                        };

                var game = GetGame(Math.Pow(2, -k));

                var firstPlayerStartStrategy = new ulong[] { 1, 0, 0 };
                var secondPlayerStartStrategy = new ulong[] { 1, 0, 0 };
                var startSituation = new Situation(firstPlayerStartStrategy, secondPlayerStartStrategy);

                experiments.Add(new ExperimentPortion(Name, game, startSituation, parameters)); 
            }

            return experiments;
        }

        private BimatrixGame GetGame(double epsilon)
        {
            var firstPlayerMatrix = new double[3, 3];
            var secondPlayerMatrix = new double[3, 3];

            firstPlayerMatrix[0, 0] = 0;
            firstPlayerMatrix[1, 1] = 0;
            firstPlayerMatrix[2, 2] = 0;

            firstPlayerMatrix[0, 1] = -1;
            firstPlayerMatrix[1, 0] = 1;

            firstPlayerMatrix[0, 2] = -epsilon;
            firstPlayerMatrix[1, 2] = -epsilon;
            firstPlayerMatrix[2, 0] = epsilon;
            firstPlayerMatrix[2, 1] = epsilon;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    secondPlayerMatrix[i, j] = -firstPlayerMatrix[i, j];
                }
            }

            return new BimatrixGame(
                Matrix<double>.Build.DenseOfArray(firstPlayerMatrix),
                Matrix<double>.Build.DenseOfArray(secondPlayerMatrix));
        }
    }
}
