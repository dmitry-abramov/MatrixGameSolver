using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

                for (int steps = 50; steps <= 1000; steps+=50)
                {
                    var parameters = new Dictionary<string, string>
                    {
                        { "first player matrix", MatrixToString(game.FirstPlayerMatrix) },
                        { "second player matrix", MatrixToString(game.SecondPlayerMatrix) },
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

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    firstPlayerMatrix[i, j] = rnd.Next(20);
                    secondPlayerMatrix[j, i] = -firstPlayerMatrix[i, j];
                }
            }

            return new BimatrixGame(firstPlayerMatrix, secondPlayerMatrix);
        }

        private string MatrixToString(double[,] matrix)
        {
            var result = new StringBuilder();
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result.AppendFormat("{0,5}", matrix[i, j]);
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
