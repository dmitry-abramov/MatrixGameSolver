using System;
using MathNet.Numerics.LinearAlgebra;

namespace SimpleGameSolver
{
    public class BimatrixGame
    {
        public Matrix<double> FirstPlayerMatrix
        {
            get;
            private set;
        }

        public Matrix<double> SecondPlayerMatrix
        {
            get;
            private set;
        }

        public BimatrixGame(int n, int m)
        {
            FirstPlayerMatrix = Matrix<double>.Build.Dense(n, m);
            SecondPlayerMatrix = Matrix<double>.Build.Dense(n, m);
        }

        public BimatrixGame(Matrix<double> firstPlayerMatrix, Matrix<double> secondPlayerMatrix)
        {
            if (firstPlayerMatrix.RowCount != secondPlayerMatrix.RowCount
                || firstPlayerMatrix.ColumnCount != secondPlayerMatrix.ColumnCount)
            {
                throw new ArgumentException("Matricies have different size");
            }

            FirstPlayerMatrix = firstPlayerMatrix;
            SecondPlayerMatrix = secondPlayerMatrix;
        }
    }
}
