using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities
{
    public class Usuario
    {

        public int UsuarioId { get; set; }

        public int? EmpleadoId { get; set; }

        public int? PerfilId { get; set; }

        public string NombreUsuario { get; set; }

        public string? Contrasena { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual Empleado? Empleado { get; set; }

        public virtual Perfile? Perfil { get; set; }

        public virtual ICollection<SalidasInventario> SalidasInventarios { get; set; } = new List<SalidasInventario>();
    }
}
