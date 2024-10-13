using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class TareaEstadoConfiguration : IEntityTypeConfiguration<TareaEstado>
{
	public void Configure(EntityTypeBuilder<TareaEstado> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_TareaEstado");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
