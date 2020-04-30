using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaDominio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly ITipoIdentificacionServicio _tipoIdentificacionServicio;

        public TipoIdentificacionController(ITipoIdentificacionServicio tipoIdentificacionServicio)
        {
            _tipoIdentificacionServicio = tipoIdentificacionServicio;
        }

        [HttpGet("ObtenerTodos")]
        [AllowAnonymous]
        public async Task<IActionResult> obtenerTodos()
        {
            try
            {
                var lista = await _tipoIdentificacionServicio.obtenerTodos();
                if (lista.Count >= 1)
                {
                    return Ok(lista);
                }
                else
                {
                    string mensaje = "No hay tipos guardados";
                    return BadRequest(mensaje);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw e;
            }            
        }




    }
}