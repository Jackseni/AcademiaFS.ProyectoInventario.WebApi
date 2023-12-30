
using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Productos.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;
using AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps;
using Microsoft.EntityFrameworkCore;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD
{
    public partial class InventarioHjdContext : DbContext
    {

        public InventarioHjdContext()
        {
        }

        public InventarioHjdContext(DbContextOptions<InventarioHjdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        public virtual DbSet<Perfile> Perfiles { get; set; }

        public virtual DbSet<PerfilesPorPermiso> PerfilesPorPermisos { get; set; }

        public virtual DbSet<Permiso> Permisos { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<ProductosLote> ProductosLotes { get; set; }

        public virtual DbSet<SalidasInventario> SalidasInventarios { get; set; }

        public virtual DbSet<SalidasInventarioDetalle> SalidasInventarioDetalles { get; set; }

        public virtual DbSet<Sucursale> Sucursales { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseSqlServer("Server=192.168.1.33\\\\\\\\academiagfs,49194;Database=InventarioHJD;User ID=academiadev;password=Demia#20;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpleadoMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new PerfilesPorPermisoMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new PermisoMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new ProductosLoteMap());
            modelBuilder.ApplyConfiguration(new SalidasInventarioDetalleMap());
            modelBuilder.ApplyConfiguration(new SalidasInventarioMap());
            modelBuilder.ApplyConfiguration(new SucursaleMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

        
    
}
