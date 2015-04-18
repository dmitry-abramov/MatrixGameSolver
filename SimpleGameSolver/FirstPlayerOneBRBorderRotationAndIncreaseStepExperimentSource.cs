using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace SimpleGameSolver
{
    public class FirstPlayerOneBRBorderRotationAndIncreaseStepExperimentSource : Experiment
    {
        public override string Name
        {
            get { return "One BR border rotation and increase step"; }
        }

        public override string Description
        {
            get { return "One BR border rotation and increase step"; }
        }

        public override IList<ExperimentPortion> GetExperimentPortion()
        {
            var experiments = new List<ExperimentPortion>();

            for (double c = -0.45; c <= 0.5; c += 0.05)
            {
                for (double stepIncreaseCoefficient = 1; stepIncreaseCoefficient < 3; stepIncreaseCoefficient += 0.05)
                {

                    var parameters = new Dictionary<string, string>
                        {
                            {"iterationsCount", "500"},
                            {"c", c.ToString()},
                            {"stepIncreaseCoefficient", stepIncreaseCoefficient.ToString() }
                        };
                    var experiment = new ExperimentPortion(Name, GetGame(c), parameters);
                    experiments.Add(experiment);
                }
            }

            return experiments;
        }

        private BimatrixGame GetGame(double c)
        {
            var firstPlayerMatrix = new double[3, 3];
            var secondPlayerMatrix = new double[3, 3];

            firstPlayerMatrix[0, 0] = 0;
            firstPlayerMatrix[0, 1] = 1;
            firstPlayerMatrix[0, 2] = 0;
            firstPlayerMatrix[1, 0] = 0;
            firstPlayerMatrix[1, 1] = 0;
            firstPlayerMatrix[1, 2] = 1;
            firstPlayerMatrix[2, 0] = (1 - 2 * c) / (1 + 2 * c);
            firstPlayerMatrix[2, 1] = 4 * c / (1 + 2 * c);
            firstPlayerMatrix[2, 2] = 0;

            secondPlayerMatrix[0, 0] = 0;
            secondPlayerMatrix[0, 1] = -1;
            secondPlayerMatrix[0, 2] = 0;
            secondPlayerMatrix[1, 0] = 0;
            secondPlayerMatrix[1, 1] = 0;
            secondPlayerMatrix[1, 2] = -1;
            secondPlayerMatrix[2, 0] = -1;
            secondPlayerMatrix[2, 1] = 0;
            secondPlayerMatrix[2, 2] = 0;

            return new BimatrixGame(
                Matrix<double>.Build.DenseOfArray(firstPlayerMatrix),
                Matrix<double>.Build.DenseOfArray(secondPlayerMatrix));
        }
    }
}
