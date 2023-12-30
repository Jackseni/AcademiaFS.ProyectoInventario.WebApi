using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Entities
{
    public class Producto
    {

        public int ProductoId { get; set; }

        public string? Nombre { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<ProductosLote> ProductosLotes { get; set; } = new List<ProductosLote>();
    }
}
