using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Requests.Images.Commands
{
    public class UploadImageCommand : IRequest<string>
    {
        public IFormFile File { get; set; }
    }
}
