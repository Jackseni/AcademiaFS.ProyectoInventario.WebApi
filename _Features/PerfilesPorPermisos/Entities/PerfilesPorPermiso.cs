using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Entities
{
    public class PerfilesPorPermiso
    {
        public int PerfilId { get; set; }

        public int PermisoId { get; set; }

        public bool Activo { get; set; }

        public int? CreadoPor { get; set; }

        public DateTime? CreadoEl { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? ModificadoEl { get; set; }

        public virtual Perfile Perfil { get; set; } = null!;

        public virtual Permiso Permiso { get; set; } = null!;
    }
}
