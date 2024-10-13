using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class FrecuenciaApoyoInformalConfiguration : IEntityTypeConfiguration<FrecuenciaApoyoInformal>
{
	public void Configure(EntityTypeBuilder<FrecuenciaApoyoInformal> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_FrecuenciaApoyoInformal");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
