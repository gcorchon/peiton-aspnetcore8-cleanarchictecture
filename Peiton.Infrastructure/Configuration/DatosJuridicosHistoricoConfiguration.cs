using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class DatosJuridicosHistoricoConfiguration : IEntityTypeConfiguration<DatosJuridicosHistorico>
{
	public void Configure(EntityTypeBuilder<DatosJuridicosHistorico> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_DatosJuridicosHistorico");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.JuzgadoId).HasColumnName("Fk_Juzgado");
		builder.Property(p => p.ProcedimientoId).HasColumnName("Fk_Procedimiento");
		builder.Property(p => p.NumeroProcedimiento).HasMaxLength(50);
		builder.Property(p => p.NombramientoId).HasColumnName("Fk_Nombramiento");
		builder.Property(p => p.PartidoJudicialInhibicionId).HasColumnName("Fk_PartidoJudicialInhibicion");
		builder.Property(p => p.Nombramiento2Id).HasColumnName("Fk_Nombramiento2");
		builder.Property(p => p.NivelIntensidadId).HasColumnName("Fk_NivelIntensidad");
		builder.Property(p => p.PartidoJudicialId).HasColumnName("Fk_PartidoJudicial");
		builder.Property(p => p.OrigenExpedienteId).HasColumnName("Fk_OrigenExpediente");
		builder.Property(p => p.SentenciaRevisada).IsRequired();
		builder.Property(p => p.LeyNombramientoId).HasColumnName("Fk_LeyNombramiento").IsRequired();
		builder.Property(p => p.EsCuratelaAsistencial).IsRequired();
		builder.Property(p => p.EsCuratelaRepresentativa).IsRequired();
		builder.Property(p => p.SolicitanteRevisionId).HasColumnName("Fk_SolicitanteRevision");
		builder.Property(p => p.GradoApoyoId).HasColumnName("Fk_GradoApoyo");
		builder.Property(p => p.NoPresentarRendicion).IsRequired();
		builder.Property(p => p.NuevoInventarioRevision).IsRequired();
		builder.Property(p => p.RendicionFinalRevision).IsRequired();
		builder.Property(p => p.PresentarLexnet).IsRequired();
		builder.Property(p => p.NoPresentarInventario).IsRequired();
		builder.Property(p => p.LimiteGastoExtraOrdinario).HasColumnType("money");
		/*builder.HasOne(d => d.Juzgado)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.JuzgadoId);*/

		/*builder.HasOne(d => d.NivelIntensidad)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.NivelIntensidadId);*/

		/*builder.HasOne(d => d.Nombramiento)
			.WithMany(p => p.DatosJuridicosHistoricosNombramiento)
			.HasForeignKey(d => d.NombramientoId);*/

		/*builder.HasOne(d => d.Nombramiento2)
			.WithMany(p => p.DatosJuridicosHistoricosNombramiento2)
			.HasForeignKey(d => d.Nombramiento2Id);*/

		/*builder.HasOne(d => d.PartidoJudicialInhibicion)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.PartidoJudicialInhibicionId);*/

		/*builder.HasOne(d => d.Procedimiento)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.ProcedimientoId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.TuteladoId);*/

		/*builder.HasOne(d => d.GradoApoyo)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.GradoApoyoId);*/

		/*builder.HasOne(d => d.LeyNombramiento)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.LeyNombramientoId);*/

		/*builder.HasOne(d => d.OrigenExpediente)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.OrigenExpedienteId);*/

		/*builder.HasOne(d => d.PartidoJudicial)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.PartidoJudicialId);*/

		/*builder.HasOne(d => d.SolicitanteRevision)
			.WithMany(p => p.DatosJuridicosHistoricos)
			.HasForeignKey(d => d.SolicitanteRevisionId);*/

	}
}
