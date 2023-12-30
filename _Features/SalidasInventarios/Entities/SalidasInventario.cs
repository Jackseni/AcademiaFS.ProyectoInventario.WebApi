using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;
using FluentValidation;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities
{
    public class SalidasInventario
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

        public virtual ICollection<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; } = new List<SalidasInventarioDetalle>();


        public virtual Sucursale? Sucursal { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }

    public class InventarioValidator : AbstractValidator<SalidasInventario>
    {
        public InventarioValidator()
        {
           
            RuleFor(r => r.Total).NotEmpty().GreaterThan(0).LessThanOrEqualTo(5000);
        }
    }
}
