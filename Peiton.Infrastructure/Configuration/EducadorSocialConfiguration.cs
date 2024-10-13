using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EducadorSocialConfiguration : IEntityTypeConfiguration<EducadorSocial>
{
	public void Configure(EntityTypeBuilder<EducadorSocial> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_EducadorSocial");
		builder.Property(p => p.Nombre).HasMaxLength(100);

	}
}
