namespace AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Dto
{
    public class EmpleadoDto
    {
        public int EmpleadoId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Direccion { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; } = DateTime.Now;

    }
}
