using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class VoluntariadoConfiguration : IEntityTypeConfiguration<Voluntariado>
	{
		public void Configure(EntityTypeBuilder<Voluntariado> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Voluntariado");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.VoluntariadoTipoId).HasColumnName("Fk_VoluntariadoTipo");
			builder.Property(p => p.VoluntarioId).HasColumnName("Fk_Voluntario");

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.Voluntariados)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.VoluntariadosUsuario)
				.HasForeignKey(d => d.UsuarioId);*/

			/*builder.HasOne(d => d.Voluntario)
				.WithMany(p => p.VoluntariadosVoluntario)
				.HasForeignKey(d => d.VoluntarioId);*/

			/*builder.HasOne(d => d.VoluntariadoTipo)
				.WithMany(p => p.Voluntariados)
				.HasForeignKey(d => d.VoluntariadoTipoId);*/

		}
	}
}