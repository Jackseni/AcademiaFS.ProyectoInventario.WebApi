namespace AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Dto
{
    public class ListarEstadoDto
    {

        public int EstadoId { get; set; }

        public string? NombreEstado { get; set; }

        public bool Estado1 { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; } 
    }
}
