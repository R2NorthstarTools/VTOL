using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System;
using System.IO;
using System.Threading.Tasks;

namespace VTOL_RFVD
{
    internal class RFVD
    {
        public static async Task UploadBlob()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=vtoldb;AccountKey=cRBrfepTVvW+EL7+nYoziI5AfRPHCMnVrA293Rko/PzTbGl/RjX0wEmIGD0iBPLya7OUfxbGQnAo+AStItEIHg==;EndpointSuffix=core.windows.net";
            string containerName = "sec-fv";
            var serviceClient = new BlobServiceClient(connectionString);
            var containerClient = serviceClient.GetBlobContainerClient(containerName);
            var path = @"c:\temp";
            var fileName = "Testfile.txt";
            var localFile = Path.Combine(path, fileName);
            await File.WriteAllTextAsync(localFile, "This is a test message");
            var blobClient = containerClient.GetBlobClient(fileName);
            Console.WriteLine("Uploading to Blob storage");
            using FileStream uploadFileStream = File.OpenRead(localFile);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
        }
    }
}
