namespace AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Dto
{
    public class SucursalDto
    {
        public int SucursalId { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
