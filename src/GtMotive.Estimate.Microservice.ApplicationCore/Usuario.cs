using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public bool PuedeAlquilar { get; set; }
        public Coche CocheAlquilado { get; set; }
    }
}
