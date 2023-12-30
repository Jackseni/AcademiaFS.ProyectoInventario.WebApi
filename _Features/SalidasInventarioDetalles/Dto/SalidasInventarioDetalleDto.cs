namespace AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Dto
{
    public class SalidasInventarioDetalleDto
    {
        public int DetalleId { get; set; }


        public int? SalidaInventarioId { get; set; }

        public int? LoteId { get; set; }

        public int CantidadProducto { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }


    }
}
