using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarioDetalles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;
using Farsiman.Domain.Core.Standard.Common;
using IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class SalidasInventarioDetalleMap : IEntityTypeConfiguration<SalidasInventarioDetalle>
    {

        public void Configure(EntityTypeBuilder<SalidasInventarioDetalle> builder)
        {


            builder.HasKey(e => e.DetalleId).HasName("PK__SalidasI__6E19D6DAAAEF477B");

            builder.ToTable("SalidasInventarioDetalle");

            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");

            builder.HasOne(d => d.Lote).WithMany(p => p.SalidasInventarioDetalles)
                .HasForeignKey(d => d.LoteId)
                .HasConstraintName("FK__SalidasIn__LoteI__403A8C7D");

            builder.HasOne(d => d.SalidaInventario).WithMany(p => p.SalidasInventarioDetalles)
                .HasForeignKey(d => d.SalidaInventarioId)
                .HasConstraintName("FK__SalidasIn__Salid__3F466844");
        }
    }
}
