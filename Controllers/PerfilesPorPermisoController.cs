using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/PerfilPorPermiso")]
    [ApiController]
    public class PerfilesPorPermisoController : ControllerBase
    {
        private readonly PerfilesPorPermisoService _perfilService;

        public PerfilesPorPermisoController(PerfilesPorPermisoService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _perfilService.ListarPerfilesPorPermiso();

            return Ok(respuesta);
        }

        [HttpPost("Agregar")]
        public IActionResult AgregarPerfil([FromBody] PerfilesPorPermisoDto request)
        {
            var nuevoEstado = _perfilService.AgregarPerfilPorPermiso(request);
            return Ok(nuevoEstado);
        }


        [HttpPut("Editar")]
        public IActionResult Editar(PerfilesPorPermisoDto perfil)
        {
            var respuesta = _perfilService.EditarPerfilPorPermiso(perfil);

            return Ok(respuesta);
        }


        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _perfilService.EliminarPerfilPorPermiso(Id);

            return Ok(respuesta);
        }

    }
}
