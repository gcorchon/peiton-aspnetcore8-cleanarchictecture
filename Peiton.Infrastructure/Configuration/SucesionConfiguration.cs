using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class SucesionConfiguration : IEntityTypeConfiguration<Sucesion>
	{
		public void Configure(EntityTypeBuilder<Sucesion> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_Sucesion");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.SucesionTipoId).HasColumnName("FK_SucesionTipo");
			builder.Property(p => p.Solicitada).IsRequired();
			builder.Property(p => p.Autorizada).IsRequired();
			builder.Property(p => p.Firme).IsRequired();
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");

			/*builder.HasOne(d => d.FKSucesionTipo)
				.WithMany(p => p.Sucesiones)
				.HasForeignKey(d => d.SucesionTipoId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.Sucesiones)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.Sucesiones)
				.HasForeignKey(d => d.UsuarioId);*/

		}
	}
}