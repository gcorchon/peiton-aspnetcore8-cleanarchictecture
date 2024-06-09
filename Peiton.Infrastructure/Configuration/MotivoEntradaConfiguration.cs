using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class MotivoEntradaConfiguration : IEntityTypeConfiguration<MotivoEntrada>
	{
		public void Configure(EntityTypeBuilder<MotivoEntrada> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_MotivoEntrada");
			builder.Property(p => p.Descripcion).HasMaxLength(250);

		}
	}
}