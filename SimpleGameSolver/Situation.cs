using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class Situation
    {
        public ulong[] FirstPlayerStrategy
        {
            get;
            private set;
        }

        public ulong[] SecondPlayerStrategy
        {
            get;
            private set;
        }

        public Situation(int n, int m)
        {
            FirstPlayerStrategy = new ulong[n];
            FirstPlayerStrategy[0] = 1;

            SecondPlayerStrategy = new ulong[n];
            SecondPlayerStrategy[0] = 1;
        }

        public Situation(IEnumerable<ulong> firstPlayerStrategy, IEnumerable<ulong> secondPlayerStrategy)
            : this(firstPlayerStrategy.ToArray(), secondPlayerStrategy.ToArray())
        { 
        }

        public Situation(ulong[] firstPlayerStrategy, ulong[] secondPlayerStrategy)
        {
            if (firstPlayerStrategy == null || secondPlayerStrategy == null)
            {
                throw new ArgumentNullException(firstPlayerStrategy == null ? "firstPlayerStrategy" : "secondPlayerStrategy");
            }

            if (!IsValid(firstPlayerStrategy))
            {
                throw new ArgumentException("Invalid strategy.", "firstPlayerStrategy");
            }

            if (!IsValid(secondPlayerStrategy))
            {
                throw new ArgumentException("Invalid strategy.", "secondPlayerStrategy");
            }

            FirstPlayerStrategy = firstPlayerStrategy;
            SecondPlayerStrategy = secondPlayerStrategy;
        }

        public override string ToString()
        {
            return string.Format("({0}) ({1})", 
                string.Join(",", FirstPlayerStrategy),
                string.Join(",", SecondPlayerStrategy));
        }

        private bool IsValid(ulong[] strategy)
        {
            return !(strategy.Any(e => e < 0) || strategy.Sum(e => (decimal)e) == 0);
        }

        
    }
}
