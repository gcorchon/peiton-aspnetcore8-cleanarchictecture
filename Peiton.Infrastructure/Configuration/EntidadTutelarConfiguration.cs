using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class EntidadTutelarConfiguration : IEntityTypeConfiguration<EntidadTutelar>
	{
		public void Configure(EntityTypeBuilder<EntidadTutelar> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_EntidadTutelar");
			builder.Property(p => p.Descripcion).HasMaxLength(255);
			builder.Property(p => p.CIF).HasMaxLength(50);

		}
	}
}