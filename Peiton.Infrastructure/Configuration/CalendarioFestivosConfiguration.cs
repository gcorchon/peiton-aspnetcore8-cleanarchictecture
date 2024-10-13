using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CalendarioFestivosConfiguration : IEntityTypeConfiguration<CalendarioFestivos>
{
	public void Configure(EntityTypeBuilder<CalendarioFestivos> builder)
	{
		builder.HasKey(t => t.Fecha);

		builder.Property(p => p.Fecha).ValueGeneratedNever();

	}
}
