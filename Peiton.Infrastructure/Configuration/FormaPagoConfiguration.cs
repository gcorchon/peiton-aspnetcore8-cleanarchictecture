using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peiton.Core.Entities;

namespace Peiton.Data.Configuration;
public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
{
	public void Configure(EntityTypeBuilder<FormaPago> builder)
	{
		builder.HasKey(t => t.Id);

		builder.Property(p => p.Id).ValueGeneratedNever().HasColumnName("Pk_FormaPago");
		builder.Property(p => p.Descripcion).HasMaxLength(50);

	}
}
