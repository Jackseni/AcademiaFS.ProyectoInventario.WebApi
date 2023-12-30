namespace AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Dto
{
    public class ListarSalidasInventarioDetalleDto
    {
        public int DetalleId { get; set; }

        public int? SalidaInventarioId { get; set; }

        public int? LoteId { get; set; }

        public int CantidadProducto { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }
    }
}
