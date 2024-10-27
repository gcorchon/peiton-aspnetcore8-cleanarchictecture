using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class GestionAdministrativaConfiguration : IEntityTypeConfiguration<GestionAdministrativa>
{
	public void Configure(EntityTypeBuilder<GestionAdministrativa> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(c => c.Id).HasColumnName("Pk_GestionAdministrativa");
		builder.Property(c => c.UsuarioId).HasColumnName("Fk_Usuario").IsRequired();
		builder.Property(c => c.GestionAdministrativaTipoId).HasColumnName("Fk_GestionAdministrativaTipo").IsRequired();
		builder.Property(c => c.GestorAdministrativoId).HasColumnName("Fk_GestorAdministrativo");
		builder.Property(c => c.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(c => c.Importe).HasColumnType("money");

	}
}
