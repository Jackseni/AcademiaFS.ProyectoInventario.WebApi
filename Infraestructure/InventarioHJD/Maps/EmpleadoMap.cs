using AcademiaFS.ProyectoInventario.WebApi._Features.Empleados.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AcademiaFS.ProyectoInventario.WebApi.Infraestructure.InventarioHJD.Maps
{
    public class EmpleadoMap : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {


            builder.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE9104C1D4D52");

            builder.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            builder.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
           

        }


    }
}
