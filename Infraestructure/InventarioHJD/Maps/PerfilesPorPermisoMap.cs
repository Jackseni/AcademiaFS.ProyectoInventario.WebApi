using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class PerfilesPorPermisoMap : IEntityTypeConfiguration<PerfilesPorPermiso>
    {
        public void Configure(EntityTypeBuilder<PerfilesPorPermiso> builder)
        {


            builder.HasKey(e => new { e.PerfilId, e.PermisoId }).HasName("PK__Perfiles__256E577418121DEC");

            builder.Property(e => e.CreadoEl).HasColumnType("date");
            builder.Property(e => e.ModificadoEl).HasColumnType("date");

            builder.HasOne(d => d.Perfil).WithMany(p => p.PerfilesPorPermisos)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PerfilesP__Perfi__2C3393D0");

            builder.HasOne(d => d.Permiso).WithMany(p => p.PerfilesPorPermisos)
                .HasForeignKey(d => d.PermisoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PerfilesP__Permi__2D27B809");

        }

    }
}
