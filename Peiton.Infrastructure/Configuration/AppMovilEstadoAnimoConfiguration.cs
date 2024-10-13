using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AppMovilEstadoAnimoConfiguration : IEntityTypeConfiguration<AppMovilEstadoAnimo>
{
	public void Configure(EntityTypeBuilder<AppMovilEstadoAnimo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_AppMovilEstadoAnimo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.Icono).HasMaxLength(255);

	}
}
