using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem.Settings;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;

namespace GtMotive.Estimate.Microservice.Infrastructure.FileSystem
{
    public class RentSystemServices : FileSystemServices, IRentSystemServices
    {
        public string Folder { get; set; }
        public RentSystemServices(IOptions<FileSystemSettings> fileSystemSettings) : base(fileSystemSettings)
        {
            Folder = fileSystemSettings.Value.FolderRent;
        }

        public IEnumerable<Rent> GetCollectionRents()
        {
            var response = new List<Rent>();
            try
            {
                string filesPath = Path.Combine(base.FolderPath, Folder);
                if (Directory.Exists(filesPath))
                {
                    foreach (var file in Directory.GetFiles(filesPath, "*.json"))
                    {
                        using (var streamReader = File.OpenRead(file))
                        {
                            var rent = (Rent)JsonSerializer.Deserialize(streamReader, typeof(Rent));
                            response.Add(rent);
                        }
                    }
                }
            }
            catch (Exception)
            {
                response = null;
                // TODO.Save Log
            }
            return response;
        }

        public bool CreateRent(Rent rent)
        {
            bool response = false;
            try
            {
                string fileName = $"{rent.Id}.json";

                string filePath = Path.Combine(base.FolderPath, Folder, fileName);

                string jsonContent = JsonSerializer.Serialize(rent, typeof(Rent));

                File.WriteAllText(filePath, jsonContent);
                response = true;
            }
            catch (Exception)
            {
                // TODO.Save Log
            }
            return response;
        }
    }
}
