using AcademiaFS.ProyectoInventario.WebApi._Common;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;
using FluentValidation;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Direccion { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }


    public class EmpleadoValidator : AbstractValidator<Empleado>
    {
        public EmpleadoValidator()
        {
            RuleFor(r => r.Nombre).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Nombre"));
            RuleFor(r => r.Apellido).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Apellido"));
            RuleFor(r => r.Direccion).NotEmpty().WithMessage(Mensajes.CAMPO_VACIO("Direccion"));
        }
    }
}
