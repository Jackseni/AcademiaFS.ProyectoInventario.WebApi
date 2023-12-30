namespace AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Dto
{
    public class PerfileDto
    {
        public int PerfilId { get; set; }

        public string? Nombre { get; set; }

        public bool Activo { get; set; } = true;

        public int CreadoPor { get; set; }

        public DateTime? CreadoEl { get; set; } = DateTime.Now;
    }
}
