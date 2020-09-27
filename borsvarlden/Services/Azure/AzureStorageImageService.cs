using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace borsvarlden.Services.Azure
{
    public interface IAzureStorageImageService
    { 
        Task<string> UploadImage(IFormFile formFile);
    }

    public class AzureStorageImageService : IAzureStorageImageService
    {
        private string _imagesAzureUploadRootPath => $@"uploads/";

        public async Task<string> UploadImage(IFormFile formFile)
        {
            var filename = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=borsvarlden;AccountKey=hhso0OgNXmxyj3L9UhXhQJwXsZraq6IFGm5n+d+6ENrpBWyX6WQgVeyLhWvBXSS0OXo9igQZ6Ydx7tCsDdAWRA==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("uploads");

            string destinationKey = $"{_imagesAzureUploadRootPath}{DateTime.Now.Year}/{DateTime.Now.Month:00}/{filename}";
            CloudBlockBlob newBlob = container.GetBlockBlobReference(destinationKey);

            await Task.Run(() => newBlob.UploadFromStream(formFile.OpenReadStream()));

            return newBlob.Uri.AbsoluteUri;
        }
    }
}
