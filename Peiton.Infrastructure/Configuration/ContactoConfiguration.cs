using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ContactoConfiguration : IEntityTypeConfiguration<Contacto>
{
	public void Configure(EntityTypeBuilder<Contacto> builder)
	{
		builder.HasKey(t => new { t.TuteladoId, t.Orden, t.Tipo });

		builder.Property(p => p.TuteladoId).HasColumnName("Fk_Tutelado");
		builder.Property(p => p.Tipo).HasMaxLength(0);
		builder.Property(p => p.Nombre).HasMaxLength(100);
		builder.Property(p => p.Telefono).HasMaxLength(100);
		builder.Property(p => p.email).HasMaxLength(255);
		builder.Property(p => p.ContactoRelacionId).HasColumnName("Fk_ContactoRelacion");

		/*builder.HasOne(d => d.ContactoRelacion)
			.WithMany(p => p.Contactos)
			.HasForeignKey(d => d.ContactoRelacionId);*/

		builder.HasOne(d => d.Tutelado)
			.WithMany(p => p.Contactos)
			.HasForeignKey(d => d.TuteladoId);

	}
}
