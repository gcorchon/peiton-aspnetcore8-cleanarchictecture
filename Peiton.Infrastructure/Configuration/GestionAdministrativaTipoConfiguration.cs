using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class GestionAdministrativaTipoConfiguration : IEntityTypeConfiguration<GestionAdministrativaTipo>
{
	public void Configure(EntityTypeBuilder<GestionAdministrativaTipo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(c => c.Id).HasColumnName("Pk_GestionAdministrativaTipo");
		builder.Property(c => c.Descripcion).HasColumnName("Descripcion").HasMaxLength(255).IsRequired();
	}
}
