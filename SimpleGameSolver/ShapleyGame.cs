using MathNet.Numerics.LinearAlgebra;
using SimpleGameSolver.Experiments;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class ShapleyGame : Experiment
    {
        public override string Name
        {
            get { return "Shapley's game"; }
        }

        public override string Description
        {
            get { return "Shapley's game with different start positions"; }
        }

        public override IList<ExperimentPortion> GetExperimentPortion()
        {
            var experiments = new List<ExperimentPortion>();
            var shapleyGame = GetShepleyGame();


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int steps = 100; steps <= 5000; steps += 100)
                    {
                        var firstPlayerStartStrategy = new ulong[3];
                        firstPlayerStartStrategy[i] = 1;
                        var secondPlayerStartStrategy = new ulong[3];
                        secondPlayerStartStrategy[j] = 1;
                        var startSituation = new Situation(firstPlayerStartStrategy, secondPlayerStartStrategy);

                        var parameters = new Dictionary<string, string>
                        {                        
                            { "iterationsCount", steps.ToString(CultureInfo.InvariantCulture) },
                            { "stepIncreaseCoefficient", "2" },
                            { "startSituation", startSituation.ToString() },
                        };

                        experiments.Add(new ExperimentPortion(Name, shapleyGame, startSituation, parameters));
                    }
                }
            }
            
            for (int steps = 100; steps <= 5000; steps += 100)
            {
                var firstPlayerStartStrategy = new ulong[3];
                var secondPlayerStartStrategy = new ulong[3];
                for (int i = 0; i < 3; i++)
                {
                    firstPlayerStartStrategy[i] = 10;
                    secondPlayerStartStrategy[i] = 10;
                }

                firstPlayerStartStrategy[0] = 11;
                secondPlayerStartStrategy[1] = 11;
                
                var startSituation = new Situation(firstPlayerStartStrategy, secondPlayerStartStrategy);

                var parameters = new Dictionary<string, string>
                        {                        
                            { "iterationsCount", steps.ToString(CultureInfo.InvariantCulture) },
                            { "stepIncreaseCoefficient", "2" },
                            { "startSituation", startSituation.ToString() },
                        };

                experiments.Add(new ExperimentPortion(Name, shapleyGame, startSituation, parameters)); 
            }

            return experiments;
        }

        private BimatrixGame GetShepleyGame()
        {
            var firstPlayerMatrix = new double[3, 3];
            var secondPlayerMatrix = new double[3, 3];

            firstPlayerMatrix[0, 0] = 0;
            firstPlayerMatrix[0, 1] = 1;
            firstPlayerMatrix[0, 2] = 0;

            firstPlayerMatrix[1, 0] = 0;
            firstPlayerMatrix[1, 1] = 0;
            firstPlayerMatrix[1, 2] = 1;

            firstPlayerMatrix[2, 0] = 1;
            firstPlayerMatrix[2, 1] = 0;
            firstPlayerMatrix[2, 2] = 0;

            secondPlayerMatrix[0, 0] = 0;
            secondPlayerMatrix[0, 1] = 0;
            secondPlayerMatrix[0, 2] = 1;

            secondPlayerMatrix[1, 0] = 1;
            secondPlayerMatrix[1, 1] = 0;
            secondPlayerMatrix[1, 2] = 0;

            secondPlayerMatrix[2, 0] = 0;
            secondPlayerMatrix[2, 1] = 1;
            secondPlayerMatrix[2, 2] = 0;

            return new BimatrixGame(
                Matrix<double>.Build.DenseOfArray(firstPlayerMatrix),
                Matrix<double>.Build.DenseOfArray(secondPlayerMatrix));
        }
    }
}
