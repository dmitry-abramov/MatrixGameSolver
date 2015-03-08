﻿using System.Collections.Generic;

namespace SimpleGameSolver
{
    public class BorderRotationExperimentSource : ExperimentSourceBase
    {
        public override string Name
        {
            get { return "Rotation of BR areas border"; }
        }

        public override string Description
        {
            get { return "In this experiment we rotate border of BR areas of first player"; }
        }

        public override IList<Experiment> GetExperiments()
        {
            var experiments = new List<Experiment>();

            for (double lambda = 0; lambda <= 1; lambda += 0.1)
            {
                var parameters = new Dictionary<string, string>
                    {
                        {"iterationsCount", "5000"},
                        {"lambda", lambda.ToString()}
                    };
                var experiment = new Experiment(Name, GetGame(lambda), parameters);
                experiments.Add(experiment);
            }

            return experiments;
        }

        private BimatrixGame GetGame(double lambda)
        {
            var firstPlayerMatrix = new double[3, 3];
            var secondPlayerMatrix = new double[3, 3];

            firstPlayerMatrix[0, 0] = 0;
            firstPlayerMatrix[0, 1] = lambda + (1 - lambda);
            firstPlayerMatrix[0, 2] = -lambda + (1 - lambda);
            firstPlayerMatrix[1, 0] = -lambda + (1 - lambda);
            firstPlayerMatrix[1, 1] = 0;
            firstPlayerMatrix[1, 2] = lambda + (1 - lambda);
            firstPlayerMatrix[2, 0] = lambda + (1 - lambda);
            firstPlayerMatrix[2, 1] = -lambda + (1 - lambda);
            firstPlayerMatrix[2, 2] = 0;

            secondPlayerMatrix[0, 0] = 0;
            secondPlayerMatrix[0, 1] = -lambda + (1 - lambda);
            secondPlayerMatrix[0, 2] = lambda + (1 - lambda);
            secondPlayerMatrix[1, 0] = lambda + (1 - lambda);
            secondPlayerMatrix[1, 1] = 0;
            secondPlayerMatrix[1, 2] = -lambda + (1 - lambda);
            secondPlayerMatrix[2, 0] = -lambda + (1 - lambda);
            secondPlayerMatrix[2, 1] = lambda + (1 - lambda);
            secondPlayerMatrix[2, 2] = 0;

            return new BimatrixGame(firstPlayerMatrix, secondPlayerMatrix);
        }
    }
}