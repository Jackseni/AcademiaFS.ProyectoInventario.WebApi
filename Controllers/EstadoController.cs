using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados;
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Estado")]
    [ApiController]
    public class EstadoController : Controller
    {


        private readonly EstadoService _estadoService;

        public EstadoController(EstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _estadoService.ListarEstados();

            return Ok(respuesta);
        }

        [HttpPost("Agregar")]
        public IActionResult AgregarEstados([FromBody] EstadoDto request)
        {
            var nuevoEstado = _estadoService.AgregarEstado(request);
            return Ok(nuevoEstado);
        }


        [HttpPut("Editar")]
        public IActionResult Editar(EstadoDto estado)
        {
            var respuesta = _estadoService.EditarEstado(estado);

            return Ok(respuesta);
        }


        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _estadoService.EliminarEstado(Id);

            return Ok(respuesta);
        }
    }
}
