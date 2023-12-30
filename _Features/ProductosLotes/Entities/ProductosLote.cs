using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities
{
    public class ProductosLote
    {

        public int LoteId { get; set; }

        public int ProductoId { get; set; }

        public int CantidadInicial { get; set; }

        public decimal Costo { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public int Inventario { get; set; }

        public bool Estado { get; set; }

        public int InventarioDisponible { get; set; }


        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual Producto? Producto { get; set; }

        public virtual ICollection<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; } = new List<SalidasInventarioDetalle>();
    
   }
}
