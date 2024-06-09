using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class UrgenciaConfiguration : IEntityTypeConfiguration<Urgencia>
	{
		public void Configure(EntityTypeBuilder<Urgencia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Urgencia");
			builder.Property(p => p.NumeroExpediente).HasMaxLength(12);
			builder.Property(p => p.Nombre).HasMaxLength(100);
			builder.Property(p => p.Apellido1).HasMaxLength(50);
			builder.Property(p => p.Apellido2).HasMaxLength(50);
			builder.Property(p => p.Apellidos).HasComputedColumnSql("([Apellido1]+case when [Apellido2] IS NOT NULL AND [Apellido2]<>'' then ' '+[Apellido2] else '' end)", false);
			builder.Property(p => p.DNI).HasMaxLength(50);
			builder.Property(p => p.UrgenciaOrigenId).HasColumnName("Fk_UrgenciaOrigen");
			builder.Property(p => p.UrgenciaTipoId).HasColumnName("Fk_UrgenciaTipo");
			builder.Property(p => p.JuzgadoId).HasColumnName("Fk_Juzgado");
			builder.Property(p => p.TrabajadorSocialId).HasColumnName("Fk_TrabajadorSocial");
			builder.Property(p => p.AbogadoId).HasColumnName("Fk_Abogado");
			builder.Property(p => p.EconomicoId).HasColumnName("Fk_Economico");
			builder.Property(p => p.ProcedimientoId).HasColumnName("Fk_Procedimiento");
			builder.Property(p => p.NumeroProcedimiento).HasMaxLength(50);
			builder.Property(p => p.FechaCreacion).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.NombreCompleto).HasComputedColumnSql("((([nombre]+' ')+[apellido1])+case when [apellido2] IS NOT NULL AND [apellido2]<>'' then ' '+[apellido2] else '' end)", false);
			builder.Property(p => p.FiscaliaId).HasColumnName("Fk_Fiscalia");
			builder.Property(p => p.OrigenOtros).HasMaxLength(255);
			builder.Property(p => p.UrgenciaTipoEspecimenId).HasColumnName("Fk_UrgenciaTipoEspecimen");
			builder.Property(p => p.Muerto).IsRequired();
			builder.Property(p => p.MotivoMuertoUrgenciaId).HasColumnName("Fk_MotivoMuertoUrgencia");

			/*builder.HasOne(d => d.Abogado)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.AbogadoId);*/

			/*builder.HasOne(d => d.Economico)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.EconomicoId);*/

			/*builder.HasOne(d => d.Fiscalia)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.FiscaliaId);*/

			/*builder.HasOne(d => d.Juzgado)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.JuzgadoId);*/

			/*builder.HasOne(d => d.MotivoMuertoUrgencia)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.MotivoMuertoUrgenciaId);*/

			/*builder.HasOne(d => d.Procedimiento)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.ProcedimientoId);*/

			/*builder.HasOne(d => d.TrabajadorSocial)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.TrabajadorSocialId);*/

			/*builder.HasOne(d => d.UrgenciaOrigen)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.UrgenciaOrigenId);*/

			/*builder.HasOne(d => d.UrgenciaTipo)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.UrgenciaTipoId);*/

			/*builder.HasOne(d => d.UrgenciaTipoEspecimen)
				.WithMany(p => p.Urgencias)
				.HasForeignKey(d => d.UrgenciaTipoEspecimenId);*/

		}
	}
}