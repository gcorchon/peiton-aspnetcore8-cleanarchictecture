using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration
{
    public class AvisoTributarioConfiguration : IEntityTypeConfiguration<AvisoTributario>
	{
		public void Configure(EntityTypeBuilder<AvisoTributario> builder)
		{
			builder.HasKey(t => t.Id);

			builder.Property(p => p.Id).HasColumnName("Pk_AvisoTributario");
			builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
			builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
			builder.Property(p => p.TipoAvisoTributarioId).HasColumnName("Fk_TipoAvisoTributario");
			builder.Property(p => p.InmuebleId).HasColumnName("Fk_Inmueble");
			builder.Property(p => p.Fecha).IsRequired().HasDefaultValueSql("(getdate())");
			builder.Property(p => p.Resuelto).IsRequired();
			builder.Property(p => p.EnTramite).IsRequired();

			/*builder.HasOne(d => d.Inmueble)
				.WithMany(p => p.AvisosTributarios)
				.HasForeignKey(d => d.InmuebleId);*/

			/*builder.HasOne(d => d.TipoAvisoTributario)
				.WithMany(p => p.AvisosTributarios)
				.HasForeignKey(d => d.TipoAvisoTributarioId);*/

			/*builder.HasOne(d => d.Tutelado)
				.WithMany(p => p.AvisosTributarios)
				.HasForeignKey(d => d.TuteladoId);*/

			/*builder.HasOne(d => d.Usuario)
				.WithMany(p => p.AvisosTributarios)
				.HasForeignKey(d => d.UsuarioId);*/

		}
	}
}