using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AusenciaConfiguration : IEntityTypeConfiguration<Ausencia>
	{
		public void Configure(EntityTypeBuilder<Ausencia> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Ausencia");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.UsuarioSuplenteId).HasColumnName("Fk_UsuarioSuplente");

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.AusenciasUsuario)
				.HasForeignKey(d => d.UsuarioId);*/

			/*builder.HasOne(d => d.UsuarioSuplente)
				.WithMany(p => p.AusenciasUsuarioSuplente)
				.HasForeignKey(d => d.UsuarioSuplenteId);*/

		}
	}
}