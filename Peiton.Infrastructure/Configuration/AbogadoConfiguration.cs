using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AbogadoConfiguration : IEntityTypeConfiguration<Abogado>
{
	public void Configure(EntityTypeBuilder<Abogado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Abogado");
		builder.Property(p => p.Nombre).HasMaxLength(50);
		builder.Property(p => p.Login).HasMaxLength(50);
		builder.Property(p => p.Senalamientos).IsRequired();
		builder.Property(p => p.NumeroColegiado).HasMaxLength(50);

	}
}
