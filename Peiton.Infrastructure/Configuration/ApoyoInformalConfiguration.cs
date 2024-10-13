using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ApoyoInformalConfiguration : IEntityTypeConfiguration<ApoyoInformal>
{
	public void Configure(EntityTypeBuilder<ApoyoInformal> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.TipologiaApoyoInformalId).HasColumnName("Fk_TipologiaApoyoInformal");
		builder.Property(p => p.Parentesco).HasMaxLength(50);
		builder.Property(p => p.Nombre).HasMaxLength(255);
		builder.Property(p => p.RelacionApoyoInformalId).HasColumnName("Fk_RelacionApoyoInformal");
		builder.Property(p => p.FrecuenciaApoyoInformalId).HasColumnName("Fk_FrecuenciaApoyoInformal");
		builder.Property(p => p.Conflictiva).IsRequired();

		/*builder.HasOne(d => d.FrecuenciaApoyoInformal)
			.WithMany(p => p.ApoyosInformales)
			.HasForeignKey(d => d.FrecuenciaApoyoInformalId);*/

		/*builder.HasOne(d => d.RelacionApoyoInformal)
			.WithMany(p => p.ApoyosInformales)
			.HasForeignKey(d => d.RelacionApoyoInformalId);*/

		/*builder.HasOne(d => d.TipologiaApoyoInformal)
			.WithMany(p => p.ApoyosInformales)
			.HasForeignKey(d => d.TipologiaApoyoInformalId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.ApoyosInformales)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
