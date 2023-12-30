using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            var respuesta = _usuarioService.Login(username, password);

            return Ok(respuesta);
        }


    }
}
