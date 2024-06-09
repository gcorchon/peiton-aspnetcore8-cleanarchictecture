using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class PartidoJudicialConfiguration : IEntityTypeConfiguration<PartidoJudicial>
	{
		public void Configure(EntityTypeBuilder<PartidoJudicial> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_PartidoJudicial");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}