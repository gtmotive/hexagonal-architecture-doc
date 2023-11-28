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
    public class VehicleSystemServices : FileSystemServices, IVehicleSystemServices
    {
        public string Folder { get; set; }

        public VehicleSystemServices(IOptions<FileSystemSettings> fileSystemSettings) : base(fileSystemSettings)
        {
            Folder = fileSystemSettings.Value.FolderVehicle;
        }

        public IEnumerable<Vehicle> GetCollectionVehicles()
        {
            var response = new List<Vehicle>();
            try
            {
                string filesPath = Path.Combine(FolderPath, Folder);
                if (Directory.Exists(filesPath))
                {
                    foreach (var file in Directory.GetFiles(filesPath, "*.json"))
                    {
                        using (var streamReader = File.OpenRead(file))
                        {
                            var vehicle = (Vehicle)JsonSerializer.Deserialize(streamReader, typeof(Vehicle));
                            response.Add(vehicle);
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

        public bool CreateVehicle(Vehicle vehicle)
        {
            bool response = false;
            try
            {
                string fileName = $"{vehicle.Id}.json";

                string filePath = Path.Combine(FolderPath, Folder, fileName);

                string jsonContent = JsonSerializer.Serialize(vehicle, typeof(Vehicle));

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
