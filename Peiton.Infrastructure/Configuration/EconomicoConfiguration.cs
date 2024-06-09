using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EconomicoConfiguration : IEntityTypeConfiguration<Economico>
	{
		public void Configure(EntityTypeBuilder<Economico> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Economico");
			builder.Property(p => p.Nombre).HasMaxLength(50);
			builder.Property(p => p.Clave).HasMaxLength(50);
			builder.Property(p => p.Email).HasMaxLength(50);

		}
	}
}