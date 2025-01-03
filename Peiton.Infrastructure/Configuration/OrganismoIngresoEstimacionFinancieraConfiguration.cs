using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class OrganismoIngresoEstimacionFinancieraConfiguration : IEntityTypeConfiguration<OrganismoIngresoEstimacionFinanciera>
{
	public void Configure(EntityTypeBuilder<OrganismoIngresoEstimacionFinanciera> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_OrganismoIngresoEstimacionFinanciera");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
