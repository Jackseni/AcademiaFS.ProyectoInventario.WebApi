using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;

namespace AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities
{
    public class Perfile
    {

        public int PerfilId { get; set; }

        public string? Nombre { get; set; }

        public bool Activo { get; set; } = true;

        public int? CreadoPor { get; set; }

        public DateTime? CreadoEl { get; set; } = DateTime.Now;

        public int? ModificadoPor { get; set; }

        public DateTime? ModificadoEl { get; set; }

        public virtual ICollection<PerfilesPorPermiso> PerfilesPorPermisos { get; set; } = new List<PerfilesPorPermiso>();

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();


      

            public const string JEFE_DE_BODEGA = "Realizar Salidas";
            public const string PROCESO_FALLIDO = "Error. Intente más tarde";
            public const string DATOS_INCORRECTOS = "Los datos se han enviado de forma incorrecta. Revise llaves foráneas, constraints, nulos, etc";
        

    }
}
