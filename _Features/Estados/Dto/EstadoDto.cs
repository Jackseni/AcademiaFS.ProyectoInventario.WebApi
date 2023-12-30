namespace AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Dto
{
    public class EstadoDto
    {

        public int EstadoId { get; set; }

        public string? NombreEstado { get; set; }

        public bool Estado { get; set; } = true;

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }= DateTime.Now;

    


    }
}
