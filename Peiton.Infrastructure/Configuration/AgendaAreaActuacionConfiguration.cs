using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AgendaAreaActuacionConfiguration : IEntityTypeConfiguration<AgendaAreaActuacion>
{
	public void Configure(EntityTypeBuilder<AgendaAreaActuacion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AgendaAreaActuacion");
		builder.Property(p => p.Descripcion).HasMaxLength(255);

	}
}
