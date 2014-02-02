using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory
{
    internal class Util
    {
        public static void ThrowExceptionIfArgumentIsNull(object argument, string argumentName)
        {
            if (argumentName == null) throw new ArgumentNullException("argumentName");

            if (argument == null) throw new ArgumentNullException(argumentName);
        }

        public static void ThrowExceptionIfArgumentIsNull(object argument, string message, Exception innerException)
        {
            if (message == null) throw new ArgumentNullException("message");

            if (argument == null) throw new ArgumentNullException(message, innerException);
        }

        public static void ThrowExceptionIfArgumentIsNull(object argument, string message, string argumentName)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (argumentName == null) throw new ArgumentNullException("argumentName");

            if (argument == null) throw new ArgumentNullException(message, argumentName);
        }
    }
}
