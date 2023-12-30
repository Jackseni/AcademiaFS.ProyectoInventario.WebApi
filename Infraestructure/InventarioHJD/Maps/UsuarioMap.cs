
using AcademiaFS.ProyectoInventario.WebApi._Features.Usuarios.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B875923781");

            builder.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.NombreUsuario)
                .HasMaxLength(255)
            .IsUnicode(false);

            builder.HasOne(d => d.Empleado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Usuarios__Emplea__300424B4");

            builder.HasOne(d => d.Perfil).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PerfilId)
                .HasConstraintName("FK__Usuarios__Perfil__30F848ED");

        }

    }
}
