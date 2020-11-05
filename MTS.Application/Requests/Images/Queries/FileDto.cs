using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MTS.Application.Requests.Images.Queries
{
    public class FileDto
    {
        public Stream BlobStream { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }
    }
}
