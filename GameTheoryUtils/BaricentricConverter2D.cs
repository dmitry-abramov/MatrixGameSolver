using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameTheoryUtils
{
    public class BaricentricConverter2D
    {
        private const double epsilon = 0.000001;

        private PointF firstVertex;
        private PointF secondVertex;
        private PointF thirdVertex;

        public PointF FirstVertex 
        {
            get
            {
                return firstVertex;
            }
            set 
            {
                if (IsOnSameLine(value, SecondVertex, ThirdVertex))
                {
                    throw new ArgumentException("Basis points should not be os the same line");
                }

                firstVertex = value;
            }
        }

        public PointF SecondVertex
        {
            get
            {
                return secondVertex;
            }
            set
            {
                if (IsOnSameLine(FirstVertex, value, ThirdVertex))
                {
                    throw new ArgumentException("Basis points should not be os the same line");
                }

                secondVertex = value;
            }
        }

        public PointF ThirdVertex
        {
            get
            {
                return thirdVertex;
            }
            set
            {
                if (IsOnSameLine(FirstVertex, SecondVertex, value))
                {
                    throw new ArgumentException("Basis points should not be os the same line");
                }

                thirdVertex = value;
            }
        }

        public BaricentricConverter2D()
            : this(new PointF(0, 0), new PointF(0, 1), new PointF(1, 0))
        { 
        }

        public BaricentricConverter2D(PointF first, PointF second, PointF third)
        {
            if (IsOnSameLine(first, second, third))
            {
                throw new ArgumentException("Basis points should not be os the same line");
            }

            firstVertex = first;
            secondVertex = second;
            thirdVertex = third;
        }

        private bool IsOnSameLine(PointF first, PointF second, PointF third)
        {
            var k1 = (second.Y - first.Y) / (second.X - first.X);
            var k2 = (third.Y - first.Y) / (third.X - first.X);

            if (double.IsNaN(k1) && double.IsNaN(k2) || double.IsInfinity(k1) && double.IsInfinity(k2))
            {
                return true;
            }

            return Math.Abs(k1 - k2) < epsilon;
        }
    }
}
