namespace AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Dto
{
    public class ListaProductoDto
    {
        public int ProductoId { get; set; }

        public string? Nombre { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
