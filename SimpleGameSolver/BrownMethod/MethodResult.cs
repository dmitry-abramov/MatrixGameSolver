using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public class MethodResult
    {
        public string MethodName
        {
            get;
            private set;
        }

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

        public MethodResult(string methodName)
        {
            MethodName = methodName;
            MethodTrace = new List<Situation>();
        }

        public MethodResult(string methodName, IList<Situation> methodTrace)
        {
            MethodName = methodName;
            MethodTrace = methodTrace;
        }
    }
}
