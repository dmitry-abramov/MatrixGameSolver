using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                        { "first player matrix", MatrixToString(game.FirstPlayerMatrix) },
                        { "second player matrix", MatrixToString(game.SecondPlayerMatrix) },
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
            
            firstPlayerMatrix[0, 1] = rnd.Next(-10, 10);
            firstPlayerMatrix[1, 0] = -firstPlayerMatrix[0, 1];

            firstPlayerMatrix[0, 2] = rnd.Next(-10, 10);
            firstPlayerMatrix[2, 0] = -firstPlayerMatrix[0, 2];

            firstPlayerMatrix[1, 2] = rnd.Next(-10, 10);
            firstPlayerMatrix[2, 1] = -firstPlayerMatrix[1, 2];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    secondPlayerMatrix[i, j] = -firstPlayerMatrix[i, j];
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
