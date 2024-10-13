using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoIngresoEstimacionFinancieraConfiguration : IEntityTypeConfiguration<TipoIngresoEstimacionFinanciera>
{
	public void Configure(EntityTypeBuilder<TipoIngresoEstimacionFinanciera> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TipoIngresoEstimacionFinanciera");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.ConceptoIngresoEstimacionFinancieraId).HasColumnName("Fk_ConceptoIngresoEstimacionFinanciera");

		/*builder.HasOne(d => d.ConceptoIngresoEstimacionFinanciera)
			.WithMany(p => p.TiposIngresosEstimacionesFinancieras)
			.HasForeignKey(d => d.ConceptoIngresoEstimacionFinancieraId);*/

	}
}
