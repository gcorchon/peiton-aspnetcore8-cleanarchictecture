using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ApoyoFormalConfiguration : IEntityTypeConfiguration<ApoyoFormal>
{
	public void Configure(EntityTypeBuilder<ApoyoFormal> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipoServicioApoyoFormalId).HasColumnName("Fk_TipoServicioApoyoFormal");
		builder.Property(p => p.ServicioApoyoFormalId).HasColumnName("Fk_ServicioApoyoFormal");
		builder.Property(p => p.AtencionApoyoFormalId).HasColumnName("Fk_AtencionApoyoFormal");
		builder.Property(p => p.EducadorSocialId).HasColumnName("Fk_EducadorSocial");
		builder.Property(p => p.Frecuencia).HasMaxLength(50);
		builder.Property(p => p.Coste).HasMaxLength(50);
		builder.Property(p => p.RelacionAMTAVisitaId).HasColumnName("Fk_RelacionAMTAVisita");
		builder.Property(p => p.RelacionAMTAContactoId).HasColumnName("Fk_RelacionAMTAContacto");
		builder.Property(p => p.CentroId).HasColumnName("Fk_Centro");
		builder.Property(p => p.TipoCentroDiaId).HasColumnName("Fk_TipoCentroDia");
		builder.Property(p => p.TipoFinanciacionId).HasColumnName("Fk_TipoFinanciacion");

		/*builder.HasOne(d => d.AtencionApoyoFormal)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.AtencionApoyoFormalId);*/

		/*builder.HasOne(d => d.EducadorSocial)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.EducadorSocialId);*/

		/*builder.HasOne(d => d.RelacionAMTAContacto)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.RelacionAMTAContactoId);*/

		/*builder.HasOne(d => d.RelacionAMTAVisita)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.RelacionAMTAVisitaId);*/

		/*builder.HasOne(d => d.ServicioApoyoFormal)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.ServicioApoyoFormalId);*/

		/*builder.HasOne(d => d.TipoServicioApoyoFormal)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.TipoServicioApoyoFormalId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.TuteladoId);*/

		/*builder.HasOne(d => d.Centro)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.CentroId);*/

		/*builder.HasOne(d => d.TipoCentroDia)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.TipoCentroDiaId);*/

		/*builder.HasOne(d => d.TipoFinanciacion)
			.WithMany(p => p.ApoyosFormales)
			.HasForeignKey(d => d.TipoFinanciacionId);*/

	}
}
