using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GameTheory
{
    public class FiniteStrategySetBase<TStrategy> : IStrategySet<TStrategy>
        where TStrategy : new()
    {
        private readonly Collection<IStrategy> strategies;

        public FiniteStrategySetBase()
            : base()
        {
            strategies = new Collection<IStrategy>();
        }

        public FiniteStrategySetBase(IList<IStrategy> strategies)
        {
            this.strategies = new Collection<IStrategy>(strategies);
        }

        public IStrategy<TStrategy> GetRandomStrategy()
        {
            int maxIndex = strategies.Count;

            if (maxIndex == 0)
            {
                throw new InvalidOperationException("Cann't get random strategy from empty set");
            }

            Random randomGenerator = new Random();
            int randomIndex = randomGenerator.Next(maxIndex);
            return strategies.Cast<IStrategy<TStrategy>>().ElementAt(randomIndex);
        }

        public void Add(IStrategy<TStrategy> item)
        {
            strategies.Add(item);
        }

        public void Clear()
        {
            strategies.Clear();
        }

        public bool Contains(IStrategy<TStrategy> item)
        {
            return strategies.Contains(item);
        }

        public void CopyTo(IStrategy<TStrategy>[] array, int arrayIndex)
        {
            strategies.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get 
            { 
                return strategies.Count; 
            }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(IStrategy<TStrategy> item)
        {
            return strategies.Remove(item);
        }

        public IEnumerator<IStrategy<TStrategy>> GetEnumerator()
        {
            return strategies.Cast<IStrategy<TStrategy>>().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return strategies.GetEnumerator();
        }

        IStrategy IStrategySet.GetRandomStrategy()
        {
            return this.GetRandomStrategy();
        }

        public void Add(IStrategy item)
        {
            strategies.Add(item);
        }

        public bool Contains(IStrategy item)
        {
            return strategies.Contains(item);
        }

        public void CopyTo(IStrategy[] array, int arrayIndex)
        {
            strategies.CopyTo(array, arrayIndex);
        }

        public bool Remove(IStrategy item)
        {
            return strategies.Remove(item);
        }

        IEnumerator<IStrategy> IEnumerable<IStrategy>.GetEnumerator()
        {
            return strategies.GetEnumerator();
        }
    }
}
