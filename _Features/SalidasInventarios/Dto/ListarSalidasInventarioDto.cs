using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Dto;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto
{
    public class ListarSalidasInventarioDto
    {
        public int? SalidaInventarioId { get; set; }
        public int SucursalId { get; set; }

        public int UsuarioId { get; set; }

        public DateTime FechaSalida { get; set; }

        public decimal Total { get; set; }

        public DateTime? FechaRecibido { get; set; }

        public int? EstadoId { get; set; }

        public bool Estado { get; set; }
        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public  List<InventarioDetalleListarDto>SalidasInventarioDetalles { get; set; } 

    }
}
