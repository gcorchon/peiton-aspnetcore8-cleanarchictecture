using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AppMovilVoluntarioConfiguration : IEntityTypeConfiguration<AppMovilVoluntario>
{
	public void Configure(EntityTypeBuilder<AppMovilVoluntario> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AppMovilVoluntario");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
