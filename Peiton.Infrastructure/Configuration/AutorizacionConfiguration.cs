using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class AutorizacionConfiguration : IEntityTypeConfiguration<Autorizacion>
{
	public void Configure(EntityTypeBuilder<Autorizacion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Autorizacion");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.FechaSolicitud).IsRequired().HasDefaultValueSql("(getdate())");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Autorizaciones)
			.HasForeignKey(d => d.TuteladoId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.Autorizaciones)
			.HasForeignKey(d => d.UsuarioId);*/

	}
}
