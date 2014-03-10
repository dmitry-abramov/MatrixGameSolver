using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public class MixedStrategySet : IStrategySet<List<double>>
    {
        private readonly int countOfStrategies;

        public MixedStrategySet() : this(3)
        {
        }

        public MixedStrategySet(int countOfStrategies)
        {
            this.countOfStrategies = countOfStrategies;
        }

        public IStrategy<List<double>> GetRandomStrategy()
        {
            var r = new Random();
            var result = new List<int>();

            for (int i = 0; i < countOfStrategies; i++)
            {
                result.Add(r.Next());                
            }

            return new MixedStrategy(new UnnormalizedMixedStrategy(result));
        }

        public bool Add(IStrategy<List<double>> item)
        {
            throw new InvalidOperationException();
        }

        public void ExceptWith(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public void IntersectWith(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public bool IsProperSubsetOf(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public bool IsProperSupersetOf(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public bool IsSubsetOf(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public bool IsSupersetOf(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public bool Overlaps(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public bool SetEquals(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public void SymmetricExceptWith(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        public void UnionWith(IEnumerable<IStrategy<List<double>>> other)
        {
            throw new InvalidOperationException();
        }

        void ICollection<IStrategy<List<double>>>.Add(IStrategy<List<double>> item)
        {
            throw new InvalidOperationException();
        }

        public void Clear()
        {
            throw new InvalidOperationException();
        }

        public bool Contains(IStrategy<List<double>> item)
        {
            if (item.Strategy.Count != countOfStrategies)
            {
                return false;
            }

            double sum = 0;
            foreach (var s in item.Strategy)
            {
                if (s < 0) return false;
                sum += s;
            }

            if (sum == 1) return true;

            return false;
        }

        public void CopyTo(IStrategy<List<double>>[] array, int arrayIndex)
        {
            throw new InvalidOperationException();
        }

        public int Count
        {
            get { return int.MinValue; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(IStrategy<List<double>> item)
        {
            throw new InvalidOperationException();
        }

        public IEnumerator<IStrategy<List<double>>> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new InvalidOperationException();
        }
    }
}
