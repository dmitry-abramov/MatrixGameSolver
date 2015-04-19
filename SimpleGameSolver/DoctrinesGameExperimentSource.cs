using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using SimpleGameSolver.Experiments;

namespace SimpleGameSolver
{
    public class DoctrinesGameExperimentSource : Experiment
    {
        public override string Name
        {
            get { return "Doctrines game experiment"; }
        }

        public override string Description
        {
            get { return "Doctrines game experiment"; }
        }

        public override IList<ExperimentPortion> GetExperimentPortion()
        {
            var fpPayoffs = new double[8, 8]
            {
                {24,  6,  0,  0, 18, 18,   5,    0},
                { 6, 24,  0,  0, 18, 18,   4,    0},
                {18, 18, 24,  6,  0,  0,   3,    0},
                {18, 18,  6, 24,  0,  0,   2,    0},
                { 0,  0, 18, 18, 24,  6,   1,    0},
                { 0,  0, 18, 18,  6, 24,   0,    0},
                { 0,  0,  0,  0,  0,  0,  25,  -25},
                { 0,  0,  0,  0,  0,  0, -25,   24}
            };
            var spPayoffs = new double[8, 8]
            {
                {24,  6, 18, 18,  0,  0,   0,    0},
                { 6, 24, 18, 18,  0,  0,   0,    0},
                { 0,  0, 24,  6, 18, 18,   0,    0},
                { 0,  0,  6, 24, 18, 18,   0,    0},
                {18, 18,  0,  0, 24,  6,   0,    0},
                {18, 18,  0,  0,  6, 24,   0,    0},
                { 4,  5,  2,  3,  0,  1,  24,  -25},
                { 0,  0,  0,  0,  0,  0, -25,   25}
            };

            var experiments = new List<ExperimentPortion>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var game = new BimatrixGame(
                        Matrix<double>.Build.DenseOfArray(fpPayoffs), 
                        Matrix<double>.Build.DenseOfArray(spPayoffs));

                    var parameters = new Dictionary<string, string>()
                    {
                        { "iterationsCount", "200" }
                    };

                    var fpStrategy = new ulong[8];
                    var spStrategy = new ulong[8];

                    fpStrategy[i] = 1;
                    spStrategy[j] = 1;

                    var startSituation = new Situation(fpStrategy, spStrategy);

                    experiments.Add(new ExperimentPortion(Name, game, startSituation, parameters));
                }
            }

            return experiments;
        }
    }
}
