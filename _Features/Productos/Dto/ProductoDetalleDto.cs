using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Dto;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto
{
    public class ProductoDetalleDto
    {
        internal int cantidadSolicitada;

        public int ProductoId { get; set; }

        public string? Nombre { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string InnventarioDisponible { get; set; }


        public bool lotes {  get; set; }

        public virtual ICollection<ProductosLote> ProductosLotes { get; set; } = new List<ProductosLote>();


    }
}
