using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AgendaActuacionConfiguration : IEntityTypeConfiguration<AgendaActuacion>
{
	public void Configure(EntityTypeBuilder<AgendaActuacion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AgendaActuacion");
		builder.Property(p => p.Descripcion).HasMaxLength(250);
		builder.Property(p => p.AgendaAreaActuacionId).HasColumnName("Fk_AgendaAreaActuacion");

		/*builder.HasOne(d => d.AgendaAreaActuacion)
			.WithMany(p => p.EntradasActuaciones)
			.HasForeignKey(d => d.AgendaAreaActuacionId);*/

	}
}
