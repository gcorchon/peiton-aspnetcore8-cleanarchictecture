using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class GastoEstimacionFinancieraConfiguration : IEntityTypeConfiguration<GastoEstimacionFinanciera>
{
	public void Configure(EntityTypeBuilder<GastoEstimacionFinanciera> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.ConceptoGastoEstimacionFinancieraId).HasColumnName("Fk_ConceptoGastoEstimacionFinanciera");
		builder.Property(p => p.FormaPagoGastoEstimacionFinancieraId).HasColumnName("Fk_FormaPagoGastoEstimacionFinanciera");
		builder.Property(p => p.Frecuencia).HasMaxLength(255);
		builder.Property(p => p.Importe).HasColumnType("money");

		/*builder.HasOne(d => d.ConceptoGastoEstimacionFinanciera)
			.WithMany(p => p.GastosEstimacionesFinancieras)
			.HasForeignKey(d => d.ConceptoGastoEstimacionFinancieraId);*/

		/*builder.HasOne(d => d.FormaPagoGastoEstimacionFinanciera)
			.WithMany(p => p.GastosEstimacionesFinancieras)
			.HasForeignKey(d => d.FormaPagoGastoEstimacionFinancieraId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.GastosEstimacionesFinancieras)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
