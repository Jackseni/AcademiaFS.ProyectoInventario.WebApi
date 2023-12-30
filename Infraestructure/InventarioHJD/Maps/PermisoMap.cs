using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Permisos.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {

            builder.HasKey(e => e.PermisoId).HasName("PK__Permisos__96E0C72360914AB5");

            builder.Property(e => e.CreadoEl).HasColumnType("date");
            builder.Property(e => e.ModificadoEl).HasColumnType("date");
            builder.Property(e => e.Permiso1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Permiso");

        }

    }
}
