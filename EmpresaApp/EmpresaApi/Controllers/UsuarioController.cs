using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmpresaDominio.Entidades.Negocio;
using EmpresaDominio.Entidades.Seguridad;
using EmpresaDominio.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmpresaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly ITipoIdentificacionServicio _tipoIdentificacionServicio;

        public UsuarioController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ITipoIdentificacionServicio tipoIdentificacionServicio, IUsuarioServicio usuarioServicio)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _usuarioServicio = usuarioServicio;
        }

        [HttpPost("Crear")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> crear([FromBody]UserInfo model)
        {
            try
            {
                var existe = await _usuarioServicio.existeUsuarioPorEmail(model.Email);
                var usuario = await _userManager.FindByEmailAsync(model.Email);
                if (usuario != null || existe)
                {
                    string mensaje = $"El usuario con el correo: {model.Email}, ya existe.";
                    return BadRequest(mensaje);
                }

                var applicationUser = new ApplicationUser { Id = Guid.NewGuid(), UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(applicationUser, model.PassWord);
                if (result.Succeeded)
                {
                    await _usuarioServicio.crear(new Usuario()
                    {
                        Id = applicationUser.Id,
                        Apellido = model.Apellido,
                        CorreoElectronico = model.Email,
                        EmpresaId = model.EmpresaId,
                        Nombre = model.Nombre,
                        TipoIdentificacionId = model.TipoIdentificacionId,
                        NumeroIdentificacion = model.NumeroIdentificacion
                    });
                    return Ok(BuildToken(model));
                }
                else
                {
                    return BadRequest("Usuario o contraseña invalidos");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw (e);
            }
        }        

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody]UserInfo userInfo)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.PassWord, true, true);
                if (result.Succeeded)
                {
                    var usuario = await _userManager.FindByEmailAsync(userInfo.Email);
                    return BuildToken(userInfo);
                }
                else
                {
                    string mensaje = $"El correo: {userInfo.Email} o la contraseña estan incorrectas";
                    return BadRequest(mensaje);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw (e);
            }            
        }

        [HttpGet("obtenerTodos")] 
        public async Task<IActionResult> obtenerTodos()
        {
            try
            {
                var lista = await _usuarioServicio.obtenerTodos();
                if (lista.Count >= 1)
                {
                    return Ok(lista);
                }
                else
                {
                    string mensaje = "No hay usuarios creados";
                    return BadRequest(mensaje);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw (e);
            }            
        }

        [HttpGet("obtenerPorId")]
        [AllowAnonymous]
        public async Task<IActionResult> obtenerPorId(string id)
        {
            Guid idU = Guid.Parse(id);
            var usuario = await _usuarioServicio.obtenerPorId(idU);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet("obtenerPorEmpresa")]
        public async Task<IActionResult> obtenerPorEmpresa(string id)
        {
            Guid idEmpresa = Guid.Parse(id);
            var lista = await _usuarioServicio.obtenerPorEmpresaId(idEmpresa);
            if (lista.Count >= 1)
            {
                return Ok(lista);
            }
            else
            {
                string mensaje = "No hay usuarios asociados a esa empresa";
                return BadRequest(mensaje);
            }
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> actualizar(UserInfo modelo)
        {
            var usuario = await _usuarioServicio.actualizar(new Usuario()
            {
                Id = modelo.Id,
                Apellido = modelo.Apellido,
                CorreoElectronico = modelo.Email,
                EmpresaId = modelo.EmpresaId,
                Nombre = modelo.Nombre,
                TipoIdentificacionId = modelo.TipoIdentificacionId,
                NumeroIdentificacion = modelo.NumeroIdentificacion
            });
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                string mensaje = $"No se pudo actualizar al usuario: {modelo.Nombre} {modelo.Apellido}";
                return BadRequest(mensaje);
            }
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> eliminar(string id)
        {
            Guid idUsuario = Guid.Parse(id);
            var resultado = await _usuarioServicio.eliminar(idUsuario);
            if (resultado)
            {
                var appUser = await _userManager.FindByIdAsync(id);
                var result = await _userManager.DeleteAsync(appUser);
                if (result.Succeeded)
                {
                    string mensaje = "Usuario borrado correctamente";
                    return Ok(mensaje);
                }
                else
                {
                    string mensaje = "Ocurrio un error al borrar el usario";
                    return BadRequest(mensaje);
                }
            }
            else
            {
                string mensaje = "Ocurrio un error al borrar el usario";
                return BadRequest(mensaje);
            }
        }

        private UserToken BuildToken(UserInfo user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Tiempo de expiracion del token
            var expiration = DateTime.UtcNow.AddMonths(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }




    }
}