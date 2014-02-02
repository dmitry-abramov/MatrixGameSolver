using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public class StrategyBase<T> where T : new()
    {
        public StrategyBase()
        {
            this.Description = string.Format("This is default strategy for type '{0}'", typeof(T).Name);
            this.Strategy = new T();
        }

        public StrategyBase(string description)
        {
            Util.ThrowExceptionIfArgumentIsNull(description, "description");

            this.Description = string.Format("{0}{1}This is default strategy for type '{2}'", 
                description, Environment.NewLine, typeof(T).Name);
            this.Strategy = new T();
        }

        public StrategyBase(T strategy)
        {
            Util.ThrowExceptionIfArgumentIsNull(strategy, "strategy");

            this.Description = string.Format("This is strategy with type '{0}'", typeof(T).Name);
            this.Strategy = strategy;
        }

        public StrategyBase(string description, T strategy)
        {
            Util.ThrowExceptionIfArgumentIsNull(strategy, "strategy");
            Util.ThrowExceptionIfArgumentIsNull(description, "description");

            this.Description = description;
            this.Strategy = strategy;
        }

        public string Description { get; private set; }

        public T Strategy { get; private set; }

        public override string ToString()
        {
            return string.Format("Description: {0}{1}Strategy: {2}", 
                Description, Environment.NewLine, Strategy);
        }
    }
}
