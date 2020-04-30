using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaApi.Models;
using EmpresaDominio.Entidades.Negocio;
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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaServicio _empresaServicio;
        public EmpresaController(IEmpresaServicio empresaServicio)
        {
            _empresaServicio = empresaServicio;
        }


        [HttpPost("crear")]
        public async Task<IActionResult> crear([FromBody] EmpresaModel model)
        {
            var empresa = await _empresaServicio.crear(new Empresa()
            {
                Id = Guid.Parse(model.Id),
                Nit = model.Nit,
                RazonSocial = model.RazonSocial                
            });
            if (empresa != null)
            {
                return Ok(empresa);
            }
            else
            {
                return BadRequest("Error creando la empresa");
            }
        }

        [HttpGet("obtenerTodos")]
        [AllowAnonymous]
        public async Task<IActionResult> obtenerTodos()
        {
            var lista = await _empresaServicio.obtenerTodos();
            if (lista.Count >= 1)
            {
                return Ok(lista);
            }
            else
            {
                return BadRequest("No hay empresas guardados");
            }
        }

        [HttpGet("obtenerPorId")]
        public async Task<IActionResult> obtenerPorId(string id)
        {
            Guid idEmpresa = Guid.Parse(id);
            var empresa = await _empresaServicio.obtenerPorId(idEmpresa);
            if (empresa != null)
            {
                return Ok(empresa);
            }
            return NotFound();
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> actualizar([FromBody] EmpresaModel model)
        {
            var empresa = await _empresaServicio.actualizar(new Empresa()
            {
                Id = Guid.Parse(model.Id),
                Nit = model.Nit,
                RazonSocial = model.RazonSocial
            });
            if (empresa != null)
            {
                return Ok(empresa);
            }
            else
            {
                return BadRequest("Error creando la empresa");
            }
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> eliminar(string id)
        {
            Guid idEmpresa = Guid.Parse(id);
            var resultado = await _empresaServicio.eliminar(idEmpresa);
            if (resultado)
            {
                string mensaje = "Empresa eliminada";
                return Ok(mensaje);
            }
            else
            {
                string mensaje = "Ocurrio un error al eliminar la empresa";
                return BadRequest(mensaje);
            }
        }

    }
}