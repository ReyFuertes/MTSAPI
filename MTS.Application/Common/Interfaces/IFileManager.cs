using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.Application.Common.Interfaces
{
    public interface IFileManager
    {
        Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken);
        Task DeleteFileAsync(string fileId, CancellationToken cancellationToken);
    }
}
