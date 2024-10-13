using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TipoObjetivoConfiguration : IEntityTypeConfiguration<TipoObjetivo>
{
	public void Configure(EntityTypeBuilder<TipoObjetivo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_TipoObjetivo");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.MostrarEnAppMovil).IsRequired();

	}
}
