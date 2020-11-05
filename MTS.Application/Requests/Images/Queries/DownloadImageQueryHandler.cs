using MediatR;
using MTS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.Application.Requests.Images.Queries
{
    public class DownloadImageQueryHandler : IRequestHandler<DownloadImageQuery, FileDto>
    {
        private readonly IFileManager _fileManager;

        public DownloadImageQueryHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<FileDto> Handle(DownloadImageQuery request, CancellationToken cancellationToken)
        {
            var response = await _fileManager.DownloadFile(request.FileName, cancellationToken);

            return response;
        }
    }
}
