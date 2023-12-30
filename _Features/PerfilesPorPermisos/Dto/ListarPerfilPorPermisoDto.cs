namespace AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Dto
{
    public class ListarPerfilPorPermisoDto
    {

        public int PerfilId { get; set; }

        public int PermisoId { get; set; }

        public bool Activo { get; set; }
    }
}
