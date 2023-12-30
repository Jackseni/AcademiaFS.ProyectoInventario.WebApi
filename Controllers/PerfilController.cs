using AcademiaFS.ProyectoInventario.WebApi._Features.Estados;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Perfil")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
      

            private readonly PerfileService _perfilService;

            public PerfilController(PerfileService perfilService)
            {
            _perfilService = perfilService;
            }

            [HttpGet("Listar")]
            public IActionResult Index()
            {
                var respuesta = _perfilService.ListarPerfiles();

                return Ok(respuesta);
            }

        [HttpPost("Agregar")]
        public IActionResult AgregarPerfil([FromBody] PerfileDto request)
        {
            var nuevoEstado = _perfilService.AgregarPerfil(request);
            return Ok(nuevoEstado);
        }


        [HttpPut("Editar")]
        public IActionResult Editar(PerfileDto perfil)
        {
            var respuesta = _perfilService.EditarPerfil(perfil);

            return Ok(respuesta);
        }


        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _perfilService.EliminarPerfil(Id);

            return Ok(respuesta);
        }

    }
}
