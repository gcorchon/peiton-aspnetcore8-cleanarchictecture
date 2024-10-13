using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class EventoConfiguration : IEntityTypeConfiguration<Evento>
{
	public void Configure(EntityTypeBuilder<Evento> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Evento");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.Lugar).HasMaxLength(255);
		builder.Property(p => p.CategoriaAgendaId).HasColumnName("Fk_CategoriaAgenda");
		builder.Property(p => p.AgendaAreaActuacionId).HasColumnName("Fk_AgendaAreaActuacion");
		builder.Property(p => p.AgendaActuacionId).HasColumnName("Fk_AgendaActuacion");
		builder.Property(p => p.AgendaId).HasColumnName("Fk_Agenda");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.RecordatorioId).HasColumnName("Fk_Recordatorio");
		builder.Property(p => p.Recordado).IsRequired();
		builder.Property(p => p.EventoId).HasColumnName("Fk_Evento");
		builder.Property(p => p.Repetido).IsRequired();

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.Eventos)
			.HasForeignKey(d => d.UsuarioId);*/

		/*builder.HasOne(d => d.Agenda)
			.WithMany(p => p.Eventos)
			.HasForeignKey(d => d.AgendaId);*/

		/*builder.HasOne(d => d.AgendaActuacion)
			.WithMany(p => p.Eventos)
			.HasForeignKey(d => d.AgendaActuacionId);*/

		/*builder.HasOne(d => d.AgendaAreaActuacion)
			.WithMany(p => p.Eventos)
			.HasForeignKey(d => d.AgendaAreaActuacionId);*/

		/*builder.HasOne(d => d.CategoriaAgenda)
			.WithMany(p => p.Eventos)
			.HasForeignKey(d => d.CategoriaAgendaId);*/

		/*builder.HasOne(d => d.EventoPadre)
			.WithMany(p => p.Eventos)
			.HasForeignKey(d => d.EventoId);*/

		/*builder.HasOne(d => d.Recordatorio)
			.WithMany(p => p.Eventos)
			.HasForeignKey(d => d.RecordatorioId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Eventos)
			.HasForeignKey(d => d.TuteladoId);*/

	}
}
