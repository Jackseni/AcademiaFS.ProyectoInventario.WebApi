using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Entities
{
    public class Permiso
    {
        public int PermisoId { get; set; }

        public string? Permiso1 { get; set; }

        public bool Activo { get; set; }

        public int? CreadoPor { get; set; }

        public DateTime? CreadoEl { get; set; }

        public int? ModificadoPor { get; set; }

        public DateTime? ModificadoEl { get; set; }

        public virtual ICollection<PerfilesPorPermiso> PerfilesPorPermisos { get; set; } = new List<PerfilesPorPermiso>();
    }
}
