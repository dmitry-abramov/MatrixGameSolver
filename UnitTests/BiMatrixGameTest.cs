using NUnit.Framework;

using GameTheory;
using GameTheory.Strategies;

namespace UnitTests
{
    [TestFixture]
    public class BiMatrixGameTest
    {
        [Test]
        [Ignore]
        public void CreateNewBiMatrixGame()
        {
            double[,] payoffFunction = new double[3, 3];

            var game = new BiMatrixGame(payoffFunction, payoffFunction, 3, 3);

            Assert.IsTrue(game.FirstPlayerStrategies.Contains(new StrategyBase<int>(2)));
            Assert.IsTrue(game.SecondPlayerStrategies.Contains(new StrategyBase<int>(2)));
        }

        [Test]
        [Ignore]
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

            var game = new BiMatrixGame(payoffFunction, payoffFunction, 3, 3);

            Assert.AreEqual(8, game.FirstPalyerPayoff(new TwoPlayerGamePosition<int>( new StrategyBase<int>(2), new StrategyBase<int>(2))));
        }
    }
}
