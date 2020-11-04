using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.Application.Requests.Images.Commands
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string>
    {
        public Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
