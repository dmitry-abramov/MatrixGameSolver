using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class BimatrixGame
    {
        public double[,] FirstPlayerMatrix
        {
            get;
            private set;
        }

        public double[,] SecondPlayerMatrix
        {
            get;
            private set;
        }

        public BimatrixGame(int n, int m)
        {
            FirstPlayerMatrix = new double[n, m];
            SecondPlayerMatrix = new double[n, m];
        }

        public BimatrixGame(double[,] firstPlayerMatrix, double[,] secondPlayerMatrix)
        {
            if (firstPlayerMatrix.GetLength(0) != secondPlayerMatrix.GetLength(0)
                || firstPlayerMatrix.GetLength(1) != secondPlayerMatrix.GetLength(1))
            {
                throw new ArgumentException("Matricies have different size");
            }

            FirstPlayerMatrix = firstPlayerMatrix;
            SecondPlayerMatrix = secondPlayerMatrix;
        }
    }
}
