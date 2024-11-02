using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class SucursalConfiguration : IEntityTypeConfiguration<Sucursal>
{
	public void Configure(EntityTypeBuilder<Sucursal> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Sucursal");
		builder.Property(p => p.EntidadFinancieraId).HasColumnName("Fk_EntidadFinanciera");
		builder.Property(p => p.Numero).HasMaxLength(2);
		builder.Property(p => p.CodigoPostal).HasMaxLength(2);
		builder.Property(p => p.Direccion).HasMaxLength(255);
		builder.Property(p => p.Ciudad).HasMaxLength(50);
		builder.Property(p => p.Provincia).HasMaxLength(50);
		builder.Property(p => p.Telefono).HasMaxLength(50);

		/*builder.HasOne(d => d.EntidadFinanciera)
			.WithMany(p => p.Sucursales)
			.HasForeignKey(d => d.EntidadFinancieraId);*/

	}
}
