using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class InformeMensualConfiguration : IEntityTypeConfiguration<InformeMensual>
{
	public void Configure(EntityTypeBuilder<InformeMensual> builder)
	{
		builder.HasKey(t => t.Fecha);

		builder.Property(p => p.Fecha).ValueGeneratedNever();

	}
}
