using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace SimpleGameSolver
{
    public class IncreaseStepAccurancy2x2 : ExperimentSourceBase
    {
        private Random rnd = new Random();

        public override string Name
        {
            get { return "Increase step accurancy 2x2"; }
        }

        public override string Description
        {
            get { return "Increase step accurancy 2x2"; }
        }

        public override IList<Experiment> GetExperiments()
        {
            var gamesCount = 10;

            var experiments = new List<Experiment>();

            for (int gameNumber = 0; gameNumber < gamesCount; gameNumber++)
            {
                var game = GetRandomGame();

                for (int steps = 50; steps <= 1000; steps += 50)
                {
                    var parameters = new Dictionary<string, string>
                    {
                        { "first player matrix", game.FirstPlayerMatrix.ToString() },
                        { "second player matrix", game.SecondPlayerMatrix.ToString() },
                        { "iterationsCount", steps.ToString() },
                        { "stepIncreaseCoefficient", "2" }
                    };

                    experiments.Add(new Experiment(Name, game, parameters));
                }
            }

            return experiments;
        }

        private BimatrixGame GetRandomGame()
        {
            var firstPlayerMatrix = new double[2, 2];
            var secondPlayerMatrix = new double[2, 2];

            firstPlayerMatrix[0, 0] = 0;
            firstPlayerMatrix[1, 1] = 0;
            firstPlayerMatrix[0, 1] = rnd.Next(20);
            firstPlayerMatrix[1, 0] = -firstPlayerMatrix[0, 1];

            secondPlayerMatrix[0, 0] = 0;
            secondPlayerMatrix[1, 1] = 0;
            secondPlayerMatrix[0, 1] = -firstPlayerMatrix[0, 1];
            secondPlayerMatrix[1, 0] = -firstPlayerMatrix[1, 0];

            return new BimatrixGame(
                Matrix<double>.Build.DenseOfArray(firstPlayerMatrix),
                Matrix<double>.Build.DenseOfArray(secondPlayerMatrix));
        }
    }
}
