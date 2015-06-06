using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace SimpleGameSolver
{
    public abstract class BrownMethodBase
    {
        public abstract string Name { get; }

        public abstract MethodResult Solve(BimatrixGame game, Situation startSituation, IDictionary<string, string> parameters);

        protected int GetFirstPlayerChoice(Matrix<double> A, ulong[] otherPlayerStartegy, int last)
        {
            int result;
            List<double> tmp = new List<double>();//список выйгрышей при разном выборе стратегии
            for (int i = 0; i < A.RowCount; i++)
            {
                tmp.Add(0);
                for (int j = 0; j < otherPlayerStartegy.Count(); j++)
                {
                    tmp[i] += A[i, j] * otherPlayerStartegy[j];
                }
            }
            double max = tmp.Max();
            if (tmp[last] == max) result = last;
            else result = tmp.IndexOf(max);
            return result;
        }

        protected int GetSecondPlayerChoice(Matrix<double> A, ulong[] otherPlayerStartegy, int last)
        {
            int result;
            List<double> tmp = new List<double>();//список выйгрышей при разном выборе стратегии
            for (int i = 0; i < A.ColumnCount; i++)
            {
                tmp.Add(0);
                for (int j = 0; j < otherPlayerStartegy.Count(); j++)
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
