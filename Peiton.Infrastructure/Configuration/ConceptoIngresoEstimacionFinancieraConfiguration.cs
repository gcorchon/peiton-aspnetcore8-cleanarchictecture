using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ConceptoIngresoEstimacionFinancieraConfiguration : IEntityTypeConfiguration<ConceptoIngresoEstimacionFinanciera>
{
	public void Configure(EntityTypeBuilder<ConceptoIngresoEstimacionFinanciera> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ConceptoIngresoEstimacionFinanciera");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
