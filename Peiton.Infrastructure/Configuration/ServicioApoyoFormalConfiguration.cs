using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ServicioApoyoFormalConfiguration : IEntityTypeConfiguration<ServicioApoyoFormal>
{
	public void Configure(EntityTypeBuilder<ServicioApoyoFormal> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ServicioApoyoFormal");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.TipoServicioApoyoFormalId).HasColumnName("Fk_TipoServicioApoyoFormal");

		/*builder.HasOne(d => d.TipoServicioApoyoFormal)
			.WithMany(p => p.ServiciosApoyosFormales)
			.HasForeignKey(d => d.TipoServicioApoyoFormalId);*/

	}
}
