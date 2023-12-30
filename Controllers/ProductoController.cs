using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos;
using Microsoft.AspNetCore.Mvc;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        
            private readonly ProductoService _productoService;

            public ProductoController(ProductoService productoservice)
            {
            _productoService = productoservice;
            }

            [HttpGet("Listar")]
            public IActionResult Index()
            {
                var respuesta1 = _productoService.ListarProductos();

                return Ok(respuesta1);
            }

            [HttpGet("ObtenerLotesPorProducto")]
            public IActionResult ObtenerLotesPorProductos(int id)
            {
                var respuesta = _productoService.ObtenerLotesPorProducto(id);

                return Ok(respuesta);
            }

            [HttpPost("ActualizarRegistroLotePorProducto")]
            public IActionResult ActualizarRegistroLotePorProductos([FromBody] int productoId, int cantidadSolicitada)
            {
                var nuevoEstado = _productoService.ActualizarRegistroLotePorProducto(productoId, cantidadSolicitada);
                return Ok(nuevoEstado);
            }



            [HttpPost("Agregar")]
                public IActionResult AgregarProductos([FromBody] ProductoDto request)
                {
                    var nuevoProducto = _productoService.AgregarProducto(request);
                    return Ok(nuevoProducto);
                }


            [HttpPut("Editar")]
            public IActionResult EditarProductos(ProductoDto producto)
            {
                var respuesta = _productoService.EditarProducto(producto);
                return Ok(respuesta);
            }


            [HttpPut("Eliminar")]
            public IActionResult EliminarProductos(int Id)
            {
                var respuesta = _productoService.EliminarProducto(Id);

                return Ok(respuesta);
            }
    }
}
