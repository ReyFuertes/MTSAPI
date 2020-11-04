using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Common.Exceptions
{
    public class NoFileFoundException : Exception
    {
        public NoFileFoundException()
            : base("No file found") { }
    }
}
