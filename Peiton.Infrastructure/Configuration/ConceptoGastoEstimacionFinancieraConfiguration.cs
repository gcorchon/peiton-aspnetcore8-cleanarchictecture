using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ConceptoGastoEstimacionFinancieraConfiguration : IEntityTypeConfiguration<ConceptoGastoEstimacionFinanciera>
	{
		public void Configure(EntityTypeBuilder<ConceptoGastoEstimacionFinanciera> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ConceptoGastoEstimacionFinanciera");
			builder.Property(p => p.Descripcion).HasMaxLength(50);

		}
	}
}