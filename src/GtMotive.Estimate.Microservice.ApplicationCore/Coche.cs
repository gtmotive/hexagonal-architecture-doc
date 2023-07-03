using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    public class Coche
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public int AñoFab { get; set; }
        public bool Disponible { get; set; }
    }
}
