using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities
{
    public class Estado
    {
        public int EstadoId { get; set; }

        public string? NombreEstado { get; set; }

        public bool Estado1 { get; set; } = true;

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<SalidasInventario> SalidasInventarios { get; set; } = new List<SalidasInventario>();
    }
}
