using Microsoft.WindowsAzure.Storage.Blob;

namespace ClassLibrary1.Data
{
    public interface IUpload
    {
        CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
    }
}
