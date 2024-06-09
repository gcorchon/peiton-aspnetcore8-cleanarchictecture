using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
	{
		public void Configure(EntityTypeBuilder<Agenda> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Agenda");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.CategoriaAgendaId).HasColumnName("Fk_CategoriaAgenda");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.AgendaActuacionId).HasColumnName("Fk_AgendaActuacion");
			builder.Property(p => p.AgendaAreaActuacionId).HasColumnName("Fk_AgendaAreaActuacion");
			builder.Property(p => p.Desacuerdo).IsRequired();

			/*builder.HasOne(d => d.AgendaAreaActuacion)
				.WithMany(p => p.Entradas)
				.HasForeignKey(d => d.AgendaAreaActuacionId);*/

			/*builder.HasOne(d => d.CategoriaAgenda)
				.WithMany(p => p.Entradas)
				.HasForeignKey(d => d.CategoriaAgendaId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.Entradas)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.Entradas)
				.HasForeignKey(d => d.UsuarioId);*/

			/*builder.HasOne(d => d.AgendaActuacion)
				.WithMany(p => p.Entradas)
				.HasForeignKey(d => d.AgendaActuacionId);*/

		}
	}
}