using System;
using System.Globalization;

namespace Mosa.Build.Tasks
{
    public class MosaSignException : Exception
    {
        public MosaSignException() : base()
        {
        }

        public MosaSignException(string message) : base(message)
        {
        }

        public MosaSignException(string message, System.Exception inner) : base(message, inner)
        {
        }

        public MosaSignException(string format, params string[] args)
            : this(string.Format(CultureInfo.CurrentCulture, format, args))
        {
        }
    }
}
