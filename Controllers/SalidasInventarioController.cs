using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{


    //[Authorize]
    [Route("api/SalidaInventario")]
    [ApiController]
    public class SalidasInventarioController : Controller
    {


        private readonly SalidasInventarioService _salidaInventarioService;

        public SalidasInventarioController(SalidasInventarioService salidaInventarioServiceService)
        {
            _salidaInventarioService = salidaInventarioServiceService;
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar(ListarSalidasInventarioDto inventario)
        {
            var respuesta = _salidaInventarioService.InsertarSalidaInventario(inventario);

            return Ok(respuesta);
        }


        [HttpGet("Reporte/{fechaInicio}/{fechaFinal}")]
        public IActionResult Reporte(DateTime fechaInicio, DateTime fechaFinal)
        {
            var respuesta = _salidaInventarioService.ReporteInventario(fechaInicio, fechaFinal);

            return Ok(respuesta);
        }

        [HttpGet("ListarInventarioSucursalxId")]
        public IActionResult ReportInventarioPorSucursalId(int sucursalId)
        {
            var respuesta = _salidaInventarioService.ReporteInventarioPorId(sucursalId);
            return Ok(respuesta);
        }

        [HttpPost("Agregar")]
        public IActionResult AgregarSalidaInventarios([FromBody] SalidasInventarioDto request)
        {
            var nuevoProducto = _salidaInventarioService.AgregarSalidaInventario(request);
            return Ok(nuevoProducto);
        }


        [HttpPut("Editar")]
        public IActionResult EditarSalidaInventarios(SalidasInventarioDto salidaInventario)
        {
            var respuesta = _salidaInventarioService.EditarSalidaInventario(salidaInventario);
            return Ok(respuesta);
        }


        [HttpPut("Eliminar")]
        public IActionResult EliminarSalidaInventarios(int Id)
        {
            var respuesta = _salidaInventarioService.EliminarSalidaInventario(Id);

            return Ok(respuesta);
        }

    }
}
