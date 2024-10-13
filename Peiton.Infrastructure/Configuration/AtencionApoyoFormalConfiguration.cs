using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AtencionApoyoFormalConfiguration : IEntityTypeConfiguration<AtencionApoyoFormal>
{
	public void Configure(EntityTypeBuilder<AtencionApoyoFormal> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_AtencionApoyoFormal");
		builder.Property(p => p.Descripcion).HasMaxLength(50);
		builder.Property(p => p.ServicioApoyoFormalId).HasColumnName("Fk_ServicioApoyoFormal");

		/*builder.HasOne(d => d.ServicioApoyoFormal)
			.WithMany(p => p.AtencionesApoyosFormales)
			.HasForeignKey(d => d.ServicioApoyoFormalId);*/

	}
}
