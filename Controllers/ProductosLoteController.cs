using AcademiaFS.ProyectoInventario.WebApi._Features.Productos;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{

    //[Authorize]
    [Route("api/LoteProductos")]
    [ApiController]
    public class ProductosLoteController : ControllerBase
    {
        private readonly ProductosLoteService _productoLoteService;

        public ProductosLoteController(ProductosLoteService productoLoteservice)
        {
            _productoLoteService = productoLoteservice;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _productoLoteService.ListarProductosLote();

            return Ok(respuesta);
        }

        [HttpGet("ObtenerLotePorFehaVencimiento")]
        public IActionResult Index1(int productoId)
        {
            var respuesta = _productoLoteService.ObtenerLotePorFehaVencimiento(productoId);

            return Ok(respuesta);
        }

        [HttpPost("Agregar")]
        public IActionResult AgregarProductosLote([FromBody] ProductosLoteDto request)
        {
            var nuevoProducto = _productoLoteService.AgregarProductoLote(request);
            return Ok(nuevoProducto);
        }



        [HttpPut("Editar")]
        public IActionResult EditarProductosLote(ProductosLoteDto productoLote)
        {
            var respuesta = _productoLoteService.EditarProductoLote(productoLote);
            return Ok(respuesta);
        }


        [HttpPut("Eliminar")]
        public IActionResult EliminarProductosLote(int Id)
        {
            var respuesta = _productoLoteService.EliminarProductoLote(Id);

            return Ok(respuesta);
        }
    }
}
