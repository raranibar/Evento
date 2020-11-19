using Evento.Core.Entities.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IBlobService
    {
        Task<BlobInfo> GetBlobAsync(string name, string container);

        Task<IEnumerable<string>> ListBlobsAsync(string container);

        Task UploadFileBlobAsync(string filePath, string fileName, string container);

        Task UploadContentBlobAsync(string content, string fileName, string container);

        Task DeleteBlobAsync(string blobName, string container);
        Task<Uri> UploadFileBlobAsync(Stream content, string contentType, string fileName, string container);

    }
}
