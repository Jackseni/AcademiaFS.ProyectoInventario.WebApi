namespace AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Dto
{
    public class PerfilesPorPermisoDto
    {
        public int PerfilId { get; set; }

        public int PermisoId { get; set; }

        public bool Activo { get; set; }
        public int? CreadoPor { get; set; }

        public DateTime? CreadoEl { get; set; }

    }
}
