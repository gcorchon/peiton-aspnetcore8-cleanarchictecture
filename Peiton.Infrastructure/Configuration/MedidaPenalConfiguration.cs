using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class MedidaPenalConfiguration : IEntityTypeConfiguration<MedidaPenal>
{
	public void Configure(EntityTypeBuilder<MedidaPenal> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.JuzgadoId).HasColumnName("Fk_Juzgado");
		builder.Property(p => p.NumeroProcedimiento).HasMaxLength(50);
		builder.Property(p => p.MedidaPenalTipoId).HasColumnName("Fk_MedidaPenalTipo");
		builder.Property(p => p.MedidaPenalNaturalezaId).HasColumnName("Fk_MedidaPenalNaturaleza");
		builder.Property(p => p.MedidaPenalMedidaId).HasColumnName("Fk_MedidaPenalMedida");
		builder.Property(p => p.Suspendida).IsRequired();

		/*builder.HasOne(d => d.Juzgado)
			.WithMany(p => p.MedidasPenales)
			.HasForeignKey(d => d.JuzgadoId);*/

		/*builder.HasOne(d => d.MedidaPenalMedida)
			.WithMany(p => p.MedidasPenales)
			.HasForeignKey(d => d.MedidaPenalMedidaId);*/

		/*builder.HasOne(d => d.MedidaPenalNaturaleza)
			.WithMany(p => p.MedidasPenales)
			.HasForeignKey(d => d.MedidaPenalNaturalezaId);*/

		/*builder.HasOne(d => d.MedidaPenalTipo)
			.WithMany(p => p.MedidasPenales)
			.HasForeignKey(d => d.MedidaPenalTipoId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.MedidasPenales)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
