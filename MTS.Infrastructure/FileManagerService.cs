using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using MTS.Application.Common.Exceptions;
using MTS.Application.Common.Interfaces;
using MTS.Application.Requests.Images.Queries;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.Infrastructure
{
    public class FileManagerService : IFileManager
    {
        //TODO: transfer to config file
        private readonly string blobConnString = "DefaultEndpointsProtocol=https;AccountName=meattheseadiag;AccountKey=meoicLqXHjXyfoAgYubvBWTlB+QjBnXiIBHtqaAunvrHZGfnnnKuTACnVZYma7dgrlcQfGJ49bOuQ0eFb1tXMg==;EndpointSuffix=core.windows.net";
        private readonly string blobContainer = "mts-dev";

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

        //For testing purpose only
        public async Task<string> UploadFileAsyncTest(IFormFile file)
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

                if (await container.ExistsAsync())
                {
                    CloudBlockBlob blob = container.GetBlockBlobReference(filename);
                    await blob.UploadFromStreamAsync(file.OpenReadStream());

                    return blob.Name;
                }
                else
                {
                    throw new BlobContainerNotFoundException(blobContainer);
                }
            }

            throw new BlobStorageAccountNotFound(blobConnString);
        }

        public async Task<FileDto> DownloadFile(string fileName, CancellationToken cancellationToken)
        {
            MemoryStream ms = new MemoryStream();
            if (CloudStorageAccount.TryParse(blobConnString, out CloudStorageAccount storageAccount))
            {
                CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = BlobClient.GetContainerReference(blobContainer);

                if (await container.ExistsAsync(cancellationToken))
                {
                    CloudBlob file = container.GetBlobReference(fileName);

                    if (await file.ExistsAsync())
                    {
                        await file.DownloadToStreamAsync(ms);
                        Stream blobStream = file.OpenReadAsync().Result;

                        return new FileDto { BlobStream = blobStream, ContentType = file.Properties.ContentType, FileName = file.Name };
                    }
                    else
                    {
                        throw new NoFileFoundException();
                    }
                }
                else
                {
                    throw new BlobStorageAccountNotFound(blobConnString);
                }
            }
            else
            {
                throw new BlobStorageAccountNotFound(blobConnString);
            }
        }

        private string GenerateFilename(IFormFile file)
            => $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}".ToLower();
    }
}
