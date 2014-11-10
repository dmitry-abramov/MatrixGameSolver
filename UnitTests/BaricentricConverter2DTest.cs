using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameTheoryUtils;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class BaricentricConverter2DTest
    {
        [TestMethod]
        public void DefaultBasis()
        {
            var converter = new BaricentricConverter2D();
                        
            Assert.AreEqual(new PointF(0, 0), converter.FirstVertex);
            Assert.AreEqual(new PointF(0, 1), converter.SecondVertex);
            Assert.AreEqual(new PointF(1, 0), converter.ThirdVertex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BasisPointsFromSameLine()
        {
            new BaricentricConverter2D(new PointF(0, 0), new PointF((float)0.5, 1), new PointF(1, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetWrongBasisOnVerticalLine()
        {
            var converter = new BaricentricConverter2D();

            converter.ThirdVertex = new PointF(0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetWrongBasis()
        {
            var converter = new BaricentricConverter2D();

            converter.SecondVertex = new PointF(10, 0);
        }
    }
}
