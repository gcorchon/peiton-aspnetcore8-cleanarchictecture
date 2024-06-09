using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ReferenteDFConfiguration : IEntityTypeConfiguration<ReferenteDF>
	{
		public void Configure(EntityTypeBuilder<ReferenteDF> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ReferenteDF");
			builder.Property(p => p.Descripcion).HasMaxLength(100);

		}
	}
}