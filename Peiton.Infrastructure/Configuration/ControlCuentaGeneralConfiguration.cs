using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class ControlCuentaGeneralConfiguration : IEntityTypeConfiguration<ControlCuentaGeneral>
	{
		public void Configure(EntityTypeBuilder<ControlCuentaGeneral> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_ControlCuentaGeneral");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.TipoCGJId).HasColumnName("Fk_TipoCGJ");
			builder.Property(p => p.JuzgadoArchivadoId).HasColumnName("Fk_JuzgadoArchivado");
			builder.Property(p => p.NombramientoArchivadoId).HasColumnName("Fk_NombramientoArchivado");
			builder.Property(p => p.JuzgadoPresentadaId).HasColumnName("Fk_JuzgadoPresentada");
			builder.Property(p => p.NombramientoPresentadaId).HasColumnName("Fk_NombramientoPresentada");
			builder.Property(p => p.MotivoMuertoId).HasColumnName("Fk_MotivoMuerto");
			builder.Property(p => p.EstadoAprobacionCGJId).HasColumnName("Fk_EstadoAprobacionCGJ");
			builder.Property(p => p.RazonDenegacionCGJId).HasColumnName("Fk_RazonDenegacionCGJ");
			builder.Property(p => p.ArchivoCGJId).HasColumnName("Fk_ArchivoCGJ");
			builder.Property(p => p.ArchivoAprobacionId).HasColumnName("Fk_ArchivoAprobacion");

			/*builder.HasOne(d => d.EstadoAprobacionCGJ)
				.WithMany(p => p.ControlesCuentasGenerales)
				.HasForeignKey(d => d.EstadoAprobacionCGJId);*/

			/*builder.HasOne(d => d.MotivoMuerto)
				.WithMany(p => p.ControlesCuentasGenerales)
				.HasForeignKey(d => d.MotivoMuertoId);*/

			/*builder.HasOne(d => d.RazonDenegacionCGJ)
				.WithMany(p => p.ControlesCuentasGenerales)
				.HasForeignKey(d => d.RazonDenegacionCGJId);*/

			/*builder.HasOne(d => d.TipoCGJ)
				.WithMany(p => p.ControlesCuentasGenerales)
				.HasForeignKey(d => d.TipoCGJId);*/

			/*builder.HasOne(d => d.ArchivoAprobacion)
				.WithMany(p => p.ControlesCuentasGeneralesArchivoAprobacion)
				.HasForeignKey(d => d.ArchivoAprobacionId);*/

			/*builder.HasOne(d => d.ArchivoCGJ)
				.WithMany(p => p.ControlesCuentasGeneralesArchivoCGJ)
				.HasForeignKey(d => d.ArchivoCGJId);*/

			/*builder.HasOne(d => d.JuzgadoArchivado)
				.WithMany(p => p.ControlesCuentasGeneralesJuzgadoArchivado)
				.HasForeignKey(d => d.JuzgadoArchivadoId);*/

			/*builder.HasOne(d => d.JuzgadoPresentada)
				.WithMany(p => p.ControlesCuentasGeneralesJuzgadoPresentada)
				.HasForeignKey(d => d.JuzgadoPresentadaId);*/

			/*builder.HasOne(d => d.NombramientoArchivado)
				.WithMany(p => p.ControlesCuentasGeneralesNombramientoArchivado)
				.HasForeignKey(d => d.NombramientoArchivadoId);*/

			/*builder.HasOne(d => d.NombramientoPresentada)
				.WithMany(p => p.ControlesCuentasGeneralesNombramientoPresentada)
				.HasForeignKey(d => d.NombramientoPresentadaId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.ControlesCuentasGenerales)
				.HasForeignKey(d => d.TuteladoId);*/

		}
	}
}