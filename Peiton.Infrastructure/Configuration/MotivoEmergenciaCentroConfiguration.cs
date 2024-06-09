using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class MotivoEmergenciaCentroConfiguration : IEntityTypeConfiguration<MotivoEmergenciaCentro>
	{
		public void Configure(EntityTypeBuilder<MotivoEmergenciaCentro> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_MotivoEmergenciaCentro");
			builder.Property(p => p.Descripcion).HasMaxLength(255);

		}
	}
}