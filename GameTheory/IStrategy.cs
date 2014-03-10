using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    public interface IStrategy<TStrategy> : IStrategy
    {
        TStrategy Strategy { get; }
    }

    public interface IStrategy
    {
        string Description { get; }

        object Strategy { get; }

        IStrategy<TStrategy> Cast<TStrategy>();
    }
}
