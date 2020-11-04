using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Common.Exceptions
{
    public class BlobContainerNotFoundException : Exception
    {
        public BlobContainerNotFoundException(string container)
            : base($"Container '{container}' not found")
        {
        }
    }
}
