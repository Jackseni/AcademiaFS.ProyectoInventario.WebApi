using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.Sucursales.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class SucursaleMap : IEntityTypeConfiguration<Sucursale>
    {
        public void Configure(EntityTypeBuilder<Sucursale> builder)
        {


            builder.HasKey(e => e.SucursalId).HasName("PK__Sucursal__6CB482E106B45F12");

            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

        }
    }
}
