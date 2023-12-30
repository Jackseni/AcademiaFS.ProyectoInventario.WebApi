using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.SalidasInventarios.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class SalidasInventarioMap : IEntityTypeConfiguration<SalidasInventario>
    {

        public void Configure(EntityTypeBuilder<SalidasInventario> builder)
        {

            builder.HasKey(e => e.SalidaInventarioId).HasName("PK__SalidasI__6F7AE0D9B734351D");
            builder.ToTable("SalidasInventario");

            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.FechaRecibido).HasColumnType("date");
            builder.Property(e => e.FechaSalida).HasColumnType("date");
            builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.EstadoNavigation).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__SalidasIn__Estad__37A5467C");

            builder.HasOne(d => d.Sucursal).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK__SalidasIn__Sucur__35BCFE0A");

            builder.HasOne(d => d.Usuario).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__SalidasIn__Usuar__36B12243");

        }
    }
}
