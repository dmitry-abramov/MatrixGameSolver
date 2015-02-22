using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class MethodResult
    {
        public IList<Situation> MethodTrace
        {
            get;
            private set;
        }

        public Situation Result
        {
            get
            {
                return MethodTrace.LastOrDefault();
            }
        }

        public MethodResult()
        {
            MethodTrace = new List<Situation>();
        }
    }
}
