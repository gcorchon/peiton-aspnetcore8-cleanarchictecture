using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class TuteladoDiagnosticoConfiguration : IEntityTypeConfiguration<TuteladoDiagnostico>
	{
		public void Configure(EntityTypeBuilder<TuteladoDiagnostico> builder)
		{
			builder.HasKey(t => new { t.TuteladoId, t.DiagnosticoId});

			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.DiagnosticoId).HasColumnName("Fk_Diagnostico");
			builder.Property(p => p.Principal).IsRequired();

			/*builder.HasOne(d => d.Diagnostico)
				.WithMany(p => p.TuteladosDiagnosticos)
				.HasForeignKey(d => d.DiagnosticoId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.TuteladosDiagnosticos)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}