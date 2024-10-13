using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class QuejaConfiguration : IEntityTypeConfiguration<Queja>
{
	public void Configure(EntityTypeBuilder<Queja> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_Queja");
		builder.Property(p => p.QuejaTipoId).HasColumnName("Fk_QuejaTipo");
		builder.Property(p => p.Expediente).HasMaxLength(20);
		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.QuejaTipoDenuncianteId).HasColumnName("Fk_QuejaTipoDenunciante");
		builder.Property(p => p.UsuarioId).HasColumnName("Fk_Usuario");
		builder.Property(p => p.DiasTranscurridos).HasComputedColumnSql("(case when [FechaCierre] IS NULL then NULL else datediff(day,[FechaEntrada],[FechaCierre]) end)", false);
		builder.Property(p => p.NombreDenunciante).HasMaxLength(100);
		builder.Property(p => p.DNIDenunciante).HasMaxLength(20);
		builder.Property(p => p.QuejaTipoCierreId).HasColumnName("Fk_QuejaTipoCierre");
		builder.Property(p => p.numero).HasMaxLength(20);
		builder.Property(p => p.UsuarioResponsableId).HasColumnName("Fk_UsuarioResponsable");
		builder.Property(p => p.Documento).HasMaxLength(512);

		/*builder.HasOne(d => d.QuejaTipo)
			.WithMany(p => p.Quejas)
			.HasForeignKey(d => d.QuejaTipoId);*/

		/*builder.HasOne(d => d.QuejaTipoCierre)
			.WithMany(p => p.Quejas)
			.HasForeignKey(d => d.QuejaTipoCierreId);*/

		/*builder.HasOne(d => d.QuejaTipoDenunciante)
			.WithMany(p => p.Quejas)
			.HasForeignKey(d => d.QuejaTipoDenuncianteId);*/

		/*builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Quejas)
			.HasForeignKey(d => d.TuteladoId);*/

		/*builder.HasOne(d => d.Usuario)
			.WithMany(p => p.QuejasUsuario)
			.HasForeignKey(d => d.UsuarioId);*/

		/*builder.HasOne(d => d.UsuarioResponsable)
			.WithMany(p => p.QuejasUsuarioResponsable)
			.HasForeignKey(d => d.UsuarioResponsableId);*/

	}
}
