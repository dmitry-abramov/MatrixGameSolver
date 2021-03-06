﻿using System;
using System.Collections.Generic;
using System.Globalization;
using MathNet.Numerics.LinearAlgebra;
using SimpleGameSolver.Experiments;

namespace SimpleGameSolver
{
    public class IncreaseStepAccurancy3x3Experiment : Experiment
    {
        private Random rnd;
        private double stepIncreaseCoefficient;
        private int seed;

        private IList<int> stepsCount = new List<int> { 10, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 600, 700, 800, 900, 1000, 1125, 1250, 1375, 1500 };

        public IncreaseStepAccurancy3x3Experiment()
        {
            rnd = new Random();
            stepIncreaseCoefficient = 2;
        }

        public IncreaseStepAccurancy3x3Experiment(int seed)
        {
            this.seed = seed;
            rnd = new Random(seed);
            stepIncreaseCoefficient = 2;
        }

        public IncreaseStepAccurancy3x3Experiment(double stepIncreaseCoefficient)
        {
            rnd = new Random();
            this.stepIncreaseCoefficient = stepIncreaseCoefficient;
        }

        public IncreaseStepAccurancy3x3Experiment(int seed, double stepIncreaseCoefficient)
        {
            rnd = new Random(seed);
            this.seed = seed;
            this.stepIncreaseCoefficient = stepIncreaseCoefficient;
        }

        public override string Name
        {
            get { return "Increase step accurancy 3x3"; }
        }

        public override string Description
        {
            get { return "Increase step accurancy 3x3"; }
        }

        public override UiConfigurator GetUiConfigurator()
        {
            return new IncreaseStepAccurancy3x3UiConfigurator();
        }

        public override IList<ExperimentPortion> GetExperimentPortion()
        {
            var gamesCount = 50;

            var experiments = new List<ExperimentPortion>();

            for (var gameNumber = 0; gameNumber < gamesCount; gameNumber++)
            {
                var game = GetRandomGame();

                foreach(var steps in stepsCount)
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

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
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
