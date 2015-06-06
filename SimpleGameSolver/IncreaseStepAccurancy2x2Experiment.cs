using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using SimpleGameSolver.Experiments;

namespace SimpleGameSolver
{
    public class IncreaseStepAccurancy2x2Experiment : Experiment
    {
        private readonly Random rnd;

        private IList<int> stepsCount = new List<int> { 10, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 600, 700, 800, 900, 1000, 1125, 1250, 1375, 1500 };

        public IncreaseStepAccurancy2x2Experiment()
        {
            rnd = new Random();
        }

        public IncreaseStepAccurancy2x2Experiment(int seed)
        {
            rnd = new Random(seed);
        }

        public override string Name
        {
            get { return "Increase step accurancy 2x2"; }
        }

        public override string Description
        {
            get { return "Increase step accurancy 2x2"; }
        }

        public override IList<ExperimentPortion> GetExperimentPortion()
        {
            var gamesCount = 50;

            var experiments = new List<ExperimentPortion>();

            for (int gameNumber = 0; gameNumber < gamesCount; gameNumber++)
            {
                var game = GetRandomGame();

                foreach(var steps in stepsCount)
                {
                    var parameters = new Dictionary<string, string>
                    {
                        { "first player matrix", game.FirstPlayerMatrix.ToString() },
                        { "second player matrix", game.SecondPlayerMatrix.ToString() },
                        { "iterationsCount", steps.ToString() },
                        { "stepIncreaseCoefficient", "2" }
                    };

                    experiments.Add(new ExperimentPortion(Name, game, parameters));
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
            firstPlayerMatrix[0, 1] = rnd.Next(1, 10);
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
