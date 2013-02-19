using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGameSolver
{
    class BiMatrixGame
    {
        public doubleMatrix firstPlayerMatrix;
        public doubleMatrix secondPlayerMatrix;
        public BiMatrixGameSolve solve;

        public BiMatrixGame()
        {
            firstPlayerMatrix = new doubleMatrix(1, 1);
            secondPlayerMatrix = new doubleMatrix(1, 1);
            solve = new BiMatrixGameSolve(1, 1);
        }

        public BiMatrixGame(doubleMatrix A, doubleMatrix B)
        {
            firstPlayerMatrix = A;
            secondPlayerMatrix = B;
            solve = new BiMatrixGameSolve(firstPlayerMatrix.GetNumberOfStrings(), secondPlayerMatrix.GetNumberOfColum());
        }

        public int GetFirstPlayerStrategyCount()
        {
            return firstPlayerMatrix.GetNumberOfStrings();
        }

        public int GetSecondPlayerStrategyCount()
        {
            return firstPlayerMatrix.GetNumberOfColum();
        }
    }
}
