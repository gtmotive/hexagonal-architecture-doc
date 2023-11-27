using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.FileSystem.Settings;
using Microsoft.Extensions.Options;

namespace GtMotive.Estimate.Microservice.Infrastructure.FileSystem
{
    public class FileSystemServices
    {
        public string FolderRent { get; set; }
        public string FolderPath { get; set; }
        public string FolderVehicle { get; set; }

        public FileSystemServices(IOptions<FileSystemSettings> fileSystemSettings)
        {
            FolderVehicle = fileSystemSettings.Value.FolderVehicle;
            FolderRent = fileSystemSettings.Value.FolderRent;
            FolderPath = fileSystemSettings.Value.FolderPath;
        }

        public IEnumerable<Vehicle> GetCollectionVehicles()
        {
            var response = new List<Vehicle>();
            try
            {
                string filesPath = Path.Combine(FolderPath, FolderVehicle);
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

                string filePath = Path.Combine(FolderPath, FolderVehicle, fileName);

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

        public IEnumerable<Rent> GetCollectionRents()
        {
            var response = new List<Rent>();
            try
            {
                string filesPath = Path.Combine(FolderPath, FolderRent);
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

                string filePath = Path.Combine(FolderPath, FolderRent, fileName);

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
