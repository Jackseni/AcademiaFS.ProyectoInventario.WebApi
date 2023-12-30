using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities
{
    public class SalidasInventarioDetalle
    {
        public int DetalleId { get; set; }

        public int? SalidaInventarioId { get; set; }

        public int? LoteId { get; set; }

        public int CantidadProducto { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual ProductosLote? Lote { get; set; }

        public virtual SalidasInventario? SalidaInventario { get; set; }
    }
}
