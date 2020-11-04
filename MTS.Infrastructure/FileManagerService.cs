using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using MTS.Application.Common.Exceptions;
using MTS.Application.Common.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.Infrastructure
{
    public class FileManagerService : IFileManager
    {
        //TODO: transfer to config file
        private readonly string blobConnString = "";
        private readonly string blobContainer = "";

        public Task DeleteFileAsync(string fileId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
            {
                throw new NoFileFoundException();
            }

            if (CloudStorageAccount.TryParse(blobConnString, out var storageAccount))
            {
                var filename = GenerateFilename(file);

                CloudBlobClient client = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = client.GetContainerReference(blobContainer);

                if (await container.ExistsAsync(cancellationToken))
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference(filename);
                    await blob.UploadFromStreamAsync(file.OpenReadStream(), cancellationToken);

                    return blob.Name;
                }
                else
                {
                    throw new BlobContainerNotFoundException(blobContainer);
                }
            }

            throw new BlobStorageAccountNotFound(blobConnString);
        }

        private string GenerateFilename(IFormFile file)
            => $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}".ToLower();
    }
}
