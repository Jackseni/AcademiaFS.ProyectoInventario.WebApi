using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities
{
    public class Sucursale
    {
        public int SucursalId { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<SalidasInventario> SalidasInventarios { get; set; } = new List<SalidasInventario>();
    }
}
