using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class GestorAdministrativoConfiguration : IEntityTypeConfiguration<GestorAdministrativo>
{
	public void Configure(EntityTypeBuilder<GestorAdministrativo> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(c => c.Id).HasColumnName("Pk_GestorAdministrativo");
		builder.Property(c => c.Nombre).HasColumnName("Nombre").HasMaxLength(50).IsRequired();
		builder.Property(c => c.Apellidos).HasColumnName("Apellidos").HasMaxLength(50).IsRequired();
		builder.Property(c => c.Domicilio).HasColumnName("Domicilio").HasMaxLength(50).IsRequired();
		builder.Property(c => c.Localidad).HasColumnName("Localidad").IsRequired();
		builder.Property(c => c.CodigoPostal).HasColumnName("CodigoPostal").HasMaxLength(5).IsRequired();
		builder.Property(c => c.Provincia).HasColumnName("Provincia").HasMaxLength(50).IsRequired();
		builder.Property(c => c.Telefono1).HasColumnName("Telefono1").HasMaxLength(20);
		builder.Property(c => c.Telefono2).HasColumnName("Telefono2").HasMaxLength(20);
		builder.Property(c => c.Telefono3).HasColumnName("Telefono3").HasMaxLength(20);
		builder.Property(c => c.Email).HasColumnName("Email").HasMaxLength(255).IsRequired();
	}
}
