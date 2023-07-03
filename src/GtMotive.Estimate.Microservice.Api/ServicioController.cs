using Microsoft.AspNetCore.Mvc;
using GtMotive.Estimate.Microservice.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace HtMotive.Estimate.Microservice.Api
{
    public class ServicioController : ApiController
    {
        private readonly List<Coche> cochesDisponibles;
        private readonly List<Usuario> listaUsuario;

        public ServicioController()
        {
            cochesDisponibles = new List<Coche>();
            listaUsuario = new List<Usuario>();
        }

        // GET: api/Servicio
        [HttpGet]
        public IActionResult ListarCochesDisponibles()
        {
            var cochesDisponibles = (from v in this.cochesDisponibles
                                        where v.Disponible
                                        select v).ToList();

            return (IActionResult)Ok(cochesDisponibles);
        }

        // POST: api/Servicio
        [HttpPost]
        public IActionResult CrearCoche([FromBody] Coche coche)
        {
            if (DateTime.Now.Year - coche.AñoFab > 5)
            {
                return (IActionResult)BadRequest("El coche no puede tener más de 5 años desde su fabricación.");
            }

            coche.Id = cochesDisponibles.Count + 1;
            cochesDisponibles.Add(coche);

            return (IActionResult)Ok("Coche creado correctamente.");
        }
        [HttpPost]
        public IActionResult AlquilarCoche(int CocheId, [FromBody] Usuario usuario)
        {
            if (!usuario.PuedeAlquilar)
            {
                return (IActionResult)BadRequest("El usuario ya tiene un coche alquilado.");
            }

            var coche = cochesDisponibles.FirstOrDefault(v => v.Id == CocheId);
            if (coche == null || !coche.Disponible)
            {
                return (IActionResult)BadRequest("El coche no se encuentra disponible.");
            }

            coche.Disponible = false;
            usuario.PuedeAlquilar = false;
            usuario.CocheAlquilado = coche;
            listaUsuario.Add(usuario);

            return (IActionResult)Ok("Coche alquilado correctamente.");
        }
        [HttpPost]
        public IActionResult DevolverCoche(int CocheId, [FromBody] Usuario usuario)
        {
            var usuarioAlquilando = listaUsuario.FirstOrDefault(c => c.Id == usuario.Id && c.PuedeAlquilar == false);
            if (usuarioAlquilando == null)
            {
                return (IActionResult)BadRequest("El usuario no tiene un coche alquilado.");
            }

            var coche = cochesDisponibles.FirstOrDefault(v => v.Id == CocheId);
            if (coche == null || coche.Disponible)
            {
                return (IActionResult)BadRequest("El coche no existe o ya está disponible.");
            }

            coche.Disponible = true;
            listaUsuario.Remove(usuarioAlquilando);
            usuarioAlquilando.CocheAlquilado = null;

            return (IActionResult)Ok("Coche devuelto.");
        }
    }
}
