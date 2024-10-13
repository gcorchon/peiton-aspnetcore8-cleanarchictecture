using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
	public void Configure(EntityTypeBuilder<Cita> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Cita");
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.FechaCreacion).IsRequired().HasDefaultValueSql("(getdate())");

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Citas)
			.HasForeignKey(d => d.TuteladoId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.Citas)
			.HasForeignKey(d => d.UsuarioId);*/

	}
}
