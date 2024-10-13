using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AppMovilActividadConfiguration : IEntityTypeConfiguration<AppMovilActividad>
{
	public void Configure(EntityTypeBuilder<AppMovilActividad> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AppMovilActividad");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.Icono).HasMaxLength(255);

	}
}
