using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Estados.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {


            builder.HasKey(e => e.EstadoId).HasName("PK__Estados__FEF86B0058A43B48");
            builder.Property(e => e.Estado1).HasColumnName("Estado");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.NombreEstado)
                .HasMaxLength(100)
                .IsUnicode(false);


        }

    }
}
