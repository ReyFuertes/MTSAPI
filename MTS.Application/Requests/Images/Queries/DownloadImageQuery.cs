using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Requests.Images.Queries
{
    public class DownloadImageQuery : IRequest<FileDto>
    {
        public string FileName { get; set; }
    }
}
