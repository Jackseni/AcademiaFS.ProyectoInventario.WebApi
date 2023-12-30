namespace AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Dto
{
    public class PermisoDto
    {

        public int PermisoId { get; set; }

        public string? Permiso1 { get; set; }

        public bool Activo { get; set; }

        public int? CreadoPor { get; set; }

        public DateTime? CreadoEl { get; set; }

    }
}
