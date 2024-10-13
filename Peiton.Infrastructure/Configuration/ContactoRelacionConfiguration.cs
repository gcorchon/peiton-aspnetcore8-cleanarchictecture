using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class ContactoRelacionConfiguration : IEntityTypeConfiguration<ContactoRelacion>
{
	public void Configure(EntityTypeBuilder<ContactoRelacion> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).HasColumnName("Pk_ContactoRelacion");
		builder.Property(p => p.Descripcion).HasMaxLength(100);

	}
}
