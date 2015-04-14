using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace SimpleGameSolver
{
    public class StepIncreaseCoefficientExperimentSource : ExperimentSourceBase
    {
        public override string Name
        {
            get { return "Step increase with coefficient"; }
        }

        public override string Description
        {
            get { return "Step increase with coefficient"; }
        }

        public override IList<Experiment> GetExperiments()
        {
            var fpPayoffs = new double[3, 3]
            {
                { 0,  1,  0},
                { 0,  0,  1},
                { 1,  0,  0}
            };
            var spPayoffs = new double[3, 3]
            {
                { 0,  0,  1},
                { 1,  0,  0},
                { 0,  1,  0}
            };

            var experiments = new List<Experiment>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (double stepIncreaseCoefficient = 1; stepIncreaseCoefficient < 3; stepIncreaseCoefficient += 0.01)
                    {


                        var game = new BimatrixGame(
                            Matrix<double>.Build.DenseOfArray(fpPayoffs),
                            Matrix<double>.Build.DenseOfArray(spPayoffs));

                        var parameters = new Dictionary<string, string>()
                        {
                            { "iterationsCount", "200" },
                            { "stepIncreaseCoefficient", stepIncreaseCoefficient.ToString() }
                        };

                        var fpStrategy = new ulong[3];
                        var spStrategy = new ulong[3];

                        fpStrategy[i] = 1;
                        spStrategy[j] = 1;

                        var startSituation = new Situation(fpStrategy, spStrategy);

                        experiments.Add(new Experiment(Name, game, startSituation, parameters));
                    }
                }
            }

            return experiments;
        }
    }
}
