using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.PerfilesPorPermisos.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class PerfilMap : IEntityTypeConfiguration<Perfile>
    {

        public void Configure(EntityTypeBuilder<Perfile> builder)
        {


            builder.HasKey(e => e.PerfilId).HasName("PK__Perfiles__0C005B0673F8E4E0");

            builder.Property(e => e.CreadoEl).HasColumnType("date");
            builder.Property(e => e.ModificadoEl).HasColumnType("date");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

        }

    }
}
