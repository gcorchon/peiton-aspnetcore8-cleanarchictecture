using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class InmuebleSolicitudAlquilerVentaConfiguration : IEntityTypeConfiguration<InmuebleSolicitudAlquilerVenta>
{
	public void Configure(EntityTypeBuilder<InmuebleSolicitudAlquilerVenta> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_InmuebleSolicitudAlquilerVenta");
		builder.Property(p => p.InmuebleId).HasColumnName("Fk_Inmueble");
		builder.Property(p => p.Nombre).HasMaxLength(50);
		builder.Property(p => p.Contacto).HasMaxLength(50);
		builder.Property(p => p.OcupacionId).HasColumnName("Fk_Ocupacion");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.Estado).IsRequired();
		builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.Tipo).HasMaxLength(50);

		/*builder.HasOne(d => d.Inmueble)
			.WithMany(p => p.InmueblesSolicitudesAlquileresVentas)
			.HasForeignKey(d => d.InmuebleId);*/

		/*builder.HasOne(d => d.Ocupacion)
			.WithMany(p => p.InmueblesSolicitudesAlquileresVentas)
			.HasForeignKey(d => d.OcupacionId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.InmueblesSolicitudesAlquileresVentas)
			.HasForeignKey(d => d.UsuarioId);*/

	}
}
