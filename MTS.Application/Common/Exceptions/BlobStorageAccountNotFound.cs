using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Common.Exceptions
{
    public class BlobStorageAccountNotFound : Exception
    {
        public BlobStorageAccountNotFound(string connectionString)
            : base($"Blob storage account '{connectionString}' not found") { }
    }
}
