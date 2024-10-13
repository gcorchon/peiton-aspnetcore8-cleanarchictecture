using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipologiaApoyoInformalConfiguration : IEntityTypeConfiguration<TipologiaApoyoInformal>
{
	public void Configure(EntityTypeBuilder<TipologiaApoyoInformal> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipologiaApoyoInformal");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
