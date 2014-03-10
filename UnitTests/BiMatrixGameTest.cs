using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GameTheory;

namespace UnitTests
{
    [TestClass]
    public class BiMatrixGameTest
    {
        [TestMethod]
        public void CreateNewBiMatrixGame()
        {
            double[,] payoffFunction = new double[3, 3];

            var game = new BiMatrixGame(payoffFunction, 3, 3);

            Assert.IsTrue(game.FirstPlayerStrategySet.Contains(new StrategyBase<int>(2)));
            Assert.IsTrue(game.SecondPlayerStrategySet.Contains(new StrategyBase<int>(2)));
        }

        [TestMethod]
        public void CreateGameAndGetPayoff()
        {
            double[,] payoffFunction = new double[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    payoffFunction[i, j] = i * 3 + j;
                }
            }

            var game = new BiMatrixGame(payoffFunction, 3, 3);

            Assert.AreEqual(8, game.GetPayoff(1, new StrategyBase<int>(2), new StrategyBase<int>(2)));
        }
    }
}
