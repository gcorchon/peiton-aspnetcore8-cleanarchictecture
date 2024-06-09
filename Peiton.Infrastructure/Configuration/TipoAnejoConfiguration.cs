using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TipoAnejoConfiguration : IEntityTypeConfiguration<TipoAnejo>
	{
		public void Configure(EntityTypeBuilder<TipoAnejo> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoAnejo");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}