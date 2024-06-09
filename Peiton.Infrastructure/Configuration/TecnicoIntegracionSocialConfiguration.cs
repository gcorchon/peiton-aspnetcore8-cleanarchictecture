using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TecnicoIntegracionSocialConfiguration : IEntityTypeConfiguration<TecnicoIntegracionSocial>
	{
		public void Configure(EntityTypeBuilder<TecnicoIntegracionSocial> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TecnicoIntegracionSocial");
			builder.Property(p => p.Nombre).HasMaxLength(100);

		}
	}
}