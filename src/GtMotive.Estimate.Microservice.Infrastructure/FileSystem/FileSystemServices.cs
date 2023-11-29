using GtMotive.Estimate.Microservice.Infrastructure.FileSystem.Settings;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;

namespace GtMotive.Estimate.Microservice.Infrastructure.FileSystem
{
    public class FileSystemServices : IFileSystemServices
    {
        public string FolderPath { get; set; }
    
        public FileSystemServices(IOptions<FileSystemSettings> fileSystemSettings)
        {
            FolderPath = fileSystemSettings.Value.FolderPath;
        }
    }
}
