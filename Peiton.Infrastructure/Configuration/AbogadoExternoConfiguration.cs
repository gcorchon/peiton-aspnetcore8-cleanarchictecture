using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AbogadoExternoConfiguration : IEntityTypeConfiguration<AbogadoExterno>
{
	public void Configure(EntityTypeBuilder<AbogadoExterno> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AbogadoExterno");
		builder.Property(p => p.Nombre).HasMaxLength(50);

	}
}
