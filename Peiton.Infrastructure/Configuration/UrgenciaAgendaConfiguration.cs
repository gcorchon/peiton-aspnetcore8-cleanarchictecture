using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class UrgenciaAgendaConfiguration : IEntityTypeConfiguration<UrgenciaAgenda>
{
	public void Configure(EntityTypeBuilder<UrgenciaAgenda> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_UrgenciaAgenda");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.CategoriaAgendaId).HasColumnName("Fk_CategoriaAgenda");
		builder.Property(p => p.UrgenciaId).HasColumnName("Fk_Urgencia");
		builder.Property(p => p.AgendaActuacionId).HasColumnName("Fk_AgendaActuacion");
		builder.Property(p => p.AgendaAreaActuacionId).HasColumnName("Fk_AgendaAreaActuacion");
		builder.Property(p => p.Desacuerdo).IsRequired();

		/*builder.HasOne(d => d.AgendaActuacion)
			.WithMany(p => p.UrgenciasEntradas)
			.HasForeignKey(d => d.AgendaActuacionId);*/

		/*builder.HasOne(d => d.AgendaAreaActuacion)
			.WithMany(p => p.UrgenciasEntradas)
			.HasForeignKey(d => d.AgendaAreaActuacionId);*/

		/*builder.HasOne(d => d.CategoriaAgenda)
			.WithMany(p => p.UrgenciasEntradas)
			.HasForeignKey(d => d.CategoriaAgendaId);*/

		/*builder.HasOne(d => d.Urgencia)
			.WithMany(p => p.UrgenciasEntradas)
			.HasForeignKey(d => d.UrgenciaId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.UrgenciasEntradas)
			.HasForeignKey(d => d.UsuarioId);*/

	}
}
