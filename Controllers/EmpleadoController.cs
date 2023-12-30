using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados;
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Empleado")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _empleadoService.ListarEmpleados();

            return Ok(respuesta);
        }

        [HttpPost("Agregar")]
        public IActionResult AgregarEmpleados([FromBody] EmpleadoDto request)
        {
            var nuevoEmpleado = _empleadoService.AgregarEmpleado(request);
            return Ok(nuevoEmpleado);
        }


        [HttpPut("Editar")]
        public IActionResult Editar(EmpleadoDto empleado)
        {
            var respuesta = _empleadoService.EditarEmpleado(empleado);

            return Ok(respuesta);
        }

        
        [HttpPut("Eliminar")]
        public IActionResult Eliminar(int Id)
        {
            var respuesta = _empleadoService.EliminarEmpleado(Id);

            return Ok(respuesta);
        }


    }
}
