using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Dto
{
    public class SalidasInventarioDto
    {
        public int SalidaInventarioId { get; set; }

        public int SucursalId { get; set; }

        public int UsuarioId { get; set; }

        public DateTime FechaSalida { get; set; }

        public decimal Total { get; set; }

        public DateTime? FechaRecibido { get; set; }

        public int? UsuarioIdRecibe { get; set; }

        public int? EstadoId { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual Estado? EstadoNavigation { get; set; }


    }
}
