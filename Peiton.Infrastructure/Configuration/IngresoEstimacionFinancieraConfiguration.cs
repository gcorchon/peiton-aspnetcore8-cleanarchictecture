using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class IngresoEstimacionFinancieraConfiguration : IEntityTypeConfiguration<IngresoEstimacionFinanciera>
	{
		public void Configure(EntityTypeBuilder<IngresoEstimacionFinanciera> builder)
		{
			builder.HasKey(t => new { t.TuteladoId, t.Orden});

			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.ConceptoIngresoEstimacionFinancieraId).HasColumnName("Fk_ConceptoIngresoEstimacionFinanciera");
			builder.Property(p => p.TipoIngresoEstimacionFinancieraId).HasColumnName("Fk_TipoIngresoEstimacionFinanciera");
			builder.Property(p => p.OrganismoIngresoEstimacionFinancieraId).HasColumnName("Fk_OrganismoIngresoEstimacionFinanciera");
			builder.Property(p => p.Importe).HasColumnType("money");
			/*builder.HasOne(d => d.ConceptoIngresoEstimacionFinanciera)
				.WithMany(p => p.IngresosEstimacionesFinancieras)
				.HasForeignKey(d => d.ConceptoIngresoEstimacionFinancieraId);*/

			/*builder.HasOne(d => d.OrganismoIngresoEstimacionFinanciera)
				.WithMany(p => p.IngresosEstimacionesFinancieras)
				.HasForeignKey(d => d.OrganismoIngresoEstimacionFinancieraId);*/

			/*builder.HasOne(d => d.TipoIngresoEstimacionFinanciera)
				.WithMany(p => p.IngresosEstimacionesFinancieras)
				.HasForeignKey(d => d.TipoIngresoEstimacionFinancieraId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.IngresosEstimacionesFinancieras)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}