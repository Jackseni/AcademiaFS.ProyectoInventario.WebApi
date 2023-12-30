namespace AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }

        public int? EmpleadoId { get; set; }

        public int? PerfilId { get; set; }

        public string? NombreUsuario { get; set; }

        public string? Contrasena { get; set; }

        public bool Estado { get; set; }
    }
}
