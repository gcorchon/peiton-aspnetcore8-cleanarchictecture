using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CoordinadorSocialConfiguration : IEntityTypeConfiguration<CoordinadorSocial>
{
	public void Configure(EntityTypeBuilder<CoordinadorSocial> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_CoordinadorSocial");
		builder.Property(p => p.Nombre).HasMaxLength(100);

	}
}
