using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public abstract class BrownMethodBase
    {
        public abstract List<List<List<ulong>>> Solve(double[,] fpp, double[,] spp, List<ulong> fpsp, List<ulong> spsp, int iterationsCount);

        protected int Choice1(double[,] A, List<ulong> otherPlayerStartegy, int last)
        {
            int result = 0;
            List<double> tmp = new List<double>();//список выйгрышей при разном выборе стратегии
            for (int i = 0; i < A.GetLength(0); i++)
            {
                tmp.Add(0);
                for (int j = 0; j < otherPlayerStartegy.Count; j++)
                {
                    tmp[i] += A[i, j] * otherPlayerStartegy[j];
                }
            }
            double max = tmp.Max();
            if (tmp[last] == max) result = last;
            else result = tmp.IndexOf(max);
            return result;
        }

        protected int Choice2(double[,] A, List<ulong> otherPlayerStartegy, int last)
        {
            int result = 0;
            List<double> tmp = new List<double>();//список выйгрышей при разном выборе стратегии
            for (int i = 0; i < A.GetLength(1); i++)
            {
                tmp.Add(0);
                for (int j = 0; j < otherPlayerStartegy.Count; j++)
                {
                    tmp[i] += A[j, i] * otherPlayerStartegy[j];
                }
            }
            double max = tmp.Max();
            if (tmp[last] == max) result = last;
            else result = tmp.IndexOf(max);
            return result;
        }
    }
}
