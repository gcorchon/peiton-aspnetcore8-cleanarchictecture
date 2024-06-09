using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TareaAgendaConfiguration : IEntityTypeConfiguration<TareaAgenda>
	{
		public void Configure(EntityTypeBuilder<TareaAgenda> builder)
		{
			builder.HasKey(t => new { t.TuteladoId, t.Orden});

			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.TareasEntradas)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}