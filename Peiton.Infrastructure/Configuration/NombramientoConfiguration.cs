using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class NombramientoConfiguration : IEntityTypeConfiguration<Nombramiento>
{
	public void Configure(EntityTypeBuilder<Nombramiento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Nombramiento");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.Procesar).IsRequired();
		builder.Property(p => p.CargoSalud).IsRequired();
		builder.Property(p => p.CargoEconomico).IsRequired();

	}
}
