using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace SimpleGameSolver
{
    public class IncreaseStepAccurancy3x3 : ExperimentSourceBase
    {
        private Random rnd = new Random();

        public override string Name
        {
            get { return "Increase step accurancy 3x3"; }
        }

        public override string Description
        {
            get { return "Increase step accurancy 3x3"; }
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

                    var firstPlayerStartStrategy = new ulong[3]{ 1, 0, 0 };
                    var secondPlayerStartStrategy = new ulong[3]{ 0, 0, 1 };
                    var startSituation = new Situation(firstPlayerStartStrategy, secondPlayerStartStrategy);

                    experiments.Add(new Experiment(Name, game, startSituation, parameters));
                }
            }

            return experiments;
        }

        private BimatrixGame GetRandomGame()
        {
            var firstPlayerMatrix = new double[3, 3];
            var secondPlayerMatrix = new double[3, 3];

            firstPlayerMatrix[0, 0] = 0;
            firstPlayerMatrix[1, 1] = 0;
            firstPlayerMatrix[2, 2] = 0;
            
            firstPlayerMatrix[0, 1] = rnd.Next(1, 10);
            firstPlayerMatrix[1, 0] = -firstPlayerMatrix[0, 1];

            firstPlayerMatrix[0, 2] = -rnd.Next(1, 10);
            firstPlayerMatrix[2, 0] = -firstPlayerMatrix[0, 2];

            firstPlayerMatrix[1, 2] = rnd.Next(1, 10);
            firstPlayerMatrix[2, 1] = -firstPlayerMatrix[1, 2];

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
