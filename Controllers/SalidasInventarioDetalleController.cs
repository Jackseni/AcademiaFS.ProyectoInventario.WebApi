using AcademiaFS.ProyectoInventario.WebApi._Features.Productos;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios;
using Microsoft.AspNetCore.Mvc;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Dto;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/SalidaInventarioDetalle")]
    [ApiController]
    public class SalidasInventarioDetalleController : ControllerBase
    {

        private readonly SalidasInventarioDetalleService _salidasDetalleService;

        public SalidasInventarioDetalleController(SalidasInventarioDetalleService Salidasdetalleservice)
        {
            _salidasDetalleService = Salidasdetalleservice;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _salidasDetalleService.ListarSalidasInventarioDetalle();

            return Ok(respuesta);
        }

        [HttpPost("Agregar")]
        public IActionResult AgregarSalidaInventariosDetalle([FromBody] SalidasInventarioDetalleDto request)
        {
            var nuevoProducto = _salidasDetalleService.AgregarSalidaInventarioDetalle(request);
            return Ok(nuevoProducto);
        }


        [HttpPut("Editar")]
        public IActionResult EditarSalidaInventariosDetalle(SalidasInventarioDetalleDto salidaInventarioDetalle)
        {
            var respuesta = _salidasDetalleService.EditarSalidaInventarioDetalle(salidaInventarioDetalle);
            return Ok(respuesta);
        }


        [HttpPut("Eliminar")]
        public IActionResult EliminarSalidaInventariosDetalle(int Id)
        {
            var respuesta = _salidasDetalleService.EliminarSalidaInventarioDetalle(Id);

            return Ok(respuesta);
        }

    }
}
