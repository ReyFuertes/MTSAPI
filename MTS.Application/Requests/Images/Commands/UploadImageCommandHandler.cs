using MediatR;
using MTS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.Application.Requests.Images.Commands
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, string>
    {
        private readonly IFileManager _fileManager;

        public UploadImageCommandHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<string> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var response = await _fileManager.UploadFileAsync(request.File, cancellationToken);

            return response;
        }
    }
}
