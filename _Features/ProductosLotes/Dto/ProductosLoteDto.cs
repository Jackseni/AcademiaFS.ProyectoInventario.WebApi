namespace AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto
{
    public class ProductosLoteDto
    {
        public int LoteId { get; set; }

        public int ProductoId { get; set; }

        public int CantidadInicial { get; set; }

        public decimal Costo { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public int Inventario { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }
        public bool lotes { get; set; }

        public int InventarioDisponible { get; internal set; }
        public string InnventarioDisponible { get; internal set; }
    }
}
