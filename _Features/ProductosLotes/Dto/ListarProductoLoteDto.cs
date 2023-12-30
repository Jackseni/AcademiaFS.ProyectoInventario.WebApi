namespace AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Dto
{
    public class ListarProductoLoteDto
    {
        public int LoteId { get; set; }

        public int? ProductoId { get; set; }

        public int CantidadInicial { get; set; }

        public decimal Costo { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public int Inventario { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }
    }
}
