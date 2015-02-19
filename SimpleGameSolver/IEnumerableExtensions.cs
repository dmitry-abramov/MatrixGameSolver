using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameSolver
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<double> Normalize<ulong>(this IEnumerable<ulong> collection)
        {
            var sum = collection.Sum(u => (decimal)u);
            return collection.Select(u => (double)(u / sum));
        }
    }
}
