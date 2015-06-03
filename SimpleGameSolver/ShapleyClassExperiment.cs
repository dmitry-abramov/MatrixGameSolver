using MathNet.Numerics.LinearAlgebra;
using SimpleGameSolver.Experiments;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class ShapleyClassExperiment: Experiment
    {
        private IList<int> stepsCount = new List<int> { 10, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 600, 700, 800, 900, 1000, 1125, 1250, 1375, 1500 };

        private Random rnd;
        private double stepIncreaseCoefficient;
        private int seed = -1;

        public ShapleyClassExperiment()
        {
            rnd = new Random();
            stepIncreaseCoefficient = 2;
        }

        public ShapleyClassExperiment(double stepIncreaseCoefficient)
        {
            rnd = new Random();            
            this.stepIncreaseCoefficient = stepIncreaseCoefficient;
        }

        public ShapleyClassExperiment(int seed, double stepIncreaseCoefficient = 2)
        {
            rnd = new Random(seed);
            this.seed = seed;
            this.stepIncreaseCoefficient = stepIncreaseCoefficient;
        }

        public override string Name
        {
            get { return "Shapley class"; }
        }

        public override string Description
        {
            get { return "Shapley class"; }
        }

        public override UiConfigurator GetUiConfigurator()
        {
            return new ShapleyClassUiConfigurator();
        }

        public override IList<ExperimentPortion> GetExperimentPortion()
        {
            var gamesCount = 50;

            var experiments = new List<ExperimentPortion>();

            for (var gameNumber = 0; gameNumber < gamesCount; gameNumber++)
            {
                var game = GetGame();

                foreach (var steps in stepsCount)
                {
                    var parameters = new Dictionary<string, string>
                    {
                        { "first player matrix", game.FirstPlayerMatrix.ToString() },
                        { "second player matrix", game.SecondPlayerMatrix.ToString() },
                        { "iterationsCount", steps.ToString(CultureInfo.InvariantCulture) },
                        { "stepIncreaseCoefficient", stepIncreaseCoefficient.ToString(CultureInfo.InvariantCulture) },
                        { "seed", seed.ToString() }
                    };

                    var firstPlayerStartStrategy = new ulong[] { 1, 0, 0 };
                    var secondPlayerStartStrategy = new ulong[] { 0, 1, 0 };
                    var startSituation = new Situation(firstPlayerStartStrategy, secondPlayerStartStrategy);

                    experiments.Add(new ExperimentPortion(Name, game, startSituation, parameters));
                }
            }

            return experiments;
        }

        private BimatrixGame GetGame()
        {
            var firstPlayerMatrix = new double[3, 3];
            var secondPlayerMatrix = new double[3, 3];

            firstPlayerMatrix[0, 1] = rnd.NextDouble();
            firstPlayerMatrix[2, 0] = firstPlayerMatrix[0, 1];
            firstPlayerMatrix[1, 2] = rnd.NextDouble();

            firstPlayerMatrix[1, 0] = rnd.NextDouble();
            firstPlayerMatrix[2, 1] = firstPlayerMatrix[1, 0];
            firstPlayerMatrix[0, 2] = firstPlayerMatrix[1, 2] + rnd.NextDouble();

            firstPlayerMatrix[0, 0] = firstPlayerMatrix[0, 1] + rnd.NextDouble();
            firstPlayerMatrix[1, 1] = firstPlayerMatrix[1, 0] + rnd.NextDouble();
            firstPlayerMatrix[2, 2] = firstPlayerMatrix[0, 2] + rnd.NextDouble();

            secondPlayerMatrix[0, 1] = rnd.NextDouble();
            secondPlayerMatrix[1, 2] = rnd.NextDouble();
            secondPlayerMatrix[2, 0] = rnd.NextDouble();

            secondPlayerMatrix[0, 0] = secondPlayerMatrix[0, 1] + rnd.NextDouble();
            secondPlayerMatrix[1, 1] = secondPlayerMatrix[1, 2] + rnd.NextDouble();
            secondPlayerMatrix[2, 2] = secondPlayerMatrix[2, 0] + rnd.NextDouble();

            secondPlayerMatrix[0, 2] = secondPlayerMatrix[0, 0] + rnd.NextDouble();
            secondPlayerMatrix[1, 0] = secondPlayerMatrix[1, 1] + rnd.NextDouble();
            secondPlayerMatrix[2, 1] = secondPlayerMatrix[2, 2] + rnd.NextDouble();
            
            return new BimatrixGame(
                Matrix<double>.Build.DenseOfArray(firstPlayerMatrix),
                Matrix<double>.Build.DenseOfArray(secondPlayerMatrix));
        }
    }
}
