using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TuteladoRelacionConvivencionalConfiguration : IEntityTypeConfiguration<TuteladoRelacionConvivencional>
	{
		public void Configure(EntityTypeBuilder<TuteladoRelacionConvivencional> builder)
		{
			builder.HasKey(t => new { t.TuteladoId, t.Orden});

			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.ConQuien).HasMaxLength(255);
			builder.Property(p => p.TipoRelacionConvivencionalId).HasColumnName("Fk_TipoRelacionConvivencional");

			/*builder.HasOne(d => d.TipoRelacionConvivencional)
				.WithMany(p => p.TuteladosRelacionesConvivencionales)
				.HasForeignKey(d => d.TipoRelacionConvivencionalId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.TuteladosRelacionesConvivencionales)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}