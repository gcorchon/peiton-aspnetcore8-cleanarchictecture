using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ActividadConfiguration : IEntityTypeConfiguration<Actividad>
{
	public void Configure(EntityTypeBuilder<Actividad> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_Actividad");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
