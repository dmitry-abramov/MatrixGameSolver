using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGameSolver
{
    class BrownMethodExp : BrownMethod
    {
        public BrownMethodExp(System.Windows.Forms.ProgressBar _progress)
            : base(_progress)
        {            
        }

        public override BiMatrixGameSolve solve(BiMatrixGame game, int iterationCount)
        {
            progress.Minimum = 0;
            progress.Value = 0;
            progress.Maximum = iterationCount;
            //BiMatrixGameSolve result = new BiMatrixGameSolve(game.GetFirstPlayerStrategyCount(), game.GetSecondPlayerStrategyCount());
            Random rnd = new Random();
            int firstPlayerChoice = 0;
            int secondPlayerChoice = 0;

            SolutionTableCreator Table = new SolutionTableCreator();
            List<double> firstPlayerSolve = new List<double>();
            List<double> secondPlayerSolve = new List<double>();
            for (int i = 0; i < game.GetFirstPlayerStrategyCount(); i++)
                firstPlayerSolve.Add(0);
            for (int i = 0; i < game.GetSecondPlayerStrategyCount(); i++)
                secondPlayerSolve.Add(0);

            firstPlayerChoice = rnd.Next(game.GetFirstPlayerStrategyCount());
            secondPlayerChoice = rnd.Next(game.GetSecondPlayerStrategyCount());

            firstPlayerSolve[firstPlayerChoice]++;
            secondPlayerSolve[secondPlayerChoice]++;

            MixedStrategyCreator f = new MixedStrategyCreator();
            f.NewMixedStrategy(firstPlayerSolve);
            MixedStrategyCreator s = new MixedStrategyCreator();
            s.NewMixedStrategy(secondPlayerSolve);
            StartPosition start = new StartPosition(f.GetMixedStrategy(), s.GetMixedStrategy(), 1);
            return solve(game, start, iterationCount);
        }

        public override BiMatrixGameSolve solveCenter(BiMatrixGame game, int iterationCount)
        {
            progress.Minimum = 0;
            progress.Value = 0;
            progress.Maximum = iterationCount;
            //BiMatrixGameSolve result = new BiMatrixGameSolve(game.GetFirstPlayerStrategyCount(), game.GetSecondPlayerStrategyCount());
            Random rnd = new Random();

            SolutionTableCreator Table = new SolutionTableCreator();
            List<double> firstPlayerSolve = new List<double>();
            List<double> secondPlayerSolve = new List<double>();
            for (int i = 0; i < game.GetFirstPlayerStrategyCount(); i++)
                firstPlayerSolve.Add(0);
            for (int i = 0; i < game.GetSecondPlayerStrategyCount(); i++)
                secondPlayerSolve.Add(0);

            for (int i = 0; i < 33; i++)
            {
                firstPlayerSolve[0]++;
                secondPlayerSolve[0]++;
                firstPlayerSolve[1]++;
                secondPlayerSolve[1]++;
                firstPlayerSolve[2]++;
                secondPlayerSolve[2]++;
            }

            for (int i = 0; i < firstPlayerSolve.Count; i++)
            {
                firstPlayerSolve[i] /= 99;
                secondPlayerSolve[i] /= 99;
            }

            MixedStrategyCreator f = new MixedStrategyCreator();
            f.NewMixedStrategy(firstPlayerSolve);
            MixedStrategyCreator s = new MixedStrategyCreator();
            s.NewMixedStrategy(secondPlayerSolve);
            StartPosition start = new StartPosition(f.GetMixedStrategy(), s.GetMixedStrategy(), 100);

            return solve(game, start, iterationCount);
        }

        public override BiMatrixGameSolve solve(BiMatrixGame game, StartPosition startPosition, int iterationCount)
        {
            progress.Minimum = 0;
            progress.Value = 0;
            progress.Maximum = iterationCount;
            Random rnd = new Random();
            TableString tmp;

            int step1 = 1; //step for first player
            int step2 = 1; //step for second player
            int norm1 = 0;
            int norm2 = 0;

            SolutionTableCreator Table = new SolutionTableCreator();
            List<double> firstPlayerSolve = new List<double>();
            List<double> secondPlayerSolve = new List<double>();
            for (int i = 0; i < game.GetFirstPlayerStrategyCount(); i++)
                firstPlayerSolve.Add(0);
            for (int i = 0; i < game.GetSecondPlayerStrategyCount(); i++)
                secondPlayerSolve.Add(0);

            //формирование решения по начальным условиям
            int k = 0;
            for (int i = 0; i < firstPlayerSolve.Count; i++)
            {
                int tmp2 = (int)(startPosition.firstPlayerStart[i] * startPosition.startStep);
                for (int j = 0; j < tmp2; j++)
                {
                    //Table.Add(new TableString(i,0));
                    firstPlayerSolve[i]++;
                    k++;
                }
            }

            for (int i = 0; i < secondPlayerSolve.Count; i++)
            {
                int tmp2 = (int)(startPosition.secondPlayerStart[i] * startPosition.startStep);
                for (int j = 0; j < tmp2; j++)
                {
                    //Table.Add(new TableString(0, i));
                    secondPlayerSolve[i]++;
                    k++;
                }
            }
            int startStep = k / 2;

            //первая итерация
            int firstPlayerChoice = Choice1(game.firstPlayerMatrix, secondPlayerSolve, rnd.Next(2));
            int secondPlayerChoice = Choice2(game.secondPlayerMatrix, firstPlayerSolve, rnd.Next(2)); ;

            tmp = new TableString(firstPlayerChoice, secondPlayerChoice);
            Table.Add(tmp);
            firstPlayerSolve[Table[0].firstPlayerChoice]++;
            secondPlayerSolve[Table[0].secondPlayerChoice]++;


            //итерации 2..iterationCount
            for (int i = 1; i < iterationCount; i++)
            {
                firstPlayerChoice =
                    Choice1(game.firstPlayerMatrix, secondPlayerSolve, Table[i - 1].firstPlayerChoice);
                secondPlayerChoice =
                    Choice2(game.secondPlayerMatrix, firstPlayerSolve, Table[i - 1].secondPlayerChoice);
                tmp = new TableString(firstPlayerChoice, secondPlayerChoice);
                Table.Add(tmp);

                //if (Table[i - 1].firstPlayerChoice != Table[i].firstPlayerChoice)
                { 
                    step1 *= 2; 
                }
                if (Table[i - 1].secondPlayerChoice != Table[i].secondPlayerChoice) step1 = 1;                
                firstPlayerSolve[Table[i].firstPlayerChoice] += step1;
                norm1 += (step1 - 1);

                //if (Table[i - 1].secondPlayerChoice != Table[i].secondPlayerChoice)
                {
                    step2 *= 2;
                }
                if (Table[i - 1].firstPlayerChoice != Table[i].firstPlayerChoice) step2 = 1;
                secondPlayerSolve[Table[i].secondPlayerChoice] += step2;
                norm2 += (step2 - 1);

                progress.Value++;
            }

            //"нормировка" результата
            for (int i = 0; i < firstPlayerSolve.Count; i++)
            {
                firstPlayerSolve[i] = firstPlayerSolve[i] / (iterationCount + norm1 + startStep);
            }
            for (int i = 0; i < secondPlayerSolve.Count; i++)
            {
                secondPlayerSolve[i] = secondPlayerSolve[i] / (iterationCount + norm2 + startStep);
            }

            MixedStrategyCreator sc1 = new MixedStrategyCreator();
            MixedStrategyCreator sc2 = new MixedStrategyCreator();
            sc1.NewMixedStrategy(firstPlayerSolve);
            MixedStrategy f = sc1.GetMixedStrategy();
            sc2.NewMixedStrategy(secondPlayerSolve);
            MixedStrategy s = sc2.GetMixedStrategy();

            BiMatrixGameSolve result = new BiMatrixGameSolve(f, s, 0, startPosition, Table); ;
            return result;
        }
    }
}
