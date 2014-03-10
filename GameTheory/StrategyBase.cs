using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public class StrategyBase<TStrategy> : IStrategy<TStrategy> where TStrategy : new()
    {
        public StrategyBase()
        {
            this.Description = string.Format("This is default strategy for type '{0}'", typeof(TStrategy).Name);
            this.Strategy = new TStrategy();
        }

        public StrategyBase(string description)
        {
            Util.ThrowExceptionIfArgumentIsNull(description, "description");

            this.Description = string.Format("{0}{1}This is default strategy for type '{2}'",
                description, Environment.NewLine, typeof(TStrategy).Name);
            this.Strategy = new TStrategy();
        }

        public StrategyBase(TStrategy strategy)
        {
            Util.ThrowExceptionIfArgumentIsNull(strategy, "strategy");

            this.Description = string.Format("This is strategy with type '{0}'", typeof(TStrategy).Name);
            this.Strategy = strategy;
        }

        public StrategyBase(string description, TStrategy strategy)
        {
            Util.ThrowExceptionIfArgumentIsNull(strategy, "strategy");
            Util.ThrowExceptionIfArgumentIsNull(description, "description");

            this.Description = description;
            this.Strategy = strategy;
        }

        public string Description { get; protected set; }

        public TStrategy Strategy { get; protected set; }

        public override string ToString()
        {
            return string.Format("Description: {0}{1}Strategy: {2}",
                Description, Environment.NewLine, Strategy);
        }

        object IStrategy.Strategy
        {
            get
            {
                return Strategy;
            }
        }

        public IStrategy<TCastStrategy> Cast<TCastStrategy>()
        {
            if (typeof(TCastStrategy) == typeof(TStrategy) || typeof(TCastStrategy).IsSubclassOf(typeof(TStrategy)))
            {
                return (IStrategy<TCastStrategy>)this;
            };

            var message = string.Format("Can not convert type {0} to type {1}",
                    typeof(TStrategy), typeof(TCastStrategy));
            throw new ArgumentException(message, "TCastStrategy");
        }

        public override bool Equals(object obj)
        {
            //Последовательность проверки должна быть именно такой.
            //Если не проверить на null объект other, то other.GetType() может выбросить //NullReferenceException.            
            if (obj == null)
                return false;

            //Если ссылки указывают на один и тот же адрес, то их идентичность гарантирована.
            if (object.ReferenceEquals(this, obj))
                return true;

            //Если класс находится на вершине иерархии или просто не имеет наследников, то можно просто
            //сделать Vehicle tmp = other as Vehicle; if(tmp==null) return false; 
            //Затем вызвать экземплярный метод, сразу передав ему объект tmp.
            if (this.GetType() != obj.GetType())
                return false;

            if (this.Strategy.GetType() != ((StrategyBase<TStrategy>)obj).Strategy.GetType())
                return false;

            return this.Strategy.Equals(((StrategyBase<TStrategy>)obj).Strategy);
        }

        public override int GetHashCode()
        {
            return Strategy.GetHashCode();
        }
    }
}
