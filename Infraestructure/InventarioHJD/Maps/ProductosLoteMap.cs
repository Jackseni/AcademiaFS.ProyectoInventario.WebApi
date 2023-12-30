using AcademiaFS.ProyectoInventario.WebApi._Features.Perfiles.Entities;
using AcademiaFS.ProyectoInventario.WebApi._Features.ProductosLotes.Entities;
using Farsiman.Domain.Core.Standard.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class ProductosLoteMap : IEntityTypeConfiguration<ProductosLote>
    {
        public void Configure(EntityTypeBuilder<ProductosLote> builder)
        {

            builder.HasKey(e => e.LoteId).HasName("PK__Producto__E6EAE698770E8719");

            builder.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.FechaVencimiento).HasColumnType("date");

            builder.HasOne(d => d.Producto).WithMany(p => p.ProductosLotes)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Productos__Produ__3C69FB99");

        }

    }
}
