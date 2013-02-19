using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGameSolver
{
    class StartPosition
    {
        protected MixedStrategy firstPlayerStartField;
        protected MixedStrategy secondPlayerStartField;
        protected int stepsAlreadyDo;

        public StartPosition()
        {
            firstPlayerStartField = new MixedStrategy(0);
            secondPlayerStartField = new MixedStrategy(0);
            stepsAlreadyDo = 0;
        }

        public StartPosition(int n, int m)
        {
            firstPlayerStartField = new MixedStrategy(n);
            secondPlayerStartField = new MixedStrategy(m);
            stepsAlreadyDo = 0;
        }

        public StartPosition(MixedStrategy f, MixedStrategy s, int n)
        {
            firstPlayerStartField = new MixedStrategy(f);
            secondPlayerStartField = new MixedStrategy(s);
            stepsAlreadyDo = n;
        }

        public MixedStrategy firstPlayerStart
        {
            get { return firstPlayerStartField; }
        }

        public MixedStrategy secondPlayerStart
        {
            get { return secondPlayerStartField; }
        }

        public int startStep
        {
            get { return stepsAlreadyDo; } 
        }
    }

    interface NumericalSolutionMethod
    { 
    }

    class BrownMethod
    {
        System.Windows.Forms.ProgressBar progress;
        public BrownMethod(System.Windows.Forms.ProgressBar _progress)
        {
            progress = _progress;
        }
        public BiMatrixGameSolve solve(BiMatrixGame game, int iterationCount)
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
            secondPlayerChoice = rnd.Next( game.GetSecondPlayerStrategyCount() );

            firstPlayerSolve[firstPlayerChoice]++;
            secondPlayerSolve[secondPlayerChoice]++;

            MixedStrategyCreator f = new MixedStrategyCreator();
            f.NewMixedStrategy(firstPlayerSolve);
            MixedStrategyCreator s = new MixedStrategyCreator();
            s.NewMixedStrategy(secondPlayerSolve);
            StartPosition start = new StartPosition(f.GetMixedStrategy(), s.GetMixedStrategy(), 1);
            return solve(game, start, iterationCount);            
        }

        public BiMatrixGameSolve solveCenter(BiMatrixGame game, int iterationCount)
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

        public BiMatrixGameSolve solve(BiMatrixGame game, StartPosition startPosition, int iterationCount)
        {
            progress.Minimum = 0;
            progress.Value = 0;
            progress.Maximum = iterationCount;
            Random rnd = new Random();
            TableString tmp;

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
            int startStep = k/2;

            //первая итерация
            int firstPlayerChoice = Choice1(game.firstPlayerMatrix, secondPlayerSolve, rnd.Next(2));
            int secondPlayerChoice = Choice2(game.secondPlayerMatrix, firstPlayerSolve, rnd.Next(2)); ;
                        
            tmp = new TableString(firstPlayerChoice, secondPlayerChoice);
            Table.Add(tmp);
            firstPlayerSolve[Table[0].firstPlayerChoiceField]++;
            secondPlayerSolve[Table[0].secondPlayerChoiceField]++;


            //итерации 2..iterationCount
            for (int i = 1; i < iterationCount; i++)
            {
                firstPlayerChoice =
                    Choice1(game.firstPlayerMatrix, secondPlayerSolve, Table[i - 1].firstPlayerChoiceField);
                secondPlayerChoice =
                    Choice2(game.secondPlayerMatrix, firstPlayerSolve, Table[i - 1].secondPlayerChoiceField);
                tmp = new TableString(firstPlayerChoice, secondPlayerChoice);
                Table.Add(tmp);
                firstPlayerSolve[Table[i].firstPlayerChoiceField]++;
                secondPlayerSolve[Table[i].secondPlayerChoiceField]++;

                progress.Value++;
            }

            //"нормировка" результата
            for (int i = 0; i < firstPlayerSolve.Count; i++)
            {
                firstPlayerSolve[i] = firstPlayerSolve[i] / (iterationCount + startStep);
            }
            for (int i = 0; i < secondPlayerSolve.Count; i++)
            {
                secondPlayerSolve[i] = secondPlayerSolve[i] / (iterationCount + startStep);
            }
            
            MixedStrategyCreator sc = new MixedStrategyCreator();
            sc.NewMixedStrategy(firstPlayerSolve);
            MixedStrategy f = sc.GetMixedStrategy();
            sc.NewMixedStrategy(secondPlayerSolve);
            MixedStrategy s = sc.GetMixedStrategy();

            BiMatrixGameSolve result = new BiMatrixGameSolve(s, f, 0, startPosition, Table); ;
            return result;
        }

        private int Choice1(doubleMatrix A, List<double> p, int last)
        {
            int result = 0;
            List<double> tmp = new List<double>();//список выйгрышей при разном выборе стратегии
            for (int i = 0; i < A.GetNumberOfStrings(); i++)
            {
                tmp.Add(0);
                for (int j = 0; j < p.Count; j++)
                {
                    tmp[i] += A.GetValue(i,j) * p[j];
                }
            }
            double max = tmp.Max();
            if (tmp[last] == max) result = last;
            else result = tmp.IndexOf(max);
            return result;
        }

        private int Choice2(doubleMatrix A, List<double> p, int last)
        {
            int result = 0;
            List<double> tmp = new List<double>();//список выйгрышей при разном выборе стратегии
            for (int i = 0; i < A.GetNumberOfColum(); i++)
            {
                tmp.Add(0);
                for (int j = 0; j < p.Count; j++)
                {
                    tmp[i] += A.GetValue(j,i) * p[j];
                }
            }
            double max = tmp.Max();
            if (tmp[last] == max) result = last;
            else result = tmp.IndexOf(max);
            return result;
        }
    }
}
