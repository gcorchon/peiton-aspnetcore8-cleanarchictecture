using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TrabajadorSocialConfiguration : IEntityTypeConfiguration<TrabajadorSocial>
	{
		public void Configure(EntityTypeBuilder<TrabajadorSocial> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_TrabajadorSocial");
			builder.Property(p => p.Nombre).HasMaxLength(50);
			builder.Property(p => p.Clave).HasMaxLength(50);

		}
	}
}