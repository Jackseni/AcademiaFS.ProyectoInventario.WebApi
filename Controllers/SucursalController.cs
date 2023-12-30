using AcademiaFS.ProyectoInventario.WebApi._Features.Productos;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaFS.ProyectoInventario.WebApi.Controllers
{
    //[Authorize]
    [Route("api/Sucursal")]
    [ApiController]
    public class SucursalController : Controller
    {

        private readonly SucursalService _sucursalService;

        public SucursalController(SucursalService sucursalservice)
        {
            _sucursalService = sucursalservice;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _sucursalService.ListarSucursales();

            return Ok(respuesta);
        }

        [HttpPost("Agregar")]
        public IActionResult AgregarProductos([FromBody] SucursalDto request)
        {
            var nuevoProducto = _sucursalService.AgregarSucursal(request);
            return Ok(nuevoProducto);
        }


        [HttpPut("Editar")]
        public IActionResult EditarProductos(SucursalDto producto)
        {
            var respuesta = _sucursalService.EditarSucursal(producto);
            return Ok(respuesta);
        }


        [HttpPut("Eliminar")]
        public IActionResult EliminarProductos(int Id)
        {
            var respuesta = _sucursalService.EliminarSucursal(Id);

            return Ok(respuesta);
        }

    }
}
