using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AdiccionComportamentalConfiguration : IEntityTypeConfiguration<AdiccionComportamental>
	{
		public void Configure(EntityTypeBuilder<AdiccionComportamental> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AdiccionComportamental");
			builder.Property(p => p.Descripcion).HasMaxLength(150);

		}
	}
}