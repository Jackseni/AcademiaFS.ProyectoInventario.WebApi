using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos;
using Microsoft.AspNetCore.Mvc;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Permisos")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly PermisoService _permisoService;

        public PermisoController(PermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _permisoService.ListarPermisos();

            return Ok(respuesta);
        }

        
     

        [HttpPut("Editar")]
        public IActionResult Editar(PermisoDto perfil)
        {
            var respuesta = _permisoService.EditarPermiso(perfil);
            return Ok(respuesta);
        }


        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _permisoService.EliminarPermiso(Id);

            return Ok(respuesta);
        }
    }
}
