using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TuteladoAllegadoConfiguration : IEntityTypeConfiguration<TuteladoAllegado>
	{
		public void Configure(EntityTypeBuilder<TuteladoAllegado> builder)
		{
			builder.HasKey(t => new { t.TuteladoId, t.AllegadoId, t.Orden});

			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.AllegadoId).HasColumnName("Fk_Allegado");
			builder.Property(p => p.Orden);
			builder.Property(p => p.RelacionAllegadoId).HasColumnName("Fk_RelacionAllegado");
			builder.Property(p => p.Numero).HasMaxLength(10);

			/*builder.HasOne(d => d.Allegado)
				.WithMany(p => p.TuteladosAllegados)
				.HasForeignKey(d => d.AllegadoId);*/

			/*builder.HasOne(d => d.RelacionAllegado)
				.WithMany(p => p.TuteladosAllegados)
				.HasForeignKey(d => d.RelacionAllegadoId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.TuteladosAllegados)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}